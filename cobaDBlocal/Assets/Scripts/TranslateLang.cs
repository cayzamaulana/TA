using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TranslateLang : MonoBehaviour {

    public Button transBtn;

	// Use this for initialization
	void Start () {
        Button btn = transBtn.GetComponent<Button>();
        btn.onClick.AddListener(onIndonesianClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void onIndonesianClick()
    {
        OneClickLocalization.OCL.SetLanguage(SystemLanguage.Indonesian);
    }
}
