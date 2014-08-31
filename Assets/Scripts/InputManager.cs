using UnityEngine;
using System.Collections;

/// <summary>
/// 入力情報を取得する
/// </summary>
public class InputManager : SingletonMonoBehaviour<InputManager> {

	public float ShortClickTimeMax = 0.3f;	// 一瞬クリックになる判定時間
	public float ShortClickDistMax = 0.1f;	// 一瞬クリックになるマウス移動距離
	public bool EnableControll = true;		// 操作の可・不可

	int ClickLevel = 0;						// クリック状態 0:無し 1:初クリック 2:継続(ドラッグの可能性あり)
	bool IsShortClick = false;				// 一瞬クリックをしたかどうか
	float ShortClickTime = 0;
	Vector2 FirstClickPos = Vector2.zero;	// 最初にクリックした位置
	Vector2 LastClickPos = Vector2.zero;	// 最後にクリックした位置
	Vector2 MouseMoveVec = Vector2.zero;	// マウスが移動した距離


	// Update is called once per frame
	void Update (){
		IsShortClick = false;	// 瞬発クリックを初期化

		// クリック判定
		if (Application.platform == RuntimePlatform.Android) {
			bool click = Input.touchCount > 0;
			Vector2 mousepos = Vector2.zero;
			if (click) {
				mousepos = getScreenPixelToMultiple (Input.GetTouch (0).position);
			}
			checkClick (click, mousepos);		// スマホクリック判定
		} else {
			bool click = Input.GetKey(KeyCode.Mouse0);
			Vector2 mousepos = getScreenPixelToMultiple (Input.mousePosition);
			checkClick (click, mousepos);		// PCクリック判定
		}
	}


	/// <summary>
	/// クリック判定
	/// </summary>
	void checkClick(bool click, Vector2 mousepos){
		if (click && EnableControll) {					// クリックしている
			// クリックの状態
			switch (ClickLevel) {
			case 0:
				ClickLevel = 1;
				FirstClickPos = mousepos;	// 最初のクリック位置
				LastClickPos = mousepos;	// マウス移動量を0にしたいので過去位置＝新位置にしておく
				break;
			case 1:
				ClickLevel = 2;
				break;
			default:
				ClickLevel = 2;
				break;
			}
			// 過去のマウス位置からマウス移動量を計算
			MouseMoveVec = mousepos - LastClickPos;
			// 過去位置として登録
			LastClickPos = mousepos;
			// タッチ時間増加
			ShortClickTime += Time.deltaTime;
		} else {						// クリックしていない
			if (ClickLevel > 0) {
				// クリックが短い・マウス移動距離が短いとき
				if (ShortClickTime <= ShortClickTimeMax && Vector2.Distance(FirstClickPos,LastClickPos) <= ShortClickDistMax) {
					IsShortClick = true;
				}
			}
			ShortClickTime = 0;
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
		return newpos;
	}

	/// <summary>
	/// 一瞬のクリックかどうか
	/// </summary>
	public bool isShortClick(){
		return IsShortClick;
	}

	/// <summary>
	/// ドラッグ中かどうか
	/// </summary>
	public bool isClick(){
		return ClickLevel > 0;
	}

	/// <summary>
	/// マウスの位置(最後にクリックした場所)を取得 =0.0~1.0
	/// </summary>
	public Vector2 getMousePosition(){
		return LastClickPos;
	}

	/// <summary>
	/// マウスの位置(最後にクリックした場所)を取得 ピクセル
	/// </summary>
	public Vector2 getMousePixel(){
		Vector2 pos = LastClickPos;
		pos.x = pos.x * Screen.width;
		pos.y = pos.y * Screen.height;
		return pos;
	}

	/// <summary>
	/// マウスの移動ベクトルを取得
	/// </summary>
	public Vector2 getMouseMove(){
		return MouseMoveVec;
	}

}
