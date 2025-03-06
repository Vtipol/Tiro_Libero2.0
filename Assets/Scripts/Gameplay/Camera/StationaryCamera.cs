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

    private bool _goingBack;

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
            ZoomOut(PullSpeed);
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


    public void PullOut()
    {
        _ortoLensStartSize = _boardCamera.Lens.OrthographicSize;
        _startPosition = _boardCamera.transform.position;
        _isPulling = true;
    }

    public void StopPulling() {
        _isPulling = false;
        _goingBack = true;

        _boardCamera.Priority = 0;
        _followCamera.Priority = 15;
    }

    private void ZoomOut(float zoomAmount)
    {
        Vector3 topBoardWorldPos = _playersTransform[GetOppositePlayer()].position; // Top of the board

        // Increase orthographic size
        _boardCamera.Lens.OrthographicSize += zoomAmount * Time.fixedDeltaTime;
        //_camera.Lens.OrthographicSize = Mathf.Clamp(_camera.Lens.OrthographicSize, minOrthoSize, maxOrthoSize);

        // Recalculate new top position
        //Vector3 newTopScreenPos = _camera.WorldToScreenPoint(topBoardWorldPos);

        // Adjust camera position to keep top part 
        _boardCamera.transform.position += -_boardCamera.transform.up * zoomAmount / 50;
    }

    private void ZoomIn(float zoomAmount)
    {
        Vector3 topBoardWorldPos = _playersTransform[GetOppositePlayer()].position; // Top of the board

        // Increase orthographic size
        _boardCamera.Lens.OrthographicSize -= zoomAmount * Time.fixedDeltaTime;
        //_camera.Lens.OrthographicSize = Mathf.Clamp(_camera.Lens.OrthographicSize, minOrthoSize, maxOrthoSize);

        // Recalculate new top position
        //Vector3 newTopScreenPos = _camera.WorldToScreenPoint(topBoardWorldPos);

        // Adjust camera position to keep top part 
        _boardCamera.transform.position += _boardCamera.transform.up * zoomAmount / 50;

        if (Vector3.Distance(_boardCamera.transform.position, _startPosition) < 0.01f || _ortoLensStartSize >= _boardCamera.Lens.OrthographicSize)
        {
            _goingBack = false;
            _boardCamera.Lens.OrthographicSize = _ortoLensStartSize;
            _boardCamera.transform.position = _startPosition;
        }
    }

    private int GetOppositePlayer() {
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

    IEnumerator RotationTransition()
    {
        yield return new WaitWhile(EndedRotation);
    }

    private bool EndedRotation()
    {
        while (true)
        {

        }

    }

    #endregion
}
