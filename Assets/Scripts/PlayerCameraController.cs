//
// プレイヤーカメラの動き
// ドラッグで視点移動
//
using UnityEngine;
using System.Collections;

public class PlayerCameraController : MonoBehaviour {

	public GameObject RotX;			// 関節の読み込み
	public GameObject RotY;
	public GameObject RotZ;
	public GameObject Camera;		// 子カメラ
	public float PlayerHeight = 1.6f;	// 身長


	// Use this for initialization
	void Start () {
		setViewHeight();	// 身長を反映
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// 身長を反映
	void setViewHeight(){
		Vector3 pos = RotX.transform.localPosition;
		pos.y = PlayerHeight;
		RotX.transform.localPosition = pos;
	}
}
