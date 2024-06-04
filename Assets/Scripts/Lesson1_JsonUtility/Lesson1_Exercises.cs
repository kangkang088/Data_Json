using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int id;
    public int num;
    public Item(int id, int num)
    {
        this.id = id;
        this.num = num;
    }
}
public class PlayerInfo
{
    public string name;
    public int atk;
    public int def;
    public float moveSpeed;
    public double roundSpeed;
    public Item weapon;
    public List<int> listInt;
    public List<Item> itemList;
    public Dictionary<int, Item> itemDic;
    public Dictionary<string, Item> itemDic2;
    [SerializeField]
    private int privateI = 1;
    [SerializeField]
    protected int protectedI = 2;
}
public class Lesson1_Exercises : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerInfo player = new PlayerInfo();
        player.name = "kangkang";
        player.atk = 12;
        player.def = 5;
        player.moveSpeed = 20.5f;
        player.roundSpeed = 21.4f;
        player.weapon = new Item(1, 1);
        player.listInt = new List<int>() { 1, 2, 3, 4, 5 };
        player.itemList = new List<Item> { new Item(1, 99), new Item(2, 22) };
        player.itemDic = new Dictionary<int, Item> { { 3, new Item(3, 33) }, { 4, new Item(4, 44) } };
        player.itemDic2 = new Dictionary<string, Item> { { "3", new Item(3, 33) }, { "4", new Item(4, 44) } };

        SaveData(player,"PlayerInfo");

        PlayerInfo player2 = LoadData("PlayerInfo");
    }
    private void SaveData(PlayerInfo player,string pathName)
    {
        string jsonStr = JsonUtility.ToJson(player);
        File.WriteAllText(Application.persistentDataPath + "/" + pathName + ".json", jsonStr);
        print(Application.persistentDataPath);
    }
    private PlayerInfo LoadData(string fileName)
    {
        string jsonStr = File.ReadAllText(Application.persistentDataPath + "/" + fileName + ".json");
        return JsonUtility.FromJson<PlayerInfo>(jsonStr);
    }
}
