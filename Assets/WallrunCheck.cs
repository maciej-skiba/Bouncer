using System.Collections;
using UnityEngine;

public class WallrunCheck : MonoBehaviour
{
    [SerializeField] private LayerMask wallrunObjectMask;
    [SerializeField] private Rigidbody _playerRigidBody;
    private float _wallrunMaxDuration = 1.5f;
    private float _maxDistanceToWall = 1.0f;
    private float _wallrunVelocity = 4.0f;

    public static bool s_wallrunUsed = false;
    public static bool s_wallrunning = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) && s_wallrunning && !IsWallRunAvailable())
        {
            s_wallrunning = false;
        }
        else if (Input.GetKey(KeyCode.W) && s_wallrunning)
        {
            this._playerRigidBody.velocity = Vector3.up * _wallrunVelocity;
        }
        else if (!Input.GetKey(KeyCode.W) && s_wallrunning)
        {
            s_wallrunning = false;
        }
        else if (Input.GetKey(KeyCode.W) && !s_wallrunUsed && IsWallRunAvailable())
        {
            s_wallrunUsed = true;
            StartCoroutine("CoWallride");
        }

        DebugText.Instance.debugText.text = $"s_wallrunning: {s_wallrunning}, s_wallrunUsed: {s_wallrunUsed}";
    }

    private bool IsWallRunAvailable()
    {
        if (Physics.Raycast(origin: this.transform.position, direction: transform.forward, layerMask: wallrunObjectMask, maxDistance: _maxDistanceToWall))
        {

            return true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);

            return false;
        }
    }
    private IEnumerator CoWallride()
    {
        Debug.Log("Wallride started");
        s_wallrunning = true;

        yield return new WaitForSeconds(_wallrunMaxDuration);

        Debug.Log("Wallride ended");
        s_wallrunning = false;
        s_wallrunUsed = false;
    }
}
