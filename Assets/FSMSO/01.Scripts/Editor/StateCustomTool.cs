using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class StateCustomTool : EditorWindow
{
    private string stateName;
    private bool includeEnter = true;
    private bool includeUpdate = true;
    private bool includeExit = true;
    
    private Editor _cachedEditor;
    private ScriptableObject _so;

    [MenuItem("Tools/Create State Script")]
    public static void ShowWindow()
    {
        var window = GetWindow<StateCustomTool>("Create State Script");
        window.minSize = new Vector2(800, 500);
        window.Show();
    }

    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        {
            #region Create
            EditorGUILayout.BeginVertical(GUILayout.Width(380)); // 왼쪽 영역의 고정된 너비 설정
            {
                GUILayout.Label("Create State Script", EditorStyles.boldLabel);
                stateName = EditorGUILayout.TextField("State Name", stateName);
                GUILayout.Space(10);
                includeEnter = EditorGUILayout.Toggle("Include Enter Method", includeEnter);
                includeUpdate = EditorGUILayout.Toggle("Include Update Method", includeUpdate);
                includeExit = EditorGUILayout.Toggle("Include Exit Method", includeExit);
                
                EditorGUILayout.Space(10);

                if (GUILayout.Button("Create Script"))
                {
                    CreateStateScript();
                }
                
                EditorGUILayout.Space(100);

                GUILayout.Space(10);

                #region State Script Template

                GUI.color = new Color(0.8f, 1f, 0.8f);
                EditorGUILayout.BeginVertical("helpbox");
                GUILayout.Label("Existing State Scripts", EditorStyles.boldLabel);
                DirectoryInfo di = new DirectoryInfo(Application.dataPath + "/FSMSO/01.Scripts/StateSOScript");
                if (!di.Exists)
                {
                    Directory.CreateDirectory(Application.dataPath + "/FSMSO/01.Scripts/StateSOScript");
                }
                FileInfo[] files = di.GetFiles("*.cs");
                foreach (var file in files)
                {
                    EditorGUILayout.BeginHorizontal();
                    GUILayout.Label(file.Name);
                    CreateSO(file.Name);
                    DeleteScriptButton(file.Name);
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndVertical();
                GUI.color = Color.white;
                #endregion

                EditorGUILayout.Space(10);

                #region State SO Template

                EditorGUILayout.BeginVertical("helpbox");
                GUILayout.Label("Existing State SOs", EditorStyles.boldLabel);
                di = new DirectoryInfo(Application.dataPath + "/FSMSO/08.SO");
                if (!di.Exists)
                {
                    Debug.LogError("[StateCustomTool] SO Directory not found. Please create the directory.");
                    EditorGUILayout.EndVertical();
                    EditorGUILayout.EndVertical();
                    EditorGUILayout.EndHorizontal();
                    return;
                }
                files = di.GetFiles("*.asset");
                foreach (var file in files)
                {
                    EditorGUILayout.BeginHorizontal();
                    if (GUILayout.Button(file.Name))
                    {
                        _so = AssetDatabase.LoadAssetAtPath<ScriptableObject>("Assets/FSMSO/08.SO/" + file.Name);
                        if (_so != null)
                        {
                            CreateInspector(_so);
                        }
                    }
                    if (_so != null)
                    {
                        DeleteSOButton(_so);
                    }
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndVertical();
                #endregion
                
                
            }
            EditorGUILayout.EndVertical();
            #endregion
            
            if (_so != null)
                DrawVerticalLine(380, 0, 380, position.height);

            #region Inspector
            EditorGUILayout.BeginVertical();
            {
                if (_cachedEditor != null && _so != null)
                {
                    EditorGUILayout.Space(10);
                    _cachedEditor.OnInspectorGUI();
                }
            }
            EditorGUILayout.EndVertical();
            #endregion
        }
        EditorGUILayout.EndHorizontal();
    }

    private void DeleteSOButton(ScriptableObject so)
    {
        if (GUILayout.Button("Delete"))
        {
            Debug.Log($"[StateCustomTool] Deleting {so.name} SO...");
            string assetPath = "Assets/FSMSO/08.SO/" + so.name + ".asset";
            AssetDatabase.DeleteAsset(assetPath);
            _so = null;
            _cachedEditor = null;
            AssetDatabase.Refresh();
        }
    }

    private void DeleteScriptButton(string fileName)
    {
        if (GUILayout.Button("Delete"))
        {
            string scriptPath = Application.dataPath + "/FSMSO/01.Scripts/StateSOScript/" + fileName;
            Debug.Log($"[StateCustomTool] Deleting {fileName} script...");
            File.Delete(scriptPath);
            AssetDatabase.Refresh();
        }
    }

    private void CreateInspector(ScriptableObject so)
    {
        if (_cachedEditor != null)
        {
            DestroyImmediate(_cachedEditor);
        }

        _cachedEditor = Editor.CreateEditor(so);
    }

    private void CreateStateScript()
    {
        if (string.IsNullOrEmpty(stateName))
        {
            Debug.LogError("[StateCustomTool] State Name is empty");
            return;
        }

        string enterMethod = includeEnter ? StateBase.GenerateMethod("Enter") : "";
        string updateMethod = includeUpdate ? StateBase.GenerateMethod("UpdateState") : "";
        string exitMethod = includeExit ? StateBase.GenerateMethod("Exit") : "";
        string stateEnumName = "";
        for (int i = 0; i < 4; i++)
        {
            StateEnum stateEnum = (StateEnum) i;
            if (stateName.Contains(stateEnum.ToString()))
            {
                stateEnumName = stateEnum.ToString();
                break;
            }
        }
        

        string script = string.Format(StateBase.stateScriptTemplate, stateName, enterMethod, updateMethod, exitMethod, stateEnumName);
        string scriptPath = Application.dataPath + "/FSMSO/01.Scripts/StateSOScript/" + stateName + "State.cs";
        if (!Directory.Exists(Application.dataPath + "/FSMSO/01.Scripts/StateSOScript"))
        {
            Debug.Log("[StateCustomTool] Directory not found. Creating directory...");
            Directory.CreateDirectory(Application.dataPath + "/FSMSO/01.Scripts/StateSOScript");
        }
        File.WriteAllText(scriptPath, script);
        AssetDatabase.Refresh();
    }

    private void CreateSO(string fileName)
    {
        if (GUILayout.Button("Create SO"))
        {
            string soName = fileName.Replace(".cs", "");
            string soPath = "Assets/FSMSO/08.SO/" + soName + ".asset";
            if (!Directory.Exists("Assets/FSMSO/08.SO"))
            {
                Debug.Log("[StateCustomTool] SO Directory not found. Creating directory...");
                Directory.CreateDirectory("Assets/FSMSO/08.SO");
            }
            ScriptableObject so = CreateInstance(soName);
            AssetDatabase.CreateAsset(so, soPath);

            foreach (var enumName in Enum.GetNames(typeof(StateEnum)))
            {
                if (soName.Contains(enumName))
                {
                    so.GetType().GetField("StateEnum").SetValue(so, Enum.Parse(typeof(StateEnum), enumName));
                    break;
                }
            }
            AssetDatabase.Refresh();
        }
    }
    
    private void DrawVerticalLine(float x1, float y1, float x2, float y2)
    {
        // 수직선 그리기
        Handles.BeginGUI();
        Handles.color = Color.black;
        Handles.DrawLine(new Vector3(x1, y1), new Vector3(x2, y2));
        Handles.EndGUI();
    }
}
