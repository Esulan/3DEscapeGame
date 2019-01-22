using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectContorller : MonoBehaviour {			// プレイヤー追従カメラ

	[SerializeField] private float turnSpeed;   		// 回転速度
	[SerializeField] private float turnAroundSpeed;

	public GameObject player;          // 注視対象プレイヤー

	private Vector3 targetPos;			//対象の位置

	private Quaternion vRotation;      // カメラの垂直回転(見下ろし回転)
	private Quaternion hRotation;      // カメラの水平回転

	private float maxAngleY; // 最大回転角度
	private float minAngleY; // 最小回転角度
	[SerializeField] private float maxAngleX; // 最大回転角度
	[SerializeField] private float minAngleX; // 最小回転角度

	private float rotateX;
	private float rotateY;


	void Start ()
	{
		// 回転の初期化
		vRotation = Quaternion.identity;         		// 垂直回転(X軸を軸とする回転)は、無回転
		hRotation = Quaternion.identity;                // 水平回転(Y軸を軸とする回転)は、無回転
		transform.rotation = hRotation * vRotation;     // 最終的なカメラの回転は、垂直回転してから水平回転する合成回転

		targetPos = player.transform.position;			//対象の位置
	}

	void Update ()
	{

		// targetの移動量分、自分（カメラ）も移動する
		transform.position += player.transform.position - targetPos;
		targetPos = player.transform.position;


		// 現在の回転角度を0～360から-180～180に変換
		if (transform.eulerAngles.y > 180) {
			rotateY = transform.eulerAngles.y - 360;
		} else {
			rotateY = transform.eulerAngles.y;
		}

		if (transform.eulerAngles.x > 180) {
			rotateX = transform.eulerAngles.x - 360;
		} else {
			rotateX = transform.eulerAngles.x;
		}


		// 現在の回転角度に入力(turn)を加味した回転角度をMathf.Clamp()を使いminAngleからMaxAngle内に収まるようにする
		float angleY = Mathf.Clamp(rotateY + Input.GetAxis("Mouse X") * turnSpeed, minAngleY, maxAngleY);
		float angleX = Mathf.Clamp(rotateX + Input.GetAxis("Mouse Y") * turnSpeed, minAngleX, maxAngleX);


		// 回転の更新
		/*
		if (Input.GetMouseButton (0)) {			
			hRotation *= Quaternion.Euler (0, Input.GetAxis ("Mouse X") * turnSpeed, 0);
			vRotation *= Quaternion.Euler (Input.GetAxis ("Mouse Y") * turnSpeed, 0, 0);
		}
		*/
		// 回転角度をオブジェクトに適用

		//hRotation = Quaternion.Euler (0, angleY, 0);
		hRotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * turnSpeed, 0);
		vRotation = Quaternion.Euler (angleX, 0, 0);
		// targetの位置のY軸を中心に、回転（公転）する
		transform.RotateAround(player.transform.position, Vector3.up, Input.GetAxis("Mouse X") * turnAroundSpeed);


		// カメラの回転(transform.rotation)の更新
		// 垂直回転してから水平回転する合成回転とする
		transform.rotation = hRotation * vRotation;

	}
}

