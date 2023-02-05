using UnityEngine;
using TMPro;

public class DebugText : MonoBehaviour
{
    public TextMeshProUGUI debugText;
    public static DebugText Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        debugText = this.GetComponent<TextMeshProUGUI>();
    }
}
