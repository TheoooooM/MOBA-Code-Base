using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace Entities.FogOfWar
{
    public class FogOfWarManager : MonoBehaviourPun
    {
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
        
        [PunRPC] private void RenderFOWRPC(Vector4[][] viewData)
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
        /// </summary>
        [PunRPC] void SyncRenderFogRPC(Vector4[][] viewData) { }

        private void UpdateTeamsFOWViewables(IFOWViewable viewable)
        {
            
        }
    }

}

