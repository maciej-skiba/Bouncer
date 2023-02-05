using UnityEngine;

public class Ninja : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private Transform _groundCheckTransform;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Collider _groundCheckCollider;

    private float _jumpSpeed = 7.0f;
    private float _xAxisInput;
    private float _yAxisInput;
    private float _xAxisMouseInput;
    private Animator _animator;
    private Rigidbody _rigidbody;
    private float _groundCheckDistance = 0.1f;
    private float _movementSpeed = 5.0f;
    private Quaternion _bodyRotation;
    private float _cameraRotationSpeed = 0.5f;

    [HideInInspector] public bool isGrounded = true;

    private void Awake()
    {
        _animator = this.GetComponent<Animator>();
        _rigidbody= this.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        //Debug.Log(isGrounded);

        _xAxisInput = Input.GetAxis("Horizontal");
        _yAxisInput= Input.GetAxis("Vertical");
        _xAxisMouseInput = Input.GetAxis("Mouse X");

        _animator.SetFloat("X_speed", _xAxisInput);
        _animator.SetFloat("Y_speed", _yAxisInput);


        if (Input.GetKeyDown(KeyCode.Space) && GroundCheck.isPlayerGrounded)
        {
            Jump();
        }

        var y_Rotation = _xAxisMouseInput * _cameraRotationSpeed;
        this.transform.Rotate(0, y_Rotation, 0);
    }


    private void FixedUpdate()
    {
        _rigidbody.velocity =
            transform.forward * _yAxisInput * _movementSpeed +
            transform.up * _rigidbody.velocity.y +
            transform.right * _xAxisInput * _movementSpeed;
    }

    private void Jump()
    {
        isGrounded = false;
        _animator.SetTrigger("Jump");
        _rigidbody.AddForce(Vector3.up * _jumpSpeed, ForceMode.Impulse);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState= CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState= CursorLockMode.None;
        }
    }
}
