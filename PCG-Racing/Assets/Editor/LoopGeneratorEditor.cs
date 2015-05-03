using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(LoopGenerator))]
public class LoopGeneratorEditor : Editor {
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();
	}
}
