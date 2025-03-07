using Unity.Cinemachine;
using UnityEngine;

public class FollowPuck : MonoBehaviour
{
    #region Variables
    // Add your variables here
    [SerializeField] private GameObject _puck;
    [SerializeField] private CinemachineCamera _followCamera;
    [SerializeField] private CinemachineCamera _boardCamera;

    private Transform _puckTransform;
    private Rigidbody _puckRb;

    public float minZoom = 1f; // Closest zoom level
    public float maxZoom = 4f; // Default zoom level
    public float zoomSpeed = 5f;
    public float heightOffset = 2f; // Adjust this to keep the top part fixed

    private Vector3 initialCamPosition;
    #endregion

    #region MonoBehaviour Lifecycle Methods

    // Called when the script is initialized
    private void Awake()
    {

    }

    // Called when the script is initialized
    private void Start()
    {
        _puckTransform = _puck.transform;
        _puckRb = _puck.GetComponent<Rigidbody>();

        if (_followCamera)
        {
            initialCamPosition = _followCamera.transform.position;
        }
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
        float zoomAmount = _puckRb.linearVelocity.magnitude / 2;


        zoomAmount = Mathf.Clamp(zoomAmount, 0f, maxZoom);


        ////_followCamera.Lens.OrthographicSize = Mathf.Clamp();
        //// Get puck's normalized forward progress (assuming Y+ is forward)
        //float progress = Mathf.InverseLerp(-2f, 2f, _puckTransform.forward.z); // Adjust -5 and 5 to your scene scale

        //Debug.Log(puck.forward.z);

        // Compute new zoom level
        float newZoom = Mathf.Lerp(maxZoom, minZoom, Mathf.InverseLerp(0f, maxZoom, zoomAmount));
        //Debug.Log(newZoom);

        _followCamera.Lens.OrthographicSize = newZoom;
        //// Adjust camera position to shift upwards
        //Vector3 camPos = initialCamPosition;
        //camPos.z += heightOffset * progress;
        //_followCamera.transform.position = camPos;
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
