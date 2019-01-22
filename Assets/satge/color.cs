using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color : MonoBehaviour {
    public GameObject TextPrefab; // A text element to display when the player is in reach of the door
    [HideInInspector] public GameObject TextPrefabInstance; // A copy of the text prefab to prevent data corruption
    [HideInInspector] public bool TextActive;
    public float Reach = 4.0F;
    [HideInInspector] public bool InReach;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0F));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Reach))
        {
            if (hit.collider.tag == "Object")
            {
                InReach = true;
                if (Input.GetKey("e"))
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                }
            }else{
            InReach = false;

            // Destroy the UI element when Player is no longer in reach of the door
            if (TextActive == true)
            {
                DestroyImmediate(TextPrefabInstance);
                TextActive = false;
            }
        }
        }else
        {
            InReach = false;

            // Destroy the UI element when Player is no longer in reach of the door
            if (TextActive == true)
            {
                DestroyImmediate(TextPrefabInstance);
    TextActive = false;
            }
        }
    }

    public bool GetColor(){
        if (this.gameObject.GetComponent<Renderer>().material.color == Color.red)
        {
            return true;
        }else{
            return false;
        }
    }

}
