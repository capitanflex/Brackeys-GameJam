using System;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
   public Dialogue dialogue;

   public bool haveCoinsQuest;
   public bool haveAppleQuest;

   public bool questCompleted;
   public Dialogue dialogueAfterQuest;



   public void TriggerDialogue()
   {

      if (!questCompleted)
      {
         FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
         if (haveCoinsQuest)
         {
            FindObjectOfType<CoinsQuest>().StartQuest();
         }

         if (haveAppleQuest)
         {
            FindObjectOfType<AppleQuest>().StartQuest();
         }
      }
      else
      {
         FindObjectOfType<DialogueManager>().StartDialogue(dialogueAfterQuest);
         if (haveCoinsQuest)
         {
            FindObjectOfType<CoinsQuest>().EndQuest();
         }

         if (haveAppleQuest)
         {
            FindObjectOfType<AppleQuest>().StartQuest();
         }
      }

   }
}
