using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AppleQuest : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questText;
    [SerializeField] private int appleToCompleteQuest;
    public bool isQuestStarted;
    
    private int appleCount;

    public void StartQuest()
    {
        isQuestStarted = true;
        questText.gameObject.SetActive(true);
        questText.color = Color.red;

    }

    public void CollectApple()
    {
        if (appleCount == appleToCompleteQuest)
        {
            
        }
    }
}
