using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
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
public class MrKang
{
    public string naem;
    public int age;
    public bool sex;
    public float testF;
    public double testD;

    public int[] ids;
    public List<int> ids2;
    public Dictionary<int, string> dic;
    public Dictionary<string, string> dic2;

    public Student s1;
    public List<Student> s2s;
    [SerializeField]
    private int privateI = 1;
    [SerializeField]
    protected int protectedI = 2;
}
public class Lesson1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //File.WriteAllText(Application.persistentDataPath + "/Test.json", "kangkang创建的Json文件");
        //print(Application.persistentDataPath);
        string str = File.ReadAllText(Application.persistentDataPath + "/Test.json");
        print(str);

        MrKang t = new MrKang();
        t.naem = "kangkang";
        t.age = 18;
        t.sex = false;
        t.testF = 1.4f;
        t.testD = 1.4;
        t.ids = new int[] { 1, 2, 3, 4, 5, 6 };
        t.ids2 = new List<int> { 1, 2, 3, 4, 5 };
        t.dic = new Dictionary<int, string> { { 1, "123" }, { 2, "234" } };
        t.dic2 = new Dictionary<string, string> { { "1", "123" }, { "2", "234" } };
        t.s1 = new Student(1, "xiaohong");
        t.s2s = new List<Student> { new Student(2, "xiaoming"), new Student(3, "xiaohang") };
        //JsonUtility提供的将类对象序列化为json字符串的方法
        string jsonString = JsonUtility.ToJson(t);
        File.WriteAllText(Application.persistentDataPath + "/MrKang.json", jsonString);

        jsonString = File.ReadAllText(Application.persistentDataPath + "/MrKang.json");
        MrKang k2 = JsonUtility.FromJson(jsonString, typeof(MrKang)) as MrKang;
        MrKang k3 = JsonUtility.FromJson<MrKang>(jsonString);

        jsonString = File.ReadAllText(Application.streamingAssetsPath + "/RoleInfo.json");
        print(jsonString);
        RoleData roleData = JsonUtility.FromJson<RoleData>(jsonString);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public class RoleData
    {
        public List<RoleInfo> list;
    }
    public class RoleInfo
    {
        public int hp;
        public int speed;
        public int volume;
        public string resName;
        public int scale;
    }
}
