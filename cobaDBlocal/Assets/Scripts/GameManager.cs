using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Placement[] placement;
    public Characters[] characters;
    public bool parentTurn, myTurn, isChoosingChar;
    public int chooseChar;
    public int[] locationChar;
    public bool kalah;
    public Text turn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void checkMove(int id)
    {
        int prev = 0, next = 0;
        if (parentTurn)
        {
            prev = id - 1;
            next = id + 1;
        }
        else if(myTurn)
        {
            prev = id - 2;
            next = id + 2;
        }
        if (prev < 0)
        {
            prev += 7;
        }

        if (next > 6)
        {
            next -= 7;
        }

        if (!placement[next].filled)
        {
            placement[next].nyala = true;
        }

        if (!placement[prev].filled)
        {
            placement[prev].nyala = true;
        }

        if(myTurn && placement[prev].filled && placement[next].filled)
        {
            turn.text = "Bebras has been caught";
            kalah = true;
        }
        isChoosingChar = true;
    }

    public void Move(int id)
    {
        int prev = characters[chooseChar].location;
        characters[chooseChar].location = id;
        locationChar[prev] = -1;
        locationChar[id] = chooseChar;
        placement[prev].filled = false;
        placement[id].filled = true;
        characters[chooseChar].transform.localPosition = new Vector3(placement[id].transform.localPosition.x, placement[id].transform.localPosition.y, characters[chooseChar].transform.localPosition.z);
        if(parentTurn)
        {
            uncheckMove(prev - 1, prev + 1);
            parentTurn = false;
            myTurn = true;
        }
        else if (myTurn)
        {
            uncheckMove(prev - 2, prev + 2);
            parentTurn = true;
            myTurn = false;
        }
    } 


    public void uncheckMove(int prev, int next)
    {

        if (prev < 0)
        {
            prev += 7;
        }

        if (next > 6)
        {
            next -= 7;
        }

        placement[next].nyala = false;

        placement[prev].nyala = false;
        isChoosingChar = false;
    }

}
