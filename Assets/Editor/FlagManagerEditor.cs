using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor( typeof(FlagManager) )]
public class FlagManagerEditor : Editor {
	static bool openglobal = true;
	public override void OnInspectorGUI(){
		FlagManager fManager = target as FlagManager;
		EditorGUILayout.BeginVertical();

		// フラグ配列の要素数
		string str = "(" + fManager.GlobalFlag.Length + ")";
		// 折込み表示
		openglobal = EditorGUILayout.Foldout (openglobal, "GlobalFlag " + str);
		if (openglobal) {
			// 要素
			EditorGUILayout.BeginHorizontal ();
			if (GUILayout.Button ("+", GUILayout.Width (25))) {
				fManager.addValue (-1);
			}
			if (GUILayout.Button ("Marker", GUILayout.Width (60))) {
				fManager.addMarker (0);
			}
			EditorGUILayout.EndHorizontal ();
			for (int i = 0; i < fManager.GlobalFlag.Length; i++) {
				// マーカー
				for (int jm = 0; jm < fManager.Marker.Length; jm++) {
					int value = fManager.Marker [jm].value;
					if (value == i) {
						EditorGUILayout.BeginHorizontal ();
						EditorGUILayout.LabelField ("@",GUILayout.Width(16));
						fManager.Marker [jm].flagname = EditorGUILayout.TextField (fManager.Marker [jm].flagname, GUILayout.Width (100));
						GUILayout.Space (5);
						if (GUILayout.Button ("+", GUILayout.Width (25))) {
							fManager.addValue (i);
						}
						if (GUILayout.Button ("-", GUILayout.Width (25))) {
							fManager.deleteMarker (i);
						}
						EditorGUILayout.EndHorizontal ();
						break;
					} else if (jm > i) {
						break;
					}
				}
				// フラグ
				EditorGUILayout.BeginHorizontal ();
				GUILayout.Space (30);
				EditorGUILayout.LabelField (i.ToString(),GUILayout.Width(20));
				EditorGUILayout.LabelField (":",GUILayout.Width(10));
				fManager.GlobalFlag [i].flagname = EditorGUILayout.TextField (fManager.GlobalFlag [i].flagname, GUILayout.Width (100));
				fManager.GlobalFlag [i].value = EditorGUILayout.IntField (fManager.GlobalFlag [i].value, GUILayout.Width (30));
				GUILayout.Space (5);
				if (GUILayout.Button ("+", GUILayout.Width (25))) {
					fManager.addValue (i);
				}
				if (GUILayout.Button ("-", GUILayout.Width (25))) {
					fManager.deleteValue (i);
				}
				if (GUILayout.Button ("Marker", GUILayout.Width (60))) {
					fManager.addMarker (i);
				}
				EditorGUILayout.LabelField ("ID:" + fManager.GlobalFlag [i].id, GUILayout.Width (30));
				EditorGUILayout.EndHorizontal ();
			}
		}
		EditorGUILayout.EndVertical();
	}

}
