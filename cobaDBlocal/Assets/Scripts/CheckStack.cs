using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckStack : MonoBehaviour {

    public Button Check;
    public Text Benar, Step;
    public static int stepCount;
    public QueueScript2 queue;
    public StackScript stack;
    public GameObject blue, yellow, violet, gray, red;

	// Use this for initialization
	void Start () {
        stepCount = 0;
        Button btn = Check.GetComponent<Button>();
        btn.onClick.AddListener(checkBenar);
    }
	
	// Update is called once per frame
	void Update () {
        Step.text = stepCount.ToString();
	}

    public void checkBenar()
    {
        if(stack.stackChild[0]==blue && stack.stackChild[1]==red && stack.stackChild[2]==violet &&
            queue.queueChild[0]==gray && queue.queueChild[1] == yellow && stepCount==6)
        {
            Benar.text = "Benar";
        }
        else
        {
            Benar.text = "Salah";
        }
    }

    public void Reset()
    {
        stack.Reset(blue, yellow, violet);
        queue.Reset(gray, red);
        stepCount = 0;
    }
}
