using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotTextScript : MonoBehaviour {

	private DialScript dial;
	private GameObject target;
	private string rot;


	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Dial");
		dial = target.GetComponent<DialScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		rot = dial.RotText ().ToString();
		this.GetComponent<TextMesh> ().text = rot;

		if (rot == "60") {
			this.GetComponent<TextMesh> ().color = Color.green;
		} else {
			this.GetComponent<TextMesh> ().color = Color.red;
		}
	}
}
