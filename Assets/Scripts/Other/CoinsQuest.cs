using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsQuest : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questText;
    [SerializeField] private int coinsToCompleteQuest;

    
    
    private int coinsCount;
    

    public void StartQuest()
    {
        questText.gameObject.SetActive(true);
        questText.text = coinsCount.ToString();
        GetComponent<QuestItem>().isQuestStarted = true;

    }

    public void EndQuest()
    {
        questText.gameObject.SetActive(true);
        GetComponent<QuestItem>().isQuestStarted = false;
    }

    public void CollectCoin()
    {
        coinsCount += 1;
        if (coinsCount == coinsToCompleteQuest)
        {
            gameObject.GetComponent<DialogueTrigger>().questCompleted = true;
        }
    }
    
    
}
