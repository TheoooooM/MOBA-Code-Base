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
        public event GlobalDelegates.FloatDelegate OnSetMaxResourceFeedback;

        public void RequestIncreaseMaxResource(float amount) { }

        [PunRPC]
        public void SyncIncreaseMaxResourceRPC(float amount) { }

        [PunRPC]
        public void IncreaseMaxResourceRPC(float amount) { }

        public event GlobalDelegates.FloatDelegate OnIncreaseMaxResource;
        public event GlobalDelegates.FloatDelegate OnIncreaseMaxResourceFeedback;

        public void RequestDecreaseMaxResource(float amount) { }

        [PunRPC]
        public void SyncDecreaseMaxResourceRPC(float amount) { }

        [PunRPC]
        public void DecreaseMaxResourceRPC(float amount) { }

        public event GlobalDelegates.FloatDelegate OnDecreaseMaxResource;
        public event GlobalDelegates.FloatDelegate OnDecreaseMaxResourceFeedback;

        public void RequestSetCurrentResource(float value) { }

        [PunRPC]
        public void SyncSetCurrentResourceRPC(float value) { }

        [PunRPC]
        public void SetCurrentResourceRPC(float value) { }

        public event GlobalDelegates.FloatDelegate OnSetCurrentResource;
        public event GlobalDelegates.FloatDelegate OnSetCurrentResourceFeedback;

        public void RequestSetCurrentResourcePercent(float value) { }

        [PunRPC]
        public void SyncSetCurrentResourcePercentRPC(float value) { }

        [PunRPC]
        public void SetCurrentResourcePercentRPC(float value) { }

        public event GlobalDelegates.FloatDelegate OnSetCurrentResourcePercent;
        public event GlobalDelegates.FloatDelegate OnSetCurrentResourcePercentFeedback;

        public void RequestIncreaseCurrentResource(float amount) { }

        [PunRPC]
        public void SyncIncreaseCurrentResourceRPC(float amount) { }

        [PunRPC]
        public void IncreaseCurrentResourceRPC(float amount) { }

        public event GlobalDelegates.FloatDelegate OnIncreaseCurrentResource;
        public event GlobalDelegates.FloatDelegate OnIncreaseCurrentResourceFeedback;

        public void RequestDecreaseCurrentResource(float amount) { }

        [PunRPC]
        public void SyncDecreaseCurrentResourceRPC(float amount) { }

        [PunRPC]
        public void DecreaseCurrentResourceRPC(float amount) { }

        public event GlobalDelegates.FloatDelegate OnDecreaseCurrentResource;
        public event GlobalDelegates.FloatDelegate OnDecreaseCurrentResourceFeedback;
    }
}