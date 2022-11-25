using Photon.Pun;
using UnityEngine;

namespace Entities.Champion
{
    public partial class Champion : IDeadable
    {
        public bool isAlive;
        public bool canDie;
        
        // TODO: Delete when TickManager is implemented
        public float timerToRespawn = 10f;
        private float timer; 

        public bool IsAlive()
        {
            return isAlive;
        }

        public bool CanDie()
        {
            return canDie;
        }

        public void RequestSetCanDie(bool value)
        {
            photonView.RPC("DieRPC", RpcTarget.MasterClient, value);
        }

        [PunRPC]
        public void SyncSetCanDieRPC(bool value)
        {
            canDie = value;
            OnSetCanDieFeedback?.Invoke(value);
        }

        [PunRPC]
        public void SetCanDieRPC(bool value)
        {
            canDie = value;
            OnSetCanDie?.Invoke(value);
            photonView.RPC("SyncSetCanDieRPC", RpcTarget.All, value);
        }

        public event GlobalDelegates.BoolDelegate OnSetCanDie;
        public event GlobalDelegates.BoolDelegate OnSetCanDieFeedback;

        public void RequestDie()
        {
            photonView.RPC("DieRPC", RpcTarget.MasterClient);
        }

        [PunRPC]
        public void SyncDieRPC()
        {
            isAlive = false;
            championInitPoint.gameObject.SetActive(false);
            InputManager.PlayerMap.Disable();
            RequestRevive();
            OnDieFeedback?.Invoke();
        }

        [PunRPC]
        public void DieRPC()
        {
            if (!canDie) return;
            OnDie?.Invoke();
            photonView.RPC("SyncDieRPC", RpcTarget.All);
        }

        public event GlobalDelegates.NoParameterDelegate OnDie;
        public event GlobalDelegates.NoParameterDelegate OnDieFeedback;

        public void RequestRevive()
        {
            photonView.RPC("ReviveRPC", RpcTarget.MasterClient);
        }

        [PunRPC]
        public void SyncReviveRPC()
        {
            isAlive = true;
            // TODO: Replace with SpawnPoint depending on the team of the player
            transform.position = new Vector3(0, 0, 0);
            championInitPoint.gameObject.SetActive(true);
            InputManager.PlayerMap.Enable();
            timer = timerToRespawn;
            OnReviveFeedback?.Invoke();
        }

        [PunRPC]
        public void ReviveRPC()
        {
            // TODO: Replace by TickManager
            while (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            OnRevive?.Invoke();
            photonView.RPC("SyncReviveRPC", RpcTarget.All);
        }

        public event GlobalDelegates.NoParameterDelegate OnRevive;
        public event GlobalDelegates.NoParameterDelegate OnReviveFeedback;
    }
}