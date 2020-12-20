using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System;

public class Combat : MonoBehaviour
{
    private bool isFight;
    [SerializeField] private Player player;
    [SerializeField] private List<Enemy> enemies = new List<Enemy>();
    public event Action OnNewTurn;
    [SerializeField] private EnemiesMover enemiesMover;
    // delite enemy fromList OnDeath / add on spawn (this scripts doesnt not ork with poolling)
    private void Start()
    {
        player.OnEndAttack += StartEnemiesAttack;
        player.StartAming();
    }
    [Button]
    public void StartFight()
    {
        if (!isFight)
        {
            player.Attack();
            foreach (var enemy in enemies)
            {
                enemy.IsMoved = false;
            }
            isFight = true;
        }
    }
    public void AddEnemy(Enemy enemy)
    {
        enemy.OnDeath += () => { enemies.Remove(enemy); };
        enemies.Add(enemy);
        enemy.OnEndAttack += CheckEndFight;
    }
    private void StartEnemiesAttack()
    {
        enemiesMover.MoveEnemies();
        if (enemies.Count == 0)
        {
            CheckEndFight();
            return;
        }
        foreach (var enemy in enemies)
        {
            enemy.Attack();
        }     
    }
    private void CheckEndFight()
    {
        foreach (var enemy in enemies)
        {
            if (!enemy.IsMoved) return;
        }
        isFight = false;
        OnNewTurn.Invoke();
        player.StartAming();
        
    }
}
