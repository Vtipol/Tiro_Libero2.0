using Unity.Cinemachine;
using UnityEngine;

public class FallingCamera : MonoBehaviour
{
    #region Variables
    // Add your variables here
    [SerializeField] private CinemachineCamera[] _fallingCameras;
    [SerializeField] private CinemachineCamera _boardCamera;
    [SerializeField] private CinemachineCamera _followCamera;

    private int _fallingCameraIndex;
    private bool _isFalling = false;

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
        if (_isFalling) return;

        _isFalling = true;

        Debug.Log(other.name);
        _fallingCameraIndex = FindClosestCamera(other.transform);
        _fallingCameras[_fallingCameraIndex].Priority = 15;
        _boardCamera.Priority = 10;
        _followCamera.Priority = 5;
        Invoke(nameof(SwitchToStationaryCamera), 2f);
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

    private void SwitchToStationaryCamera()
    {
        _fallingCameras[_fallingCameraIndex].Priority = 0;
        _boardCamera.Priority = 15;
        _followCamera.Priority = 5;

        _isFalling = false;
    }

    private int FindClosestCamera(Transform puck)
    {
        int index = 0;

        float minDistance = float.MaxValue;

        for (int i = 0; i < _fallingCameras.Length; i++)
        {
            if (Vector3.Distance(puck.position, _fallingCameras[i].transform.position) < minDistance)
            {
                minDistance = Vector3.Distance(puck.position, _fallingCameras[i].transform.position);
                index = i;
            }
        }


        Debug.Log(index);
        return index;
    }

    #endregion
}
