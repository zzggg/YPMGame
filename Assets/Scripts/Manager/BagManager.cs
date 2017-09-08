using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManager  {
    
    //key 编号   value 数量
    public Dictionary<int, int> consumableDic = new Dictionary<int, int>();

    //装备  key -> BagEquip.equipID
    public Dictionary<int, BagEquip> Bag_Equip = new Dictionary<int, BagEquip>();

    //任务物品
    public List<Task> taskList = new List<Task>();

}
