using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logout : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.DeleteAll();
		Application.LoadLevel ("pageHome");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
