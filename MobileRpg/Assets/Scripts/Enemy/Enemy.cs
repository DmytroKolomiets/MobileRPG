using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NaughtyAttributes;
using DG.Tweening;
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyPreset preset;
    public EnemyPreset Preset => preset;
    [SerializeField] private int currentHealth;
    [SerializeField] private Player target;
    public SnapPoint CurrentSnapPoint;
    public event Action OnDeath;
    public event Action OnEndAttack;
    public bool IsMoved = true;
    public event Action<string> OnDeatForQuest;
    [SerializeField] private HealthBar healthBar;


    private void Awake()
    {
        SetStartHealth();
    }
    //public void Interact(SnapPoint snapPoint) // Think alot. maybe be interface? how behaviorController will change interaction??
    //{
    //    Move(snapPoint);
    //    if (CurrentSnapPoint.Index.y == preset.AvaliableAttackRange)
    //    {
    //        Attack();
    //    }
    //    else
    //    {
    //        IsMoved = true;
    //        OnEndAttack.Invoke();
    //    }
    //}
    public void Move(SnapPoint positionToMove)
    {
        CurrentSnapPoint.IsFree = true;
        CurrentSnapPoint = positionToMove;
        transform.position = CurrentSnapPoint.Position;
        CurrentSnapPoint.IsFree = false;
    }
    [Button]
    public void Attack() // should be class
    {
        if (CurrentSnapPoint.Index.y != preset.AvaliableAttackRange)
        {
            StartCoroutine(Wait(() =>
            {
                IsMoved = true;
                OnEndAttack.Invoke();               
            }, 0.4f));
            return;
        }
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
        healthBar.ApplyDamge(damage);
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
        healthBar.SetHealth(currentHealth);
    }
    IEnumerator Wait(System.Action action, float time)
    {
        yield return new WaitForSeconds(time);
        action.Invoke();
    }
}
