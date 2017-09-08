using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csvRoleInitInfo {
    public int id { get; set; }
    public string name { get; set; }
    public int HP { get; set; }
    public int MP { get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }
    public int Speed { get; set; }
    public float Crit { get; set; }             //暴击概率
    public string description { get; set; }    //角色描述
}
