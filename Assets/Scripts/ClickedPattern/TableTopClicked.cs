using UnityEngine;
using System.Collections;

public class TableTopClicked : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Clicked(){
		TextManager.Instance.setText ("テーブルがある。");
	}
}
