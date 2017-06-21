using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;


public class Selesai : MonoBehaviour {

    public Text nilai;
	public Button submitBtn;
	string user;


	// Use this for initialization
    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("username").ToString());
		int score0 = PlayerPrefs.GetInt("scoreno0");
		int score1 = PlayerPrefs.GetInt("scoreno1");
		int score2 = PlayerPrefs.GetInt("scoreno2");
        int score3 = PlayerPrefs.GetInt("scoreno3");
        user = PlayerPrefs.GetString("username").ToString();
		int total = score0 + score1 + score2 + score3;
		print(total);
		PlayerPrefs.SetInt("TampilNilai", total);
		StartCoroutine(Postscore(user, total));
        Debug.Log(PlayerPrefs.GetInt("TampilNilai"));
        string Nilai = PlayerPrefs.GetInt("TampilNilai").ToString();
        nilai.text = Nilai;
		Button btn = submitBtn.GetComponent<Button>();
		btn.onClick.AddListener(Submit);
    }

	public void Submit(){
		PlayerPrefs.DeleteAll();
		Application.LoadLevel ("pageHome");
	}

	IEnumerator Postscore(string user, int total)
	{
		UnityWebRequest link = UnityWebRequest.Get("http://somethingnotright.dx.am/selesai.php?r_username=" + user + "&r_nilai=" + total);
		yield return link.Send();
		if (link.isError)
		{
			Debug.Log(link.error);
		}
	}
    // Update is called once per frame
    void Update () {
		
	}
}
