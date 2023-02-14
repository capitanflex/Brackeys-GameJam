using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    [SerializeField] private GameObject[] trackedObjects;
    private List<GameObject> radarObjects;
    [SerializeField] private GameObject radarPrefab; 
    private List<GameObject> borderObjects;

    [SerializeField] private float switchDistance; 
    [SerializeField] private Transform helpTransform; 

    void Start()
    {
     CreateRadarPoints();   
    }

    
    void Update()
    {
        for (int i = 0; i < radarObjects.Count; i++)
        {
            if (Vector3.Distance(radarObjects[i].transform.position,transform.position) > switchDistance)
            {
                helpTransform.LookAt(radarObjects[i].transform);
                borderObjects[i].transform.position = transform.position + switchDistance * helpTransform.forward;
                borderObjects[i].layer = LayerMask.NameToLayer("radar");
                radarObjects[i].layer = LayerMask.NameToLayer("invisible");
                
            }
            else
            {
                borderObjects[i].layer = LayerMask.NameToLayer("invisible");
                radarObjects[i].layer = LayerMask.NameToLayer("radar");

            }
        }
    }

    private void CreateRadarPoints()
    {
        radarObjects = new List<GameObject>();
        borderObjects = new List<GameObject>();
        foreach (GameObject obj in trackedObjects)
        {
            GameObject point = Instantiate(radarPrefab, obj.transform.position, Quaternion.identity);
            radarObjects.Add(point);
            GameObject borderObj = Instantiate(radarPrefab, obj.transform.position, Quaternion.identity);
            borderObjects.Add(borderObj);
        }
    }
}