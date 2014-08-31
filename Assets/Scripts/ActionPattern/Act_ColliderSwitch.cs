using UnityEngine;
using System.Collections;

public class Act_ColliderSwitch : MonoBehaviour {

	public GameObject[] ClickedEnableColliders;
	public GameObject[] ClickedDisableColliders;
	public GameObject[] LeaveEnableColliders;
	public GameObject[] LeaveDisableColliders;


	void Clicked(){
		// 表示するCollider
		for (int i = 0; i < ClickedEnableColliders.Length; i++) {
			ClickedEnableColliders [i].collider.enabled = true;
		}
		// 非表示にするCollider
		for (int i = 0; i < ClickedDisableColliders.Length; i++) {
			ClickedDisableColliders [i].collider.enabled = false;
		}
	}

	void Leave(){
		// 表示するCollider
		for (int i = 0; i < LeaveEnableColliders.Length; i++) {
			LeaveEnableColliders [i].collider.enabled = true;
		}
		// 非表示にするCollider
		for (int i = 0; i < LeaveDisableColliders.Length; i++) {
			LeaveDisableColliders [i].collider.enabled = false;
		}
	}
}
