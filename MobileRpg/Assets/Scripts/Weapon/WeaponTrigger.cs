using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTrigger : MonoBehaviour
{
    [SerializeField] Collider coll;
    private int damage;

    public void Attack(int damage)
    {
        this.damage = damage;
        coll.enabled = true;
    }
    public void ToAimState()
    {
        coll.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Enemy>().TakeDamage(damage);
    }
}
