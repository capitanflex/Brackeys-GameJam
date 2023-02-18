using System;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    public bool isCoin;
    public bool isApple;
    [SerializeField] private DialogueTrigger _dialogueTrigger;
    public bool isQuestStarted;
    public void Collect()
    {
        if (_dialogueTrigger.questStarted)
        {
            if (isCoin)
            {
                _dialogueTrigger.ItemCollected();
                Destroy(gameObject, 2);
            }
            if (isApple)
            {
                _dialogueTrigger.ItemCollected();
                Destroy(gameObject, 2);
            }
        }
    }
}
