using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginalOpenDoorScript : MonoBehaviour {

	private Animator anim;
	private bool flag = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider col) {
		if (col.tag == "Player" && flag == false) {
			anim.SetBool ("open", true);
			flag = true;
		}
	}

	void OnTriggerExit (Collider col) {
		if (col.tag == "Player" && flag == true) {
			anim.SetBool ("open", false);
			flag = false;
		}
	}

}
