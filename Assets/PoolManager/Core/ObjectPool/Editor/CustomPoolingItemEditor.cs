using System;
using ObjectPooling;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PoolingItemSO))]
public class CustomPoolingItemEditor : Editor
{
    private SerializedProperty enumNameProp;
    private SerializedProperty poolingNameProp;
    private SerializedProperty descriptionProp;
    private SerializedProperty poolCountProp;
    private SerializedProperty prefabProp;

    private GUIStyle textAreaStyle;
    
    private void OnEnable()
    {
        GUIUtility.keyboardControl = 0;
        StyleSetup();
        enumNameProp = serializedObject.FindProperty("enumName");
        poolingNameProp = serializedObject.FindProperty("poolingName");
        descriptionProp = serializedObject.FindProperty("description");
        poolCountProp = serializedObject.FindProperty("poolCount");
        prefabProp = serializedObject.FindProperty("prefabObject");
    }

    private void StyleSetup()
    {
        if (textAreaStyle == null)
        {
            textAreaStyle = new GUIStyle(EditorStyles.textArea);
            textAreaStyle.wordWrap = true;
            textAreaStyle.active.textColor = Color.white;
        }
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.BeginHorizontal("HelpBox");
        {
            EditorGUILayout.BeginVertical();
            {
                #region EnumName
                EditorGUI.BeginChangeCheck(); // 변경 체크
                string prevName = enumNameProp.stringValue;
                // 엔터가 쳐지거나 포커스가 나갈 때까지 변경 저장 안함
                EditorGUILayout.DelayedTextField(enumNameProp);

                if (EditorGUI.EndChangeCheck())
                {
                    // 현재 편집중인 에셋의 경로
                    string assetPath = AssetDatabase.GetAssetPath(target);
                    string newName = $"Pool_{enumNameProp.stringValue}";
                    serializedObject.ApplyModifiedProperties();
                    
                    string msg = AssetDatabase.RenameAsset(assetPath, newName);
                    
                    // 성공적으로 파일명 변경
                    if (string.IsNullOrEmpty(msg))
                    {
                        target.name = newName;
                        EditorGUILayout.EndVertical();
                        EditorGUILayout.EndHorizontal();
                        return;
                    }
                    
                    enumNameProp.stringValue = prevName;
                }
                #endregion
                
                EditorGUILayout.PropertyField(poolingNameProp);

                #region Description
                EditorGUILayout.BeginVertical("HelpBox");
                {
                    EditorGUILayout.LabelField("Description");
                    
                    descriptionProp.stringValue = 
                        EditorGUILayout.TextArea(descriptionProp.stringValue,  textAreaStyle, GUILayout.Height(60));
                }
                EditorGUILayout.EndVertical();
                #endregion

                EditorGUILayout.BeginHorizontal();
                {
                    EditorGUILayout.PrefixLabel("Pool Settings");
                    EditorGUILayout.PropertyField(poolCountProp, GUIContent.none);
                    EditorGUILayout.PropertyField(prefabProp, GUIContent.none);
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndHorizontal();

        serializedObject.ApplyModifiedProperties();
    }
}
