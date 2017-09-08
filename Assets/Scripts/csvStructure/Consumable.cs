using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable :Item {

    public int funcType { get; set; }    //消耗品类型
    public int funcValue { get; set; }      //消耗品数值
    public string description { get; set; }
    public int price { get; set; }
}
