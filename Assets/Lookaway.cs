using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using static UnityEngine.GraphicsBuffer;

/// <summary>
/// Uses code from LiamAcademy: "Make ANY Object Smoothly Turn Or Look At Another Object"
/// </summary>
public class Lookaway : MonoBehaviour
{
    public Camera camera;
    public Transform cameraHolder;
    [Range(1, 180)]
    public float triggerAngle;
    public float awaySpeed;
    [Range (1, 500)]
    public float towardSpeed;

    bool lookingAt;
    bool disabled = false;
    int decider = 0;
    float rotateDirection = 90;
    float counter = 0;

    //private Coroutine LookCoroutine;

    Vector3 dummyVector = new Vector3(10f, 0, 0);
    Quaternion targetRotation;

    void Start()
    {
        //All bodies will look either left or right to look away
        decider = UnityEngine.Random.Range(0, 2);
        towardSpeed = 360;
        awaySpeed = 5;
    }

    void Update()
    {
        Vector3 targetDir = transform.position - camera.transform.position;
        float angle = Vector3.Angle(targetDir, camera.transform.forward);
        
        //if the user makes a loud enough noise, look at the player for 5 seconds

        //If the camera is within the trigger viewing angle, we will make the object face the player
        //NEXT STEP: Instead of looking at an arbitrary point, it will randomize a certain angle away from the player (-90 or 90) and smoothly animate to that position using time.delta time
        if (angle < triggerAngle)
        {
            if (disabled)
            {

            }
            else
            {
                if (!lookingAt)
                {
                    counter = 0;
                    decider = UnityEngine.Random.Range(0, 2);
                    if (decider == 0)
                    {
                        rotateDirection = 90;
                    }
                    if (decider == 1)
                    {
                        rotateDirection = -90;
                    }
                }
                float rotate = rotateDirection * Time.deltaTime * awaySpeed;
                counter = counter + rotate;

                //Smoothly look away and stop once we reach 90 degrees
                if (counter < 90 && decider == 0)
                {
                    targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + rotate, transform.eulerAngles.z);
                }
                if (counter > -90 && decider == 1)
                {
                    targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + rotate, transform.eulerAngles.z);
                }

                lookingAt = true;
                transform.rotation = targetRotation;
            }
            //If we looked away and are now looking back, we randomize if the person looks left or right when looking away
            
        }

        else
        {
            lookingAt = false;
            counter = 0;
            lookAtPlayer();
            //LookAtPlayer();

            //transform.LookAt(camera.transform.position);
            //Debug.Log("toRotation is " +  toRotation + "And direction is " + direction);
            //Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
            //targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + 1, transform.eulerAngles.z);
            //transform.rotation = targetRotation;
        }
    }

    public void lookAtPlayer()
    {
        var direction = (camera.transform.position - transform.position);
        var toRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, towardSpeed * Time.deltaTime);
    }

    public void disableLookaway(bool b)
    {
        if (b)
        {
            disabled = true;
        }
        else
        {
            disabled = false;
        }
        
    }

}
