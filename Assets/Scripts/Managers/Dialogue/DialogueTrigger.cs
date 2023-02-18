using TMPro;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI questText;
   [SerializeField] private QuestItem[] _QuestItems;
   [SerializeField] private OpenDoors _openDoors;
   public int itemsCount;
   public int itemsToCompleteQuest;

 

   public bool questCompleted;
   public bool questStarted;
   
   private DialogueManager _dialogueManager;

   
   public Dialogue dialogue;
   public Dialogue dialogueAfterQuest;
  

   private void Start()
   {
      _dialogueManager = FindObjectOfType<DialogueManager>();
      questText.text = itemsCount.ToString();
   }

   public void ItemCollected()
   {
      print("+apple");
      itemsCount += 1;
      questText.text = itemsCount.ToString();
      if (itemsToCompleteQuest <= itemsCount)
      {
         questCompleted = true;
         _openDoors.a = true;
      }
   }

   public void TriggerDialogue()
   {
      
      if (!questCompleted)
      {
         questStarted = true;
         _dialogueManager.StartDialogue(dialogue);
        questText.gameObject.SetActive(true);
        questText.text = "0";

        foreach (var VARIABLE in _QuestItems)
        {
           print("bebra");
           VARIABLE.isQuestStarted = true;
        }
      }
      else
      {
         _dialogueManager.StartDialogue(dialogueAfterQuest);
        
      }

   }
}
