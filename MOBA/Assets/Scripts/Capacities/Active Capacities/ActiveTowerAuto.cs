using System.Collections;
using System.Collections.Generic;
using Entities.Capacities;
using UnityEngine;

public class ActiveTowerAuto : ActiveCapacity
{
    public override bool TryCast(int casterIndex, int[] targetsEntityIndexes, Vector3[] targetPositions)
    {
        throw new System.NotImplementedException();
    }

    public override void PlayFeedback(int casterIndex, int[] targetsEntityIndexes, Vector3[] targetPositions)
    {
        throw new System.NotImplementedException();
    }
}
