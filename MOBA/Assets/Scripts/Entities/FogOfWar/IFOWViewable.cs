namespace Entities.FogOfWar
{
    public interface IFOWViewable
    {
        public bool CanView();

        /// <returns>The view range of the entity</returns>
        public float GetFOWViewRange();
        public float GetFOWBaseViewRange();

        public void RequestSetCanView();
        public void SyncSetCanViewRPC();
        public void SetCanViewRPC();
        public event GlobalDelegates.NoParameterDelegate OnSetCanView;
        
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

        public void RequestSetBaseViewRange(float value);
        public void SyncSetBaseViewRangeRPC(float value);
        public void SetBaseViewRangeRPC(float value);
        public event GlobalDelegates.FloatDelegate OnSetBaseViewRange;

        public void RequestAddFOWSeeable(uint FOWSeeableIndex);
        public void SyncAddFOWSeeableRPC(uint FOWSeeableIndex);
        public void AddFOWSeeableRPC(uint FOWSeeableIndex);
        public event GlobalDelegates.UintDelegate OnAddFOWSeeable;
        
        public void RequestRemoveFOWSeeable(uint FOWSeeableIndex);
        public void SyncRemoveFOWSeeableRPC(uint FOWSeeableIndex);
        public void RemoveFOWSeeableRPC(uint FOWSeeableIndex);
        public event GlobalDelegates.UintDelegate OnRemoveFOWSeeable;

    }
}