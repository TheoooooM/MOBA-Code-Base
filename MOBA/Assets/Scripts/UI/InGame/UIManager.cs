using UnityEngine;

public partial class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private Vector3 offset = new Vector3(0, 2f, 0);

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