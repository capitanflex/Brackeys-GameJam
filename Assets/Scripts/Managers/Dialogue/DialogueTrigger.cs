using TMPro;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI questText;
   [SerializeField] private QuestItem[] _QuestItems;
   [SerializeField] private OpenDoors _openDoors;
   public int itemsCount;
   public int itemsToCompleteQuest;

   public bool CoinQuest;
   public bool AppleQuest;

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
      
      itemsCount += 1;
      questText.text = itemsCount.ToString();
      if (itemsToCompleteQuest <= itemsCount && CoinQuest)
      {
         print("+apple");
         questCompleted = true;
         _openDoors.a = true;
      }

      if (itemsToCompleteQuest <= itemsCount && AppleQuest)
      {
         questCompleted = true;
         _dialogueManager.isLastDialogue = true;
      }
   }

   public void TriggerDialogue()
   {
      
      if (!questCompleted)
      {
         questStarted = true;
         print("quest started");
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
