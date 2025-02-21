using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    private PlayerControl _inputActions;
    private InputAction _shootingAction;
    private InputAction _reloadAction;

    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _shootingForce;
    [SerializeField] private Transform _firePoint;
    private void Awake()
    {
        _inputActions = new();

        _shootingAction = _inputActions.PlayerShooting.Shoot;
        _shootingAction.performed += PlayerShootingPerformed;

        _reloadAction = _inputActions.PlayerShooting.Reload;
        _reloadAction.performed += PlayerReloadPerformed;

        _inputActions.Enable();

    }

    private void PlayerReloadPerformed(InputAction.CallbackContext context)
    {
    }

    private void PlayerShootingPerformed(InputAction.CallbackContext context)
    {
        Bullet bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation, null);
        bullet.Rigidbody.velocity = transform.forward * _shootingForce;
    }
}
