using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class CameraControlMouse : MonoBehaviour
{
    public float sensitivity = 15;
    //public LayerMask mask;

    float xRotation = 0f;
    float yRotation = 0f;

    public Transform orientation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        //Old: xRotation -= Input.GetAxis("Mouse Y") * sensitivity;
        //Sensitivity would be around 5
        xRotation -= Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;
        yRotation += Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);             // to stop the player from looking above/below 90

        transform.localEulerAngles = new Vector3(xRotation, yRotation, 0);
        orientation.localEulerAngles = new Vector3(0, yRotation, 0);
        

       /* if (Physics.Raycast(transform.position, transform.forward, out var hit, Mathf.Infinity, mask))
        {
            var obj = hit.collider.gameObject;

            Debug.Log($"looking at {obj.name}", this);
        }*/
    }
}
