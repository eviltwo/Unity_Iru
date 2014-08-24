using UnityEngine;
using System.Collections;

/// <summary>
/// カメラの向きを制御する
/// </summary>
public class PlayerCameraController : MonoBehaviour {

	public Vector2 RotSpeed = new Vector2(3.0f, 3.0f);	// 回転速度
	public float RotMaxX = 80.0f;						// 上下を向ける限界角度
	public GameObject RotX;			// 関節の読み込み
	public GameObject RotY;
	public GameObject RotZ;
	public GameObject MyCamera;		// 子カメラ
	public float RandomMoveValue = 0.005f;	// Sin派の振れ幅

	float RandomMoveTime = 0;		// Sin波のx軸
	Vector2 RandomMoveWide = new Vector2();	// ランダムで周期を決める

	// Use this for initialization
	void Start () {
		RandomMoveWide.x = Random.Range (0.6f, 1.0f);
		RandomMoveWide.y = Random.Range (0.6f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		rotateCamera ();	// カメラ回転
		rotateRandom ();	// ランダム回転
	}

	/// <summary>
	/// 入力によるカメラの回転
	/// </summary>
	void rotateCamera(){
		if (InputManager.Instance.isClick()) {
			// マウス移動量によりカメラを回転
			Vector2 move = InputManager.Instance.getMouseMove ();
			RotX.transform.Rotate (new Vector3 (move.y * RotSpeed.y, 0, 0));
			RotY.transform.Rotate (new Vector3 (0, -move.x * RotSpeed.x, 0));

			fixRotX ();		// 上下の角度修正
		}
	}

	/// <summary>
	/// ランダム回転で息遣いを表現
	/// </summary>
	void rotateRandom(){
		RandomMoveTime += Time.deltaTime;
		Vector2 move = Vector2.zero;
		move.x = Mathf.Sin (RandomMoveTime*RandomMoveWide.x)*RandomMoveValue;
		move.y = Mathf.Sin (RandomMoveTime*RandomMoveWide.y)*RandomMoveValue;
		RotX.transform.Rotate (new Vector3 (move.y, 0, 0));
		RotY.transform.Rotate (new Vector3 (0, -move.x, 0));

		fixRotX ();		// 上下の角度修正
	}

	/// <summary>
	/// x軸回転の角度限界による角度修正
	/// </summary>
	void fixRotX(){
		// 上下の角度を修正
		Vector3 rot = RotX.transform.localEulerAngles;
		if (rot.x > 180) {
			rot.x -= 360;
		}
		if (rot.x > RotMaxX) {
			rot.x = RotMaxX;
		} else if (rot.x < -RotMaxX) {
			rot.x = -RotMaxX;
		}
		RotX.transform.localEulerAngles = rot;
	}
}
