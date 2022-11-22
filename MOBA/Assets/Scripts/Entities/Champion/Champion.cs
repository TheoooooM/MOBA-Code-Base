using Controllers;
using UnityEngine;

namespace Entities.Champion
{
    public partial class Champion : Entity
    {
        public ChampionSO championSo;

        public byte attackAbilityIndex;
        public byte[] abilitiesIndexes = new byte[2];
        public byte ultimateAbilityIndex;

        protected override void OnStart() 
        {
            //set the camera to follow the champion using CameraController.LinkCameraToTransform(CameraController.mainCamera, transform);
            CameraController.SetPlayer(transform); 
        }

        protected override void OnUpdate() { }
        
    }
}