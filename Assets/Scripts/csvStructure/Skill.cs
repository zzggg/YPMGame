using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill {

    public int id { get; set; }                 //技能编号
    public string name { get;set; }             //技能名称
    public int needLv { get; set; }             //升级技能需要等级
    public int lv { get; set; }                 //技能等级
    public string description { get; set; }        //技能描述
    public int cd { get; set; }                 //技能冷却时间
    public int mp { get; set; }                 //耗蓝
}
