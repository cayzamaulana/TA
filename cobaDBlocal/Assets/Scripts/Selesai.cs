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
    string idsoal = "S0";
    string idsoal1 = "S1";
    string idsoal2 = "S2";
    string idsoal3 = "S3";

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
        int nilai0 = score0;
        int nilai1 = score1;
        int nilai2 = score2;
        int nilai3 = score3;
        PlayerPrefs.SetInt("TampilNilai", total);
		StartCoroutine(Postscore(user, idsoal, idsoal1, idsoal2, idsoal3, nilai0, nilai1, nilai2, nilai3, total));
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

	IEnumerator Postscore(string user, string idsoal, string idsoal1, string idsoal2, string idsoal3, int nilai0, int nilai1, int nilai2, int nilai3, int total)
	{
		UnityWebRequest link = UnityWebRequest.Get("http://somethingnotright.dx.am/masukinnilai.php?r_username=" + user + "&r_idsoal=" + idsoal + "&r_idsoal1=" + idsoal1 + "&r_idsoal2=" + idsoal2  + "&r_idsoal3=" + idsoal3 + "&r_nilai=" + nilai0 + "&r_nilai1=" + nilai1 + "&r_nilai2=" + nilai2 + "&r_nilai3=" + nilai3 + "&r_total=" + total);
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
