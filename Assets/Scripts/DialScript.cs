using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialScript : MonoBehaviour {
	private int rotX;
	private int rot;
	private float round;
	public bool flag;

	// Use this for initialization
	void Start () {
		rot = (int)this.transform.localEulerAngles.x;
	}
	
	// Update is called once per frame
	void Update () {
		
		rotX = (int)this.transform.localEulerAngles.x;

		float arc = Mathf.DeltaAngle (rot, rotX);

		round = Mathf.Round(Mathf.Abs(arc) / 10) * 10;

		if (round == 60) {
			flag = true;
		} else {
			flag = false;
		}
	}

	public bool DialFlag(){
		return flag;
	}

	public float RotText(){
		return round;
	}
}
