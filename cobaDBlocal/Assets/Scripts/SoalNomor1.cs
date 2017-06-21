using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 

[RequireComponent(typeof(Button))]

public class SoalNomor1 : MonoBehaviour {

	public RectTransform panelRectTransform1;
	public RectTransform panelRectTransform2;
	public RectTransform panelRectTransform3;
	public RectTransform panelRectTransform4;
	public RectTransform panelRectTransform5;
	//public RectTransform panelRectTransform6;
	//public RectTransform panelRectTransform7;
	public RectTransform panelRectTransform8;
	public RectTransform panelRectTransform9;
	public RectTransform panelRectTransform10;
	public RectTransform panelRectTransform11;
	public RectTransform panelRectTransform12;
	public RectTransform panelRectTransform13;
	public RectTransform panelRectTransform14;
	//public RectTransform panelRectTransform15;
	public RectTransform panelRectTransform16;
	public RectTransform panelRectTransform17;
	public RectTransform panelRectTransform18;
	public RectTransform panelRectTransform19;
	public RectTransform panelRectTransform20;
	public RectTransform panelRectTransform21;
	public RectTransform panelRectTransform22;
	public RectTransform panelRectTransform23;
	public RectTransform panelRectTransform24;
	public RectTransform panelRectTransform25;
	public RectTransform panelRectTransform26;
	public RectTransform panelRectTransform27;

	public RectTransform panelRectTransformRumahFrank;
	public RectTransform panelRectTransformRumahSandy;
	public RectTransform panelRectTransformKafe;


    // Use this for initialization
    //public Text score;
    //private int nilai;
    public Button mybutton, mybutton2, mybutton3, mybutton4, mybutton5, mybutton6, mybutton7, mybutton8, mybutton9, mybutton10, 
	mybutton11, mybutton12, mybutton13, mybutton14, mybutton15, mybutton16, mybutton17, mybutton18, mybutton19, mybutton20, 
	mybutton21, mybutton22, mybutton23, mybutton24, mybutton25, mybutton26, mybutton27;
	public Sprite jalan;
    public Sprite pencet;
	private int counter1, counter2, counter3, counter4, counter5, counter6, counter7, counter8, counter9, counter10, 
	counter11, counter12, counter13, counter14, counter15, counter16, counter17, counter18, counter19, counter20, 
	counter21, counter22, counter23, counter24, counter25, counter26, counter27 = 0;
    void Start () {
        mybutton = GetComponent<Button>();
        mybutton2 = GetComponent<Button>();
        mybutton3 = GetComponent<Button>();
        mybutton4 = GetComponent<Button>();
        mybutton5 = GetComponent<Button>();
        mybutton6 = GetComponent<Button>();
        mybutton7 = GetComponent<Button>();
        mybutton8 = GetComponent<Button>();
        mybutton9 = GetComponent<Button>();
        mybutton10 = GetComponent<Button>();
        mybutton11 = GetComponent<Button>();
		mybutton12 = GetComponent<Button>();
		mybutton13 = GetComponent<Button>();
		mybutton14 = GetComponent<Button>();
		mybutton15 = GetComponent<Button>();
		mybutton16 = GetComponent<Button>();
		mybutton17 = GetComponent<Button>();
		mybutton18 = GetComponent<Button>();
		mybutton19 = GetComponent<Button>();
		mybutton20 = GetComponent<Button>();
		mybutton21 = GetComponent<Button>();
		mybutton22 = GetComponent<Button>();
		mybutton23 = GetComponent<Button>();
		mybutton24 = GetComponent<Button>();
		mybutton25 = GetComponent<Button>();
		mybutton26 = GetComponent<Button>();
		mybutton27 = GetComponent<Button>();

    }

    public void jalan1()
    {
        counter1++;
        if (counter1 % 2 == 0)
        {
            mybutton.image.overrideSprite = jalan;
            PlayerPrefs.SetInt("jalan1", 0);
            Debug.Log(PlayerPrefs.GetInt("jalan1"));
			panelRectTransform1.SetAsFirstSibling();
        } else
        {
            mybutton.image.overrideSprite = pencet;
            PlayerPrefs.SetInt("jalan1", 1);
            Debug.Log(PlayerPrefs.GetInt("jalan1"));
			panelRectTransform1.SetAsLastSibling();
			panelRectTransformRumahSandy.SetAsLastSibling();

        }
    }

