using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(HexGridLayout))]
public class HexPropertyDrawer : PropertyDrawer {


	public override void OnGUI(Rect position,SerializedProperty property,GUIContent label){
        EditorGUI.PrefixLabel(position,label);
		Rect newposition = position;
		newposition.y += 12f;
		SerializedProperty grid = property.FindPropertyRelative("grid");
		//data.rows[0][]
		for(int j=0;j<grid.arraySize;j++){
			SerializedProperty row = grid.GetArrayElementAtIndex(j).FindPropertyRelative("row");
			newposition.height = 12f;
            /*
			if(row.arraySize != 10)
				row.arraySize = 10;
            */
            //newposition.width = position.width/row.arraySize;
            newposition.width = 12;
            for (int i=0;i<row.arraySize;i++){
				EditorGUI.PropertyField(newposition,row.GetArrayElementAtIndex(i),GUIContent.none);
				newposition.x += newposition.width;
			}

			newposition.x = position.x;
            if(j%2 == 1) {
                newposition.x += newposition.width/2;
            }
			newposition.y += 12f;
		}
	}
	public override float GetPropertyHeight(SerializedProperty property,GUIContent label){
		return 12f * (property.FindPropertyRelative("grid").arraySize + 1);
	}
}
