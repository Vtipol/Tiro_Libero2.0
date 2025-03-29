using UnityEngine;
using System;
using System.Collections.Generic; // Required for Events

public class PuckBase : MonoBehaviour
{
    [SerializeField] protected PuckData _puckData;
    public bool placed;
    public bool throwed;
    public bool stopped;
    protected Rigidbody _rigidbody;
    protected Vector3 _stopPosition;
    private Vector3 _startPosition;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startPosition = transform.position;

        GameManager.Instance.puckList.Add(this);
    }

    private void Start()
    {
        ApplyPuckSettings();   
    }
    public void DestroyPuck(){
        GameManager.Instance.puckList.Remove(this);
        Destroy(gameObject);
    }

    /// Applies force to the puck based on its weight.
    public virtual void ApplyForce(Vector3 force)
    {
        if (_rigidbody != null)
        {
            _rigidbody.AddForce(force * _puckData.weight, ForceMode.Impulse);
        }
    }

    /// Stores the stop position of the puck.
    public virtual void MoveFromStartPosition(Vector3 startPosition, Vector3 stopPosition)
    {
        _stopPosition = stopPosition;
        Debug.Log($"Puck moving from {startPosition} to {stopPosition}");
    }

    protected virtual void ApplyPuckSettings()
    {
        _rigidbody.mass = _puckData.weight;
    }

    public Vector3 GetStopPosition() => _stopPosition;
}
