using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 


public class SoalNomor2 : MonoBehaviour {

	public Button mybutton1, mybutton2, mybutton3;
	public Sprite rumah1;
	public Sprite rumah2;
	public Sprite rumah3;

	public Sprite rumah1dipilih;
	public Sprite rumah2dipilih;
	public Sprite rumah3dipilih;

	private int counter1, counter2, counter3 = 0;

	void Start () {
		mybutton1 = GetComponent<Button> ();
		mybutton2 = GetComponent<Button> ();
		mybutton3 = GetComponent<Button> ();
	}

	public void rmh1()
	{
		counter1++;
		if (counter1 % 2 == 0)
		{
			mybutton1.image.overrideSprite = rumah1;
			PlayerPrefs.SetInt("rumah1", 0);
			Debug.Log(PlayerPrefs.GetInt("rumah2"));
		} else
		{
			mybutton1.image.overrideSprite = rumah1dipilih;
			PlayerPrefs.SetInt("rumah1", 0);
			Debug.Log (PlayerPrefs.GetInt ("rumah1"));
		}
	}

	public void rmh2()
	{
		counter2++;
		if (counter2 % 2 == 0)
		{
			mybutton2.image.overrideSprite = rumah2;
			PlayerPrefs.SetInt("rumah2", 0);
			Debug.Log(PlayerPrefs.GetInt("rumah2"));
		} else
		{
			mybutton2.image.overrideSprite = rumah2dipilih;
			PlayerPrefs.SetInt("rumah2", 0);
			Debug.Log (PlayerPrefs.GetInt ("rumah2"));
		}
	}

	public void rmh3()
	{
		counter3++;
		if (counter3 % 2 == 0)
		{
			mybutton3.image.overrideSprite = rumah3;
			PlayerPrefs.SetInt("rumah3", 0);
			Debug.Log(PlayerPrefs.GetInt("rumah3"));
		} else
		{
			mybutton3.image.overrideSprite = rumah3dipilih;
			PlayerPrefs.SetInt("rumah3", 1);
			Debug.Log (PlayerPrefs.GetInt ("rumah3"));
		}
	}
}
