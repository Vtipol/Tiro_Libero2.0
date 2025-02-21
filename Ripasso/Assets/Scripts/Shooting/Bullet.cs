using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour, IDamager
{

    private Rigidbody _rb;

    public Rigidbody Rigidbody => _rb;

    [field: SerializeField] public int Damage { get; set; }
    [field: SerializeField] public float ReloadTime { get; set; }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
