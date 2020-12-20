using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponPreset : ScriptableObject
{
    [SerializeField] private int damage;
    [SerializeField] private float rotationTime;
    [SerializeField] private WeaponAbility ability;

    public int Damage => damage;
    public float RotationTime => rotationTime;
    public WeaponAbility Ability => ability;
}
