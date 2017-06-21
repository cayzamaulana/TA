using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackScript : MonoBehaviour {

    public Stack<GameObject> Deck1 = new Stack<GameObject>();
    public GameObject stack;
    public List<GameObject> stackChild;
    public Button pop1;
    public float positionRangeY;
    public QueueScript2 queue;
    public float BasePosition;
    public GameObject Violet, Yellow, Blue;

	// Use this for initialization
	void Start () {
        int count = stack.transform.childCount;
        for(int i = 0; i<count; i++)
        {
            Transform go = stack.transform.GetChild(i);
            stackChild.Add(go.gameObject);
            Deck1.Push(go.gameObject);
        }
        Button btn = pop1.GetComponent<Button>();
        btn.onClick.AddListener(popA);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void popA()
    {
        CheckStack.stepCount++;
        GameObject go = Deck1.Pop();
        stackChild.Remove(go);
        queue.pushB(go);
        //Destroy(go);
    }

    public void pushA(GameObject go)
    {
        Vector3 go2 = new Vector3 (0,0,-1);
        if (Deck1.Count != 0)
            go2 = Deck1.Peek().transform.localPosition;
        else
            go2 = new Vector3(0, BasePosition, -1);
        stackChild.Add(go);
        Deck1.Push(go);
        Vector3 oldPosition = go.transform.localPosition;
        go.transform.parent = stack.transform;
        //go.transform.position = new Vector3(go.transform.position.x, go.transform.localPosition.y + positionRangeY,go.transform.localPosition.z);
        go.transform.localPosition = new Vector3(oldPosition.x, go2.y + positionRangeY, go.transform.localPosition.z);
    }

    public void Reset(GameObject blue, GameObject yellow, GameObject violet)
    {
        Deck1.Clear();
        stackChild.Clear();
        pushA(blue);
        pushA(yellow);
        pushA(violet);
    }
}
