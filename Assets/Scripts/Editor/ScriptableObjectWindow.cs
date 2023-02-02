using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;


// TODO: Make a dropdown box for showing the different types of ScriptableObject Classes the project has 
// and from there grab the findAsset code instruction to grab the necessary SO type.
public class ScriptableObjectWindow : EditorWindow
{
    private List<string> _directories;
    private int _selectedDirectoryIndex;
    private Vector2 _scrollPos;
    private string[] _guids = new string[0];
    private int _selectedIndex = -1;

    [MenuItem("Window/Scriptable Object Organizer")]
    static void Init()
    {
        ScriptableObjectWindow window = (ScriptableObjectWindow)EditorWindow.GetWindow(typeof(ScriptableObjectWindow));
        window.Show();
    }


    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();

        // Left side of the window
        EditorGUILayout.BeginVertical(GUILayout.Width(300));
        DisplayScriptableObjectsList();
        EditorGUILayout.EndVertical();

        // Right side of the window
        EditorGUILayout.BeginVertical();
        DisplayScriptableObjectInspector();
        EditorGUILayout.EndVertical();

        EditorGUILayout.EndHorizontal();
    }
    GUIStyle customLabelStyle = new GUIStyle(EditorStyles.label);
    private void DisplayScriptableObjectInspector()
    {
        if (_selectedIndex >= 0 && _selectedIndex < _guids.Length)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(_guids[_selectedIndex]);
            ScriptableObject obj = AssetDatabase.LoadAssetAtPath<ScriptableObject>(assetPath);

            customLabelStyle.fontSize = 20;
            GUILayout.Label(obj.name, customLabelStyle, GUILayout.Height(40));

            
            Editor scriptableObjectEditor = Editor.CreateEditor(obj);
            scriptableObjectEditor.OnInspectorGUI();
        }
    }


    private void DisplayScriptableObjectsList()
    {
        customLabelStyle.fontSize = 15;
        string[] directoriesArray = _directories.ToArray();
        GUILayout.Label("Select a folder:", customLabelStyle);
        _selectedDirectoryIndex = EditorGUILayout.Popup(_selectedDirectoryIndex, directoriesArray);

        
        GUILayout.Label(Path.GetFileName(directoriesArray[_selectedDirectoryIndex]), customLabelStyle);

        if (GUILayout.Button("Load Scriptable Objects"))
        {
            customLabelStyle.fontSize = 13;
            
            string selectedDirectory = _directories[_selectedDirectoryIndex];
            _guids = AssetDatabase.FindAssets("t:VoidEventChannelSO", new[] { selectedDirectory });
            // Load your ScriptableObjects here using the selected path
            Debug.Log(_guids.Length);
            foreach (string guid in _guids)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guid);
                ScriptableObject obj = AssetDatabase.LoadAssetAtPath<ScriptableObject>(assetPath);
                Debug.Log(obj);
            }
        }
        GUILayout.Label("SO List", customLabelStyle);
        _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);

        int index = 0;
        foreach (string guid in _guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            ScriptableObject obj = AssetDatabase.LoadAssetAtPath<ScriptableObject>(assetPath);
            bool selected = index == _selectedIndex;
            selected = EditorGUILayout.ToggleLeft(obj.name, selected);
            if (selected)
            {
                _selectedIndex = index;
            }
            index++;
        }
        EditorGUILayout.EndScrollView();
    }

    private void OnFocus()
    {
        _directories = new List<string>();
        GetDirectories(Application.dataPath, _directories);
    }

    private void GetDirectories(string path, List<string> directories)
    {
        string[] subDirectories = System.IO.Directory.GetDirectories(path);
        for (int i = 0; i < subDirectories.Length; i++)
        {
            subDirectories[i] = subDirectories[i].Replace(Application.dataPath, "Assets");
        }
        directories.AddRange(subDirectories);

        foreach (string subDirectory in subDirectories)
        {
            GetDirectories(subDirectory, directories);
        }
        directories.Sort();
    }
}