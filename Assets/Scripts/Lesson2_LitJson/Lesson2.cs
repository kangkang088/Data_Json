using System.Collections.Generic;
using System.IO;
using Custom.JsonManager;
using LitJson;
using UnityEngine;

public class Student2
{
    public int age;
    public string name;

    public Student2()
    {
    }

    public Student2(int age, string name)
    {
        this.age = age;
        this.name = name;
    }
}

public class MrTang2
{
    public string name;
    public int age;
    public bool sex;
    public float test_f;
    public double test_d;

    public int[] ids;
    public List<int> ids2;
    public Dictionary<string, string> dic;
    public Dictionary<string, string> dic2;

    public Student2 s1;
    public List<Student2> s2s;

    private int private_i;
    protected int protected_i;
}

public class RoleInfo2
{
    public int hp;
    public int speed;
    public int volume;
    public string resName;
    public int scale;
}

public class Lesson2 : MonoBehaviour
{
    private void Start()
    {
        var t = new MrTang2
        {
            name = "唐老师",
            age = 18,
            sex = false,
            test_f = 3.1f,
            test_d = 1.5,
            ids = new[] { 1, 2, 3, 4, 5 },
            ids2 = new List<int> { 1, 2, 3, 4, 5 },
            dic = new Dictionary<string, string> { { "1", "123" }, { "2", "234" } },
            dic2 = new Dictionary<string, string> { { "1", "123" }, { "2", "234" } },
            s1 = null,
            s2s = new List<Student2> { new(2, "小明"), new(3, "小强") }
        };

        var json_str = JsonMapper.ToJson(t);
        File.WriteAllText(Application.streamingAssetsPath + "/MrTang2.json", json_str);

        var obj = JsonMapper.ToObject<MrTang2>(File.ReadAllText(Application.streamingAssetsPath + "/MrTang2.json"));

        json_str = File.ReadAllText(Application.streamingAssetsPath + "/Array.json");

        var array = JsonMapper.ToObject<RoleInfo2[]>(json_str);

        Debug.Log(array[0].hp);

        var dic = JsonMapper.ToObject<Dictionary<string,int>>(File.ReadAllText(Application.streamingAssetsPath + "/Dic.json"));
        Debug.Log(dic["name"]);

        JsonManager.Instance.SaveData(t,"t");

        var tt = JsonManager.Instance.LoadData<MrTang2>("t");

        Debug.Log(tt.name);
    }
}
