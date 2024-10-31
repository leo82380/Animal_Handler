using System;
using System.IO;
using System.Text;
using ObjectPooling;
using UnityEditor;
using UnityEngine;

public partial class UtilityWindow
{
    private readonly string _poolDirectory = "Assets/08.SO/ObjectPool";
    private PoolingTableSO _poolTable;
    
    /**
     * UtilWindow의 에디터 스타일 설정
     */
    private void EditorStyleSetting()
    {
        _selectTexture = new Texture2D(1, 1); // 1픽셀짜리 텍스쳐 그림
        _selectTexture.SetPixel(0, 0, new Color(0.24f, 0.48f, 0.9f, 0.4f));
        _selectTexture.Apply();

        _selectStyle = new GUIStyle();
        _selectStyle.normal.background = _selectTexture;
        
        _selectTexture.hideFlags = HideFlags.DontSave;
        
        _toolbarItemNames = Enum.GetNames(typeof(UtilType));
        foreach (UtilType type in Enum.GetValues(typeof(UtilType)))
        {
            if (scrollPositions.ContainsKey(type) == false)
                scrollPositions[type] = Vector2.zero;
            if (selectedItem.ContainsKey(type) == false)
                selectedItem[type] = null;
        }
    }

    /**
     * PoolManager의 PoolTable 설정
     */
    private void PoolSetting()
    {
        #region Pool Setting
        if (_poolTable == null)
        {
            _poolTable = AssetDatabase.LoadAssetAtPath<PoolingTableSO>
                ($"{_poolDirectory}/table.asset");
            if (_poolTable == null)
            {
                _poolTable = CreateInstance<PoolingTableSO>();
                string fileName = AssetDatabase.GenerateUniqueAssetPath
                    ($"{_poolDirectory}/table.asset");
                
                AssetDatabase.CreateAsset(_poolTable, fileName);
                Debug.Log($"Create Pooling Table at {fileName}");
            }
        }
        #endregion
    }

    /**
     * PoolManager의 메뉴 설정
     */
    private void PoolMenuSetting()
    {
        #region Pool Menu Set
        //상단에 메뉴 2개를 만들자.
        EditorGUILayout.BeginHorizontal();
        {
            GUI.color = new Color(0.19f, 0.76f, 0.08f);
            if(GUILayout.Button("Generate Item"))
            {
                GeneratePoolItem();
            }

            GUI.color = new Color(0.81f, 0.13f, 0.18f);
            if(GUILayout.Button("Generate enum file"))
            {
                GenerateEnumFile();
            }
        }
        EditorGUILayout.EndHorizontal();
        #endregion
    }

    /**
     * 사각형 정보 알아오기
     */
    private void GetRect(PoolingItemSO item)
    {
        // 마지막으로 그린 사각형 정보를 알아옴
        Rect lastRect = GUILayoutUtility.GetLastRect();

        if (Event.current.type == EventType.MouseDown
            && lastRect.Contains(Event.current.mousePosition)) 
        {
            inspectorScroll = Vector2.zero;
            selectedItem[UtilType.Pool] = item;
            Event.current.Use();
        }
    }

    /**
     * Pool Item 삭제 버튼
     */
    private void PoolItemDeleteButton(PoolingItemSO item)
    {
        #region Delete Button
        EditorGUILayout.BeginVertical();
        {
            EditorGUILayout.Space(10f);
            GUI.color = Color.red;
            if (GUILayout.Button("X", GUILayout.Width(20f)))
            {
                _poolTable.datas.Remove(item);
                AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(item));
                EditorUtility.SetDirty(_poolTable);
                AssetDatabase.SaveAssets();
            }
            GUI.color = Color.white;
        }
        EditorGUILayout.EndVertical();
        #endregion
    }

    /**
     * Pool Table 그리기
     */
    private void DrawPoolTable()
    {
        foreach (PoolingItemSO item in _poolTable.datas)
        {
            // 현재 그릴 item이 선택아이템과 동일하면 스타일 지정
            GUIStyle style = selectedItem[UtilType.Pool] == item
                ? _selectStyle
                : GUIStyle.none;
            EditorGUILayout.BeginHorizontal(style, GUILayout.Height(40f));
            {
                EditorGUILayout.LabelField(item.enumName, 
                    GUILayout.Height(40f), GUILayout.Width(240f));

                PoolItemDeleteButton(item);
                            
            }
            EditorGUILayout.EndHorizontal();
                        
            GetRect(item);
                        
            // 삭제 확인 break;
            if (item == null)
                break;
        }
    }

    /**
     * 인스펙터 그리기
     */
    private void DrawPoolInspector()
    {
        if (selectedItem[UtilType.Pool] != null)
        {
            inspectorScroll = EditorGUILayout.BeginScrollView(inspectorScroll);
            {
                EditorGUILayout.Space(2f);
                Editor.CreateCachedEditor(
                    selectedItem[UtilType.Pool], null, ref _cachedEditor);
                        
                _cachedEditor.OnInspectorGUI();
            }
            EditorGUILayout.EndScrollView();
        }    }
    
    /**
     * 풀 아이템 만들기
     */
    private void GeneratePoolItem()
    {
        Guid guid = Guid.NewGuid(); // 고유한 문자열 키 반환
        
        PoolingItemSO item = CreateInstance<PoolingItemSO>(); // 메모리에만 생성
        item.enumName = guid.ToString();
        
        AssetDatabase.CreateAsset(item, $"{_poolDirectory}/PoolItems/Pool_{item.enumName}.asset");
        _poolTable.datas.Add(item);
        
        EditorUtility.SetDirty(_poolTable);
        AssetDatabase.SaveAssets();
    }
    
    /**
     * Pool Enum 파일 생성
     */
    private void GenerateEnumFile()
    {
        StringBuilder codeBuilder = new StringBuilder();

        foreach (PoolingItemSO item in _poolTable.datas)
        {
            codeBuilder.Append(item.enumName);
            codeBuilder.Append(",");
        }
        
        string code = string.Format(CodeFormat.PoolingTypeFormat, codeBuilder.ToString());
        
        string path = $"{Application.dataPath}/PoolManager/Core/ObjectPool/PoolingType.cs";
        
        
        File.WriteAllText(path, code);
        AssetDatabase.Refresh();
    }
    
    /**
     * 풀 그리기
     */
    private void DrawPoolItems()
    {
        PoolMenuSetting();

        GUI.color = Color.white; //원래 색상으로 복귀.

        EditorGUILayout.BeginHorizontal();
        {
            #region Pooling List
            EditorGUILayout.BeginVertical(EditorStyles.helpBox, GUILayout.Width(300f));
            {
                EditorGUILayout.LabelField("Pooling list");
                EditorGUILayout.Space(3f);
                
                scrollPositions[UtilType.Pool] = EditorGUILayout.BeginScrollView
                (scrollPositions[UtilType.Pool], false, true, 
                    GUIStyle.none, GUI.skin.verticalScrollbar, GUIStyle.none);
                {
                    DrawPoolTable();
                }
                EditorGUILayout.EndScrollView();
            }
            EditorGUILayout.EndVertical();
            #endregion
            
            // 인스펙터 그리기
            DrawPoolInspector();
        }
        EditorGUILayout.EndHorizontal();
    }
}