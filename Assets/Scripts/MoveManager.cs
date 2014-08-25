using UnityEngine;
using System.Collections;

/// <summary>
/// プレイヤーによる物体の探索を制御する。
/// 画面移動した物体を記憶しており、自由に戻ることが可能。
/// </summary>
public class MoveManager : SingletonMonoBehaviour<MoveManager> {

	ArrayList Moves = new ArrayList();			// 渡ってきたオブジェクトリスト

	/// <summary>
	/// 次のオブジェクトに移る
	/// </summary>
	public void nextObj(GameObject obj){
		Moves.Add (obj);
	}

	/// <summary>
	/// ひとつ前のオブジェクトに戻る
	/// </summary>
	public void prevObj(){
		int last = Moves.Count - 1;
		Moves.RemoveAt (last);
		last -= 1;
		GameObject obj = (GameObject)Moves [last];
		obj.SendMessage ("Returned",SendMessageOptions.DontRequireReceiver);	// 戻ってきたことを知らせる
	}

	/// <summary>
	/// 戻れる数を取得
	/// </summary>
	public int getMoveValue(){
		return Moves.Count;
	}


}
