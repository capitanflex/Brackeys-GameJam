using System;
using UnityEngine;

public class RightDoor : MonoBehaviour
{
    public float rotationDegreesPerSecond = 45f;
    public float rotationDegreesAmount = 120f;
    private float totalRotation = 0;
    public bool needOpen;

    private void Update()
    {
        Rotation();
    }

    public void Rotation()
    { 
        if ((Mathf.Abs(totalRotation) < Mathf.Abs(rotationDegreesAmount) && needOpen))
        {
                float currentAngle = transform.rotation.eulerAngles.y;
                transform.rotation =
                    Quaternion.AngleAxis(currentAngle + (Time.deltaTime * -rotationDegreesPerSecond), Vector3.up);
                totalRotation += Time.deltaTime * rotationDegreesPerSecond;
               
        }
    }
}