using UnityEngine;

public class GroundCheckPoint : MonoBehaviour
{
    private LayerMask _groundLayerMask;
    
    public bool isPointGrounded = true;

    private void Awake()
    {
        _groundLayerMask = transform.parent.GetComponent<GroundCheck>().groundLayerMask;
    }

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.2f, _groundLayerMask);

        DebugText.Instance.debugText.text += " " + hitColliders.Length.ToString();

        if (hitColliders.Length > 0)
        {
            isPointGrounded = true;
        }
        else
        {
            isPointGrounded = false;
        }
    }
}
