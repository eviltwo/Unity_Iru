using UnityEngine;
using System.Collections;

/// <summary>
/// プレイヤーの角度を記憶する
/// カメラ戻ってくる用
/// </summary>
public class Act_PlayerRoot : MonoBehaviour {

	public float MoveTime = 1.0f;

	PosRot CameraRoot;
	GameObject Player;
	GameObject RotX;
	GameObject RotY;
	GameObject RotZ;
	// Use this for initialization
	void Start () {
		MoveManager.Instance.nextObj (this.gameObject);

		Player = CameraMoveManager.Instance.Player;
		RotX = CameraMoveManager.Instance.RotX;
		RotY = CameraMoveManager.Instance.RotY;
		RotZ = CameraMoveManager.Instance.RotZ;
	}
	
	// Update is called once per frame
	void Update () {
		// カメラが探索移動していないとき
		if (MoveManager.Instance.getMoveValue () == 0 && InputManager.Instance.EnableControll) {
			CameraRoot = GetComponent<PlayerCameraController> ().getPosRot ();
		}
	}

	// 戻ってきた時、カメラ移動
	void Returned(){
		PosRot ps = new PosRot ();
		ps.position = Player.transform.position;
		Vector3 playerangles = new Vector3 ();
		playerangles.x = RotX.transform.localEulerAngles.x;
		playerangles.y = RotY.transform.localEulerAngles.y;
		playerangles.z = RotZ.transform.localEulerAngles.z;
		ps.eulerAngles = playerangles;
		CameraMoveManager.Instance.startMove (ps, CameraRoot, MoveTime);
	}
}
