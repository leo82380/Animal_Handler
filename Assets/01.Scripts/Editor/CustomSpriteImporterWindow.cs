using UnityEngine;
using UnityEditor;

public class CustomSpriteImporterWindow : EditorWindow
{
    private int pixelsPerUnit = 100;
    private SpriteImportMode spriteImportMode = SpriteImportMode.Multiple;
    private FilterMode filterMode = FilterMode.Point;
    private int maxTextureSize = 512;
    private TextureImporterCompression textureCompression = TextureImporterCompression.Uncompressed;
    private int sliceWidth = 32;
    private int sliceHeight = 32;

    [MenuItem("Tools/Custom Sprite Importer #s")]
    public static void ShowWindow()
    {
        var window = GetWindow(typeof(CustomSpriteImporterWindow), false, "Sprite Importer Settings");
        window.minSize = new Vector2(300, 300);
    }

    private void OnGUI()
    {
        GUILayout.Label("Sprite Importer Settings", EditorStyles.boldLabel);

        spriteImportMode = (SpriteImportMode)EditorGUILayout.EnumPopup("Sprite Import Mode", spriteImportMode);
        pixelsPerUnit = EditorGUILayout.IntField("Pixels Per Unit", pixelsPerUnit);
        filterMode = (FilterMode)EditorGUILayout.EnumPopup("Filter Mode", filterMode);
        maxTextureSize = EditorGUILayout.IntField("Max Texture Size", maxTextureSize);
        textureCompression = (TextureImporterCompression)EditorGUILayout.EnumPopup("Texture Compression", textureCompression);
        GUILayout.Space(10);
        GUILayout.Label("Sprite Slicing Settings", EditorStyles.boldLabel);
        sliceWidth = EditorGUILayout.IntField("Slice Width", sliceWidth);
        sliceHeight = EditorGUILayout.IntField("Slice Height", sliceHeight);

        if (GUILayout.Button("Apply to Selected Textures"))
        {
            ApplySettingsToSelectedTextures();
        }
    }

    private void ApplySettingsToSelectedTextures()
    {
        Object[] selectedObjects = Selection.objects;

        foreach (Object obj in selectedObjects)
        {
            string path = AssetDatabase.GetAssetPath(obj);
            TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;

            if (importer != null)
            {
                importer.textureType = TextureImporterType.Sprite;
                importer.spriteImportMode = SpriteImportMode.Multiple;
                importer.spritePixelsPerUnit = pixelsPerUnit;
                importer.filterMode = filterMode;
                importer.maxTextureSize = maxTextureSize;
                importer.textureCompression = textureCompression;

                // Sprite slicing
                Texture2D texture = AssetDatabase.LoadAssetAtPath<Texture2D>(path);
                int columns = texture.width / sliceWidth;
                int rows = texture.height / sliceHeight;

                SpriteMetaData[] metaData = new SpriteMetaData[columns * rows];
                for (int y = 0; y < rows; y++)
                {
                    for (int x = 0; x < columns; x++)
                    {
                        SpriteMetaData spriteMetaData = new SpriteMetaData();
                        spriteMetaData.rect = new Rect(x * sliceWidth, y * sliceHeight, sliceWidth, sliceHeight);
                        spriteMetaData.name = $"{texture.name}_{y * columns + x}";
                        metaData[y * columns + x] = spriteMetaData;
                    }
                }
                importer.spritesheet = metaData;

                AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
            }
        }

        AssetDatabase.Refresh();
    }
}
