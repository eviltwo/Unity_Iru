using UnityEngine;
using System.Collections;

public class FlagManager : SingletonMonoBehaviour<FlagManager> {

	public Flag[] GlobalFlag = new Flag[1];
	public Flag[] Marker = new Flag[1];
	public int FlagID = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addValue(int pos){
		Flag[] newflag = new Flag[GlobalFlag.Length+1];
		for (int i = 0; i <= pos; i++) {
			newflag [i] = GlobalFlag [i];
		}
		newflag [pos + 1].flagname = "";
		newflag [pos + 1].value = 0;
		newflag [pos + 1].id = FlagID;
		FlagID++;
		for (int i = pos+1; i < GlobalFlag.Length; i++) {
			newflag [i+1] = GlobalFlag [i];
		}
		GlobalFlag = newflag;

		slideMarker (pos, true);
	}

	public void deleteValue(int pos){
		if (GlobalFlag.Length > 1) {
			Flag[] newflag = new Flag[GlobalFlag.Length - 1];
			for (int i = 0; i < pos; i++) {
				newflag [i] = GlobalFlag [i];
			}
			for (int i = pos + 1; i < GlobalFlag.Length; i++) {
				newflag [i - 1] = GlobalFlag [i];
			}
			GlobalFlag = newflag;

			slideMarker (pos, false);
		}
	}

	public void addMarker(int pos){
		Flag[] newmarker = new Flag [Marker.Length + 1];
		int just = 0;
		for (int i = 0; i < Marker.Length; i++) {
			if (Marker [i].value == pos) {
				return;
			} else if (Marker [i].value > pos) {
				break;
			} else {
				newmarker [i] = Marker [i];
				just++;
			}
		}
		newmarker [just].flagname = "";
		newmarker [just].value = pos;
		newmarker [just].id = 0;
		for (int i = just; i < Marker.Length; i++) {
			newmarker [i+1] = Marker [i];
		}
		Marker = newmarker;
	}

	public void deleteMarker(int pos){
		Flag[] newmarker = new Flag [Marker.Length - 1];
		int just = 0;
		for (int i = 0; i < Marker.Length; i++) {
			if (Marker [i].value == pos) {
				break;
			} else if (Marker [i].value > pos) {
				return;
			} else {
				newmarker [i] = Marker [i];
				just++;
			}
		}
		for (int i = just+1; i < Marker.Length; i++) {
			newmarker [i-1] = Marker [i];
		}
		Marker = newmarker;
	}

	public void slideMarker(int pos, bool forward){
		for (int i = 0; i < Marker.Length; i++) {
			if (Marker [i].value > pos) {
				if (forward) {
					Marker [i].value += 1;
				} else {
					Marker [i].value -= 1;
				}
			}
		}

	}
}
