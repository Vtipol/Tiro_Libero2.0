using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DiscController : MonoBehaviour
{
    private MyInputActions input;
    public Transform discPosition;
    public Rigidbody rb;
    public Camera mainCamera;
    public float distanceFromCamera;
    public float force;
    public bool isMoving = false;

    
    private void OnEnable()
    {
        input = new MyInputActions();
        input.Mouse.MouseMoved.performed += MouseMoved_Performed;
        
        input.Mouse.MouseReleased.performed += MouseRealeased_Performed;
        input.Mouse.MouseReleased.canceled += MouseRealeased_Canceled;
        input.Enable();
    }



    private void MouseRealeased_Canceled(InputAction.CallbackContext context)
    {
        
        
    }

    private void MouseMoved_Performed(InputAction.CallbackContext context)
    {       
      if(context.performed)
      {
       MouseMoved();
      }
           
    }
    private void MouseRealeased_Performed(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
           MouseRealeased();
        }
       
    }

    

    

    private void MouseMoved()
    {
        if(!isMoving)
        {
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            Debug.LogWarning(mousePosition);

            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, distanceFromCamera));
            Debug.LogWarning(mouseWorldPosition);

            discPosition.position = mouseWorldPosition;
        }
        
        
    }
    private void MouseRealeased()
    {
        if (!isMoving)
        {
            isMoving = true;
            rb.AddForce(Vector3.forward * force, ForceMode.Impulse);
            
        }
        isMoving = false;
        
    }
    
}

