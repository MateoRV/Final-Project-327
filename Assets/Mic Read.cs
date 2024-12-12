using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MicRead : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public float loudnessSensibility = 1f;
    public float loudThreshold = .1f;
    public LoudnessDetect detector;
    public Lookaway lookaway;

    float elapsedTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;
        //Debug.Log ("Loudness = " + loudness);
        if (loudness > loudThreshold)
        {
            lookaway.disableLookaway(true);
            lookaway.lookAtPlayer();
            source.clip = clip;
            if (!source.isPlaying || source.time > 7)
            {
                source.Play();
            }
            StartCoroutine(StartTimer());
        }
        //lookaway.disableLookaway(false);
    }
    //Look at the player for 5 seconds and trigger the sound effect
    private IEnumerator StartTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(6);
            lookaway.disableLookaway(false);
            yield break;
        }
    }
}
