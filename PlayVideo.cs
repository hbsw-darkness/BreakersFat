using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

//[RequireComponent(typeof(AudioSource))]

public class PlayVideo : MonoBehaviour {

//	public MovieTexture movie;
	//	private AudioSource audio;

	// Use this for initialization
//	void Start () {


//		GetComponent<RawImage>().texture = movie as MovieTexture;
		//		audio = GetComponent<AudioSource> ();
		//		audio.clip = movie.audioClip;
//		movie.Play ();
		//		audio.Play ();
//		StartCoroutine(play());
//	}


	// Update is called once per frame
//	void Update () {
//
//	}
//
//	IEnumerator play()
//	{
//				yield return new WaitForSeconds(5f);
////		movie.Play ();
////		iPhoneUtils.PlayMovie("Comp 1_3.mp4", Color.black);
//		Handheld.PlayFullScreenMovie("");
//	
//
//		yield return new WaitForSeconds(7f);
//		Application.LoadLevel ("StartScene");
//
//		}

	private string movPath = "Comp 1_3.mp4";

// Use this for initialization
void Start () {
	PlayStreamingVideo(movPath);
}

private void PlayStreamingVideo(string url)
{
	Handheld.PlayFullScreenMovie(url, Color.black, FullScreenMovieControlMode.Full, FullScreenMovieScalingMode.AspectFit);
	Debug.Log("Video playback completed.");
	Application.LoadLevel ("StartScene");
    }
	
}
