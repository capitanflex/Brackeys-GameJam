using UnityEngine;

public class CrownCompleted : MonoBehaviour
{
    private GameObject King;
    
    private void Start()
    {
        King = GameObject.FindGameObjectWithTag("King");
    }

    private void CompletedQuest()
    {
        King.GetComponent<Phrase>().questItem = true;
    }
}
