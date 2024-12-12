using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class VisionAngleVector : MonoBehaviour
{
    public Transform target;
    [Range(1, 180)]
    public float triggerAngle;
    void Start()
    {
        
    }

    void Update()
    {
        // prints "close" if the z-axis of this transform looks
        // almost towards the target
        Vector3 targetDir = target.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);

        if (angle < triggerAngle)
            print("Close");
    }
}
