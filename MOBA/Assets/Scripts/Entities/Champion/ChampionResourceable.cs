using Photon.Pun;

namespace Entities.Champion
{
    public partial class Champion : IResourceable
    {
        public float maxResource;
        public float currentResource;

        public float GetMaxResource()
        {
            return maxResource;
        }

        public float GetCurrentResource()
        {
            return currentResource;
        }

        public float GetCurrentResourcePercent()
        {
            return currentResource / maxResource * 100;
        }

        public void RequestSetMaxResource(float value)
        {
            photonView.RPC("SetMaxResourceRPC", RpcTarget.MasterClient, value);
        }

        [PunRPC]
        public void SyncSetMaxResourceRPC(float value)
        {
            maxResource = value;
            OnSetMaxResourceFeedback?.Invoke(maxResource);
        }

        [PunRPC]
        public void SetMaxResourceRPC(float value)
        {
            maxResource = value;
            OnSetMaxResource?.Invoke(maxResource);
            photonView.RPC("SyncSetMaxResourceRPC", RpcTarget.All, maxResource);
        }

        public event GlobalDelegates.FloatDelegate OnSetMaxResource;
        public event GlobalDelegates.FloatDelegate OnSetMaxResourceFeedback;

        public void RequestIncreaseMaxResource(float amount)
        {
            photonView.RPC("IncreaseMaxResourceRPC", RpcTarget.MasterClient, amount);
        }

        [PunRPC]
        public void SyncIncreaseMaxResourceRPC(float amount)
        {
            maxResource = amount;
            OnIncreaseMaxResourceFeedback?.Invoke(maxResource);
        }

        [PunRPC]
        public void IncreaseMaxResourceRPC(float amount)
        {
            maxResource += amount;
            OnIncreaseMaxResource?.Invoke(maxResource);
            photonView.RPC("SyncIncreaseMaxResourceRPC", RpcTarget.All, maxResource);
        }

        public event GlobalDelegates.FloatDelegate OnIncreaseMaxResource;
        public event GlobalDelegates.FloatDelegate OnIncreaseMaxResourceFeedback;

        public void RequestDecreaseMaxResource(float amount)
        {
            photonView.RPC("DecreaseMaxResourceRPC", RpcTarget.MasterClient, amount);
        }

        [PunRPC]
        public void SyncDecreaseMaxResourceRPC(float amount)
        {
            maxResource = amount;
            OnDecreaseMaxResourceFeedback?.Invoke(maxResource);
        }

        [PunRPC]
        public void DecreaseMaxResourceRPC(float amount)
        {
            maxResource -= amount;
            OnDecreaseMaxResource?.Invoke(maxResource);
            photonView.RPC("SyncDecreaseMaxResourceRPC", RpcTarget.All, maxResource);
        }

        public event GlobalDelegates.FloatDelegate OnDecreaseMaxResource;
        public event GlobalDelegates.FloatDelegate OnDecreaseMaxResourceFeedback;

        public void RequestSetCurrentResource(float value)
        {
            photonView.RPC("SetCurrentResourceRPC", RpcTarget.MasterClient, value);
        }

        [PunRPC]
        public void SyncSetCurrentResourceRPC(float value)
        {
            currentResource = value;
            OnSetCurrentResourceFeedback?.Invoke(currentResource);
        }

        [PunRPC]
        public void SetCurrentResourceRPC(float value)
        {
            currentResource = value;
            OnSetCurrentResource?.Invoke(currentResource);
            photonView.RPC("SyncSetCurrentResourceRPC", RpcTarget.All, currentResource);
        }

        public event GlobalDelegates.FloatDelegate OnSetCurrentResource;
        public event GlobalDelegates.FloatDelegate OnSetCurrentResourceFeedback;

        public void RequestSetCurrentResourcePercent(float value)
        {
            photonView.RPC("SetCurrentResourcePercentRPC", RpcTarget.MasterClient, value);
        }

        [PunRPC]
        public void SyncSetCurrentResourcePercentRPC(float value)
        {
            currentResource = value;
            OnSetCurrentResourcePercentFeedback?.Invoke(currentResource);
        }

        [PunRPC]
        public void SetCurrentResourcePercentRPC(float value)
        {
            currentResource = value * maxResource;
            OnSetCurrentResourcePercent?.Invoke(currentResource);
            photonView.RPC("SyncSetCurrentResourcePercentRPC", RpcTarget.All, currentResource);
        }

        public event GlobalDelegates.FloatDelegate OnSetCurrentResourcePercent;
        public event GlobalDelegates.FloatDelegate OnSetCurrentResourcePercentFeedback;

        public void RequestIncreaseCurrentResource(float amount)
        {
            photonView.RPC("IncreaseCurrentResourceRPC", RpcTarget.MasterClient, amount);
        }

        [PunRPC]
        public void SyncIncreaseCurrentResourceRPC(float amount)
        {
            currentResource = amount;
            OnIncreaseCurrentResourceFeedback?.Invoke(currentResource);
        }

        [PunRPC]
        public void IncreaseCurrentResourceRPC(float amount)
        {
            currentResource += amount;
            OnIncreaseCurrentResource?.Invoke(currentResource);
            photonView.RPC("SyncIncreaseCurrentResourceRPC", RpcTarget.All, currentResource);
        }

        public event GlobalDelegates.FloatDelegate OnIncreaseCurrentResource;
        public event GlobalDelegates.FloatDelegate OnIncreaseCurrentResourceFeedback;

        public void RequestDecreaseCurrentResource(float amount)
        {
            photonView.RPC("DecreaseCurrentResourceRPC", RpcTarget.MasterClient, amount);
        }

        [PunRPC]
        public void SyncDecreaseCurrentResourceRPC(float amount)
        {
            currentResource = amount;
            OnDecreaseCurrentResourceFeedback?.Invoke(currentResource);
        }

        [PunRPC]
        public void DecreaseCurrentResourceRPC(float amount)
        {
            currentResource -= amount;
            OnDecreaseCurrentResource?.Invoke(currentResource);
            photonView.RPC("SyncDecreaseCurrentResourceRPC", RpcTarget.All, currentResource);
        }

        public event GlobalDelegates.FloatDelegate OnDecreaseCurrentResource;
        public event GlobalDelegates.FloatDelegate OnDecreaseCurrentResourceFeedback;
    }
}