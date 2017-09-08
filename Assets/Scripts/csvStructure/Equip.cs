using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : Item {
    
    public int prop { get; set; }           //装备类型
    public int propValue { get; set; }      //装备属性值
    public int price { get; set; }
    public string description { get; set; }
}
