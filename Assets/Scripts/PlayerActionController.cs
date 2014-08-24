using UnityEngine;
using System.Collections;
/// <summary>
/// 瞬発クリックによる探索処理を行う。
/// クリック先のオブジェクトのClicked()を実行させる。
/// </summary>
public class PlayerActionController : MonoBehaviour {

	public GameObject Camaera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		checkObject ();		// クリック先のオブジェクトを調べる
	}

	/// <summary>
	/// クリック先のオブジェクトを調べ、Clicked()メッセージを送る。
	/// </summary>
	void checkObject(){
		if (InputManager.Instance.isShortClick ()) {
			Debug.Log ("click");
		}
	}
}
