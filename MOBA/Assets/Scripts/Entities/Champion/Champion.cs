using Entities.FogOfWar;
using Entities.Inventory;
using Photon.Pun;
using UnityEngine;

namespace Entities.Champion
{
    public partial class Champion : Entity, IDeadable, ITargetable, IDisplaceable, IResourceable, ITeamable,
        IFOWViewable, IFOWShowable, IInventoryable
    {
        public ChampionSO championSo;


        public float maxResource;
        public float currentResource;
        public float viewRange;
        public bool isAlive;

        public byte attackAbilityIndex;
        public byte[] abilitiesIndexes = new byte[2];
        public byte ultimateAbilityIndex;

        public bool canDie;
        public bool canBeDisplaced;
        public bool canChangeTeam;

        public Enums.Team team;

        public Item[] items = new Item[3];

        protected override void OnStart() { }

        protected override void OnUpdate() { }


       
        public bool IsAlive()
        {
            return isAlive;
        }

        public bool CanDie()
        {
            return canDie;
        }

        public void RequestSetCanDie(bool value) { }

        [PunRPC]
        public void SyncSetCanDieRPC(bool value) { }

        [PunRPC]
        public void SetCanDieRPC(bool value) { }

        public event GlobalDelegates.BoolDelegate OnSetCanDie;

        public void RequestDie() { }

        [PunRPC]
        public void SyncDieRPC() { }

        [PunRPC]
        public void DieRPC() { }

        public event GlobalDelegates.NoParameterDelegate OnDie;

        public void RequestRevive() { }

        [PunRPC]
        public void SyncReviveRPC() { }

        [PunRPC]
        public void ReviveRPC() { }

        public event GlobalDelegates.NoParameterDelegate OnRevive;

        public bool CanBeDisplaced()
        {
            return canBeDisplaced;
        }

        public void RequestSetCanBeDisplaced(bool value) { }

        [PunRPC]
        public void SyncSetCanBeDisplacedRPC(bool value) { }

        [PunRPC]
        public void SetCanBeDisplacedRPC(bool value) { }

        public event GlobalDelegates.BoolDelegate OnSetCanBeDisplaced;

        public void RequestDisplace() { }

        [PunRPC]
        public void SyncDisplaceRPC() { }

        [PunRPC]
        public void DisplaceRPC() { }

        public event GlobalDelegates.NoParameterDelegate OnDisplace;


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

        public Enums.Team GetTeam()
        {
            return team;
        }

        public bool CanChangeTeam()
        {
            return canChangeTeam;
        }

        public void RequestChangeTeam(bool value) { }

        [PunRPC]
        public void SyncChangeTeamRPC(bool value) { }

        [PunRPC]
        public void ChangeTeamRPC(bool value) { }

        public event GlobalDelegates.BoolDelegate OnChangeTeam;

        public float GetViewRange()
        {
            return viewRange;
        }

        public bool CanView()
        {
            throw new System.NotImplementedException();
        }

        public float GetFOWViewRange()
        {
            throw new System.NotImplementedException();
        }

        public float GetFOWBaseViewRange()
        {
            throw new System.NotImplementedException();
        }

        public void RequestSetCanView()
        {
            throw new System.NotImplementedException();
        }

        [PunRPC]
        public void SyncSetCanViewRPC()
        {
            throw new System.NotImplementedException();
        }

        [PunRPC]
        public void SetCanViewRPC()
        {
            throw new System.NotImplementedException();
        }

        public event GlobalDelegates.NoParameterDelegate OnSetCanView;

        public void RequestSetViewRange(float value) { }

        [PunRPC]
        public void SyncSetViewRangeRPC(float value) { }

        [PunRPC]
        public void SetViewRangeRPC(float value) { }

        public event GlobalDelegates.FloatDelegate OnSetViewRange;

        public void RequestSetBaseViewRange(float value)
        {
            throw new System.NotImplementedException();
        }

        [PunRPC]
        public void SyncSetBaseViewRangeRPC(float value)
        {
            throw new System.NotImplementedException();
        }

        [PunRPC]
        public void SetBaseViewRangeRPC(float value)
        {
            throw new System.NotImplementedException();
        }

        public event GlobalDelegates.FloatDelegate OnSetBaseViewRange;

        public void RequestAddFOWSeeable(uint FOWSeeableIndex)
        {
            throw new System.NotImplementedException();
        }

        [PunRPC]
        public void SyncAddFOWSeeableRPC(uint FOWSeeableIndex)
        {
            throw new System.NotImplementedException();
        }

        [PunRPC]
        public void AddFOWSeeableRPC(uint FOWSeeableIndex)
        {
            throw new System.NotImplementedException();
        }

        public event GlobalDelegates.UintDelegate OnAddFOWSeeable;

        public void RequestRemoveFOWSeeable(uint FOWSeeableIndex)
        {
            throw new System.NotImplementedException();
        }

        [PunRPC]
        public void SyncRemoveFOWSeeableRPC(uint FOWSeeableIndex)
        {
            throw new System.NotImplementedException();
        }

        [PunRPC]
        public void RemoveFOWSeeableRPC(uint FOWSeeableIndex)
        {
            throw new System.NotImplementedException();
        }

        public event GlobalDelegates.UintDelegate OnRemoveFOWSeeable;

        public Item[] GetItems()
        {
            return items;
        }

        public Item GetItem(int index)
        {
            if (index < 0 || index >= items.Length) return null;
            return items[index];
        }

        public void RequestAddItem(byte index) { }

        [PunRPC]
        public void SyncAddItemRPC(byte index) { }

        [PunRPC]
        public void AddItemRPC(byte index) { }

        public event GlobalDelegates.ByteDelegate OnAddItem;

        public void RequestRemoveItem(byte index) { }

        public void RequestRemoveItem(Item item) { }

        [PunRPC]
        public void SyncRemoveItemRPC(byte index) { }

        [PunRPC]
        public void RemoveItemRPC(byte index) { }

        public event GlobalDelegates.ByteDelegate OnRemoveItem;

        public bool CanBeTargeted()
        {
            throw new System.NotImplementedException();
        }

        public void RequestSetCanBeTargeted(bool value)
        {
            throw new System.NotImplementedException();
        }

        [PunRPC]
        public void SyncSetCanBeTargetedRPC(bool value)
        {
            throw new System.NotImplementedException();
        }

        [PunRPC]
        public void SetCanBeTargetedRPC(bool value)
        {
            throw new System.NotImplementedException();
        }

        public event GlobalDelegates.BoolDelegate OnSetCanBeTargeted;

        public void RequestOnTargeted()
        {
            throw new System.NotImplementedException();
        }

        [PunRPC]
        public void SyncOnTargetedRPC()
        {
            throw new System.NotImplementedException();
        }

        [PunRPC]
        public void OnTargetedRPC()
        {
            throw new System.NotImplementedException();
        }

        public event GlobalDelegates.NoParameterDelegate OnOnTargeted;

        public void RequestOnUntargeted() { }

        [PunRPC]
        public void SyncOnUntargetedRPC() { }

        [PunRPC]
        public void OnUntargetedRPC() { }

        public event GlobalDelegates.NoParameterDelegate OnOnUntargeted;

        public void TryAddFOWViewable(IFOWViewable FOWWhichSee)
        {
            throw new System.NotImplementedException();
        }

        public void TryRemoveFOWViewable(IFOWViewable FOWWhichSee)
        {
            throw new System.NotImplementedException();
        }

        public bool CanShow()
        {
            throw new System.NotImplementedException();
        }

        public bool CanHide()
        {
            throw new System.NotImplementedException();
        }

        public void RequestSetCanShow(bool value)
        {
            throw new System.NotImplementedException();
        }

        [PunRPC]
        public void SyncSetCanShowRPC(bool value)
        {
            throw new System.NotImplementedException();
        }

        [PunRPC]
        public void SetCanShowRPC(bool value)
        {
            throw new System.NotImplementedException();
        }

        public event GlobalDelegates.BoolDelegate OnSetCanShow;

        public void RequestSetCanHide(bool value)
        {
            throw new System.NotImplementedException();
        }

        [PunRPC]
        public void SyncSetCanHideRPC(bool value)
        {
            throw new System.NotImplementedException();
        }

        [PunRPC]
        public void SetCanHideRPC(bool value)
        {
            throw new System.NotImplementedException();
        }

        public event GlobalDelegates.BoolDelegate OnSetCanHide;

        public void TryAddFOWViewable(uint viewableIndex)
        {
            throw new System.NotImplementedException();
        }

        [PunRPC]
        public void ShowElementsRPC()
        {
            throw new System.NotImplementedException();
        }

        public event GlobalDelegates.NoParameterDelegate ShowElement;

        public void TryRemoveFOWViewable(uint viewableIndex)
        {
            throw new System.NotImplementedException();
        }

        [PunRPC]
        public void HideElementsRPC()
        {
            throw new System.NotImplementedException();
        }

        public event GlobalDelegates.NoParameterDelegate HideElement;
    }
}