namespace Entities
{
    public interface ITeamable
    {
        /// <returns>the team of the entity</returns>
        public Enums.Team GetTeam();
        
        /// <returns>true if the entity can change team, false if not</returns>
        public bool CanChangeTeam();
        /// <summary>
        /// Sends an RPC to the master to set if the entity can move.
        /// </summary>
        public void RequestChangeTeam(bool value);
        /// <summary>
        /// Sends an RPC to all clients to set if the entity can move.
        /// </summary>
        public void SyncChangeTeamRPC(bool value);
        /// <summary>
        /// Sets if the entity can move.
        /// </summary>
        public void ChangeTeamRPC(bool value);

        public event GlobalDelegates.BoolDelegate OnChangeTeam;
        public event GlobalDelegates.BoolDelegate OnChangeTeamFeedback;
    }
}