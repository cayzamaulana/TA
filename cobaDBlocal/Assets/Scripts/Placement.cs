using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{

    public int id;
    public bool filled, nyala;
    public GameManager gameManager;
    SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (nyala)
        {
            sprite.color = Color.green;
        }
        else
        {
            sprite.color = Color.white;
        }
	}

    void OnMouseDown()
    {
        ClickPlace();
    }

    public void ClickPlace()
    {
        if (filled)
        {
            Debug.Log("Masuk");
            if (gameManager.parentTurn && (gameManager.locationChar[id]==0 || gameManager.locationChar[id]==1))
            {           
                gameManager.chooseChar = gameManager.locationChar[id];
                gameManager.checkMove(id);
            }
            else  if (gameManager.myTurn && gameManager.locationChar[id] == 2)
            {
                gameManager.chooseChar = gameManager.locationChar[id];
                gameManager.checkMove(id);
            }
        }
        else if(!filled && gameManager.isChoosingChar)
        {
            gameManager.Move(id);
        }
    }
}
