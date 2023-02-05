using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private GroundCheckPoint[] _groundCheckPoints;
    static public bool isPlayerGrounded = true;

    public LayerMask groundLayerMask;

    private void Update()
    {
        foreach (GroundCheckPoint point in _groundCheckPoints)
        {
            if (point.isPointGrounded)
            {
                isPlayerGrounded = true;
                break;
            }

            isPlayerGrounded = false;
        }

        DebugText.Instance.debugText.text = isPlayerGrounded.ToString();
    }
}
