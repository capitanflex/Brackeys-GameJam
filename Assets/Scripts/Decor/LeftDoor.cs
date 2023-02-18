using UnityEngine;
using Mathf = UnityEngine.Mathf;
using MonoBehaviour = UnityEngine.MonoBehaviour;
using Quaternion = UnityEngine.Quaternion;
using Time = UnityEngine.Time;
using Vector3 = UnityEngine.Vector3;

public class LeftDoor : MonoBehaviour
{
    public float rotationDegreesPerSecond = 45f;
    public float rotationDegreesAmount = 120f;
    private float totalRotation = 0;
    
    public void Rotation()
    {
        if (Mathf.Abs(totalRotation) < Mathf.Abs(rotationDegreesAmount))
        {
            float currentAngle = transform.rotation.eulerAngles.y;
            transform.rotation =
                Quaternion.AngleAxis(currentAngle + (Time.deltaTime * rotationDegreesPerSecond), Vector3.up);
            totalRotation += Time.deltaTime * rotationDegreesPerSecond;
        }
    }
}