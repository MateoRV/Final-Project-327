using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource; //reference to a transform where the Ray will be casted from
    public float InteractRange = 10000; //The length of the raycast
    public MeshRenderer renderer; //I end up assigning the capsule directly to this
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward); //A Ray stores 2 vector 3s: Origin and direction
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))    //These two lines are the raycast
        {
            //renderer = hitInfo.collider.GetComponent<MeshRenderer>();
            renderer.sharedMaterial.color = Color.green;
        }
        else
        {
            renderer.sharedMaterial.color = Color.cyan;
        }
    }
}
