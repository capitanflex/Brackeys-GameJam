using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    [SerializeField] private Transform Leftdoor;
    [SerializeField] private Transform Rightdoor;
    
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Leftdoor.GetComponent<LeftDoor>().Rotation();
            Rightdoor.GetComponent<RightDoor>().Rotation();
        }
    }
}