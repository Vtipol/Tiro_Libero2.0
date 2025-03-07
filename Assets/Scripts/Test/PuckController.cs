using UnityEngine;

public class PuckController : MonoBehaviour
{
    public GameObject puck;
    public Transform centerPoint; // The center of the circle
    public float radius = 5f; // The distance from the center (must stay the same)
    public float minAngle = -30f; // Left boundary of the slice
    public float maxAngle = 30f; // Right boundary of the slice
    public float moveSpeed = 50f; // Speed of movement

    private float currentAngle; // The puck's current angle in degrees

    void Start()
    {
        // Calculate initial angle based on puck's position
        Vector3 dir = puck.transform.position - centerPoint.position;
        currentAngle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
        currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);
        UpdatePuckPosition();
    }

    public bool _isAming = false;
    public float _rotationSpeed = 1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        { 
            _isAming = !_isAming;
        }

        if(_isAming)
        {
            Vector3 rotation = puck.transform.rotation.eulerAngles;

            if (Input.GetKey(KeyCode.A))
            {
                rotation.y -= _rotationSpeed;
            }

            if (Input.GetKey(KeyCode.D))
            {
                rotation.y += _rotationSpeed;
            }


            //Debug.Log(rotation);
            puck.transform.rotation = Quaternion.Euler(rotation);

            return;
        }


        float input = Input.GetAxis("Horizontal"); // A/D keys or Left/Right Arrow

        if (input != 0)
        {
            currentAngle += input * moveSpeed * Time.deltaTime;
            currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle); // Keep inside slice
            UpdatePuckPosition();
        }
    }

    void UpdatePuckPosition()
    {
        // Convert angle to world position
        float radianAngle = currentAngle * Mathf.Deg2Rad;
        Vector3 newPos = new Vector3(Mathf.Cos(radianAngle), 0, Mathf.Sin(radianAngle)) * radius;
        puck.transform.position = centerPoint.position + newPos;
        Rigidbody rb = puck.GetComponent<Rigidbody>();
        rb.linearVelocity *= 0;
        rb.angularVelocity *= 0;
        puck.transform.rotation = Quaternion.Euler(new(0, puck.transform.rotation.eulerAngles.y, 0));
    }
}