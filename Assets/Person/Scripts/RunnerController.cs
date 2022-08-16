using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.3f;
    [SerializeField] float maxSpeed = 5f;
    [SerializeField] float jumpAmount = 5f;
    [SerializeField] Vector3 direction;

    [SerializeField] float frontRay;
    [SerializeField] float downRay;

    PlayerActions _input;
    Rigidbody _rb;


    // Всё связанное с jump и input system закомментировано
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
        Move(direction);
        /*if (_input.RunnerControls.Jump.triggered)
        {
            if (GroundCheck())
            Jump();
            
        }*/
    }

    private void Move(Vector3 direction)
    {
        if (!Physics.Raycast(transform.position, Vector3.right, frontRay))
        {
            float scaledMoveSpeed = moveSpeed;

            Vector3 moveDirection = new Vector3(direction.x, 0, 0);
            _rb.AddForce(moveDirection * scaledMoveSpeed, ForceMode.Impulse);
            _rb.velocity = new Vector3(Mathf.Clamp(_rb.velocity.x, -1, maxSpeed), _rb.velocity.y, _rb.velocity.z);
        }
    }

    /*private void Jump()
    {
        Debug.Log("Do jump");
        _rb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
    }*/

    /*private bool GroundCheck()
    {
        RaycastHit hit;
        bool downCheck = Physics.Raycast(transform.position, Vector3.down, out hit, downRay);
        Transform hitObject = hit.transform;
        Debug.Log("Enter: downCheck - " + downCheck);
        Debug.Log("Enter: hitObject.GetComponent<Collider>() - " + hitObject.GetComponent<Collider>());
        Debug.Log("return - " + (downCheck && hitObject.GetComponent<Collider>() != null));
        return (downCheck && hitObject.GetComponent<Collider>() != null);
    }*/

    private void OnEnable()
    {
        _input.RunnerControls.Enable();
    }

    private void OnDisable()
    {
        _input.RunnerControls.Disable();
    }
}
