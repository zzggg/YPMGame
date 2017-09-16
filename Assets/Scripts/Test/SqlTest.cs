using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class SqlTest : MonoBehaviour {
    
	void Start () {
        string path = "data source =" + Application.streamingAssetsPath + "/YPMGame.sqlite";
        //SqlManager.instance.OpenDB(path);
	}


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            string table = "PlayerInfo";

            string[] cols = new string[] { "password","number" };
            string[] typ = new string[] { "TEXT", "INTEGER" };
            //SqlManager.instance.CreateTable("student", cols, typ);
            //string[] op = new string[] { "=","<" };
            //string[] values = new string[] { "123456","10" };
            //SqlManager.instance.UpdateData(table, cols, values, "username", "=", "sdsd");
            //string[] field = new string[] {"username"};
            //SqliteDataReader reader = SqlManager.instance.SelectWhere(table, cols, op, values,field);

            //SqliteDataReader reader = SqlManager.instance.SelectFromTable(table,field);
            SqliteDataReader reader = SqlManager.instance.SelectFromTable(table);
            List<string> list = new List<string>();
            list = SqlManager.instance.GetTableFieldInfo(table);
            foreach (var item in list)
            {
                print(item);
            }
            //string[] val = new string[] { "gpppp"};
            //string[] col = new string[] { "asda" };

            //SqlManager.instance.InsertInto(table, val,col);

            //string t1 = "Test";
            //string[] v1 = new string[] { "1" };
            //string[] c1 = new string[] { "sss" };
            //string[] o1 = new string[] { "="};
            //SqlManager.instance.Delete(t1, c1, o1, v1);
            //SqlManager.instance.DeleteAllTable(t1);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dic.Add(list[i], reader.GetValue(i).ToString());
                }
            }
            SqlManager.instance.CloseDB();
            ReadManager.TypeChange<PlayerInfo>(PlayerInfo.Instance, dic);

            Debug.Log(PlayerInfo.Instance.level);
            Debug.Log(PlayerInfo.Instance.Crit);
            //string p = "csvRoleInfo.csv";
            //List<csvRoleInitInfo> l = new List<csvRoleInitInfo>();
            //l = ReadManager.ReaderCSV<csvRoleInitInfo>(p);
            //for (int i = 0; i < l.Count; i++)
            //{
            //    print(l[i].name + "  " + l[i].description);
            //}


        }
    }
}
