using System;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    [SerializeField] private Transform Leftdoor;
    [SerializeField] private Transform Rightdoor;
    public bool a;


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && a)
        {
            Leftdoor.GetComponent<LeftDoor>().needOpen = true;
            Rightdoor.GetComponent<RightDoor>().needOpen = true;
        }
    }
}