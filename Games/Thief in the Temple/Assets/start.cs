using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour {

    public string level = "";

    public loadGame load;

    // Use this for initialization
    public void Play()
    {
        load.FadeTo(level);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
