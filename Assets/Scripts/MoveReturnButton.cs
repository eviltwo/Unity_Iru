using UnityEngine;
using System.Collections;

/// <summary>
/// 戻るボタン
/// </summary>
public class MoveReturnButton : MonoBehaviour {
	public Vector2 RectScale = new Vector2();
	void OnGUI(){
		if (MoveManager.Instance.getMoveValue () > 0) {
			Rect rect = new Rect();
			rect.width = Screen.width * RectScale.x;
			rect.height = Screen.height * RectScale.y;
			rect.x = Screen.width/2-rect.width/2;
			rect.y = Screen.height-rect.height;
			if (GUI.Button (rect,"▼")) {
				MoveManager.Instance.prevObj ();
			}
		}
	}
}
