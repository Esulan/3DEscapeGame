using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchObjectScripts : MonoBehaviour {
	// public float Radius;
	Rigidbody rb;
	public bool flag = false;
	// public float sum;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// 判定エリアに入ったとき
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.name == "Water") {
			// sum += col.GetComponent<Rigidbody>().mass;
			// Debug.Log ("in" + sum);
			flag = true;
		}
	}

	// 判定エリアから出たとき
	void OnTriggerExit (Collider col) {
		if (col.gameObject.name == "Water") {
			// sum -= col.GetComponent<Rigidbody>().mass;
			// Debug.Log ("out" + sum);
			flag = false;
		}
	}

	public bool InnerFlag() {
		return flag;
	}
}
