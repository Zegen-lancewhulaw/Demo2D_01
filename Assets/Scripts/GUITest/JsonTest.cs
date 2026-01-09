using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
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
    public List<int> intList;
    public List<Item> itemList;

    public Dictionary<int, Item> itemDic;
    public Dictionary<string, Item> itemDic2;

    [SerializeField]
    private int _privateI = 1;
    [SerializeField]
    protected int _protectedI = 2;
}

public static class Serialization
{
    // json 序列化方法
    public static string SerializeToJson(object? obj, string path, string fileName)
    {
        if (obj == null)
            return string.Empty;

        if(fileName.Length <= 5 || fileName.Substring(fileName.Length - 5, 5) != ".json")
        {
            fileName += ".json";
        }

        string jsonMe = JsonUtility.ToJson(obj, true);
        string absolutePath = path + "/" + fileName;
        File.WriteAllText(absolutePath, jsonMe);

        return absolutePath;
    }

    // json 反序列化方法
    public static T DeserializeFromJson<T>(string? pathName)
    {
        if(string.IsNullOrEmpty(pathName))
            return default(T);

        string jsonMe = File.ReadAllText(pathName);

        return JsonUtility.FromJson<T>(jsonMe);
    }
}

public class JsonTest : MonoBehaviour
{
    private void Start()
    {
        PlayerInfo p = new PlayerInfo();
        p.name = "Test";
        p.atk = 10;
        p.def = 10;
        p.moveSpeed = 1.4f;
        p.roundSpeed = 1.4;

        p.weapon = null;

        p.intList = new List<int>();
        p.intList.Add(1);
        p.intList.Add(2);
        p.intList.Add(3);

        p.itemList = new List<Item>();
        p.itemList.Add(new Item(2, 1));
        p.itemList.Add(new Item(3, 1));
        p.itemList.Add(new Item(4, 2));

        p.itemDic = new Dictionary<int, Item>();
        p.itemDic.Add(0, new Item(1,1));

        p.itemDic2 = new Dictionary<string, Item>();
        p.itemDic2.Add("0", new Item(1,1));

        string destinaton = Serialization.SerializeToJson(p, Application.persistentDataPath, "test.json");

        if (!string.IsNullOrEmpty(destinaton))
        {
            print(destinaton);
            PlayerInfo p1 = Serialization.DeserializeFromJson<PlayerInfo>(destinaton);
            
        }
    }
}
