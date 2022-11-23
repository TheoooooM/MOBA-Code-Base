using System;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;

namespace Entities.Champion
{
    public partial class Champion : ITeamable
    {


        public Enums.Team GetTeam()
        {
            return team;
        }

        public List<Enums.Team> GetEnemyTeams()
        {
            return Enum.GetValues(typeof(Enums.Team)).Cast<Enums.Team>().Where(someTeam => someTeam != team).ToList(); //returns all teams that are not 'team'
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