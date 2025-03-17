using UnityEngine;
using System; // Required for Events

public abstract class Puck : MonoBehaviour
{
    [SerializeField] protected PuckData _puckData;
    protected Rigidbody _rigidbody;
    protected Vector3 _stopPosition;
    private Vector3 _startPosition;
    private bool _hasFlown = false;

    // Events
    public event Action PuckStop;
    public event Action PuckFly;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startPosition = transform.position;
    }

    private void Update()
    {
        CheckPuckStopped();
        CheckPuckFly();
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

    /// Checks if the puck has stopped moving.
    private void CheckPuckStopped()
    {
        if (_rigidbody.linearVelocity.magnitude <= 0.01f) // Considered stopped
        {
            PuckStop?.Invoke();
        }
    }

    /// Checks if the puck has moved in the Z direction.
    private void CheckPuckFly()
    {
        if (!_hasFlown && Math.Abs(transform.position.y - _startPosition.y) > 0.01f)
        {
            _hasFlown = true;
            _puckData.scoreMultiplier = 0; // Reset multiplier
            Debug.Log("Puck has flown! Score Multiplier set to 0.");
            PuckFly?.Invoke();
        }
    }

    protected virtual void ApplyPuckSettings()
    {
        _rigidbody.mass = _puckData.weight;
    }

    public Vector3 GetStopPosition() => _stopPosition;
}
