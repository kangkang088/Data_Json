using System;
using System.IO;
using LitJson;
using UnityEngine;

namespace Custom.JsonManager
{
    public enum Json_Type
    {
        JsonUtility,
        LitJson
    }

    public class JsonManager
    {
        private static JsonManager instance = new();

        public static JsonManager Instance => instance;

        private JsonManager()
        {
        }

        public void SaveData(object data, string file_name, Json_Type json_type = Json_Type.LitJson)
        {
            var path = Application.persistentDataPath + "/" + file_name + ".json";

#if UNITY_EDITOR
            Debug.Log(path);
#endif

            var json_str = json_type switch
            {
                Json_Type.JsonUtility => JsonUtility.ToJson(data),
                Json_Type.LitJson => JsonMapper.ToJson(data),
                _ => throw new ArgumentOutOfRangeException(nameof(json_type), json_type, null)
            };

            File.WriteAllText(path, json_str);
        }

        public T LoadData<T>(string file_name, Json_Type json_type = Json_Type.LitJson) where T : new()
        {
            var path = Application.streamingAssetsPath + "/" + file_name + ".json";

            if (!File.Exists(path))
            {
                path = Application.persistentDataPath + "/" + file_name + ".json";
            }

            if (!File.Exists(path))
                return new T();

            var json_str = File.ReadAllText(path);

            var data = default(T);

            switch (json_type)
            {
                case Json_Type.JsonUtility:
                    data = JsonUtility.FromJson<T>(json_str);
                    break;
                case Json_Type.LitJson:
                    data = JsonMapper.ToObject<T>(json_str);
                    break;
            }

            return data;
        }
    }
}
