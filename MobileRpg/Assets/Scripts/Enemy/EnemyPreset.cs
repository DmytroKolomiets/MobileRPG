using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyPreset : ScriptableObject
{
    [SerializeField] private Sprite icon;
    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] private int avaliableRange; //int[] avaliableRange;
    [SerializeField] private int moveSpeed;
    [SerializeField] private int movePriority;
    [SerializeField] private float statsMultiplier;
    [SerializeField] private EnemyAbility ability;
    [SerializeField] private GameObject model;
 
    public Sprite Icon => icon;
    public int Health => health;
    public int Damage => damage;
    public int AvaliableAttackRange => avaliableRange;
    public int MoveSpeed => moveSpeed;
    public int MovePriority => movePriority;
    public float StatsMultiplier => statsMultiplier;
    public EnemyAbility Ability => ability;
    public GameObject Model => model;
}
