using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamBamBam : MonoBehaviour
{
    public float rotationDegreesPerSecond;
    public float rotationDegreesAmount = 99999999f;
    private float currDegrees = 0;

    private void Update()
    {
        // float currentAngle = transform.rotation.eulerAngles.x;
        if (currDegrees < 0.4)
        {
            currDegrees += rotationDegreesPerSecond * Time.deltaTime;
        }

        transform.Rotate(currDegrees,0,0);
    }
}
