﻿using UnityEngine;
using System.Collections;

public class startBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Application.LoadLevel(1);
        }

    }
}
