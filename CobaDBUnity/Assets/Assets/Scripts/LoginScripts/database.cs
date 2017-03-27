using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class database : MonoBehaviour
{
    public static string user = "", name = "";
    private string password = "", rePass = "", message = "";

    private bool register = false;

    private void OnGUI()
    {
        if (message != "")
        {
            GUILayout.Box(message);
        }

        if (register)
        {
            GUILayout.Label("Username");
            user = GUILayout.TextField(user);
            GUILayout.Label("Name");
            name = GUILayout.TextField(name);
            GUILayout.Label("Password");
            password = GUILayout.PasswordField(password, "*"[0]);
            GUILayout.Label("Re-Password");
            rePass = GUILayout.PasswordField(rePass, "*"[0]);

            GUILayout.BeginHorizontal();

            if(GUILayout.Button("Back"))
            {
                register = false;
            }

            if (GUILayout.Button("Register"))
            {
                message = "";
                if (user == "" || name == "" || password == "")
                    message += "Please Enter All The Fields \n";
                else
                {
                    if (password == rePass)
                    {
                        WWWForm form = new WWWForm();
                        form.AddField("user", user);
                        form.AddField("name", name);
                        form.AddField("password", password);
                        WWW w = new WWW("http://somethingnotright.dx.am/register.php", form);
                        StartCoroutine(registerFunc(w));
                    }
                    else
                        message += "Your Password Does Not Match \n";
                }
            }
            GUILayout.EndHorizontal();
        }
        else
        {
            GUILayout.Label("User:");
            user = GUILayout.TextField(user);
            GUILayout.Label("Password:");
            password = GUILayout.PasswordField(password, "*"[0]);

            GUILayout.BeginHorizontal();

            if(GUILayout.Button("Login"))
            {
                message = "";
                if (user == "" || password == "")
                {
                    message += "Please Enter All The Fields \n";
                }
                else
                {
                    WWWForm form = new WWWForm();
                    form.AddField("user", user);
                    form.AddField("password", password);
                    WWW w = new WWW("http://somethingnotright.dx.am/login.php", form);
                    StartCoroutine(login(w));
                }
            }

            if (GUILayout.Button("Register"))
            {
                register = true;
            }

            GUILayout.EndHorizontal();
        }
    }

    IEnumerator login(WWW w)
    {
        yield return w;
        if (w.error == null)
        {
            if (w.text == "login-SUCCESS")
            {
                print("Yatta");
            }
            else
            {
                message += w.text;
            }     
        }
        else
        {
            message += "Error: " + w.error + "\n";
        }
    }

    IEnumerator registerFunc(WWW w)
    {
        yield return w;
        if(w.error==null)
        {
            message += w.text;
        }
        else
        {
            message += "Error: " + w.error + "\n";
        }
    }
}
