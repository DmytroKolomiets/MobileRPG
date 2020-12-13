using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Quest : MonoBehaviour
{
    [NaughtyAttributes.BoxGroup("KingQuest")]
    [SerializeField] private List<EnemyPreset> EnemiesForKingQuest = new List<EnemyPreset>();

    [NaughtyAttributes.BoxGroup("WinQuest")]
    [SerializeField] private List<EnemyPreset> EnemiesForWinQuest = new List<EnemyPreset>();

    private EnemyPreset currentEnemy;
    public void CheckQuests(string name)
    {
        ChecKingQuest(name);
        CheckWinQuest(name);
    }
    private void ChecKingQuest(string name)
    {
        
        if (EnemiesForKingQuest.Count == 0)
            return;
        currentEnemy = null;
        for (int i = 0; i < EnemiesForKingQuest.Count; i++)
        {
            if(EnemiesForKingQuest[i].name == name)
            {
                currentEnemy = EnemiesForKingQuest[i];
                break;
            }
        }
        if (!currentEnemy)
            return;
        EnemiesForKingQuest.Remove(currentEnemy);
        if (EnemiesForKingQuest.Count == 0)
        {
            Debug.Log("KING QUEST COMPLITE");
        }
    }
    private void CheckWinQuest(string name)
    {
        
        if (EnemiesForWinQuest.Count == 0)
            return;
        currentEnemy = null;
        for (int i = 0; i < EnemiesForWinQuest.Count; i++)
        {
            if (EnemiesForWinQuest[i].name == name)
            {
                currentEnemy = EnemiesForWinQuest[i];              
                break;
            }
        }
        if (!currentEnemy)
            return;
        EnemiesForWinQuest.Remove(currentEnemy);
        if (EnemiesForWinQuest.Count == 0)
        {
            Debug.Log("WIN QUEST COMPLITE");
        }
    }
}
