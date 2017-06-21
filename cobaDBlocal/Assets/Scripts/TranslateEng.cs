using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TranslateEng : MonoBehaviour {

    public Button transBtn2;

    // Use this for initialization
    void Start () {
        Button btn = transBtn2.GetComponent<Button>();
        btn.onClick.AddListener(onEnglishClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void onEnglishClick()
    {
        OneClickLocalization.OCL.SetLanguage(SystemLanguage.English);
    }
}
