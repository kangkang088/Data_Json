using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

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
public class MrKang2
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
    
    private int privateI = 1;
    
    protected int protectedI = 2;
}
public class Lesson2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MrKang2 t = new MrKang2();
        t.naem = "kangkang";
        t.age = 18;
        t.sex = false;
        t.testF = 1.4f;
        t.testD = 1.4;
        t.ids = new int[] { 1, 2, 3, 4, 5, 6 };
        t.ids2 = new List<int> { 1, 2, 3, 4, 5 };
        t.dic = new Dictionary<int, string> { { 1, "123" }, { 2, "234" } };
        t.dic2 = new Dictionary<string, string> { { "1", "123" }, { "2", "234" } };
        t.s1 = null;
        t.s2s = new List<Student> { new Student(2, "xiaoming"), new Student(3, "xiaohang") };
        //LitJson提供的将类对象序列化为json字符串的方法
        string jsonString = JsonMapper.ToJson(t);
        File.WriteAllText(Application.persistentDataPath + "/MrKang2.json", jsonString);

        jsonString = File.ReadAllText(Application.productName + "/MrKang.json");
        JsonData data = JsonMapper.ToObject(jsonString);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public class RoleData2
    {
        public List<RoleInfo2> list;
    }
    public class RoleInfo2
    {
        public int hp;
        public int speed;
        public int volume;
        public string resName;
        public int scale;
    }
}
