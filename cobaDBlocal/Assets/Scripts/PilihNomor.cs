using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PilihNomor : MonoBehaviour {

	public Button submitBtn;

	int scene;
    int min = 0;
    int max = 3;

	// Use this for initialization
	void Start () {
        Debug.Log(PlayerPrefs.GetString("username").ToString());
        Button btn = submitBtn.GetComponent<Button>();
        btn.onClick.AddListener(Submit);
    }
	
	void Submit()
    {
        scene = Random.Range(min,max);
		string acak = scene.ToString();
		Application.LoadLevel(acak);
		Debug.Log(acak);
    }
}
