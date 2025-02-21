using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    // VARIABLES
    private PlayerControl _inputActions;
    private InputAction _movementAction;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;


    private Vector3 _direction;
    private bool _isGrounded;

    private Rigidbody _rb;

    // LIFECYCLE
    private void Awake()
    {
        // Setting input
        _inputActions = new();

        _movementAction = _inputActions.PlayerMovement.Movement;
        _inputActions.PlayerMovement.Movement.performed += PlayerMovementPerformed;
        _inputActions.PlayerMovement.Jump.performed += PlayerJumpPerformed;

        _inputActions.Enable();

        // Getting components
        _rb = GetComponent<Rigidbody>();

        // Setting vars
        _isGrounded = true;
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void OnDrawGizmos()
    {

    }

    // METHODS

    // _events
    private void PlayerJumpPerformed(InputAction.CallbackContext context)
    {
        if (_isGrounded)
        {
            Jump();
        }
    }

    private void PlayerMovementPerformed(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector3>();

        if (_direction == Vector3.zero)
        {
            float velocityY = (_isGrounded) ? 0 : _rb.velocity.y;
            _direction = new(0, velocityY, 0);
        }
    }

    private void PlayerMovement()
    {
        _rb.velocity = _direction * _movementSpeed;
    }

    private void Jump() {
        _rb.AddForce(new(0, _jumpForce, 0));
    }
}
