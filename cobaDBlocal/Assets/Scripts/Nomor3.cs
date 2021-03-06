﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class Nomor3 : MonoBehaviour {

	public Button submitBtn;

	public float StartTimes, t;
	public string minutes, seconds;

	public Text timerText;
	int scene;
	int min = 0;
	int max = 3;

	int min1 = 0;
	int max1 = 2;
	int[] number = new int [3] {0,1,2};
	int[] number1 = new int [2] {1,2};
	int[] number2 = new int [2] {0,2};
	int[] number3 = new int [2] {0,1};

	int score3;
	string user;
	string idsoal = "S3";
	string soal = "Soal_nomor_3";

    // Use this for initialization
    void Start()
	{
		int cekno3 = PlayerPrefs.GetInt ("scoreno3");
		Debug.Log(cekno3);
		Debug.Log(PlayerPrefs.GetString("username").ToString());
		StartTimes = 180;
		StartCoroutine(Postsoal(idsoal,soal));
		Button btn = submitBtn.GetComponent<Button>();
		btn.onClick.AddListener(Submit);
	}

    void Update()
    {
        t = StartTimes - Time.timeSinceLevelLoad;
        minutes = ((int)t / 60).ToString();
        seconds = (t%60).ToString("f0");

        timerText.text = minutes + " : " + seconds;

        if (t <= 0)
        {
            timerText.text = "Waktu Habis";
            timerText.color = Color.red;
            PlayerPrefs.SetInt("scoreno3", -5);
			int cekno1 = PlayerPrefs.GetInt ("scoreno1");
			int cekno2 = PlayerPrefs.GetInt ("scoreno2");
			int cekno0 = PlayerPrefs.GetInt ("scoreno0");
			int cekno3 = PlayerPrefs.GetInt ("scoreno3");

			score3 = PlayerPrefs.GetInt("scoreno3");
			Debug.Log (PlayerPrefs.GetInt ("scoreno3"));
			user = PlayerPrefs.GetString("username").ToString();
			//StartCoroutine(Postscore(user,idsoal, score3, 10f));

			string acak = scene.ToString();
			if (cekno1 != 0 && cekno2 != 0 && cekno0 != 0 && cekno3!= 0) {
				Application.LoadLevel ("pageSelesai");
			}
			else if (cekno3 != 0 && cekno1 == 0 && cekno0 == 0 && cekno2 == 0) {
				scene = number [UnityEngine.Random.Range (min, max)];
				acak = scene.ToString ();
				Debug.Log (acak);
				Application.LoadLevel (acak);
			} else if (cekno3 != 0 && cekno0 != 0 && cekno1 == 0 && cekno2 == 0) {
				scene = number1 [UnityEngine.Random.Range (min1, max1)];
				print (scene);
				acak = scene.ToString ();
				Debug.Log (acak);
				Application.LoadLevel (acak);
			} else if (cekno3 != 0 && cekno1 != 0 && cekno0 == 0 && cekno2 == 0) {
				scene = number2 [UnityEngine.Random.Range (min1, max1)];
				print (scene);
				acak = scene.ToString ();
				Debug.Log (acak);
				Application.LoadLevel (acak);
			} else if (cekno3 != 0 && cekno1 == 0 && cekno0 == 0 && cekno2 != 0) {
				scene = number3 [UnityEngine.Random.Range (min1, max1)];
				print (scene);
				acak = scene.ToString ();
				Debug.Log (acak);
				Application.LoadLevel (acak);
			} else if (cekno0 == 0 && cekno2 != 0 && cekno1 != 0 && cekno3 != 0 ) {
				Application.LoadLevel ("0");
			} else if (cekno0 != 0 && cekno2 != 0 && cekno1 == 0 && cekno3 != 0) {
				Application.LoadLevel ("1");
			} else if (cekno0 != 0 && cekno2 == 0 && cekno1 != 0 && cekno3 != 0) {
				Application.LoadLevel ("2");
			}
        }
    }


    // Update is called once per frame
    public void Submit()
    {
        int skorrumah = PlayerPrefs.GetInt("rumah3");
        int totalrumah = skorrumah;

        if (totalrumah == 1)
        {
            PlayerPrefs.SetInt("scoreno3", 25);
        }
        else
        {
            PlayerPrefs.SetInt("scoreno3", -5);
        }

        int cekno1 = PlayerPrefs.GetInt ("scoreno1");
		int cekno2 = PlayerPrefs.GetInt ("scoreno2");
		int cekno0 = PlayerPrefs.GetInt ("scoreno0");
		int cekno3 = PlayerPrefs.GetInt ("scoreno3");

		score3 = PlayerPrefs.GetInt("scoreno3");
		Debug.Log (PlayerPrefs.GetInt ("scoreno3"));
		user = PlayerPrefs.GetString("username").ToString();
		//StartCoroutine(Postscore(user,idsoal, score3, 40f));

		string acak = scene.ToString();
		if (cekno1 != 0 && cekno2 != 0 && cekno0 != 0 && cekno3!= 0) {
			Application.LoadLevel ("pageSelesai");
		}
		else if (cekno3 != 0 && cekno1 == 0 && cekno0 == 0 && cekno2 == 0) {
			scene = number [UnityEngine.Random.Range (min, max)];
			acak = scene.ToString ();
			Debug.Log (acak);
			Application.LoadLevel (acak);
		} else if (cekno3 != 0 && cekno0 != 0 && cekno1 == 0 && cekno2 == 0) {
			scene = number1 [UnityEngine.Random.Range (min1, max1)];
			print (scene);
			acak = scene.ToString ();
			Debug.Log (acak);
			Application.LoadLevel (acak);
		} else if (cekno3 != 0 && cekno1 != 0 && cekno0 == 0 && cekno2 == 0) {
			scene = number2 [UnityEngine.Random.Range (min1, max1)];
			print (scene);
			acak = scene.ToString ();
			Debug.Log (acak);
			Application.LoadLevel (acak);
		} else if (cekno3 != 0 && cekno1 == 0 && cekno0 == 0 && cekno2 != 0) {
			scene = number3 [UnityEngine.Random.Range (min1, max1)];
			print (scene);
			acak = scene.ToString ();
			Debug.Log (acak);
			Application.LoadLevel (acak);
		} else if (cekno0 == 0 && cekno2 != 0 && cekno1 != 0 && cekno3 != 0 ) {
			Application.LoadLevel ("0");
		} else if (cekno0 != 0 && cekno2 != 0 && cekno1 == 0 && cekno3 != 0) {
			Application.LoadLevel ("1");
		} else if (cekno0 != 0 && cekno2 == 0 && cekno1 != 0 && cekno3 != 0) {
			Application.LoadLevel ("2");
		}
	}

	IEnumerator Postscore(string user, string idsoal, int nilai3, float delay)
	{
		UnityWebRequest link = UnityWebRequest.Get ("http://somethingnotright.dx.am/masukinnilai.php?r_username=" + user + "&r_idsoal=" + idsoal + "&r_nilai=" + nilai3);
		yield return link.Send ();
        yield return new WaitForSeconds(delay);
        if (link.isError) {
			Debug.Log (link.error);
		}
	}

	IEnumerator Postsoal(string idsoal, string soal)
	{
		UnityWebRequest link = UnityWebRequest.Get ("http://somethingnotright.dx.am/masukinsoal.php?r_idsoal=" + idsoal + "&r_soal=" + soal);
		yield return link.Send ();
		if (link.isError) {
			Debug.Log (link.error);
		}
	}
}
