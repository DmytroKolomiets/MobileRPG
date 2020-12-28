using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using NaughtyAttributes;
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private TextMeshProUGUI damageTakenText;
    [SerializeField] private TextMeshProUGUI currentHealthText;
    [SerializeField] private Image healthImage;
    [SerializeField] private Vector3 startDamageTakenTextPosition;
    private Queue<TextMeshProUGUI> textPool = new Queue<TextMeshProUGUI>();
    private int startHealth;
    private int currentHealth;
    public bool lookatcamerea;

    public void SetHealth(int startHealth)
    {
        this.startHealth = startHealth;
        currentHealth = startHealth;        
        currentHealthText.text = currentHealth.ToString();
    }
    
    public void ApplyDamge(int damage)
    {
        currentHealth -= damage;
        currentHealthText.text = currentHealth.ToString();
        Debug.Log(((float)damage / startHealth));
        healthImage.fillAmount -= ((float)damage / startHealth);
        ShowAppliedDamge(damage);
    }
    private void ShowAppliedDamge(int damge)
    {
        var text = GetTextFromPool();
        text.text = "-" + damge.ToString();
        text.transform.position = startDamageTakenTextPosition;
        text.gameObject.SetActive(true);
        text.transform.DOLocalMoveY(3, 1).onComplete += () =>
        {
            SetToTextToPool(text);
        };
    }
    private TextMeshProUGUI GetTextFromPool()
    {
        if(textPool.Count > 0)
        {
            return textPool.Dequeue();
        }
        else
        {
           return Instantiate(damageTakenText, transform);
        }
    }
    private void SetToTextToPool(TextMeshProUGUI text)
    {
        text.gameObject.SetActive(false);
        textPool.Enqueue(text);
    }
    void LateUpdate()
    {
        if (!lookatcamerea)
            return;
        transform.LookAt(cam.transform);
        transform.Rotate(0, 180, 0);
    }
    [Button]
    private void TestInit()
    {
        SetHealth(140);
    }
    [Button]
    private void Test()
    {
        ApplyDamge(5);
    }
}
