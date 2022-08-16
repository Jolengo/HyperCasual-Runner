using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.3f;
    [SerializeField] float maxSpeed = 5f;
    [SerializeField] float jumpAmount = 5f;

    PlayerActions _input;
    Rigidbody _rb;
    bool _isGrounded;

    private void Awake()
    {
        _input = new PlayerActions();
        _rb = gameObject.GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    public void Start()
    {
        _input.Enable();
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = _input.PlayerControls.Movement.ReadValue<Vector3>();

        Move(moveDirection);
        if (_input.PlayerControls.Jump.triggered && _isGrounded)
        {
            Jump();
        }
    }

    private void Move(Vector3 direction)
    {
        if (!Physics.Raycast(transform.position, Vector3.right, 1.05f))
        {
            float scaledMoveSpeed = moveSpeed;

            Vector3 moveDirection = new Vector3(direction.x, 0, direction.z);
            _rb.AddForce(moveDirection * scaledMoveSpeed, ForceMode.Impulse);
            _rb.velocity = new Vector3(Mathf.Clamp(_rb.velocity.x, -1, maxSpeed), _rb.velocity.y, _rb.velocity.z);
        }
    }

    private void Jump()
    {
        //_rb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
        _rb.AddForce(new Vector3(0, 1 * jumpAmount, 0), ForceMode.Impulse);
        //_rb.velocity = new Vector3(Mathf.Clamp(_rb.velocity.x, -1, maxSpeed), _rb.velocity.y, _rb.velocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        RaycastHit hit;
        bool downCheck = Physics.Raycast(transform.position, Vector3.down, out hit, 1.05f);
        Transform hitObject = hit.transform;
        if (downCheck && hitObject.GetComponent<Collider>() != null)
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        RaycastHit hit;
        bool downCheck = Physics.Raycast(transform.position, Vector3.down, out hit, 1.05f);
        Transform hitObject = hit.transform;
        if (downCheck && hitObject.GetComponent<Collider>() != null)
        {
            _isGrounded = false;
        }
    }

    private void OnEnable()
    {
        _input.PlayerControls.Enable();
    }

    private void OnDisable()
    {
        _input.PlayerControls.Disable();
    }
}
