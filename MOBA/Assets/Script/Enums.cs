using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums : MonoBehaviour
{
    public enum Team
    {
        Neutral, Team1, Team2
    }
    
    /// <summary>
    /// All type of a capacity that can define it
    /// </summary>
    public enum CapacityType
    {
        Kit, Item, Positive, Negative, Attack 
    }
}
