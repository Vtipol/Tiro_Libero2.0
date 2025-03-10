using System;
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

    // Aggiungi i quattro trasformazioni per definire i vertici del poligono
    public Transform transform1;
    public Transform transform2;
    public Transform transform3;
    public Transform transform4;

    private void OnEnable()
    {
        input = new MyInputActions();
        input.Mouse.MouseMoved.performed += MouseMoved_Performed;
        input.Mouse.MouseReleased.performed += MouseRealeased_Performed;
        input.Enable();
    }

    private void OnDisable()
    {
        input.Mouse.MouseMoved.performed -= MouseMoved_Performed;
        input.Mouse.MouseReleased.performed -= MouseRealeased_Performed;
        input.Disable();
    }

    private void MouseMoved_Performed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            MouseMoved();
        }
    }

    private void MouseRealeased_Performed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            MouseRealeased();
        }
    }

    private void MouseMoved()
    {
        if (!isMoving)
        {
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, distanceFromCamera));

            // Proietta la posizione del mouse sul bordo più vicino del poligono
            Vector3 projectedPosition = ProjectPointOntoPolygon(mouseWorldPosition);

            // Aggiorna la posizione del disco
            discPosition.position = projectedPosition;
        }
    }

    private void MouseRealeased()
    {
        if (!isMoving)
        {
            isMoving = true;

            Vector3 mousePosition = Mouse.current.position.ReadValue();
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, distanceFromCamera));

            // Proietta la posizione del mouse sul bordo più vicino del poligono
            Vector3 projectedPosition = ProjectPointOntoPolygon(mouseWorldPosition);

            // Applica la forza nella direzione del movimento
            Vector3 direction = (projectedPosition - discPosition.position).normalized;
            rb.AddForce(direction * force, ForceMode.Impulse);
        }
    }

    // Funzione per proiettare un punto sul bordo più vicino del poligono
    private Vector3 ProjectPointOntoPolygon(Vector3 point)
    {
        // Definisci i lati del poligono
        Vector3[] polygonVertices = new Vector3[]
        {
            transform1.position,
            transform2.position,
            transform3.position,
            transform4.position
        };

        Vector3 closestPoint = Vector3.zero;
        float closestDistance = float.MaxValue;

        // Itera su tutti i lati del poligono
        for (int i = 0; i < polygonVertices.Length; i++)
        {
            Vector3 start = polygonVertices[i];
            Vector3 end = polygonVertices[(i + 1) % polygonVertices.Length]; // Connette l'ultimo punto al primo

            // Proietta il punto sul lato corrente
            Vector3 projectedPoint = ProjectPointOntoLine(start, end, point);

            // Calcola la distanza tra il punto e la proiezione
            float distance = Vector3.Distance(point, projectedPoint);

            // Trova la proiezione più vicina
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPoint = projectedPoint;
            }
        }

        return closestPoint;
    }

    // Funzione per proiettare un punto su una linea (lato del poligono)
    private Vector3 ProjectPointOntoLine(Vector3 start, Vector3 end, Vector3 point)
    {
        Vector3 lineDirection = (end - start).normalized;
        Vector3 pointDirection = point - start;

        // Proietta il punto sulla linea
        float projectionLength = Vector3.Dot(pointDirection, lineDirection);
        Vector3 projectedPoint = start + lineDirection * projectionLength;

        // Limita la proiezione ai limiti del segmento di linea
        float segmentLength = Vector3.Distance(start, end);
        if (projectionLength < 0)
        {
            projectedPoint = start;
        }
        else if (projectionLength > segmentLength)
        {
            projectedPoint = end;
        }

        return projectedPoint;
    }
}