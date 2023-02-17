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
    
    

    private void Update()
    {
        InterationWith();
        DropItem();
    }

    private void InterationWith()
    {
        RaycastHit hit;
        if (Physics.Raycast(rayPosition.transform.position, rayPosition.transform.forward, out hit, _distance, questMask))
        {
            if (Input.GetKeyDown(KeyCode.E) && (hit.collider.CompareTag("QuestNPC")) )
            {
                ItemQuest(hit.collider.GetComponent<Phrase>());
                print(phrase);
                
            }
            if (Input.GetKeyDown(KeyCode.E) && (hit.collider.CompareTag("QuestItem")) )
            {
                hit.collider.GetComponent<QuestItem>().CompleteQuest();

                TakeItem(hit.collider.gameObject);
                
            }
            indicatorInteraction.gameObject.SetActive(true); 
        }
        else
        {
            indicatorInteraction.gameObject.SetActive(false);
        }
    }

    private string ItemQuest(Component a)
    {
        if(a.GetComponent<Phrase>().questItem && pickedUpItem != null)
        {
            phrase = a.GetComponent<Phrase>().sentences[0];
            DeleteItem();
        }
        else{
            phrase = a.GetComponent<Phrase>().sentences[1];
        };
        return phrase;
    }

    private void TakeItem(GameObject hit)
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
