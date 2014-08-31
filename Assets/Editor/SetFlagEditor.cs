using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor( typeof(Act_SetFlag) )]
public class SetFlagEditor : Editor {

	public override void OnInspectorGUI(){
		FlagManager fManager = FlagManager.Instance;
		/*
		EditorGUILayout.LabelField (FlagManager.Instance.GlobalFlag.Length.ToString());
		fManager.GlobalFlag[0] = EditorGUILayout.IntSlider (fManager.GlobalFlag[0], 0, 20);
		*/

	}
}