    public void jalan2()
    {
        counter2++;
        if (counter2 % 2 == 0)
        {
            mybutton2.image.overrideSprite = jalan;
            PlayerPrefs.SetInt("jalan2", 0);
            Debug.Log(PlayerPrefs.GetInt("jalan2"));
			panelRectTransform2.SetAsFirstSibling();

        }
        else
        {
            mybutton2.image.overrideSprite = pencet;
            PlayerPrefs.SetInt("jalan2", 1);
            Debug.Log(PlayerPrefs.GetInt("jalan2"));
			panelRectTransform2.SetAsLastSibling();

		}
    }

    public void jalan3()
    {
        counter3++;
        if (counter3 % 2 == 0)
        {
            mybutton3.image.overrideSprite = jalan;
            PlayerPrefs.SetInt("jalan3", 0);
            Debug.Log(PlayerPrefs.GetInt("jalan3"));
			panelRectTransform3.SetAsFirstSibling();

        }
        else
        {
            mybutton3.image.overrideSprite = pencet;
            PlayerPrefs.SetInt("jalan3", 1);
            Debug.Log(PlayerPrefs.GetInt("jalan3"));
			panelRectTransform3.SetAsLastSibling();

        }
    }

    public void jalan4()
    {
        counter4++;
        if (counter4 % 2 == 0)
        {
            mybutton4.image.overrideSprite = jalan;
            PlayerPrefs.SetInt("jalan4", 0);
            Debug.Log(PlayerPrefs.GetInt("jalan4"));
			panelRectTransform4.SetAsFirstSibling();

        }
        else
        {
            mybutton4.image.overrideSprite = pencet;
            PlayerPrefs.SetInt("jalan4", 1);
            Debug.Log(PlayerPrefs.GetInt("jalan4"));
			panelRectTransform4.SetAsLastSibling();

        }
    }

    public void jalan5()
    {
        counter5++;
        if (counter5 % 2 == 0)
        {
            mybutton5.image.overrideSprite = jalan;
            PlayerPrefs.SetInt("jalan5", 0);
            Debug.Log(PlayerPrefs.GetInt("jalan5"));
			panelRectTransform5.SetAsFirstSibling();

        }
        else
        {
            mybutton5.image.overrideSprite = pencet;
            PlayerPrefs.SetInt("jalan5", 1);
            Debug.Log(PlayerPrefs.GetInt("jalan5"));
			panelRectTransform5.SetAsLastSibling();

        }
    }

    public void jalan6()
    {
        counter6++;
        if (counter6 % 2 == 0)
        {
            mybutton6.image.overrideSprite = jalan;
            PlayerPrefs.SetInt("jalan6", 0);
            Debug.Log(PlayerPrefs.GetInt("jalan6"));
			//panelRectTransform6.SetAsFirstSibling();

        }
        else
        {
            mybutton6.image.overrideSprite = pencet;
            PlayerPrefs.SetInt("jalan6", 1);
            Debug.Log(PlayerPrefs.GetInt("jalan6"));
			//panelRectTransform6.SetAsLastSibling();

        }
    }

    public void jalan7()
    {
        counter7++;
        if (counter7 % 2 == 0)
        {
            mybutton7.image.overrideSprite = jalan;
            PlayerPrefs.SetInt("jalan7", 0);
            Debug.Log(PlayerPrefs.GetInt("jalan7"));
			//panelRectTransform7.SetAsFirstSibling();

        }
        else
        {
            mybutton7.image.overrideSprite = pencet;
            PlayerPrefs.SetInt("jalan7", 1);
            Debug.Log(PlayerPrefs.GetInt("jalan7"));
			//panelRectTransform7.SetAsLastSibling();
			//panelRectTransformKafe.SetAsLastSibling();


        }
    }

