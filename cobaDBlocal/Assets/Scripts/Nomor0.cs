using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Nomor0 : MonoBehaviour {

	public Button submitBtn;

	public float StartTimes, t;
	public string minutes, seconds;

	public Text timerText;
	int scene;
	int min = 0;
	int max = 3;

	int min1 = 0;
	int max1 = 2;
	int[] number = new int [3] {1,2,3};
	int[] number1 = new int [2] {2,3};
	int[] number2 = new int [2] {1,3};
	int[] number3 = new int [2] {1,2};

	int score0;
	string user;
	string idsoal = "S0";
	string soal = "Soal_nomor_0";

	// Use this for initialization
	void Start()
	{
		int cekno0 = PlayerPrefs.GetInt ("scoreno0");
		Debug.Log(cekno0);
		Debug.Log (PlayerPrefs.GetString ("username").ToString ());
		StartTimes = 180;
		StartCoroutine (Postsoal (idsoal, soal));
		Button btn = submitBtn.GetComponent<Button> ();
		btn.onClick.AddListener (Submit);
	}


	public void Update()
	{
		t = StartTimes - Time.timeSinceLevelLoad;
		minutes = ((int)t / 60).ToString();
		seconds = (t % 60).ToString("f0");

		timerText.text = minutes + " : " + seconds;

		if (t <= 0)
		{
			timerText.text = "Waktu Habis";
			timerText.color = Color.red;
			PlayerPrefs.SetInt ("scoreno0", -5);

			int cekno1 = PlayerPrefs.GetInt ("scoreno1");
			int cekno2 = PlayerPrefs.GetInt ("scoreno2");
			int cekno0 = PlayerPrefs.GetInt ("scoreno0");
			int cekno3 = PlayerPrefs.GetInt ("scoreno3");

			score0 = PlayerPrefs.GetInt("scoreno0");
			Debug.Log (PlayerPrefs.GetInt ("scoreno0"));
			user = PlayerPrefs.GetString("username").ToString();
			//StartCoroutine(Postscore(user,idsoal, score0, 10f));
			string acak = scene.ToString();
			if (cekno1 != 0 && cekno2 != 0 && cekno0 != 0 && cekno3 != 0) {
				Application.LoadLevel ("pageSelesai");
			} else if (cekno0 != 0 && cekno2 == 0 && cekno1 == 0 && cekno3 == 0) {
				scene = number [UnityEngine.Random.Range (min, max)];
				print (scene);
				acak = scene.ToString ();
				Debug.Log (acak);
				Application.LoadLevel (acak);

			} else if (cekno0 != 0 && cekno2 == 0 && cekno1 != 0 && cekno3 == 0) {
				scene = number1 [UnityEngine.Random.Range (min1, max1)];
				print (scene);
				acak = scene.ToString ();
				Debug.Log (acak);
				Application.LoadLevel (acak);
			} else if (cekno0 != 0 && cekno2 != 0 && cekno1 == 0 && cekno3 == 0) {
				scene = number2 [UnityEngine.Random.Range (min1, max1)];
				print (scene);
				acak = scene.ToString ();
				Debug.Log (acak);
				Application.LoadLevel (acak);
			} else if (cekno0 != 0 && cekno2 == 0 && cekno1 == 0 && cekno3 != 0) {
				scene = number3 [UnityEngine.Random.Range (min1, max1)];
				print (scene);
				acak = scene.ToString ();
				Debug.Log (acak);
				Application.LoadLevel (acak);
			} else if (cekno0 != 0 && cekno2 != 0 && cekno1 == 0 && cekno3 != 0 ) {
				Application.LoadLevel ("1");
			} else if (cekno0 != 0 && cekno2 == 0 && cekno1 != 0 && cekno3 != 0) {
				Application.LoadLevel ("2");
			} else if (cekno0 != 0 && cekno2 != 0 && cekno1 != 0 && cekno3 == 0) {
				Application.LoadLevel ("3");
			}
		}
	}

	public void Submit()
	{
        int scoree1 = PlayerPrefs.GetInt("jalan1");
        int scoree2 = PlayerPrefs.GetInt("jalan2");
        int scoree3 = PlayerPrefs.GetInt("jalan3");
        int scoree4 = PlayerPrefs.GetInt("jalan4");
        int scoree5 = PlayerPrefs.GetInt("jalan5");
        int scoree6 = PlayerPrefs.GetInt("jalan6");
        int scoree7 = PlayerPrefs.GetInt("jalan7");
        int scoree8 = PlayerPrefs.GetInt("jalan8");
        int scoree9 = PlayerPrefs.GetInt("jalan9");
        int scoree10 = PlayerPrefs.GetInt("jalan10");
        int scoree11 = PlayerPrefs.GetInt("jalan11");
        int scoree12 = PlayerPrefs.GetInt("jalan12");
        int scoree13 = PlayerPrefs.GetInt("jalan13");
        int scoree14 = PlayerPrefs.GetInt("jalan14");
        int scoree15 = PlayerPrefs.GetInt("jalan15");
        int scoree16 = PlayerPrefs.GetInt("jalan16");
        int scoree17 = PlayerPrefs.GetInt("jalan17");
        int scoree18 = PlayerPrefs.GetInt("jalan18");
        int scoree19 = PlayerPrefs.GetInt("jalan19");
        int scoree20 = PlayerPrefs.GetInt("jalan20");
        int scoree21 = PlayerPrefs.GetInt("jalan21");
        int scoree22 = PlayerPrefs.GetInt("jalan22");
        int scoree23 = PlayerPrefs.GetInt("jalan23");
        int scoree24 = PlayerPrefs.GetInt("jalan24");
        int scoree25 = PlayerPrefs.GetInt("jalan25");
        int scoree26 = PlayerPrefs.GetInt("jalan26");
        int scoree27 = PlayerPrefs.GetInt("jalan27");

        int total = scoree1 + scoree2 + scoree3 + scoree4 + scoree5 + scoree6 + scoree7 + scoree8 + scoree9 + scoree10 +
            scoree11 + scoree12 + scoree13 + scoree14 + scoree15 + scoree16 + scoree17 + scoree18 + scoree19 + scoree20 +
            scoree21 + scoree22 + scoree23 + scoree24 + scoree25 + scoree26 + scoree27;
        print(total);
        if (total == 11)
        {
            PlayerPrefs.SetInt("scoreno0", 25);
        }
        else
        {
            PlayerPrefs.SetInt("scoreno0", -5);
        }
        int cekno1 = PlayerPrefs.GetInt ("scoreno1");
		int cekno2 = PlayerPrefs.GetInt ("scoreno2");
		int cekno0 = PlayerPrefs.GetInt ("scoreno0");
		int cekno3 = PlayerPrefs.GetInt ("scoreno3");

		score0 = PlayerPrefs.GetInt("scoreno0");
		Debug.Log (PlayerPrefs.GetInt ("scoreno0"));
		user = PlayerPrefs.GetString("username").ToString();
		//StartCoroutine(Postscore(user, idsoal, score0, 40f));
		string acak = scene.ToString();
		if (cekno1 != 0 && cekno2 != 0 && cekno0 != 0 && cekno3 != 0) {
			Application.LoadLevel ("pageSelesai");
		} else if (cekno0 != 0 && cekno2 == 0 && cekno1 == 0 && cekno3 == 0) {
			scene = number [UnityEngine.Random.Range (min, max)];
			print (scene);
			acak = scene.ToString ();
			Debug.Log (acak);
			Application.LoadLevel (acak);

		} else if (cekno0 != 0 && cekno2 == 0 && cekno1 != 0 && cekno3 == 0) {
				scene = number1 [UnityEngine.Random.Range (min1, max1)];
				print (scene);
				acak = scene.ToString ();
				Debug.Log (acak);
				Application.LoadLevel (acak);
		} else if (cekno0 != 0 && cekno2 != 0 && cekno1 == 0 && cekno3 == 0) {
			scene = number2 [UnityEngine.Random.Range (min1, max1)];
			print (scene);
			acak = scene.ToString ();
			Debug.Log (acak);
			Application.LoadLevel (acak);
		} else if (cekno0 != 0 && cekno2 == 0 && cekno1 == 0 && cekno3 != 0) {
			scene = number3 [UnityEngine.Random.Range (min1, max1)];
			print (scene);
			acak = scene.ToString ();
			Debug.Log (acak);
			Application.LoadLevel (acak);
		} else if (cekno0 != 0 && cekno2 != 0 && cekno1 == 0 && cekno3 != 0 ) {
			Application.LoadLevel ("1");
		} else if (cekno0 != 0 && cekno2 == 0 && cekno1 != 0 && cekno3 != 0) {
			Application.LoadLevel ("2");
		} else if (cekno0 != 0 && cekno2 != 0 && cekno1 != 0 && cekno3 == 0) {
			Application.LoadLevel ("3");
		}
	}
	IEnumerator Postscore(string user, string idsoal, int nilai0, float delay)
	{
		UnityWebRequest link = UnityWebRequest.Get ("http://somethingnotright.dx.am/masukinnilai.php?r_username=" + user + "&r_idsoal=" + idsoal + "&r_nilai=" + nilai0);
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