using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class testMove : MonoBehaviour
{
    public MovieTexture movie;
    //private AudioSource audio;
    void Start()
    {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        //audio = GetComponent<AudioSource>();
        //audio.clip = movie.audioClip;
        movie.Play();
        //audio.Play();
        StartCoroutine(play());
    }

    IEnumerator play()
    {
        yield return new WaitForSeconds(0.1f);
        movie.Play();
        Handheld.PlayFullScreenMovie("Comp 1_3.mp4", Color.black);
        //Handheld.PlayFullScreenMovie("");
    }
}
