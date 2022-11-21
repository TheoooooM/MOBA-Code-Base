using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums : MonoBehaviour
{
    /// <summary>
    /// All teams something can belong to
    /// </summary>
    public enum Team
    {
        Neutral, Team1, Team2
    }
    
    /// <summary>
    /// All type a capacity can have
    /// </summary>
    public enum CapacityType
    {
        Kit, Item, Positive, Negative, Attack 
    }
}
