using UnityEngine;
using System.Collections;

/// <summary>
/// Edit時は見やすい明るさにしておき、実行時はしていした明るさにする。
/// </summary>
public class SmallPowerLight : MonoBehaviour {

	public float Intensity = 0.05f;		// ゲーム中の明るさ

	// Use this for initialization
	void Start () {
		light.intensity = Intensity;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
