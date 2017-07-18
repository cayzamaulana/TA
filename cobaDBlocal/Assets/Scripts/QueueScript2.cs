using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueueScript2 : MonoBehaviour {

    public Queue<GameObject> Deck2 = new Queue<GameObject>();
    public GameObject queue;
    public List<GameObject> queueChild;
    public Button pop2;
    public StackScript stack;
    public float PositionRangeY;
    public float BasePosition;
    public GameObject Red, Gray;
    public string nama;
    public Text keterangan;

    // Use this for initialization
    void Start()
    {
        stack = FindObjectOfType<StackScript>();
        int count = queue.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            Transform go = queue.transform.GetChild(i);
            queueChild.Add(go.gameObject);
            //Deck2.Push(go.gameObject);
            Deck2.Enqueue(go.gameObject);
        }
        Button btn = pop2.GetComponent<Button>();
        btn.onClick.AddListener(popB);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void popB()
    {
        CheckStack.stepCount++;
        GameObject go = Deck2.Dequeue();
        queueChild.Remove(go);
        stack.pushA(go);
        ResetPosition();
        string warna = go.GetComponent<Warna>().warna;
        keterangan.text = "Piringan " + warna + " pindah menuju wadah hijau";
    }

    public void ResetPosition()
    {
        for(int i = 0;i<queueChild.Count;i++)
        {
            queueChild[i].transform.localPosition = new Vector3(queueChild[i].transform.localPosition.x, queueChild[i].transform.localPosition.y - PositionRangeY, queueChild[i].transform.localPosition.z);
        }
    }

    public void pushB(GameObject go)
    {
        Vector3 go2 = new Vector3(0, 0, -1);
        if (queueChild.Count != 0)
            go2 = queueChild[queueChild.Count - 1].transform.localPosition;
        else
            go2 = new Vector3(0, BasePosition, -1);
        Deck2.Enqueue(go);
        queueChild.Add(go);
        Vector3 oldPosition = go.transform.localPosition;
        go.transform.parent = queue.transform;
        //go.transform.position = new Vector3(go.transform.position.x, go.transform.localPosition.y + positionRangeY,go.transform.localPosition.z);
        go.transform.localPosition = new Vector3(oldPosition.x, go2.y + PositionRangeY, -1);
    }

    public void Reset(GameObject gray, GameObject red)
    {
        Deck2.Clear();
        queueChild.Clear();
        pushB(gray);
        pushB(red);
    }
}
