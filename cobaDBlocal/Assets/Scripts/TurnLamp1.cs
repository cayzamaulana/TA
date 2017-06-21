using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnLamp1 : MonoBehaviour {

    public LampStats[] lampu;
    public Button btn1, btn2, btn3, btn4, btn5;
    public CheckLamp check;

	// Use this for initialization
	void Start () {
        Button switch1 = btn1.GetComponent<Button>();
        Button switch2 = btn2.GetComponent<Button>();
        Button switch3 = btn3.GetComponent<Button>();
        Button switch4 = btn4.GetComponent<Button>();
        Button switch5 = btn5.GetComponent<Button>();
        switch1.onClick.AddListener(Switch1);
        switch2.onClick.AddListener(Switch2);
        switch3.onClick.AddListener(Switch3);
        switch4.onClick.AddListener(Switch4);
        switch5.onClick.AddListener(Switch5);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Switch1()
    {
        CheckLamp.stepCount++;
        lampu[0].nyala = !lampu[0].nyala;
        lampu[1].nyala = !lampu[1].nyala;
        lampu[3].nyala = !lampu[3].nyala;
        lampu[4].nyala = !lampu[4].nyala;
        lampu[5].nyala = !lampu[5].nyala;
        lampu[9].nyala = !lampu[9].nyala;
        lampu[15].nyala = !lampu[15].nyala;
        lampu[19].nyala = !lampu[19].nyala;
        lampu[20].nyala = !lampu[20].nyala;
        lampu[21].nyala = !lampu[21].nyala;
        lampu[23].nyala = !lampu[23].nyala;
        lampu[24].nyala = !lampu[24].nyala;
    }

    public void Switch2()
    {
        CheckLamp.stepCount++;
        lampu[0].nyala = !lampu[0].nyala;
        lampu[1].nyala = !lampu[1].nyala;
        lampu[2].nyala = !lampu[2].nyala;
        lampu[3].nyala = !lampu[3].nyala;
        lampu[4].nyala = !lampu[4].nyala;
        lampu[5].nyala = !lampu[5].nyala;
        lampu[10].nyala = !lampu[10].nyala;
        lampu[15].nyala = !lampu[15].nyala;
    }

    public void Switch3()
    {
        CheckLamp.stepCount++;
        lampu[2].nyala = !lampu[2].nyala;
        lampu[7].nyala = !lampu[7].nyala;
        lampu[10].nyala = !lampu[10].nyala;
        lampu[11].nyala = !lampu[11].nyala;
        lampu[12].nyala = !lampu[12].nyala;
        lampu[13].nyala = !lampu[13].nyala;
        lampu[14].nyala = !lampu[14].nyala;
        lampu[17].nyala = !lampu[17].nyala;
        lampu[22].nyala = !lampu[22].nyala;
    }

    public void Switch4()
    {
        CheckLamp.stepCount++;
        lampu[0].nyala = !lampu[0].nyala;
        lampu[5].nyala = !lampu[5].nyala;
        lampu[10].nyala = !lampu[10].nyala;
        lampu[15].nyala = !lampu[15].nyala;
        lampu[20].nyala = !lampu[20].nyala;
        lampu[21].nyala = !lampu[21].nyala;
        lampu[22].nyala = !lampu[22].nyala;
        lampu[23].nyala = !lampu[23].nyala;
        lampu[24].nyala = !lampu[24].nyala;
    }

    public void Switch5()
    {
        CheckLamp.stepCount++;
        lampu[1].nyala = !lampu[1].nyala;
        lampu[2].nyala = !lampu[2].nyala;
        lampu[3].nyala = !lampu[3].nyala;
        lampu[5].nyala = !lampu[5].nyala;
        lampu[9].nyala = !lampu[9].nyala;
        lampu[10].nyala = !lampu[10].nyala;
        lampu[14].nyala = !lampu[14].nyala;
        lampu[15].nyala = !lampu[15].nyala;
        lampu[19].nyala = !lampu[19].nyala;
        lampu[21].nyala = !lampu[21].nyala;
        lampu[22].nyala = !lampu[22].nyala;
        lampu[23].nyala = !lampu[23].nyala;
    }

    public void Reset()
    {
        for(int i = 0; i<lampu.Length; i++)
        {
            lampu[i].nyala = false;
            CheckLamp.stepCount = 0;
            check.benarsalah.gameObject.SetActive(false);
        }
    }
}
