using System.Collections.Generic;

namespace Entities.FogOfWar
{
    public interface IFOWViewable : ITeamable
    {
        /// <returns>If the entity can see</returns>
        public bool CanView();
        /// <returns>The current view range of the entity</returns>
        public float GetFOWViewRange();
        /// <returns>The base view range of the entity</returns>
        public float GetFOWBaseViewRange();

        public List<IFOWShowable> SeenShowables();

        public void RequestSetCanView(bool value);
        public void SyncSetCanViewRPC(bool value);
        public void SetCanViewRPC(bool value);
        public event GlobalDelegates.BoolDelegate OnSetCanView;
        public event GlobalDelegates.BoolDelegate OnSetCanViewFeedback;
        
        /// <summary>
        /// Sends an RPC to the master to set the entity's view range.
        /// </summary>
        /// <param name="value">the value to set it to</param>
        public void RequestSetViewRange(float value);

        /// <summary>
        /// Sends an RPC to all clients to set the entity's view range.
        /// </summary>
        /// <param name="value">the value to set it to</param>
        public void SyncSetViewRangeRPC(float value);

        /// <summary>
        /// Sets the entity's view range.
        /// </summary>
        /// <param name="value">the value to set it to</param>
        public void SetViewRangeRPC(float value);

        public event GlobalDelegates.FloatDelegate OnSetViewRange;
        public event GlobalDelegates.FloatDelegate OnSetViewRangeFeedback;

        public void RequestSetBaseViewRange(float value);
        public void SyncSetBaseViewRangeRPC(float value);
        public void SetBaseViewRangeRPC(float value);
        public event GlobalDelegates.FloatDelegate OnSetBaseViewRange;
        public event GlobalDelegates.FloatDelegate OnSetBaseViewRangeFeedback;

        public void RequestAddFOWSeeable(uint FOWSeeableIndex);
        public void SyncAddFOWSeeableRPC(uint FOWSeeableIndex);
        public void AddFOWSeeableRPC(uint FOWSeeableIndex);
        public event GlobalDelegates.UintDelegate OnAddFOWSeeable;
        public event GlobalDelegates.UintDelegate OnAddFOWSeeableFeedback;
        
        public void RequestRemoveFOWSeeable(uint FOWSeeableIndex);
        public void SyncRemoveFOWSeeableRPC(uint FOWSeeableIndex);
        public void RemoveFOWSeeableRPC(uint FOWSeeableIndex);
        public event GlobalDelegates.UintDelegate OnRemoveFOWSeeable;
        public event GlobalDelegates.UintDelegate OnRemoveFOWSeeableFeedback;

    }
}