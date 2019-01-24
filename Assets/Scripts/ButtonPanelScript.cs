using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPanelScript : MonoBehaviour {
	
	public ArrayList buttonList;
	string buttonText = "";
	public bool sw = false;

	public bool flag = false;


	// Use this for initialization
	void Start () {
		buttonList = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ButtonPush(string s) {
		if(buttonText != "1658") {
			buttonList.Add(s);
			sw = true;
			if(sw == true){
				if(buttonText.Length >= 4) {
					buttonText = "";
				}
				for (int i = 0; i < buttonList.Count; i++){
					buttonText += buttonList[i];
				}
				this.GetComponent<TextMesh>().text = buttonText.ToString();
			}
			buttonList.Clear();
			if(buttonText == "1658") {
				this.GetComponent<TextMesh>().color = Color.green;
				flag = true;
			}
		} else {
			flag = true;
		}
	}

	public void UnButtonPush() {
		sw = false;
	}

	public bool PanelFlag() {
		return flag;
	}
}
