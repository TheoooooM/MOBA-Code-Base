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

        public void AddShowable(uint showableIndex);
        public void AddShowable(IFOWShowable showable);
        public void SyncAddShowableRPC(uint showableIndex);
        public event GlobalDelegates.UintDelegate OnAddShowable;
        public event GlobalDelegates.UintDelegate OnAddShowableFeedback;
        
        public void RemoveShowable(uint showableIndex);
        public void RemoveShowable(IFOWShowable showable);
        public void SyncRemoveShowableRPC(uint showableIndex);
        public event GlobalDelegates.UintDelegate OnRemoveShowable;
        public event GlobalDelegates.UintDelegate OnRemoveShowableFeedback;
    }
}