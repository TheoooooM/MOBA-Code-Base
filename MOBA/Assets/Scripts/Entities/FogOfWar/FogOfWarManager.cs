using System;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace Entities.FogOfWar
{
    public class FogOfWarManager : MonoBehaviourPun
    {
        //Instance => talk to the group to see if that possible
        private static FogOfWarManager _instance;
        public static FogOfWarManager Instance { get { return _instance; } }
        
        private void Awake()
        {
            cameraFog.GetComponent<Camera>().orthographicSize = worldSize * 0.5f;
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }

            //maskMatPlane.SetFloat("_Opacity", 0);
        }

        public Dictionary<uint, IFOWViewable> allViewables = new Dictionary<uint, IFOWViewable>();
        public List<IFOWViewable> allFOWViewable = new List<IFOWViewable>();
        private Dictionary<Enums.Team, List<IFOWViewable>> teamFOWViewablesDict = new Dictionary<Enums.Team, List<IFOWViewable>>();

        /// <summary>
        /// List Of all IFogOfWarViewable for Fog of War render
        /// </summary>
        /// <param name="IFogOfWarViewable"> Interface for Entity </param>
        private List<IFOWViewable> allViewable;

        /// <summary>
        /// Call In Update
        /// Render and Update the Fog of War
        /// </summary>
        /// <param name="viewData">List of Vector2 pos + radius for view Informations</param>

        [Header("Camera Setup")] 
        public Camera cameraFog;

        [Header("Fog Of War Parameter")] 
        [Tooltip("Color for the area where the player can't see")]
        public Color fogColor = new Color(0.25f, 0.25f, 0.25f, 1f);
        [Tooltip("Material who is going to be render in the RenderPass")] 
        public Material fogMat;
        [Tooltip("Define the size of the map to make the texture fit the RenderPass")]
        public int worldSize = 24;
        public bool worldSizeGizmos;
        
        //Parameter For Creating Field Of View Mesh
        
        [HideInInspector] public MeshFilter viewMeshFilter;
        Mesh viewMesh;
        public FOVSettings settingsFOV;

        private void RenderFOW(List<IFOWViewable> viewables)
        {
            //Maths...
            //DrawFieldOfView();
            // calculer la texture 
        }

 
        /// <summary>
        /// Add Entity To the Fog Of War render
        /// </summary>
        /// <param name="viewable"></param>
        void AddFOWViewable(IFOWViewable viewable)
        {
            allViewable.Add(viewable);
        }

        /// <summary>
        /// Remove Entity To the Fog Of War render
        /// </summary>
        /// <param name="viewable"></param>
         void RemoveFOWViewable(IFOWViewable viewable)
        {
            allViewable.Remove(viewable);
        }
        
        
        public void UpdateTeamsFOWViewables()
        {
            // prenne chaque viewable et tu regarde à quelle team ils appartiennent 
            //
            //RenderFOW();
        }

        private void Start()
        {   
            
        }

        private void Update()
        {
           UpdateTeamsFOWViewables();  
        }

        public void InitMesh()
        {
            viewMesh = new Mesh();
            viewMesh.name = "View Mesh";
            viewMeshFilter.mesh = viewMesh;
        }
        
        //Draw the Field of View for the Player.
        public void DrawFieldOfView ()
        {
            int stepCount = Mathf.RoundToInt(settingsFOV.viewAngle * settingsFOV.meshResolution / 5);
            float stepAngleSize = settingsFOV.viewAngle / stepCount;
            List<Vector3> viewPoints = new List<Vector3>();
            ViewCastInfo oldViewCast = new ViewCastInfo();

            for (int i = 0; i <= stepCount; i++)
            {
                float angle = transform.eulerAngles.y - settingsFOV.viewAngle / 2 + stepAngleSize * i;
                ViewCastInfo newViewCast = ViewCast(angle);

                if (i > 0)
                {
                    bool edgeDstThresholdExceeded = Mathf.Abs(oldViewCast.dst - newViewCast.dst) > settingsFOV.edgeDstThreshold;
                    if (oldViewCast.hit != newViewCast.hit || (oldViewCast.hit && newViewCast.hit && edgeDstThresholdExceeded))
                    {
                        EdgeInfo edge = FindEdge(oldViewCast, newViewCast);
                        if (edge.pointA != Vector3.zero)
                        {
                            viewPoints.Add(edge.pointA);
                        }
                        if (edge.pointB != Vector3.zero)
                        {
                            viewPoints.Add(edge.pointB);
                        }
                    }
                }
                viewPoints.Add(newViewCast.point);
                oldViewCast = newViewCast;
            }

            int vertexCount = viewPoints.Count + 1;
            Vector3[] vertices = new Vector3[vertexCount];
            int[] triangles = new int[(vertexCount - 2) * 3];

            vertices[0] = Vector3.zero;
            for (int i = 0; i < vertexCount - 1; i++)
            {
                vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]) + Vector3.forward * settingsFOV.maskCutawayDst;

                if (i < vertexCount - 2)
                {
                    triangles[i * 3] = 0;
                    triangles[i * 3 + 1] = i + 1;
                    triangles[i * 3 + 2] = i + 2;
                }
            }

            if (viewMesh == null)
            {
                InitMesh();
            }

            viewMesh.Clear();

            viewMesh.vertices = vertices;
            viewMesh.triangles = triangles;
            viewMesh.RecalculateNormals();
        }
        
        EdgeInfo FindEdge ( ViewCastInfo minViewCast, ViewCastInfo maxViewCast )
        {
            float minAngle = minViewCast.angle;
            float maxAngle = maxViewCast.angle;
            Vector3 minPoint = Vector3.zero;
            Vector3 maxPoint = Vector3.zero;

            for (int i = 0; i < settingsFOV.edgeResolveIterations; i++)
            {
                float angle = (minAngle + maxAngle) / 2;
                ViewCastInfo newViewCast = ViewCast(angle);

                bool edgeDstThresholdExceeded = Mathf.Abs(minViewCast.dst - newViewCast.dst) > settingsFOV.edgeDstThreshold;
                if (newViewCast.hit == minViewCast.hit && !edgeDstThresholdExceeded)
                {
                    minAngle = angle;
                    minPoint = newViewCast.point;
                }
                else
                {
                    maxAngle = angle;
                    maxPoint = newViewCast.point;
                }
            }

            return new EdgeInfo(minPoint, maxPoint);
        }
        
        ViewCastInfo ViewCast ( float globalAngle )
        {
            Vector3 dir = DirFromAngle(globalAngle, true);
            RaycastHit hit;

            if (Physics.Raycast(transform.position, dir, out hit, settingsFOV.viewRadius, settingsFOV.obstacleMask))
            {
                return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
            }
            else
            {
                return new ViewCastInfo(false, transform.position + dir * settingsFOV.viewRadius, settingsFOV.viewRadius, globalAngle);
            }
        }

        public Vector3 DirFromAngle ( float angleInDegrees, bool angleIsGlobal )
        {
            if (!angleIsGlobal)
            {
                angleInDegrees += transform.eulerAngles.y;
            }
            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        }

        public struct ViewCastInfo
        {
            public bool hit;
            public Vector3 point;
            public float dst;
            public float angle;

            public ViewCastInfo ( bool _hit, Vector3 _point, float _dst, float _angle )
            {
                hit = _hit;
                point = _point;
                dst = _dst;
                angle = _angle;
            }
        }

        public struct EdgeInfo
        {
            public Vector3 pointA;
            public Vector3 pointB;

            public EdgeInfo ( Vector3 _pointA, Vector3 _pointB )
            {
                pointA = _pointA;
                pointB = _pointB;
            }
        }

        private void OnDrawGizmos()
        {
            if (!worldSizeGizmos) return;
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, new Vector3(worldSize *0.9f, 10, worldSize *0.9f));
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, new Vector3(worldSize , 10, worldSize));
        }
    }
}

[System.Serializable]
public class FOVSettings
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    
    public float meshResolution;
    public int edgeResolveIterations;
    public float edgeDstThreshold;
    public float maskCutawayDst = .1f;
}

