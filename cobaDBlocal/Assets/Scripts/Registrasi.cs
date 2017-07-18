using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Registrasi : MonoBehaviour {

    List<string> names = new List<string>() { "Pilih Provinsi Anda", "ACEH", "SUMATERA UTARA", "SUMATERA BARAT",
        "RIAU", "JAMBI", "SUMATERA SELATAN", "BENGKULU", "LAMPUNG", "KEPULAUAN BANGKA BELITUNG", "KEPULAUAN RIAU", "DKI JAKARTA",
        "JAWA BARAT", "JAWA TENGAH", "DI YOGYAKARTA", "JAWA TIMUR", "BANTEN", "BALI", "NUSA TENGGARA BARAT", "NUSA TENGGARA TIMUR",
        "KALIMANTAN BARAT", "KALIMANTAN TENGAH", "KALIMANTAN SELATAN", "KALIMANTAN TIMUR", "KALIMANTAN UTARA", "SULAWESI UTARA",
        "SULAWESI TENGAH", "SULAWESI SELATAN", "SULAWESI TENGGARA", "GORONTALO", "SULAWESI BARAT", "MALUKU", "MALUKU UTARA",
        "PAPUA BARAT", "PAPUA"
    };

    public Dropdown dropdown;
    public Text pilihprovinsi;

    public InputField r_username;
    public InputField r_name;
    public InputField r_pass;
    public InputField r_repass;

    private string username_r;
    private string name_r;
    private string pass_r;
    private string repass_r;

    private string provinsi;

    public Text error;

    private string g_string;
    private Color green = Color.blue;
    private Color red = new Color(64, 0, 0, 1);

    public void Dropdown_indexchanged(int index)
    {
        pilihprovinsi.text = names [index];

    }

    void Start()
    {
        PopulateList ();
    }

    void PopulateList(){
        dropdown.AddOptions (names);
    }

    public void submit()
    {
        error.text = "";
        username_r = r_username.text;
        name_r = r_name.text;
        pass_r = r_pass.text;
        repass_r = r_repass.text;
        provinsi = pilihprovinsi.text;

        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            error.color = red;
            error.text = "Check Internet Connection";
        }

        //sign_up(username_r, name_r, pass_r);
        StartCoroutine(sign_up(username_r, name_r, pass_r, provinsi));
    }

    IEnumerator sign_up(string elm, string elm1, string elm2, string elm3)
    {
        if (pass_r == repass_r)
        {
			if (provinsi != "Pilih Provinsi Anda") 
			{
	            UnityWebRequest link = UnityWebRequest.Get("http://somethingnotright.dx.am/registrasi.php?r_username=" + elm + "&r_nama=" + elm1 + "&r_pass="+elm2 + "&r_provinsi="+elm3);
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
			else error.text = "Silahkan Pilih Provinsi Anda";
		}
        else error.text = "Password Tidak Cocok";
    }

    private void show_error(string elm)
    {
        string[] arr = null;
        arr = elm.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
		if (arr [3] == "Berhasil") {
			error.color = green;
			error.text = elm;
		}
		else
        {
            error.color = red;
            error.text = elm;
        }
    }
}
