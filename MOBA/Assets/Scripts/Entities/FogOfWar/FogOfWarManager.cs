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

        [Header("Fog Of War Parameter")] 
        [Tooltip("Color for the area where the player can't see")]
        public Color fogColor = new Color(0.25f, 0.25f, 0.25f, 1f);
        [Tooltip("Material who is going to be render in the RenderPass")] 
        public Material fogMat;
        [Tooltip("Define the size of the map to make the texture fit the RenderPass")]
        public int worldSize = 24;
        public bool worldSizeGizmos;
        

        [PunRPC] 
        private void RenderFOWRPC(Vector4[][] viewData)
        {
            //Maths...
        
            photonView.RPC("SyncRenderFogRPC", RpcTarget.All);
        }

        /// <summary>
        /// Add Entity To the Fog Of War render
        /// </summary>
        /// <param name="viewable"></param>
        public void AddFOWViewable(IFOWViewable viewable)
        {
            allViewable.Add(viewable);
        }

        /// <summary>
        /// Remove Entity To the Fog Of War render
        /// </summary>
        /// <param name="viewable"></param>
        public void RemoveFOWViewable(IFOWViewable viewable)
        {
            allViewable.Remove(viewable);
        }

        /// <summary>
        /// Synchronise The View For Every Player
        /// First Array is for the team
        /// The second JaggedArray is for position (X and Y) + radius of FoV (Z)
        /// </summary>
        [PunRPC]
        void SyncRenderFogRPC(Vector4[][] viewData)
        {
            
        }

        private void UpdateTeamsFOWViewables(IFOWViewable viewable)
        {
            
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

