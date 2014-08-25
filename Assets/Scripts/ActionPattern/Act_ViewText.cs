using UnityEngine;
using System.Collections;

/// <summary>
/// クリックされたらセリフを出す処理
/// </summary>
public class Act_ViewText : MonoBehaviour {

	public string Text;

	/// <summary>
	/// クリックされた時に呼ばれる
	/// </summary>
	void Clicked(){
		// 文字を表示
		TextManager.Instance.setText (Text);
	}
}
