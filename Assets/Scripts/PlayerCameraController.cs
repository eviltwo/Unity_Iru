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
	public GameObject Camera;		// 子カメラ


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		rotateCamera ();	// カメラ回転
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

}
