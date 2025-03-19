using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class StationaryCamera : MonoBehaviour
{
    #region Variables
    // Add your variables here

    [SerializeField] private Transform[] _playersTransform;
    [SerializeField] private CinemachineCamera _boardCamera;
    [SerializeField] private CinemachineCamera _followCamera;
    [SerializeField] private float _rotationSpeed = 1f;

    private int _currentPlayerIndex = 0;

    private bool _isPulling = false;
    public float PullSpeed = 1f;

    public bool _goingBack;

    private Vector3 _startPosition;
    private float _ortoLensStartSize;


    #endregion

    #region MonoBehaviour Lifecycle Methods

    // Called when the script is initialized
    private void Awake()
    {
        _ortoLensStartSize = _boardCamera.Lens.OrthographicSize;
        _startPosition = _boardCamera.transform.position;
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
        if (_isPulling)
        {
            float zoomAmount = _distance - _previousDistance;

            Zoom(zoomAmount);
        }

        if (_goingBack)
        {
            ZoomIn(PullSpeed * 5);
        }

        if (!_rotating) return;

        Quaternion targetRotation = Quaternion.Euler(_endRotation);
        //Debug.Log(_endRotation);
        //Debug.Log(_camera.transform.rotation);
        _boardCamera.transform.rotation = Quaternion.RotateTowards(_boardCamera.transform.rotation, targetRotation, _rotationSpeed * Time.fixedDeltaTime);

        // Check if we reached the target
        if (Quaternion.Angle(_boardCamera.transform.rotation, targetRotation) < 0.1f)
        {
            _rotating = false;
            _boardCamera.transform.rotation = targetRotation; // Snap to final rotation to avoid drift
        }
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

    public void NextPlayer()
    {
        if (_currentPlayerIndex < _playersTransform.Length - 1)
        {
            _currentPlayerIndex++;
        }
        else
        {
            _currentPlayerIndex = 0;
        }

        RotateToPlayer(_currentPlayerIndex);
    }

    public void PreviousPlayer()
    {
        if (_currentPlayerIndex > 0)
        {
            _currentPlayerIndex--;
        }
        else
        {
            _currentPlayerIndex = _playersTransform.Length - 1;
        }

        RotateToPlayer(_currentPlayerIndex);
    }

    public void SetPlayer(int index)
    {
        _currentPlayerIndex = index;
        RotateToPlayer(_currentPlayerIndex);
    }

    private bool _rotating = false;
    private Vector3 _startRotation;
    private Vector3 _endRotation;

    private void RotateToPlayer(int index)
    {
        Vector3 nextRotation = _boardCamera.transform.rotation.eulerAngles;

        _startRotation = nextRotation;

        nextRotation.y = _playersTransform[index].localEulerAngles.y;

        _endRotation = nextRotation;

        Debug.Log(_startRotation);
        Debug.Log(_endRotation);

        _rotating = true;
    }

    private float _distance = 0f;
    private float _previousDistance = 0f;

    public void StartPull()
    {
        _isPulling = true;
        _ortoLensStartSize = _boardCamera.Lens.OrthographicSize;
        _startPosition = _boardCamera.transform.position;
    }

    public void UpdatePullDistance(float distance)
    {
        _previousDistance = _distance;
        _distance = distance;
    }

    public void StopPulling()
    {
        _isPulling = false;
        _goingBack = true;

        _boardCamera.Priority = 0;
        _followCamera.Priority = 15;
    }


    /// <summary>
    /// Zooms in/out the camera based on user's drag
    /// </summary>
    /// <param name="zoomAmount"></param>
    private void Zoom(float zoomAmount)
    {
        Vector3 topBoardWorldPos = _playersTransform[GetOppositePlayer()].position; // Top of the board

        // adjust orthographic size to zoom in/out
        _boardCamera.Lens.OrthographicSize += zoomAmount * PullSpeed * Time.fixedDeltaTime;

        // Adjust camera position to keep top part of the board in view
        _boardCamera.transform.position += PullSpeed * zoomAmount * -_boardCamera.transform.up / 50;
    }

    /// <summary>
    /// Goes back to original view
    /// </summary>
    /// <param name="zoomAmount"></param>
    private void ZoomIn(float zoomAmount)
    {
        // Decreases orthographic size
        _boardCamera.Lens.OrthographicSize -= zoomAmount * Time.fixedDeltaTime;

        // Adjust camera position to keep top part
        _boardCamera.transform.position += _boardCamera.transform.up * zoomAmount / 50;

        if (Vector3.Distance(_boardCamera.transform.position, _startPosition) < 0.01f || _ortoLensStartSize >= _boardCamera.Lens.OrthographicSize)
        {
            _goingBack = false;
            _boardCamera.Lens.OrthographicSize = _ortoLensStartSize;
            _boardCamera.transform.position = _startPosition;
        }
    }

    /// <summary>
    /// Returns the index of the opposite player, used for pulling the camera
    /// </summary>
    /// <returns></returns>
    private int GetOppositePlayer()
    {
        if (_playersTransform.Length == 2)
        {
            return _currentPlayerIndex == 0 ? 1 : 0;
        }
        else
        {
            if (_currentPlayerIndex < 2)
            {
                return _currentPlayerIndex + 2;
            }
            else
            {
                return _currentPlayerIndex - 2;
            }
        }
    }
    #endregion
}
