namespace Entities
{
    public interface IRessourceable
    {
        /// <returns>The maxRessource of the entity</returns>
        public float GetMaxRessource();
        /// <returns>The currentRessource of the entity</returns>
        public float GetCurrentRessource();
        /// <returns>The percentage of currentRessource on maxRessource of the entity</returns>
        public float GetCurrentRessourcePercent();
        
        /// /// <summary>
        /// Sends an RPC to the master to set the entity's maxRessource.
        /// </summary>
        /// <param name="value">the value to set it to</param>
        public void RequestSetMaxRessource(float value);
        /// <summary>
        /// Sends an RPC to all clients to set the entity's maxRessource.
        /// </summary>
        /// <param name="value">the value to set it to</param>
        public void SyncSetMaxRessourceRPC(float value);
        /// <summary>
        /// Sets the entity's maxRessource.
        /// </summary>
        /// <param name="value">the value to set it to</param>
        public void SetMaxRessourceRPC(float value);
        
        /// <summary>
        /// Sends an RPC to the master to increase the entity's maxRessource.
        /// </summary>
        /// <param name="amount">the increase amount</param>
        public void RequestIncreaseMaxRessource(float amount);
        /// <summary>
        /// Sends an RPC to all clients to increase the entity's maxRessource.
        /// </summary>
        /// <param name="amount">the increase amount</param>
        public void SyncIncreaseMaxRessourceRPC(float amount);
        /// <summary>
        /// Increases the entity's maxRessource.
        /// </summary>
        /// <param name="amount">the increase amount</param>
        public void IncreaseMaxRessourceRPC(float amount);
        
        /// <summary>
        /// Sends an RPC to the master to decrease the entity's maxRessource.
        /// </summary>
        /// <param name="amount">the decrease amount</param>
        public void RequestDecreaseMaxRessource(float amount);
        /// <summary>
        /// Sends an RPC to all clients to decrease the entity's maxRessource.
        /// </summary>
        /// <param name="amount">the increase amount</param>
        public void SyncDecreaseMaxRessourceRPC(float amount);
        /// <summary>
        /// Decreases the entity's maxRessource.
        /// </summary>
        /// <param name="amount">the increase amount</param>
        public void DecreaseMaxRessourceRPC(float amount);
        
        /// <summary>
        /// Sends an RPC to the master to set the entity's currentRessource.
        /// </summary>
        /// <param name="value">the value to set it to</param>
        public void RequestSetCurrentRessource(float value);
        /// <summary>
        /// Sends an RPC to all clients to set the entity's currentRessource.
        /// </summary>
        /// <param name="value">the value to set it to</param>
        public void SyncSetCurrentRessourceRPC(float value);
        /// <summary>
        /// Set the entity's currentRessource.
        /// </summary>
        /// <param name="value">the value to set it to</param>
        public void SetCurrentRessourceRPC(float value);
        
        /// <summary>
        /// Sends an RPC to the master to set the entity's currentRessource to a percentage of  its maxRessource.
        /// </summary>
        /// <param name="value">the value to set it to</param>
        public void RequestSetCurrentRessourcePercent(float value);
        /// <summary>
        /// Sends an RPC to all clients to set the entity's currentRessource to a percentage of  its maxRessource.
        /// </summary>
        /// <param name="value">the value to set it to</param>
        public void SyncSetCurrentRessourcePercentRPC(float value);
        /// <summary>
        /// Sets the entity's currentRessource to a percentage of its maxRessource.
        /// </summary>
        /// <param name="value">the value to set it to</param>
        public void SetCurrentRessourceRPCPercent(float value);
        
        /// <summary>
        /// Sends an RPC to the master to increase the entity's currentRessource.
        /// </summary>
        /// <param name="amount">the increase amount</param>
        public void RequestIncreaseCurrentRessource(float amount);
        /// <summary>
        /// Sends an RPC to all clients to increase the entity's currentRessource.
        /// </summary>
        /// <param name="amount">the increase amount</param>
        public void SyncIncreaseCurrentRessourceRPC(float amount);
        /// <summary>
        /// Increases the entity's currentRessource.
        /// </summary>
        /// <param name="amount">the decrease amount</param>
        public void IncreaseCurrentRessourceRPC(float amount);
        
        /// <summary>
        /// Sends an RPC to the master to decrease the entity's currentRessource.
        /// </summary>
        /// <param name="amount">the decrease amount</param>
        public void RequestDecreaseCurrentRessource(float amount);
        /// <summary>
        /// Sends an RPC to all clients to decrease the entity's currentRessource.
        /// </summary>
        /// <param name="amount">the decrease amount</param>
        public void SyncDecreaseCurrentRessourceRPC(float amount);
        /// <summary>
        /// Decreases the entity's currentRessource.
        /// </summary>
        /// <param name="amount">the decrease amount</param>
        public void DecreaseCurrentRessourceRPC(float amount);
    }
}