using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWay : MonoBehaviour {

	public GameObject TargetObj;
	private Vector3 targetPos;

	void Start () {
		TargetObj = GameObject.Find("unitychan");
		targetPos = TargetObj.transform.position;
	}

	void Update() {
		// targetの移動量分、自分も移動する
		transform.position += TargetObj.transform.position - targetPos;
		targetPos = TargetObj.transform.position;

		// マウスの移動量
		float mouseInputX = Input.GetAxis("Mouse X");
		float mouseInputY = Input.GetAxis("Mouse Y");
		// targetの位置のY軸を中心に、回転（公転）する
		transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * 200f);
		// 垂直移動（※角度制限なし、必要が無ければコメントアウト）
		transform.RotateAround(targetPos, transform.right, mouseInputY * Time.deltaTime * 200f);

	} 
}
