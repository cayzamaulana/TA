using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopupMessage : MonoBehaviour {

    public Text message;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
