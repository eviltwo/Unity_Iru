using UnityEngine;
using System.Collections;

public class TableTopClicked : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// クリックされた時に呼ばれる
	/// </summary>
	void Clicked(){
		// 文字を表示
		TextManager.Instance.setText ("木のテーブルだ。\nかなり古い。");
	}
}
