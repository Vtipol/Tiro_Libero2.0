using UnityEngine;

public class GiveForce : MonoBehaviour
{
    #region Variables
    // Add your variables here

    [SerializeField] private Rigidbody _rb;

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
    
    public void AddForce(float force)
    {
        _rb.AddRelativeForce(new(0, 0, force), ForceMode.Impulse);
    }

    #endregion
}
