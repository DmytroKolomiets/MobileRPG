using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

public class Weapon : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] Transform center;
    [SerializeField] Vector3 rotationAxis;
    [SerializeField] WeaponTrigger weaponTrigger;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Enemy>().TakeDamage(damage);
    }
    public void Hide()
    {
        center.DOKill();
        gameObject.SetActive(false);
    }
    [Button]
    public void StartAiming()
    {
        gameObject.SetActive(true);
        center.eulerAngles = Vector3.zero;
        weaponTrigger.ToAimState();
        center.DORotate(rotationAxis, 1f, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
    }
    [Button]
    public void Attack() 
    {
        center.DOKill();
        weaponTrigger.Attack(damage);
    }
}