    public void jalan8()
    {
        counter8++;
        if (counter8 % 2 == 0)
        {
            mybutton8.image.overrideSprite = jalan;
            PlayerPrefs.SetInt("jalan8", 0);
            Debug.Log(PlayerPrefs.GetInt("jalan8"));
			panelRectTransform8.SetAsFirstSibling();

        }
        else
        {
            mybutton8.image.overrideSprite = pencet;
            PlayerPrefs.SetInt("jalan8", 20);
            Debug.Log(PlayerPrefs.GetInt("jalan8"));
			panelRectTransform8.SetAsLastSibling();

        }
    }

    public void jalan9()
    {
        counter9++;
        if (counter9 % 2 == 0)
        {
            mybutton9.image.overrideSprite = jalan;
            PlayerPrefs.SetInt("jalan9", 0);
            Debug.Log(PlayerPrefs.GetInt("jalan9"));
			panelRectTransform9.SetAsFirstSibling();

        }
        else
        {
            mybutton9.image.overrideSprite = pencet;
            PlayerPrefs.SetInt("jalan9", 20);
            Debug.Log(PlayerPrefs.GetInt("jalan9"));
			panelRectTransform9.SetAsLastSibling();

        }
    }

    public void jalan10()
    {
        counter10++;
        if (counter10 % 2 == 0)
        {
            mybutton10.image.overrideSprite = jalan;
            PlayerPrefs.SetInt("jalan10", 0);
            Debug.Log(PlayerPrefs.GetInt("jalan10"));
			panelRectTransform10.SetAsFirstSibling();


        }
        else
        {
            mybutton10.image.overrideSprite = pencet;
            PlayerPrefs.SetInt("jalan10", 20);
            Debug.Log(PlayerPrefs.GetInt("jalan10"));
			panelRectTransform10.SetAsLastSibling();

        }
    }

    public void jalan11()
    {
        counter11++;
        if (counter11 % 2 == 0)
        {
            mybutton11.image.overrideSprite = jalan;
            PlayerPrefs.SetInt("jalan11", 0);
            Debug.Log(PlayerPrefs.GetInt("jalan11"));
			panelRectTransform11.SetAsFirstSibling();


        }
        else
        {
            mybutton11.image.overrideSprite = pencet;
            PlayerPrefs.SetInt("jalan11", 20);
            Debug.Log(PlayerPrefs.GetInt("jalan11"));
			panelRectTransform11.SetAsLastSibling();

        }
    }

	public void jalan12()
	{
		counter12++;
		if (counter12 % 2 == 0)
		{
			mybutton12.image.overrideSprite = jalan;
			PlayerPrefs.SetInt("jalan12", 0);
			Debug.Log(PlayerPrefs.GetInt("jalan12"));
			panelRectTransform12.SetAsFirstSibling();


		} else
		{
			mybutton12.image.overrideSprite = pencet;
			PlayerPrefs.SetInt("jalan12", 20);
			Debug.Log(PlayerPrefs.GetInt("jalan12"));
			panelRectTransform12.SetAsLastSibling();
			panelRectTransformRumahSandy.SetAsLastSibling ();
		}
	}

	public void jalan13()
	{
		counter13++;
		if (counter13 % 2 == 0)
		{
			mybutton13.image.overrideSprite = jalan;
			PlayerPrefs.SetInt("jalan13", 0);
			Debug.Log(PlayerPrefs.GetInt("jalan13"));
			panelRectTransform13.SetAsFirstSibling();


		} else
		{
			mybutton13.image.overrideSprite = pencet;
			PlayerPrefs.SetInt("jalan13", 20);
			Debug.Log(PlayerPrefs.GetInt("jalan13"));
			panelRectTransform13.SetAsLastSibling();

		}
	}

	public void jalan14()
	{
		counter14++;
		if (counter14 % 2 == 0)
		{
			mybutton14.image.overrideSprite = jalan;
			PlayerPrefs.SetInt("jalan14", 0);
			Debug.Log(PlayerPrefs.GetInt("jalan14"));
			panelRectTransform14.SetAsFirstSibling();


		} else
		{
			mybutton14.image.overrideSprite = pencet;
			PlayerPrefs.SetInt("jalan14", 20);
			Debug.Log(PlayerPrefs.GetInt("jalan14"));
			panelRectTransform14.SetAsLastSibling();

		}
	}

