using UnityEngine;
using System.Collections;

/// <summary>
/// カメラの向きを制御する
/// </summary>
public class PlayerCameraController : MonoBehaviour {

	public Vector2 RotSpeed = new Vector2(3.0f, 3.0f);	// 回転速度
	public GameObject RotX;			// 関節の読み込み
	public GameObject RotY;
	public GameObject RotZ;
	public GameObject Camera;		// 子カメラ


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		rotateCamera ();
	}

	/// <summary>
	/// 入力によるカメラの回転
	/// </summary>
	void rotateCamera(){
		if (InputManager.Instance.isClick()) {
			Vector2 move = InputManager.Instance.getMouseMove ();
			RotX.transform.Rotate (new Vector3 (move.y * RotSpeed.y, 0, 0));
			RotY.transform.Rotate (new Vector3 (0, -move.x * RotSpeed.x, 0));
		}
	}

}
