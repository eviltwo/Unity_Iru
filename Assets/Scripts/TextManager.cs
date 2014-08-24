using UnityEngine;
using System.Collections;

/// <summary>
/// 中央テキスト(主にセリフ)の管理
/// </summary>
public class TextManager : SingletonMonoBehaviour<TextManager> {

	public GameObject TextObject;			// 表示させるためのオブジェクト
	public float ViewTimeMax = 5.0f;		// はっきり見える時間
	public float DeleteTimeMax = 1.0f;		// だんだん消す事にかかる時間

	string Text = "";
	float ViewTime = 0;
	bool IsView = false;
	Color DefaultColor;

	// Use this for initialization
	void Start () {
		DefaultColor = TextObject.guiText.color;
		setText ("");
	}
	
	// Update is called once per frame
	void Update () {
		if (IsView) {
			ViewTime += Time.deltaTime;
			if (ViewTime >= ViewTimeMax) {
				// だんだん消えていく
				float deletetime = ViewTime - ViewTimeMax;
				float mlt = 1 - deletetime / DeleteTimeMax;
				Color newcolor = DefaultColor;
				newcolor.a *= mlt;
				TextObject.guiText.color = newcolor;
				if (ViewTime >= ViewTimeMax + DeleteTimeMax) {
					// 消す
					ViewTime = 0;
					IsView = false;
					TextObject.guiText.enabled = false;
				}
			}
		}
	}

	/// <summary>
	/// テキストを表示する。
	/// </summary>
	public void setText(string text){
		// 表示
		Text = text;
		TextObject.guiText.text = Text;
		// カウントリセット
		TextObject.guiText.color = DefaultColor;
		ViewTime = 0;
		IsView = true;
		TextObject.guiText.enabled = true;
	}

	/// <summary>
	/// テキストを削除する。
	/// </summary>
	public void deleteText(){
		if (IsView) {
			if (ViewTime < ViewTimeMax) {
				ViewTime = ViewTimeMax;
			}
		}
	}
}
