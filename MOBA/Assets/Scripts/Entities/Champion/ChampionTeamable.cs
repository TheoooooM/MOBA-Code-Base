using Photon.Pun;

namespace Entities.Champion
{
    public partial class Champion : ITeamable
    {
        public bool canChangeTeam;

        public Enums.Team team;

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
        public event GlobalDelegates.BoolDelegate OnChangeTeamFeedback;
    }
}