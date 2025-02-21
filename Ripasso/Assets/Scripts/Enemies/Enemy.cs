using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [field: SerializeField] public int MaxLife { get; set; }
    [field: SerializeField] public int CurrentLife { get; set; }

    public void Die()
    {
        Debug.Log($"{gameObject.name} died");
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        CurrentLife -= damage;
        if (CurrentLife < 1)
        {
            Die();
        }

        Debug.Log($"{gameObject.name} remaining life: {CurrentLife}");
    }


    private void Awake()
    {
        CurrentLife = MaxLife;
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
