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
        List<int> pucksToRemove = new();

        for (int i = 0; i < _rbPucks.Count; i++)
        {
            Vector2 _puckPosition = new(_rbPucks[i].position.x, _rbPucks[i].position.z);
            if (Vector2.Distance(_puckPosition, _centerPosition) > _radius)
            {
                Debug.Log("AHHAHAH");
                _rbPucks[i].excludeLayers = ~_triggersLayerMask.value;
                pucksToRemove.Add(i);
            }
            else
            {
                _rbPucks[i].excludeLayers = 0;
            }
        }

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
