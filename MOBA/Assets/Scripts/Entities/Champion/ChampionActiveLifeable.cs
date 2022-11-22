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
        }

        [PunRPC]
        public void SetMaxHpRPC(float value)
        {
            maxHp = value;
            photonView.RPC("SyncSetMaxHpRPC", RpcTarget.All, maxHp);
        }

        public event GlobalDelegates.FloatDelegate OnSetMaxHp;

        public void RequestIncreaseMaxHp(float amount)
        {
            photonView.RPC("IncreaseMaxHpRPC", RpcTarget.MasterClient, amount);
        }

        [PunRPC]
        public void SyncIncreaseMaxHpRPC(float amount)
        {
            maxHp = amount;
        }

        [PunRPC]
        public void IncreaseMaxHpRPC(float amount)
        {
            maxHp -= amount;
            photonView.RPC("SyncSetMaxHpRPC", RpcTarget.MasterClient, maxHp);
        }

        public event GlobalDelegates.FloatDelegate OnIncreaseMaxHp;

        public void RequestDecreaseMaxHp(float amount)
        {
            photonView.RPC("DecreaseMaxHpRPC", RpcTarget.MasterClient, amount);
        }

        [PunRPC]
        public void SyncDecreaseMaxHpRPC(float amount)
        {
            maxHp = amount;
        }

        [PunRPC]
        public void DecreaseMaxHpRPC(float amount)
        {
            maxHp -= amount;
            photonView.RPC("SyncDecreaseMaxHpRPC", RpcTarget.MasterClient, maxHp);
        }

        public event GlobalDelegates.FloatDelegate OnDecreaseMaxHp;

        public void RequestSetCurrentHp(float value)
        {
            photonView.RPC("SetCurrentHpRPC", RpcTarget.MasterClient, value);
        }

        [PunRPC]
        public void SyncSetCurrentHpRPC(float value)
        {
            currentHp = value;
        }

        [PunRPC]
        public void SetCurrentHpRPC(float value)
        {
            currentHp = value;
            photonView.RPC("SyncSetCurrentHpRPC", RpcTarget.All, value);
        }

        public event GlobalDelegates.FloatDelegate OnSetCurrentHp;

        public void RequestSetCurrentHpPercent(float value)
        {
            photonView.RPC("SetCurrentHpPercentRPC", RpcTarget.All, value);
        }

        [PunRPC]
        public void SyncSetCurrentHpPercentRPC(float value)
        {
            currentHp = value;
        }

        [PunRPC]
        public void SetCurrentHpPercentRPC(float value)
        {
            currentHp = value * maxHp;
            photonView.RPC("SetCurrentHpPercentRPC", RpcTarget.All, value);
        }

        public event GlobalDelegates.FloatDelegate OnSetCurrentHpPercent;

        public void RequestIncreaseCurrentHp(float amount) { }

        [PunRPC]
        public void SyncIncreaseCurrentHpRPC(float amount) { }

        [PunRPC]
        public void IncreaseCurrentHpRPC(float amount) { }

        public event GlobalDelegates.FloatDelegate OnIncreaseCurrentHp;

        public void RequestDecreaseCurrentHp(float amount) { }

        [PunRPC]
        public void SyncDecreaseCurrentHpRPC(float amount) { }

        [PunRPC]
        public void DecreaseCurrentHpRPC(float amount) { }

        public event GlobalDelegates.FloatDelegate OnDecreaseCurrentHp;
    }
}