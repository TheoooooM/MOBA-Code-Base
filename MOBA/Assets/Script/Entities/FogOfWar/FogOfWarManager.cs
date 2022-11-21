using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace Entities.FogOfWar
{
    public class FogOfWarManager : MonoBehaviourPun
    {
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
        void RenderFog(Vector3[] viewData)
        {
            //Maths...
        
            photonView.RPC("SyncRenderFogRPC", RpcTarget.All);
        }

        /// <summary>
        /// Add Entity To the Fog Of War render
        /// </summary>
        /// <param name="viewable"></param>
        public void AddViewable(IFOWViewable viewable)
        {
            allViewable.Add(viewable);
        }
    
        /// <summary>
        /// Remove Entity To the Fog Of War render
        /// </summary>
        /// <param name="viewable"></param>
        public void REmoveViewable(IFOWViewable viewable)
        {
            allViewable.Remove(viewable);
        }
    
    
        /// <summary>
        /// Synchronise The View For Every Player
        /// </summary>
        [PunRPC] void SyncRenderFogRPC(Vector3[] viewData) { }
    }

}

