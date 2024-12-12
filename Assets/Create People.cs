using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePeople : MonoBehaviour
{
    public int numberOfPeople = 5;
    //public GameObject personPrefab;
    public GameObject person;

    public GameObject floor;

    float xBoundary;
    float zBoundary;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate the floor boundaries 
        Renderer planeRenderer = floor.transform.GetComponent<Renderer>();
        Bounds floorBounds = planeRenderer.bounds;
        xBoundary = floorBounds.max.x;
        zBoundary = floorBounds.max.z;
        for (int i = 0; i < numberOfPeople; i++)
        {
            //Create a person
            person = GameObject.Instantiate(GameObject.Find("Person 1"));
            //Randomize its location
            float xPos = Random.Range(-xBoundary + 2, xBoundary -2);
            float zPos = Random.Range(-zBoundary + 2, zBoundary - 2);
            person.transform.position = new Vector3(xPos, .7f, zPos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
