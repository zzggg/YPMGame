using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipAndSkill {
    private static PlayerEquipAndSkill instance;
    private PlayerEquipAndSkill() { }

    public static PlayerEquipAndSkill Instance
    {
        get
        {
            if (instance == null) instance = new PlayerEquipAndSkill();
            return instance;
        }
    }

    public int playerID { get; set; }
    public int weaponLv { get; set; }
    public int weaponLv_int { get; set; }
    public int clothLv { get; set; }
    public int clothLv_int { get; set; }
    public int shoeLv { get; set; }
    public int shoeLv_int { get; set; }

    public int skillLv_1 { get; set; }
    public int skillLv_2 { get; set; }
    public int skillLv_3 { get; set; }
}
