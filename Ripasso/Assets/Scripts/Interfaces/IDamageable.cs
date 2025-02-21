using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public int MaxLife { get; set; }
    public int CurrentLife { get; set; }

    public void TakeDamage(int damage);
    public void Die();
}
