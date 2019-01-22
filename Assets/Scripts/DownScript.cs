using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownScript : MonoBehaviour {

	CapsuleCollider col;
	public GameObject PlayerHead;
	Vector3 posNew;
	Vector3 posDef;

	// Use this for initialization
	void Start () {
		col = this.GetComponent<CapsuleCollider>();
		posNew = new Vector3(0f, -1.2f, 0f);
		posDef = new Vector3(0f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = PlayerHead.transform.localPosition;
		

		if (Input.GetKey(KeyCode.C)){
			col.center = Vector3.zero;
			col.height = 2f;
			pos = posNew;
		} else {
			col.center = new Vector3(0f, 1f, 0f);
			col.height = 4f;
			pos = posDef;
		}

		PlayerHead.transform.position = pos;
	}
}
