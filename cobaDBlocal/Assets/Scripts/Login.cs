using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;


public class Login : MonoBehaviour {

	public Button submitBtn;

    public InputField r_username;
    public InputField r_pass;

    private string username_r;
    private string pass_r;

    public Text error;

    private string g_string;
    private Color green = Color.blue;
    private Color red = new Color(64, 0, 0, 1);

	void Start(){
		Button btn = submitBtn.GetComponent<Button>();
		btn.onClick.AddListener(Submit);
	}

    public void Submit()
    {
        error.text = "";
        username_r = r_username.text;
        pass_r = r_pass.text;

        //error.text = username_r + pass_r;
        StartCoroutine(log_in(username_r, pass_r));
        if (error.color == green)
        {
            PlayerPrefs.SetString("username", username_r);
            //Debug.Log(PlayerPrefs.GetString("username").ToString());
            Application.LoadLevel("pagePilihNomor");
        }
        else return;    
    }

    IEnumerator log_in(string el, string el1)
    {
		UnityWebRequest link = UnityWebRequest.Get("http://somethingnotright.dx.am/login2.php?r_username=" + el + "&r_pass=" + el1);
        yield return link.Send();
        if (link.isError)
        {
            Debug.Log(link.error);
        }
        else
        {
            g_string = link.downloadHandler.text;
        
            show_error(g_string.ToString());
        }
    }

    private void show_error(string el)
    {
        string[] arr = null;
        arr = el.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        if (arr[2] == "Berhasil")
        {
            error.color = green;
            error.text = el;  
        } 
        else
        {
            error.color = red;
            error.text = el;
        }
    }
}
