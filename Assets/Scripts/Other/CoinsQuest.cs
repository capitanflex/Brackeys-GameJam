using TMPro;
using UnityEngine;

public class CoinsQuest : MonoBehaviour
{

    [SerializeField] private DialogueTrigger _dialogueTrigger;

    
    public void CollectCoin()
    {
        if (_dialogueTrigger.questStarted)
        {
            _dialogueTrigger.ItemCollected();
        }
    }
    
    
}
