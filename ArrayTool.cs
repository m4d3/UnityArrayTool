using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Examples;

public class ArrayTool : EditorWindow
{
    [MenuItem("Window/ArrayTool")]
    private static void Create() {
        ArrayTool window = (ArrayTool)GetWindow(typeof(ArrayTool));
    }

    private Vector3 _axis;
    private int _count = 0;
    private float _spacing = 0.0f;
    private List<GameObject> _objs;
    private GameObject[] _selection;

	// Use this for initialization
	void Start () {
		_objs = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI() {
        EditorGUILayout.BeginVertical();

        _axis = EditorGUILayout.Vector3Field("Direction: ", _axis);
        EditorGUI.BeginChangeCheck();
        _count = EditorGUILayout.IntField("Amount: ", _count);
        _spacing = EditorGUILayout.FloatField("Spacing: ", _spacing);
        if (EditorGUI.EndChangeCheck())
        {
            _selection = Selection.gameObjects;
            foreach (GameObject o in _objs)
            {
                DestroyImmediate(o);
            }
            _objs = new List<GameObject>();
            foreach (GameObject o in _selection)
            {
                for (int i = 0; i < _count; i++)
                {
                    GameObject newObj = (GameObject)Instantiate(o, o.transform.position + _axis * _spacing * i, o.transform.rotation);
                    _objs.Add(newObj);
                }
            }
        }

        if (GUILayout.Button("Delete Array"))
        {
            foreach (GameObject o in _objs) {
                DestroyImmediate(o);
            }
            _objs = new List<GameObject>();
        }

        EditorGUILayout.EndVertical();
    }
}
