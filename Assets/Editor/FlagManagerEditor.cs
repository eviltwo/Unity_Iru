using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor( typeof(FlagManager) )]
public class FlagManagerEditor : Editor {
	public override void OnInspectorGUI(){
		FlagManager fManager = target as FlagManager;
		EditorGUILayout.BeginVertical();
		// フラグ配列の要素数
		string str = "TotalFlag:" + fManager.GlobalFlag.Length;
		EditorGUILayout.LabelField (str);

		for (int i = 0; i < fManager.GlobalFlag.Length; i++) {
			EditorGUILayout.BeginHorizontal();
			fManager.GlobalFlag[i].flagname = EditorGUILayout.TextField(fManager.GlobalFlag[i].flagname);
			GUILayout.Space(20);
			if (GUILayout.Button ("+")) {

			}
			if (GUILayout.Button ("-")) {

			}
			EditorGUILayout.EndHorizontal ();
		}
		EditorGUILayout.EndVertical();
	}

}
