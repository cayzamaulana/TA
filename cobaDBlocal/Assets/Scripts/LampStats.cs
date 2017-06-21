using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampStats : MonoBehaviour {

    public bool nyala;
    private SpriteRenderer lampu;

	// Use this for initialization
	void Start () {
        lampu = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (nyala)
        {
            lampu.color = Color.yellow;
        }
        else
        {
            lampu.color = Color.white;
        }
	}
}
