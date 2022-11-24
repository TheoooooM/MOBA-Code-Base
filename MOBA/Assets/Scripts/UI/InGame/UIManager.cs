using UnityEngine;

public partial class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    [SerializeField] private Canvas canvasPrefab;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            DestroyImmediate(gameObject);
            return;
        }

        Instance = this;
    }


}