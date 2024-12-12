using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InCameraDetector : MonoBehaviour
{
    Camera camera;
    MeshRenderer renderer;
    Plane[] cameraFrustum;
    Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        renderer = GetComponent<MeshRenderer>(); //This gets the mesh renderer of the cube we attatched this to
        collider = GetComponent<Collider>();  //This will get the collider of the current object
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(camera); //This returns an array of planes to represent the camera frustum (cone)
        /*for (int i = 0; i < 6; ++i)
        {
            GameObject p = GameObject.CreatePrimitive(PrimitiveType.Plane);
            p.name = "Plane " + i.ToString();
            p.transform.position = -cameraFrustum[i].normal * cameraFrustum[i].distance;
            p.transform.rotation = Quaternion.FromToRotation(Vector3.up, cameraFrustum[i].normal);
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        var bounds = collider.bounds; //The boundaries of the collider must be updated in update since it is calculated and not a reference
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(camera); //This returns an array of planes to represent the camera frustum (cone)
        if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds)) //Takes a series of planes and also a series of collider boundaries to see if the AABB are within the frustum
        {
            renderer.sharedMaterial.color = Color.green;
        }
        else
        {
            renderer.sharedMaterial.color = Color.red;
        }
    }
}
