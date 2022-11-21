using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static PlayerInputs PlayerMap;
    
    public static PlayerInputs PlayerUIMap;

    private void Awake()
    {
        if (PlayerMap != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        PlayerMap = new PlayerInputs();
    }

    /// <summary>
    /// Toggle PlayerMap
    /// </summary>
    /// <param name="value">State : true or false</param>
    public static void TogglePlayerMap(bool value)
    {
        if(value) PlayerMap.Enable();
        else PlayerMap.Disable();
    }
    
    /// <summary>
    /// Toggle PlayerUIMap
    /// </summary>
    /// <param name="value">State : true or false</param>
    public static void TogglePlayerUIMap(bool value)
    {
        if(value) PlayerUIMap.Enable();
        else PlayerUIMap.Disable();
    }
}
