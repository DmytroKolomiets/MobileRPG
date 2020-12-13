using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponChanger : MonoBehaviour
{
    [SerializeField] private Weapon meele;
    [SerializeField] private Weapon middle;
    [SerializeField] private Weapon ranged;
    [SerializeField] private Player player;

    [SerializeField] private Button meeleButton;
    [SerializeField] private Button middleButton;
    [SerializeField] private Button rangedButton;

    private void Start()
    {
        meeleButton.onClick.AddListener(() => player.ChangeWeapon(meele));
        middleButton.onClick.AddListener(() => player.ChangeWeapon(middle));
        rangedButton.onClick.AddListener(() => player.ChangeWeapon(ranged));
    }

}
