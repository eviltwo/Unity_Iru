using UnityEngine;
using System.Collections;
[System.Serializable]
public struct Flag {
	public string flagname;	// フラグ名
	public int value;		// 値
	public int id;			// フラグID(フラグの順番が上下してもIDは変わらない)
}
