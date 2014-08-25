using UnityEngine;
using System.Collections;

/// <summary>
/// 自分のオブジェクトに移動したことを伝える処理
/// </summary>
public class Act_MoveObj : MonoBehaviour {

	// クリックされたら自分を登録
	void Clicked(){
		MoveManager.Instance.nextObj (this.gameObject);
	}

}
