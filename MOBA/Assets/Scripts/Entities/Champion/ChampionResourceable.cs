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

        public void RequestSetMaxResource(float value) { }

        [PunRPC]
        public void SyncSetMaxResourceRPC(float value) { }

        [PunRPC]
        public void SetMaxResourceRPC(float value) { }

        public event GlobalDelegates.FloatDelegate OnSetMaxResource;

        public void RequestIncreaseMaxResource(float amount) { }

        [PunRPC]
        public void SyncIncreaseMaxResourceRPC(float amount) { }

        [PunRPC]
        public void IncreaseMaxResourceRPC(float amount) { }

        public event GlobalDelegates.FloatDelegate OnIncreaseMaxResource;

        public void RequestDecreaseMaxResource(float amount) { }

        [PunRPC]
        public void SyncDecreaseMaxResourceRPC(float amount) { }

        [PunRPC]
        public void DecreaseMaxResourceRPC(float amount) { }

        public event GlobalDelegates.FloatDelegate OnDecreaseMaxResource;

        public void RequestSetCurrentResource(float value) { }

        [PunRPC]
        public void SyncSetCurrentResourceRPC(float value) { }

        [PunRPC]
        public void SetCurrentResourceRPC(float value) { }

        public event GlobalDelegates.FloatDelegate OnSetCurrentResource;

        public void RequestSetCurrentResourcePercent(float value) { }

        [PunRPC]
        public void SyncSetCurrentResourcePercentRPC(float value) { }

        [PunRPC]
        public void SetCurrentResourcePercentRPC(float value) { }

        public event GlobalDelegates.FloatDelegate OnSetCurrentResourcePercent;

        public void RequestIncreaseCurrentResource(float amount) { }

        [PunRPC]
        public void SyncIncreaseCurrentResourceRPC(float amount) { }

        [PunRPC]
        public void IncreaseCurrentResourceRPC(float amount) { }

        public event GlobalDelegates.FloatDelegate OnIncreaseCurrentResource;

        public void RequestDecreaseCurrentResource(float amount) { }

        [PunRPC]
        public void SyncDecreaseCurrentResourceRPC(float amount) { }

        [PunRPC]
        public void DecreaseCurrentResourceRPC(float amount) { }

        public event GlobalDelegates.FloatDelegate OnDecreaseCurrentResource;
    }
}