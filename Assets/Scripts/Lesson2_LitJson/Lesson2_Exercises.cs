using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class Item2
{
    public int id;
    public int num;

    public Item2()
    {
    }

    public Item2(int id, int num)
    {
        this.id = id;
        this.num = num;
    }
}
public class PlayerInfo2
{
    public string name;
    public int atk;
    public int def;
    public float moveSpeed;
    public double roundSpeed;
    public Item2 weapon;
    public List<int> listInt;
    public List<Item2> itemList;
    public Dictionary<string, Item2> itemDic2;
}
public class Lesson2_Exercises : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerInfo2 player = new PlayerInfo2();
        player.name = "kangkang";
        player.atk = 12;
        player.def = 5;
        player.moveSpeed = 20.5f;
        player.roundSpeed = 21.4f;
        player.weapon = new Item2(1, 1);
        player.listInt = new List<int>() { 1, 2, 3, 4, 5 };
        player.itemList = new List<Item2> { new Item2(1, 99), new Item2(2, 22) };
        player.itemDic2 = new Dictionary<string, Item2> { { "3", new Item2(3, 33) }, { "4", new Item2(4, 44) } };
        JsonMgr.Instance.SaveData(player,"PlayerInfo3",E_Json_Type.LitJson);
        PlayerInfo2 player2 = JsonMgr.Instance.LoadData<PlayerInfo2>("PlayerInfo3");
    }
    private void SaveData(PlayerInfo2 player, string pathName)
    {
        string jsonStr = JsonMapper.ToJson(player);
        File.WriteAllText(Application.persistentDataPath + "/" + pathName + ".json", jsonStr);
        print(Application.persistentDataPath);
    }
    private PlayerInfo2 LoadData(string fileName)
    {
        string jsonStr = File.ReadAllText(Application.persistentDataPath + "/" + fileName + ".json");
        return JsonMapper.ToObject<PlayerInfo2>(jsonStr);
    }
}
