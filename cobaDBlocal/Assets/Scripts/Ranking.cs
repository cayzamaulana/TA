using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour {

    public Text data;

	IEnumerator Start(){
		WWW itemsdata = new WWW("http://somethingnotright.dx.am/ranking.php");
		yield return itemsdata;
		string itemsdatastring = itemsdata.text;
		print (itemsdatastring);
		data.text = itemsdatastring;
	}
}
