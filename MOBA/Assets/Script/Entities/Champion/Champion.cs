using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities;

public abstract class Champion : Entity, IActiveLifeable, IAttackable, ICastable, IDeadable, IDisplaceable, IMoveable,
    IRessourceable, ITeamable
{
    public ChampionSO championSo;
    
    
}