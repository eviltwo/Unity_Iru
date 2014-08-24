using UnityEngine;
using System.Collections;

public class GlobalObject : MonoBehaviour {

	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}
}
