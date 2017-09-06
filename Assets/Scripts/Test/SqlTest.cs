using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class SqlTest : MonoBehaviour {
    
	void Start () {
        string path = "data source =" + Application.streamingAssetsPath + "/YPMGame.sqlite";
        SqlManager.instance.OpenDB(path);
        
	}


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            string table = "User";

            string[] cols = new string[] { "password","number" };
            string[] op = new string[] { "=","<" };
            string[] values = new string[] { "123456","10" };
            string[] field = new string[] {"username"};
            //SqliteDataReader reader = SqlManager.instance.SelectWhere(table, cols, op, values,field);

            //SqliteDataReader reader = SqlManager.instance.SelectFromTable(table,field);
            SqliteDataReader reader = SqlManager.instance.SelectFromTable(table);

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Debug.Log(reader.GetValue(i).ToString());
                }
            }
            //SqlManager.instance.CloseDB();
        }
    }
}
