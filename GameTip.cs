using UnityEngine;
using System.Collections;

public class GameTip : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.SetResolution(800, 480, true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			Application.LoadLevel ("StartScene2");
		}
	}
}
