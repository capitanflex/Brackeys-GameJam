using System;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    public bool isCoin;
    public bool isApple;
    
    public bool isQuestStarted;
    public void Collect()
    {
        if (isCoin)
        {
            FindObjectOfType<CoinsQuest>().CollectCoin();
            Destroy(gameObject, 2);
        }
        if (isApple)
        {
            FindObjectOfType<AppleQuest>().CollectApple();
            Destroy(gameObject, 2);
        }
    }
}
