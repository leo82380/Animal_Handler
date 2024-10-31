using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

namespace EasySave.Json
{
    public static class EasyToJson
    {
        private static readonly string LocalPath = Application.dataPath + "/Json/";
        
        public static void CreateJsonFolder()
        {
            if (!Directory.Exists(LocalPath))
            {
                Debug.Log("폴더가 존재하지 않습니다.");
                Debug.Log("폴더를 생성합니다.");
                Directory.CreateDirectory(LocalPath);
                Debug.Log($"저장 경로: {LocalPath}");
            }
        }

        private static string GetFilePath(string fileName)
        {
            return Path.Combine(LocalPath, $"{fileName}.json");
        }
        
        /**
         * <summary>
         * Json 파일로 저장
         * </summary>
         * <param name="obj">Json으로 저장할 객체</param>
         * <param name="jsonFileName">Json 파일 이름</param>
         * <param name="prettyPrint">Json을 보기 좋게 출력할 지 여부</param>
         */
        public static void ToJson<T>(T obj, string jsonFileName, bool prettyPrint = false)
        {
            CreateJsonFolder();
            string path = GetFilePath(jsonFileName);
            string json = JsonUtility.ToJson(obj, prettyPrint);
            File.WriteAllText(path, json);
            Debug.Log(json);
        }
        
        /**
         * <summary>
         * Json 파일을 읽어서 객체로 반환
         * </summary>
         * <param name="jsonFileName">Json 파일 이름</param>
         * <returns>Json 파일을 읽어서 만든 객체</returns>
         */
        public static T FromJson<T>(string jsonFileName)
        {
            string path = GetFilePath(jsonFileName);
            if (!File.Exists(path))
            {
                Debug.Log("파일이 존재하지 않습니다.");
                Debug.Log("파일을 생성합니다.");
                T defaultObj = default;
                ToJson(defaultObj, jsonFileName, true);
                return defaultObj;
            }
            string json = File.ReadAllText(path);
            T obj = JsonUtility.FromJson<T>(json);
            return obj;
        }
        
        /**
         * <summary>
         * List를 Json 파일로 저장
         * </summary>
         * <param name="list">Json으로 저장할 리스트</param>
         * <param name="jsonFileName">Json 파일 이름</param>
         * <param name="prettyPrint">Json을 보기 좋게 출력할 지 여부</param>
         */
        public static void ListToJson<T>(List<T> list, string jsonFileName, bool prettyPrint = false)
        {
            CreateJsonFolder();
            string path = GetFilePath(jsonFileName);
            string json = JsonConvert.SerializeObject(list, prettyPrint ? Formatting.Indented : Formatting.None);
            File.WriteAllText(path, json);
            Debug.Log(json);
        }
        
        /**
         * <summary>
         * Json 파일을 읽어서 List로 반환
         * </summary>
         * <param name="jsonFileName">Json 파일 이름</param>
         * <returns>Json 파일을 읽어서 만든 List</returns>
         */
        public static List<T> ListFromJson<T>(string jsonFileName)
        {
            string path = GetFilePath(jsonFileName);
            if (!File.Exists(path))
            {
                Debug.Log("파일이 존재하지 않습니다.");
                Debug.Log("파일을 생성합니다.");
                List<T> defaultList = new List<T>();
                ListToJson(defaultList, jsonFileName, true);
                return defaultList;
            }
            string json = File.ReadAllText(path);
            List<T> obj = JsonConvert.DeserializeObject<List<T>>(json);
            return obj;
        }

        /**
         * <summary>
         * Dictionary를 Json 파일로 저장
         * </summary>
         * <param name="dictionary">Json으로 저장할 Dictionary</param>
         * <param name="jsonFileName">Json 파일 이름</param>
         * <param name="prettyPrint">Json을 보기 좋게 출력할 지 여부</param>
         */
        public static void DictionaryToJson<T, TU>(Dictionary<T, TU> dictionary, string jsonFileName, bool prettyPrint = false)
        {
            CreateJsonFolder();
            string path = GetFilePath(jsonFileName);
            string json = JsonConvert.SerializeObject(dictionary, prettyPrint ? Formatting.Indented : Formatting.None);
            File.WriteAllText(path, json);
            Debug.Log(json);
        }
        
        /**
         * <summary>
         * Json 파일을 읽어서 Dictionary로 반환
         * </summary>
         * <param name="jsonFileName">Json 파일 이름</param>
         * <returns>Json 파일을 읽어서 만든 Dictionary</returns>
         */
        public static Dictionary<T, TU> DictionaryFromJson<T, TU>(string jsonFileName)
        {
            string path = GetFilePath(jsonFileName);
            if (!File.Exists(path))
            {
                Debug.Log("파일이 존재하지 않습니다.");
                Debug.Log("파일을 생성합니다.");
                Dictionary<T, TU> defaultDic = new Dictionary<T, TU>();
                DictionaryToJson(defaultDic, jsonFileName, true);
                return defaultDic;
            }
            string json = File.ReadAllText(path);
            Dictionary<T, TU> obj = JsonConvert.DeserializeObject<Dictionary<T, TU>>(json);
            Debug.Log(json);
            return obj;
        }
    }
}