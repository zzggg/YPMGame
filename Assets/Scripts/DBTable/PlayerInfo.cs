using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo  {
    private static PlayerInfo instance;
    private PlayerInfo() { }

    public static PlayerInfo Instance
    {
        get
        {
            if (instance == null) instance = new PlayerInfo();
            return instance;
        }
    }


    public int playerID { get; set; }
	public int level { get; set; }
    public int HP { get; set; }
    public int MP { get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }
    public int Speed { get; set; }
    public float Crit { get; set; }

    public int curHP { get; set; }
    public int curMP { get; set; }
    public int Exp { get; set; }

    //数据库数据映射
    public void init(List<string> list)
    {
        playerID = int.Parse(list[0]);
        level = int.Parse(list[1]);
        HP = int.Parse(list[2]);
        MP = int.Parse(list[3]);
        Atk = int.Parse(list[4]);
        Def = int.Parse(list[5]);
        Speed = int.Parse(list[6]);
        Crit = float.Parse(list[7]);
        curHP = int.Parse(list[8]);
        curMP = int.Parse(list[9]);
        Exp = int.Parse(list[10]);
    }
}
