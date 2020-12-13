using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NaughtyAttributes;
using DG.Tweening;
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyPreset preset;
    [SerializeField] private int currentHealth;
    [SerializeField] private Player target;
    public SnapPoint CurrentSnapPoint;
    public event Action OnDeath;
    public event Action OnEndAttack;
    public bool IsMoved = true;
    public event Action<string> OnDeatForQuest;
    public int AttackRange { get; private set; }


    private void Awake()
    {
        SetStartHealth();
        AttackRange = preset.AvaliableAttackRange;
    }
    public void Move()
    {
        
    }
    [Button]
    public void Attack() // should be class
    {
        transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f).onComplete += () =>
        {
            transform.DOScale(Vector3.one, 0.2f).onComplete += () => 
            {
                target.TakeDamage(preset.Damage);
                IsMoved = true;
                OnEndAttack.Invoke();
            };
        };       
    }
    public void TakeDamage(int damage) // should be interface(player and enemy)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            CurrentSnapPoint.IsFree = true;
            OnDeath.Invoke();
            OnDeatForQuest.Invoke(preset.name);
            Destroy(gameObject);
        }
    }
    private void SetStartHealth()
    {
        currentHealth = preset.Health;
    }
}
