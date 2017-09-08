using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global{
    public const string AND = "AND";
    public const string OR = "OR";

    //角色
    public enum Role
    {
        A = 1,
        B = 2,
        C = 3
    }

    //装备
    public enum Equip
    {
        WeaponA,
        WeaponB,
        WeaponC,
        Cloth,
        Shoe
    }

    //装备属性
    public enum EquipProp
    {
        Atk = 1,
        Def = 2,
        Speed = 3
    }

    //消耗品属性
    public enum ConsumProp
    {
        Stone = 0,
        HP = 1,
        MP = 2,
        Crit = 3
    }
}
