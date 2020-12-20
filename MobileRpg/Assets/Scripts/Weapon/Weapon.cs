using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform center;
    [SerializeField] Vector3 rotationAxis;
    [SerializeField] WeaponTrigger weaponTrigger;
    [SerializeField] private WeaponPreset preset;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Enemy>().TakeDamage(preset.Damage);
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
        center.DORotate(rotationAxis, preset.RotationTime, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
    }
    [Button]
    public void Attack() 
    {
        center.DOKill();
        weaponTrigger.Attack(preset.Damage);
    }
}
