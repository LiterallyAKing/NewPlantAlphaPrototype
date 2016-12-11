using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SortingLayerScript))]
class SortingLayerScriptEditor : Editor {

	public override void OnInspectorGUI (){
		SortingLayerScript sortingscript = (SortingLayerScript)target;
		base.OnInspectorGUI ();
		if(GUILayout.Button("Sort")) {
			sortingscript.AssignSortingLayers ();
		}
	}
}