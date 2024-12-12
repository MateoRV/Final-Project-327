using UnityEngine;
using System.IO;

public class ImageProcessor : MonoBehaviour
{
    private void Start()
    {

        // Start is called before the first frame update

        void Start()

        {

            // Load image

            string path = "Face1.png";

            byte[] bytes = File.ReadAllBytes(path);

            Texture2D loadTexture = new Texture2D(1, 1); //mock size 1x1

            loadTexture.LoadImage(bytes);

            GetComponent<Renderer>().material.mainTexture = loadTexture;
        }
    }
}




   /* Texture2D texture;
    // Start is called before the first frame update

    void Start()

    {

        // Load image

        string path = "BowserJr.png";
        //Bytes is my array of pixels. 4 bytes per pixel. RGB and A
        byte[] pixels = File.ReadAllBytes(path);

        texture = GetComponent<Renderer>().material.mainTexture as Texture2D;

        //transform.localScale = new Vector3(texture.width, texture.height, 1);

        for (int row = 0; row < texture.height; row++)
        {
            int rowOffset = texture.width * row * 4;
            for (int col = 0; col < texture.width; col++)
            {
                int pixelIndex = rowOffset + col * 4;

                pixels[pixelIndex] = (byte)(byte.MaxValue - pixels[pixelIndex]);
                pixels[pixelIndex + 1] = (byte)(byte.MaxValue - pixels[pixelIndex + 1]);
                pixels[pixelIndex + 2] = (byte)(byte.MaxValue - pixels[pixelIndex + 2]);
            }
        }

        Texture2D loadTexture = new Texture2D(1, 1); //mock size 1x1

        //Takes the pixels and loads it onto texture2D as image
        loadTexture.LoadImage(pixels);


        // Get the component this is attatched to and put the image as its mask.
        GetComponent<Renderer>().material.mainTexture = loadTexture;

        //Texture2D texture = GetComponent<Renderer>().material.mainTexture as Texture2D;


        *//*texture.LoadRawTextureData(pixels);
        texture.Apply();*//*

        //palette = GameObject.CreatePrimitive(PrimitiveType.Plane);




    }*/



