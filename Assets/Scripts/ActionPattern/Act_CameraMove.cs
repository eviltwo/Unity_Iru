using UnityEngine;
using System.Collections;
/// <summary>
/// カメラを移動させる
/// </summary>
public class Act_CameraMove : MonoBehaviour {
	public Vector3 MovePosition = new Vector3 ();
	public Vector3 MoveAngles = new Vector3 ();
	public float MoveTime = 1.0f;


	GameObject Player;
	GameObject RotX;
	GameObject RotY;
	GameObject RotZ;
	void Start(){
		Player = CameraMoveManager.Instance.Player;
		RotX = CameraMoveManager.Instance.RotX;
		RotY = CameraMoveManager.Instance.RotY;
		RotZ = CameraMoveManager.Instance.RotZ;
	}

	void Clicked(){
		PosRot ps = new PosRot ();
		ps.position = Player.transform.position;
		Vector3 playerangles = new Vector3 ();
		playerangles.x = RotX.transform.localEulerAngles.x;
		playerangles.y = RotY.transform.localEulerAngles.y;
		playerangles.z = RotZ.transform.localEulerAngles.z;
		ps.eulerAngles = playerangles;
		PosRot ns = new PosRot ();
		ns.position = MovePosition;
		ns.eulerAngles = MoveAngles;
		CameraMoveManager.Instance.startMove (ps, ns, MoveTime);
	}
}
