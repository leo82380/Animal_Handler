using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class AutoSaveOnPlay
{
    static AutoSaveOnPlay()
    {
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange obj)
    {
        if (obj == PlayModeStateChange.ExitingEditMode)
        {
            Debug.Log($"{SceneManager.GetActiveScene().name} Scene saving...");
            EditorSceneManager.SaveOpenScenes();
            AssetDatabase.SaveAssets();
            Debug.Log($"{SceneManager.GetActiveScene().name} Scene saved at {System.DateTime.Now}");
        }
    }
}
