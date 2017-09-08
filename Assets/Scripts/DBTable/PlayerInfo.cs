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
}
