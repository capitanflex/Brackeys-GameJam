using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    private QuestItem _questItem;
    private float _distance = 2;
    private string phrase;

    private GameObject pickedUpItem;
    
    [SerializeField] private GameObject rayPosition;
    [SerializeField] private LayerMask questMask;
    [SerializeField] private TextMeshProUGUI indicatorInteraction;
    
    [SerializeField] private GameObject transformForItem;

    public bool canMove = true;
    

    private GameManager _gameManager;
    private DialogueManager _dialogueManager;

    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void Update()
    {
        InterationWith();
        DropItem();
    }

    private void InterationWith()
    {
        RaycastHit hit;
        if (Physics.Raycast(rayPosition.transform.position, rayPosition.transform.forward, out hit, _distance, questMask) && canMove)
        {
            if (Input.GetKeyDown(KeyCode.E) && (hit.collider.CompareTag("QuestNPC")) )
            {
                var dialogue = hit.collider.GetComponent<DialogueTrigger>();
                dialogue.TriggerDialogue();
                _gameManager.CanMove(false);

            }
            if (Input.GetKeyDown(KeyCode.E) && (hit.collider.CompareTag("QuestItem")) )
            {
                hit.collider.GetComponent<QuestItem>().Collect();

                TakeItem(hit.collider.gameObject);
                
            }
            indicatorInteraction.gameObject.SetActive(true); 
        }
        else
        {
            indicatorInteraction.gameObject.SetActive(false);
            if (Input.GetKeyDown(KeyCode.E))
            {
                _dialogueManager.DisplayNextSentence();
            }
        }
    }
    

    private void TakeItem(GameObject hit)
    {
        if (hit.gameObject.GetComponent<QuestItem>().isQuestStarted = true)
        {
            pickedUpItem = hit.gameObject;

            Transform pointTransform;
            pointTransform = transformForItem.GetComponent<Transform>();
        
        
            hit.transform.parent = transformForItem.transform;
            hit.transform.position = pointTransform.position;
            hit.transform.rotation = pointTransform.rotation;

            hit.GetComponent<Rigidbody>().isKinematic = true;
            hit.GetComponent<Collider>().enabled = false;
            
        }

    }

    private void DropItem()
    {
        if (Input.GetKeyDown(KeyCode.G ) && pickedUpItem != null)
        {
            pickedUpItem.GetComponent<Rigidbody>().isKinematic = false;
            pickedUpItem.GetComponent<Collider>().enabled = true;
            
            pickedUpItem.transform.parent = null;
            pickedUpItem = null;
            
            

        }
    }
    
    private void DeleteItem()
    {
        Destroy(transformForItem.GetComponentInChildren<Collider>().gameObject);
        pickedUpItem = null;
    }
}
