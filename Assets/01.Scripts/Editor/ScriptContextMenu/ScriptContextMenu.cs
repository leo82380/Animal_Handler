using UnityEditor;
using UnityEngine;

public static class ScriptContextMenu
{
    [MenuItem("Assets/Create/Create Object With Script", false, 0)]
    private static void CreateObjectWithScript()
    {
        Object selectedObject = Selection.activeObject;

        if (selectedObject is MonoScript monoScript)
        {
            GameObject newObject = new GameObject(monoScript.GetClass().Name);

            newObject.AddComponent(monoScript.GetClass());

            Selection.activeGameObject = newObject;

            EditorGUIUtility.PingObject(newObject);
        }
        else
        {
            Debug.LogError("선택된 오브젝트가 MonoScript가 아닙니다.");
        }
    }

    [MenuItem("Assets/Create/Create Object With Script", true)]
    private static bool ValidateCreateObjectWithScript()
    {
        // 선택된 오브젝트가 MonoScript인지 확인
        return Selection.activeObject is MonoScript;
    }
}