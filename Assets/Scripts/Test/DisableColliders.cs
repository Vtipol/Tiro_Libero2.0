using UnityEngine;
using System.Collections.Generic;

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

    #endregion

    #region MonoBehaviour Lifecycle Methods

    // Called when the script is initialized
    private void Awake()
    {
        
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
        for (int i = 0; i < _rbPucks.Count; i++)
        {
            Transform transform = _rbPucks[i].transform;
            if (Vector3.Distance(transform.position, _center.position) > _radius)
            {
                _rbPucks[i].excludeLayers = ~_triggersLayerMask.value;
            }
            else
            { 
                _rbPucks[i].excludeLayers = 0;
            }
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

    #endregion
}
