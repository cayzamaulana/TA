using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailPeserta : MonoBehaviour {

    public Text data;
    public Text ttl;
    public Text provin;

	IEnumerator Start(){
		WWW itemsdata = new WWW("http://somethingnotright.dx.am/detailpeserta.php");
		WWW total = new WWW("http://somethingnotright.dx.am/totalpeserta.php");
		WWW prov = new WWW("http://somethingnotright.dx.am/detailprovinsi.php");
		yield return itemsdata;
		yield return total;
		yield return prov;
		string itemsdatastring = itemsdata.text;
		string itemstotal = total.text;
		string itemsprov = prov.text;
		print (itemsdatastring);
		print (itemstotal);
		print (itemsprov);
		data.text = itemsdatastring;
		ttl.text = itemstotal;
		provin.text = itemsprov;
	}
}
