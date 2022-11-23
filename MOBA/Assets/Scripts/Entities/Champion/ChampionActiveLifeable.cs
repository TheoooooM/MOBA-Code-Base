using Photon.Pun;

namespace Entities.Champion
{
    public partial class Champion : IActiveLifeable
    {
        public float maxHp;
        public float currentHp;

        public float GetMaxHp()
        {
            return maxHp;
        }

        public float GetCurrentHp()
        {
            return currentHp;
        }

        public float GetCurrentHpPercent()
        {
            return currentHp / maxHp * 100f;
        }

        public void RequestSetMaxHp(float value)
        {
            photonView.RPC("SetMaxHpRPC", RpcTarget.MasterClient, value);
        }

        [PunRPC]
        public void SyncSetMaxHpRPC(float value)
        {
            maxHp = value;
            OnSetMaxHpFeedback?.Invoke(maxHp);
        }

        [PunRPC]
        public void SetMaxHpRPC(float value)
        {
            maxHp = value;
            OnSetMaxHp?.Invoke(maxHp);
            photonView.RPC("SyncSetMaxHpRPC", RpcTarget.All, maxHp);
        }

        public event GlobalDelegates.FloatDelegate OnSetMaxHp;
        public event GlobalDelegates.FloatDelegate OnSetMaxHpFeedback;

        public void RequestIncreaseMaxHp(float amount)
        {
            photonView.RPC("IncreaseMaxHpRPC", RpcTarget.MasterClient, amount);
        }

        [PunRPC]
        public void SyncIncreaseMaxHpRPC(float amount)
        {
            maxHp = amount;
            OnIncreaseMaxHpFeedback?.Invoke(maxHp);
        }

        [PunRPC]
        public void IncreaseMaxHpRPC(float amount)
        {
            maxHp += amount;
            OnIncreaseMaxHp?.Invoke(maxHp);
            photonView.RPC("SyncSetMaxHpRPC", RpcTarget.All, maxHp);
        }

        public event GlobalDelegates.FloatDelegate OnIncreaseMaxHp;
        public event GlobalDelegates.FloatDelegate OnIncreaseMaxHpFeedback;

        public void RequestDecreaseMaxHp(float amount)
        {
            photonView.RPC("DecreaseMaxHpRPC", RpcTarget.MasterClient, amount);
        }

        [PunRPC]
        public void SyncDecreaseMaxHpRPC(float amount)
        {
            maxHp = amount;
            OnDecreaseMaxHpFeedback?.Invoke(maxHp);
        }

        [PunRPC]
        public void DecreaseMaxHpRPC(float amount)
        {
            maxHp -= amount;
            OnDecreaseMaxHp?.Invoke(maxHp);
            photonView.RPC("SyncDecreaseMaxHpRPC", RpcTarget.All, maxHp);
        }

        public event GlobalDelegates.FloatDelegate OnDecreaseMaxHp;
        public event GlobalDelegates.FloatDelegate OnDecreaseMaxHpFeedback;

        public void RequestSetCurrentHp(float value)
        {
            photonView.RPC("SetCurrentHpRPC", RpcTarget.MasterClient, value);
        }

        [PunRPC]
        public void SyncSetCurrentHpRPC(float value)
        {
            currentHp = value;
            OnSetCurrentHpFeedback?.Invoke(currentHp);
        }

        [PunRPC]
        public void SetCurrentHpRPC(float value)
        {
            currentHp = value;
            OnSetCurrentHp?.Invoke(currentHp);
            photonView.RPC("SyncSetCurrentHpRPC", RpcTarget.All, currentHp);
        }

        public event GlobalDelegates.FloatDelegate OnSetCurrentHp;
        public event GlobalDelegates.FloatDelegate OnSetCurrentHpFeedback;

        public void RequestSetCurrentHpPercent(float value)
        {
            photonView.RPC("SetCurrentHpPercentRPC", RpcTarget.MasterClient, value);
        }

        [PunRPC]
        public void SyncSetCurrentHpPercentRPC(float value)
        {
            currentHp = value;
            OnSetCurrentHpPercentFeedback?.Invoke(currentHp);
        }

        [PunRPC]
        public void SetCurrentHpPercentRPC(float value)
        {
            currentHp = value * maxHp;
            OnSetCurrentHpPercentFeedback?.Invoke(currentHp);
            photonView.RPC("SetCurrentHpPercentRPC", RpcTarget.All, currentHp);
        }

        public event GlobalDelegates.FloatDelegate OnSetCurrentHpPercent;
        public event GlobalDelegates.FloatDelegate OnSetCurrentHpPercentFeedback;

        public void RequestIncreaseCurrentHp(float amount)
        {
            photonView.RPC("IncreaseCurrentHpRPC",RpcTarget.MasterClient,amount);
        }

        [PunRPC]
        public void SyncIncreaseCurrentHpRPC(float amount)
        {
            currentHp = amount;
            OnIncreaseCurrentHpFeedback?.Invoke(currentHp);
        }

        [PunRPC]
        public void IncreaseCurrentHpRPC(float amount)
        {
            currentHp += amount;
            OnIncreaseCurrentHp?.Invoke(currentHp);
            photonView.RPC("SyncIncreaseCurrentHpRPC",RpcTarget.All,currentHp);
        }

        public event GlobalDelegates.FloatDelegate OnIncreaseCurrentHp;
        public event GlobalDelegates.FloatDelegate OnIncreaseCurrentHpFeedback;

        public void RequestDecreaseCurrentHp(float amount)
        {
            photonView.RPC("SyncIncreaseCurrentHpRPC",RpcTarget.MasterClient,amount);
        }

        [PunRPC]
        public void SyncDecreaseCurrentHpRPC(float amount)
        {
            currentHp = amount;
            OnDecreaseCurrentHpFeedback?.Invoke(currentHp);
        }

        [PunRPC]
        public void DecreaseCurrentHpRPC(float amount)
        {
            currentHp -= amount;
            OnDecreaseCurrentHp?.Invoke(currentHp);
            photonView.RPC("SyncIncreaseCurrentHpRPC",RpcTarget.All,currentHp);
        }

        public event GlobalDelegates.FloatDelegate OnDecreaseCurrentHp;
        public event GlobalDelegates.FloatDelegate OnDecreaseCurrentHpFeedback;
    }
}