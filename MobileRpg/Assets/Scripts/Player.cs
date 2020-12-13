using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int health;
    public event Action OnDeath;
    public event Action OnEndAttack;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Text hp;
    private void Start()
    {
        hp.text = health.ToString();
    }
    [Button]
    public void Attack()
    {
        weapon.Attack();
        StartCoroutine(HideWeapon());
    }
    [Button]
    public void StartAming()
    {
        weapon.StartAiming();
    }
    public void ChangeWeapon(Weapon weapon)
    {
        if (this.weapon == weapon) return;
        this.weapon.Hide();
        this.weapon = weapon;
        weapon.StartAiming();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;     
        if (health <= 0)
        {
            OnDeath?.Invoke();
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene);
        }
        hp.text = health.ToString();
    }  
    IEnumerator HideWeapon()
    {
        yield return new WaitForSeconds(0.2f);
        weapon.Hide();
        OnEndAttack?.Invoke();
    }
}
