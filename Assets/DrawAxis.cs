using UnityEngine;

public class DrawAxis : MonoBehaviour
{

    public float axisLength = 1.0f;

    private LineRenderer lineRenderer;

    void Start()
    {
        // Aggiungi un LineRenderer all'oggetto
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 6; // 2 punti per ogni asse (X, Y, Z)
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
    }

    void Update()
    {
        // Imposta i punti per gli assi X, Y, Z
        Vector3 start = transform.position;
        lineRenderer.SetPosition(0, start); // Inizio asse X
        lineRenderer.SetPosition(1, start + transform.right * axisLength); // Fine asse X (Rosso)
        lineRenderer.SetPosition(2, start); // Inizio asse Y
        lineRenderer.SetPosition(3, start + transform.up * axisLength); // Fine asse Y (Verde)
        lineRenderer.SetPosition(4, start); // Inizio asse Z
        lineRenderer.SetPosition(5, start + transform.forward * axisLength); // Fine asse Z (Blu)

        // Colori degli assi
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        lineRenderer.startColor = Color.green;
        lineRenderer.endColor = Color.green;
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.blue;
    }
}

