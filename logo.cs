using UnityEngine;
using System.Collections;

public class logo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(moveToNextScene());
	}

	private IEnumerator moveToNextScene()
	{
		yield return new WaitForSeconds (3f);
		Application.LoadLevel ("PlayVideo");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
