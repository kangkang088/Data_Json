using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

[Serializable]
public class Student
{
    public int age;
    public string name;

    public Student(int age, string name)
    {
        this.age = age;
        this.name = name;
    }
}

public class MrTang
{
    public string name;
    public int age;
    public bool sex;
    public float test_f;
    public double test_d;

    public int[] ids;
    public List<int> ids2;
    public Dictionary<int, string> dic;
    public Dictionary<string, string> dic2;

    public Student s1;
    public List<Student> s2s;

    [SerializeField] private int private_i;
    [SerializeField] protected int protected_i;
}

[Serializable]
public class RoleInfo
{
    public int hp;
    public int speed;
    public int volume;
    public string resName;
    public int scale;
}

public class RoleData
{
    public List<RoleInfo> list;
}

public class Lesson1 : MonoBehaviour
{
    private void Start()
    {
        print(Application.persistentDataPath);

        var t = new MrTang
        {
            name = "唐老师",
            age = 18,
            sex = false,
            test_f = 3.1f,
            test_d = 1.5,
            ids = new[] { 1, 2, 3, 4, 5 },
            ids2 = new List<int> { 1, 2, 3, 4, 5 },
            dic = new Dictionary<int, string> { { 1, "123" }, { 2, "234" } },
            dic2 = new Dictionary<string, string> { { "1", "123" }, { "2", "234" } },
            s1 = null,
            s2s = new List<Student> { new(2, "小明"), new(3, "小强") }
        };

        var json_str = JsonUtility.ToJson(t);

        File.WriteAllText(Application.streamingAssetsPath + "/MrTang.json", json_str);

        var json_object = JsonUtility.FromJson<MrTang>(File.ReadAllText(Application.streamingAssetsPath + "/MrTang.json"));
        Debug.Log(json_object.test_f);

        try
        {
            json_str = File.ReadAllText(Application.streamingAssetsPath + "/RoleInfo.json");
            var role_data = JsonUtility.FromJson<RoleData>(json_str);
            Debug.Log(role_data.list[0].hp);

        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }

#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }
}
