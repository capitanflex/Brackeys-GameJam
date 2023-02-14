using System;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    [SerializeField] private Phrase phrase;
    public void CompleteQuest()
    {
        phrase.questItem = true;
    }
}
