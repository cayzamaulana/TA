using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckLamp : MonoBehaviour {

    public LampStats[] lampu;
    public static int stepCount;
    public Button check;
    public Text step, benarsalah;
    public int[] nyala = {4, 5, 7, 10, 11, 12, 13, 15, 17, 21, 22, 23 };
    public bool benar;

    // Use this for initialization
    void Start () {
        stepCount = 0;
        Button btn = check.GetComponent<Button>();
        btn.onClick.AddListener(checkBenar);
    }
	
	// Update is called once per frame
	void Update () {
        step.text = stepCount.ToString();
    }

    public void checkBenar()
    {
        int flag = 0;
        for (int i = 0; i<lampu.Length; i++) {
            if(i == nyala[flag])
            {
                Debug.Log(nyala[flag]);
                if (lampu[i].nyala == true)
                {
                    flag++;
                }
                if (flag == nyala.Length)
                    break;
            }
            else
            {
                if(lampu[i].nyala == true)
                {
                    benar = false;
                    break;
                }
            }
        }

        if (flag == nyala.Length)
        {
            benar = true;
            benarsalah.gameObject.SetActive(true);
            benarsalah.text = "Benar";
        }
        else if(flag != nyala.Length || benar == false)
        {
            benarsalah.gameObject.SetActive(true);
            benarsalah.text = "Salah";
        }
    }
}