	public void jalan15()
	{
		counter15++;
		if (counter15 % 2 == 0)
		{
			mybutton15.image.overrideSprite = jalan;
			PlayerPrefs.SetInt("jalan15", 0);
			Debug.Log(PlayerPrefs.GetInt("jalan15"));
			//panelRectTransform15.SetAsFirstSibling();


		} else
		{
			mybutton15.image.overrideSprite = pencet;
			PlayerPrefs.SetInt("jalan15", 20);
			Debug.Log(PlayerPrefs.GetInt("jalan15"));
			//panelRectTransform15.SetAsFirstSibling();

		}
	}

	public void jalan16()
	{
		counter16++;
		if (counter16 % 2 == 0)
		{
			mybutton16.image.overrideSprite = jalan;
			PlayerPrefs.SetInt("jalan16", 0);
			Debug.Log(PlayerPrefs.GetInt("jalan16"));
			panelRectTransform16.SetAsFirstSibling();


		} else
		{
			mybutton16.image.overrideSprite = pencet;
			PlayerPrefs.SetInt("jalan16", 1);
			Debug.Log(PlayerPrefs.GetInt("jalan16"));
			panelRectTransform16.SetAsLastSibling();
			panelRectTransformRumahFrank.SetAsLastSibling();

		}
	}

	public void jalan17()
	{
		counter17++;
		if (counter17 % 2 == 0)
		{
			mybutton17.image.overrideSprite = jalan;
			PlayerPrefs.SetInt("jalan17", 0);
			Debug.Log(PlayerPrefs.GetInt("jalan17"));
			panelRectTransform17.SetAsFirstSibling();


		} else
		{
			mybutton17.image.overrideSprite = pencet;
			PlayerPrefs.SetInt("jalan17", 1);
			Debug.Log(PlayerPrefs.GetInt("jalan17"));
			panelRectTransform17.SetAsLastSibling();

		}
	}

	public void jalan18()
	{
		counter18++;
		if (counter18 % 2 == 0)
		{
			mybutton18.image.overrideSprite = jalan;
			PlayerPrefs.SetInt("jalan18", 0);
			Debug.Log(PlayerPrefs.GetInt("jalan18"));
			panelRectTransform18.SetAsFirstSibling();


		} else
		{
			mybutton18.image.overrideSprite = pencet;
			PlayerPrefs.SetInt("jalan18", 20);
			Debug.Log(PlayerPrefs.GetInt("jalan18"));
			panelRectTransform18.SetAsLastSibling();

		}
	}

	public void jalan19()
	{
		counter19++;
		if (counter19 % 2 == 0)
		{
			mybutton19.image.overrideSprite = jalan;
			PlayerPrefs.SetInt("jalan19", 0);
			Debug.Log(PlayerPrefs.GetInt("jalan19"));
			panelRectTransform19.SetAsFirstSibling();


		} else
		{
			mybutton19.image.overrideSprite = pencet;
			PlayerPrefs.SetInt("jalan19", 20);
			Debug.Log(PlayerPrefs.GetInt("jalan19"));
			panelRectTransform19.SetAsLastSibling();

		}
	}

	public void jalan20()
	{
		counter20++;
		if (counter20 % 2 == 0)
		{
			mybutton20.image.overrideSprite = jalan;
			PlayerPrefs.SetInt("jalan20", 0);
			Debug.Log(PlayerPrefs.GetInt("jalan20"));
			panelRectTransform20.SetAsFirstSibling();


		} else
		{
			mybutton20.image.overrideSprite = pencet;
			PlayerPrefs.SetInt("jalan20", 20);
			Debug.Log(PlayerPrefs.GetInt("jalan20"));
			panelRectTransform20.SetAsLastSibling();

		}
	}

	public void jalan21()
	{
		counter21++;
		if (counter21 % 2 == 0)
		{
			mybutton21.image.overrideSprite = jalan;
			PlayerPrefs.SetInt("jalan21", 0);
			Debug.Log(PlayerPrefs.GetInt("jalan21"));
			panelRectTransform21.SetAsFirstSibling();


		} else
		{
			mybutton21.image.overrideSprite = pencet;
			PlayerPrefs.SetInt("jalan21", 1);
			Debug.Log(PlayerPrefs.GetInt("jalan21"));
			panelRectTransform21.SetAsLastSibling();

		}
	}

