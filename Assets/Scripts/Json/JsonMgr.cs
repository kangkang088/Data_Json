using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using LitJson;

public enum E_Json_Type
{
    JsonUtility,
    LitJson
}
public class JsonMgr
{
    private static JsonMgr instance = new JsonMgr();
    public static JsonMgr Instance => instance;
    private JsonMgr()
    {
    }
    public void SaveData(object data, string fileName, E_Json_Type jsonType = E_Json_Type.LitJson)
    {
        string path = Application.persistentDataPath + "/" + fileName + ".json";
        string jsonStr = "";
        switch (jsonType)
        {
            case E_Json_Type.JsonUtility:
                jsonStr = JsonUtility.ToJson(data);
                break;
            case E_Json_Type.LitJson:
                jsonStr = JsonMapper.ToJson(data);
                break;
            default:
                break;
        }
        File.WriteAllText(path, jsonStr);
    }
    public T LoadData<T>(string fileName, E_Json_Type jsonType = E_Json_Type.LitJson) where T : new()
    {
        //先加载默认资源文件夹
        string path = Application.streamingAssetsPath + "/" + fileName + ".json";
        //再去找游戏运行时的加载资源
        if (!File.Exists(path))
            path = Application.persistentDataPath + "/" + fileName + ".json";
        //两个文件都没有
        if (!File.Exists(path))
            return new T();
        string jsonStr = File.ReadAllText(path);
        T data = default(T);
        switch (jsonType)
        {
            case E_Json_Type.JsonUtility:
                data = JsonUtility.FromJson<T>(jsonStr);
                break;
            case E_Json_Type.LitJson:
                data = JsonMapper.ToObject<T>(jsonStr);
                break;
        }
        return data;
    }
}
