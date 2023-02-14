using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    private QuestItem _questItem;
    private float _distance = 2;
    [SerializeField] private GameObject rayPosition;
    [SerializeField] private LayerMask questMask;
    [SerializeField] private TextMeshProUGUI indicatorInteraction;
    private string phrase;
    

    private void FixedUpdate()
    {
        InterationWith();
    }

    private void InterationWith()
    {
        RaycastHit hit;
        if (Physics.Raycast(rayPosition.transform.position, rayPosition.transform.forward, out hit, _distance, questMask))
        {
            if (Input.GetKeyDown(KeyCode.E) && (hit.collider.CompareTag("QuestNPC")))
            {
                ItemQuest(hit.collider.GetComponent<Phrase>());
                print(phrase);
            }
            if (Input.GetKeyDown(KeyCode.E) && (hit.collider.CompareTag("QuestItem")))
            {
                hit.collider.GetComponent<QuestItem>().CompleteQuest();
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
        if(a.GetComponent<Phrase>().questItem)
        {
            phrase = a.GetComponent<Phrase>().sentences[0];
        }
        else{
            phrase = a.GetComponent<Phrase>().sentences[1];
        };
        return phrase;
    }
}