	public void jalan22()
	{
		counter22++;
		if (counter22 % 2 == 0)
		{
			mybutton22.image.overrideSprite = jalan;
			PlayerPrefs.SetInt("jalan22", 0);
			Debug.Log(PlayerPrefs.GetInt("jalan22"));
			panelRectTransform22.SetAsFirstSibling();


		} else
		{
			mybutton22.image.overrideSprite = pencet;
			PlayerPrefs.SetInt("jalan22", 1);
			Debug.Log(PlayerPrefs.GetInt("jalan22"));
			panelRectTransform22.SetAsLastSibling();
			panelRectTransformKafe.SetAsLastSibling();


		}
	}

	public void jalan23()
	{
		counter23++;
		if (counter23 % 2 == 0)
		{
			mybutton23.image.overrideSprite = jalan;
			PlayerPrefs.SetInt("jalan23", 0);
			Debug.Log(PlayerPrefs.GetInt("jalan23"));
			panelRectTransform23.SetAsFirstSibling();

		} else
		{
			mybutton23.image.overrideSprite = pencet;
			PlayerPrefs.SetInt("jalan23", 20);
			Debug.Log(PlayerPrefs.GetInt("jalan23"));
			panelRectTransform23.SetAsLastSibling();
		}
	}

	public void jalan24()
	{
		counter24++;
		if (counter24 % 2 == 0)
		{
			mybutton24.image.overrideSprite = jalan;
			PlayerPrefs.SetInt("jalan24", 0);
			Debug.Log(PlayerPrefs.GetInt("jalan24"));
			panelRectTransform24.SetAsFirstSibling();


		} else
		{
			mybutton24.image.overrideSprite = pencet;
			PlayerPrefs.SetInt("jalan24", 20);
			Debug.Log(PlayerPrefs.GetInt("jalan24"));
			panelRectTransform24.SetAsLastSibling();
			panelRectTransformRumahFrank.SetAsLastSibling();

		}
	}

	public void jalan25()
	{
		counter25++;
		if (counter25 % 2 == 0)
		{
			mybutton25.image.overrideSprite = jalan;
			PlayerPrefs.SetInt("jalan25", 0);
			Debug.Log(PlayerPrefs.GetInt("jalan25"));
			panelRectTransform25.SetAsFirstSibling();


		} else
		{
			mybutton25.image.overrideSprite = pencet;
			PlayerPrefs.SetInt("jalan25", 20);
			Debug.Log(PlayerPrefs.GetInt("jalan25"));
			panelRectTransform25.SetAsLastSibling();

		}
	}

	public void jalan26()
	{
		counter26++;
		if (counter26 % 2 == 0)
		{
			mybutton26.image.overrideSprite = jalan;
			PlayerPrefs.SetInt("jalan26", 0);
			Debug.Log(PlayerPrefs.GetInt("jalan26"));
			panelRectTransform26.SetAsFirstSibling();


		} else
		{
			mybutton26.image.overrideSprite = pencet;
			PlayerPrefs.SetInt("jalan26", 20);
			Debug.Log(PlayerPrefs.GetInt("jalan26"));
			panelRectTransform26.SetAsLastSibling();
			panelRectTransformKafe.SetAsLastSibling();


		}
	}

	public void jalan27()
	{
		counter27++;
		if (counter27 % 2 == 0)
		{
			mybutton27.image.overrideSprite = jalan;
			PlayerPrefs.SetInt("jalan27", 0);
			Debug.Log(PlayerPrefs.GetInt("jalan27"));
			panelRectTransform27.SetAsFirstSibling();


		} else
		{
			mybutton27.image.overrideSprite = pencet;
			PlayerPrefs.SetInt("jalan27", 20);
			Debug.Log(PlayerPrefs.GetInt("jalan27"));
			panelRectTransform27.SetAsLastSibling();

		}
	}
}
