using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ImageLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int decider = UnityEngine.Random.Range(1, 10);
        string path = "Faces/Face" + decider + ".png";

        byte[] bytes = File.ReadAllBytes(path);

        Texture2D loadTexture = new Texture2D(1, 1); //mock size 1x1

        loadTexture.LoadImage(bytes);

        GetComponent<Renderer>().material.mainTexture = loadTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
