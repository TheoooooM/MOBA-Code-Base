using GameStates;
using Photon.Pun;
using UnityEngine;

namespace Entities.Champion
{
    public class ChampionMeshLinker : MonoBehaviourPun
    {
        [SerializeField] private MeshRenderer[] teamColorfulParts;
        private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");
        private Champion ch;
        
        public void LinkTeamColor(Champion champion)
        {
            ch = champion;
            var color = Color.white;

            foreach (var tc in GameStateMachine.Instance.teamColors)
            {
                if(ch.team != tc.team) continue;
                color = tc.color;
                break;
            }
            
            RequestSetColor(new Vector3(color.r, color.g, color.b));
        }

        private void RequestSetColor(Vector3 color)
        {
            photonView.RPC("SetColorRPC", RpcTarget.MasterClient, color);
        }

        [PunRPC]
        private void SetColorRPC(Vector3 color)
        {
            photonView.RPC("SyncSetColorRPC", RpcTarget.All, color);
        }

        [PunRPC]
        private void SyncSetColorRPC(Vector3 color)
        {
            transform.SetParent(ch.championInitPoint);

            var c = new Color(color.x, color.y, color.z, 1);
            foreach (var rd in teamColorfulParts)
            {
                rd.material.SetColor(EmissionColor, c * 1f);
            }
        }
    }
}
