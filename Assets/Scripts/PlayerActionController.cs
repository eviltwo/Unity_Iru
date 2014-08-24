using UnityEngine;
using System.Collections;
/// <summary>
/// 瞬発クリックによる探索処理を行う。
/// クリック先のオブジェクトのClicked()を実行させる。
/// </summary>
public class PlayerActionController : MonoBehaviour {

	public GameObject MyCamaera;

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
			// レイを飛ばす準備
			Vector3 mousepos = InputManager.Instance.getMousePixel ();
			Ray ray = new Ray();
			RaycastHit hit = new RaycastHit();
			ray = MyCamaera.camera.ScreenPointToRay(mousepos);
			// レイを飛ばす
			if(Physics.Raycast(ray.origin,ray.direction,out hit,Mathf.Infinity)){
				GameObject obj = hit.collider.gameObject;
				// クリックされたことを知らせる (Clicked()が無くてもエラーは出ない)
				obj.SendMessage ("Clicked",SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
