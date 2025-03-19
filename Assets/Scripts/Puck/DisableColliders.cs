using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Prevents pucks from colliding with anything except the out triggers
/// </summary>
public class DisableColliders : MonoBehaviour
{
    #region Variables
    // Add your variables here

    // Pucks are added when first thrown
    // Going outside of the radius disables the colliders
    [SerializeField] private List<Rigidbody> _rbPucks;
    [SerializeField] private Transform _center;
    [SerializeField] private float _radius;

    [SerializeField] private LayerMask _triggersLayerMask;

    private Vector2 _centerPosition;

    #endregion

    #region MonoBehaviour Lifecycle Methods

    // Called when the script is initialized
    private void Awake()
    {
        _centerPosition = new Vector2(_center.transform.position.x, _center.transform.position.z);
    }

    // Called when the script is initialized
    private void Start()
    {

    }

    // Called when the object is enabled
    private void OnEnable()
    {

    }

    // Called when the object is disabled
    private void OnDisable()
    {

    }

    // Called every frame
    private void Update()
    {
        ExcludePucksWhenOutside();
    }

    private void ExcludePucksWhenOutside()
    {
        // Keeps track of the pucks that we have to remove
        // to avoid changing the list while iterating
        List<int> pucksToRemove = new();

        for (int i = 0; i < _rbPucks.Count; i++)
        {
            Vector2 _puckPosition = new(_rbPucks[i].position.x, _rbPucks[i].position.z);
            // checks if the puck is outside the radius
            if (Vector2.Distance(_puckPosition, _centerPosition) > _radius)
            {
                // excludes the puck from colliding with anything except the triggers
                _rbPucks[i].excludeLayers = ~_triggersLayerMask.value;
                pucksToRemove.Add(i);
            }
            else
            {
                // includes the puck in all layers
                _rbPucks[i].excludeLayers = 0;
            }
        }

        // finally removes the pucks that are outside the radius
        // from the list that keeps track of them when inside the radius
        for (int i = 0; i < pucksToRemove.Count; i++)
        {
            _rbPucks.RemoveAt(pucksToRemove[i]);
        }
    }

    // Called on every physics update (Fixed timestep)
    private void FixedUpdate()
    {

    }

    // Called after all Update methods have been called
    private void LateUpdate()
    {

    }

    #endregion

    #region Collision Methods

    // Called when the collider enters another collider
    private void OnCollisionEnter(Collision collision)
    {

    }

    // Called when the collider stays in contact with another collider
    private void OnCollisionStay(Collision collision)
    {

    }

    // Called when the collider exits another collider
    private void OnCollisionExit(Collision collision)
    {

    }

    // Called when a trigger collider enters another collider
    private void OnTriggerEnter(Collider other)
    {

    }

    // Called when a trigger collider stays in contact with another collider
    private void OnTriggerStay(Collider other)
    {

    }

    // Called when a trigger collider exits another collider
    private void OnTriggerExit(Collider other)
    {

    }
    #endregion

    #region Custom Methods

    public void AddRb(Rigidbody rb)
    {
        _rbPucks.Add(rb);
    }

    public void RemoveRb(Rigidbody rb)
    {
        _rbPucks.Remove(rb);
    }

    #endregion
}
