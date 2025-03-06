using UnityEngine;
// Receiver: la fionda/proiettile che viene teso e rilasciato
public class Slingshot : MonoBehaviour
{
    public Transform _disc;
    private Vector3 _startPosition;
    private Vector3 launchForce;

    private void Start()
    {
        _startPosition = _disc.position;
    }

    public void Charge(Vector3 pullPosition)
    {
        // Sposta il proiettile all'indietro per simulare il tiro
        _disc.position = _startPosition + (pullPosition - _startPosition) * 0.5f;
    }

    public void Release()
    {
        // Lancia il proiettile in avanti
        Rigidbody rb = _disc.GetComponent<Rigidbody>();

        // Aggiunge forza al proiettile
        if (rb!=null)
        {
            rb.linearVelocity = (_startPosition - _disc.position) *5f;
        }
    }

}
