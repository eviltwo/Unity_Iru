using UnityEngine;
using System.Collections;

/// <summary>
/// 入力情報を取得する
/// </summary>
public class InputManager : SingletonMonoBehaviour<InputManager> {

	int ClickLevel = 0;						// クリック状態 0:無し 1:初クリック 2:継続(ドラッグの可能性あり)
	Vector2 LastClickPos = Vector2.zero;	// 最後にクリックした位置


	// Update is called once per frame
	void Update (){
		if (Application.platform == RuntimePlatform.Android) {
			checkTouch ();		// スマホクリック判定
		} else {
			checkClick ();		// PCクリック判定
		}
	}

	/// <summary>
	/// スマホ用　クリック判定
	/// </summary>
	void checkTouch(){
		if (Input.touchCount > 0) {	// タッチしている
			// タッチの状態
			switch (ClickLevel) {
			case 0:
				ClickLevel = 1;
				break;
			case 1:
				ClickLevel = 2;
				break;
			default:
				ClickLevel = 1;
				break;
			}
			// タッチ位置を倍数に変換
			LastClickPos = getScreenPixelToMultiple (Input.GetTouch (0).position);
		} else {					// タッチしていない
			ClickLevel = 0;
		}
	}

	/// <summary>
	/// PC用　クリック判定
	/// </summary>
	void checkClick(){
		if (Input.GetKey(KeyCode.Mouse0)) {	// クリックしている
			// クリックの状態
			switch (ClickLevel) {
			case 0:
				ClickLevel = 1;
				break;
			case 1:
				ClickLevel = 2;
				break;
			default:
				ClickLevel = 1;
				break;
			}
			// クリック位置を倍数に変換
			LastClickPos = getScreenPixelToMultiple (Input.mousePosition);
		} else {					// クリックしていない
			ClickLevel = 0;
		}
	}

	/// <summary>
	/// マウス座標をピクセルから倍率に変換(0.0~1.0)
	/// </summary>
	Vector2 getScreenPixelToMultiple(Vector2 pixel){
		Vector2 newpos = new Vector2();
		newpos.x = pixel.x / Screen.width;
		newpos.y = pixel.y / Screen.height;
		Debug.Log (newpos);
		return newpos;
	}

	/// <summary>
	/// クリックしたかどうか
	/// </summary>
	public bool isClick(){
		return ClickLevel == 1;
	}

	/// <summary>
	/// ドラッグ中かどうか
	/// </summary>
	public bool isDrag(){
		return ClickLevel > 0;
	}

	/// <summary>
	/// マウスの位置(最後にクリックした場所)を取得 =0.0~1.0
	/// </summary>
	public Vector2 getMousePosition(){
		return LastClickPos;
	}
}
