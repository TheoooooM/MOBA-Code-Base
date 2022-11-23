using System.Collections.Generic;
using Entities;
using UnityEngine;

public partial class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    // class entity + image 
    [SerializeField] private Dictionary<int, Entity> entities ;
    [SerializeField] private Canvas hudPlayer;
    [SerializeField] private Vector3 offset;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            DestroyImmediate(gameObject);
            return;
        }

        Instance = this;
    }

    private void Update()
    {
        if (!player) return;
        
        // Update UI with player's position
        hudPlayer.transform.position = player.position + offset;
        hudPlayer.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        UpdateLifeBar();
        UpdateResourceBar();
    }

}