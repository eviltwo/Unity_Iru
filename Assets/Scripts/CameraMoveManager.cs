using UnityEngine;
using System.Collections;

/// <summary>
/// カメラの移動モーションを作ってくれる
/// </summary>
public class CameraMoveManager : SingletonMonoBehaviour<CameraMoveManager> {

	public GameObject Player;			// 移動させるカメラ制御オブジェクト
	public GameObject RotX;
	public GameObject RotY;
	public GameObject RotZ;

	PosRot OldState;		// 前の位置・回転
	PosRot NewState;		// 次の位置・回転
	float MoveTime = 0;		// 現在の移動時間
	float MoveTimeMax = 1;	// 最大移動時間
	bool IsMove = false;
	
	// Update is called once per frame
	void Update () {
		if (IsMove) {
			// 時間経過
			MoveTime += Time.deltaTime;
			if (MoveTime >= MoveTimeMax) {
				MoveTime = MoveTimeMax;
				IsMove = false;
			}
			PosRot pr = getStatus ();
			Player.transform.position = pr.position;
			RotX.transform.localEulerAngles = new Vector3(pr.eulerAngles.x,0,0);
			RotY.transform.localEulerAngles = new Vector3(0,pr.eulerAngles.y,0);
			RotZ.transform.localEulerAngles = new Vector3(0,0,pr.eulerAngles.z);
		}
	}

	/// <summary>
	/// 移動を開始する
	/// </summary>
	public void startMove(PosRot old_pr, PosRot new_pr, float time){
		// 登録
		OldState = old_pr;
		NewState = new_pr;
		MoveTimeMax = time;
		// 初期化
		MoveTime = 0;
		IsMove = true;
	}

	/// <summary>
	/// 現在のカメラ状況を取得
	/// </summary>
	public PosRot getStatus(){
		float mlt = MoveTime / MoveTimeMax;
		Vector3 pos = OldState.position + (NewState.position - OldState.position) * mlt;
		Vector3 angles = new Vector3();
		angles.x = Mathf.LerpAngle (OldState.eulerAngles.x, NewState.eulerAngles.x, mlt);
		angles.y = Mathf.LerpAngle (OldState.eulerAngles.y, NewState.eulerAngles.y, mlt);
		angles.z = Mathf.LerpAngle (OldState.eulerAngles.z, NewState.eulerAngles.z, mlt);
		PosRot pr = new PosRot ();
		pr.position = pos;
		pr.eulerAngles = angles;
		return pr;
	}


	/// <summary>
	/// 移動中かどうか
	/// </summary>
	public bool isMove(){
		return IsMove;
	}
}
