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

    // 序列化方法
    public void Serialize(string path)
    {
        if(path.Substring(path.Length - 5, 5) != ".json")
        {
            MonoBehaviour.print("传入的文件格式不是\".json\"，已选择默认路径：" + Application.persistentDataPath + "/" + this.name + ".json");
            Serialize();
            return;
        }
        string jsonMe = JsonUtility.ToJson(this);
        File.WriteAllText(path, jsonMe);
    }

    public void Serialize()
    {
        Serialize(Application.persistentDataPath + "/" + this.name + ".json");
    }

    // 反序列化方法
    public static PlayerInfo Deserialize(string path)
    {
        string jsonMe = File.ReadAllText(path);
        return JsonUtility.FromJson<PlayerInfo>(jsonMe);
    }
}

public class JsonTest : MonoBehaviour
{
    private void Start()
    {
        print("");
    }
}
