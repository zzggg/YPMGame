using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

using System;
using System.Data;

public class SqlManager : MonoBehaviour {
    
    public static SqlManager instance;

    private SqliteConnection conn;
    private SqliteCommand cmd;
    private SqliteDataReader reader;

    private void Awake()
    {
        instance = this;
    }

    /*
     * 打开/连接数据库
     */
    public void OpenDB(string path)
    {
        try
        {
            conn = new SqliteConnection(path);
            conn.Open();
            Debug.Log("Open success!");
        }
        catch (Exception e)
        {
            Debug.Log(e);
            throw;
        }
    }

    /*
     * 关闭数据库
     */
    public void CloseDB()
    {
        if (cmd != null)
        {
            cmd.Dispose();
        }
        cmd = null;

        if(reader != null && !reader.IsClosed)
        {
            reader.Close();
        }
        reader = null;

        if(conn != null)
        {
            conn.Close();
        }
        conn = null;

        Debug.Log("Close success!");
    }

    /*
     * 执行sql语句
     */
    public SqliteDataReader ExecuteSql(string sql)
    {
        cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        reader = cmd.ExecuteReader();
        return reader;
    }

    /*
     * 查询名为tableName的表
     * 返回该表所有数据的field字段的值
     */
    public SqliteDataReader SelectFromTable(string tableName,string[] field = null)
    {
        int len = 0;
        if (field != null) len = field.Length;
        
        string sql = "SELECT ";
        if (len == 0)
        {
            sql += "* ";
        }
        else
        {
            for(int i = 0; i < len-1; i++)
            {
                sql += field[i] + ",";
            }
            sql += field[len - 1];
        }
        sql += " FROM " + tableName;
        Debug.Log(sql);

        return ExecuteSql(sql);
    }

    /*
     * 查询表中符合where条件的数据
     * 
     * tableName 表名
     * cols 表中列名
     * op 操作数
     * values cols需要比较的值
     * field 查询返回字段
     * connector    AND   OR
     */
    public SqliteDataReader SelectWhere(string tableName,
        string[] cols,string[] op,string[] values,
        string[] field = null,string connector = Global.AND)
    {
        if (cols.Length != op.Length || op.Length != values.Length) throw new Exception("length error!");

        int len = 0;
        if (field != null) len = field.Length;

        string sql = "SELECT ";
        if (len == 0)
        {
            sql += "* ";
        }
        else
        {
            for (int i = 0; i < len - 1; i++)
            {
                sql += field[i] + ",";
            }
            sql += field[len - 1];
        }

        len = cols.Length;
        sql += " FROM " + tableName + " WHERE " + cols[0] + " "+ op[0] + " '" + values[0]+"'";
        for(int i = 1; i < len; i++)
        {
            sql += " " + connector + " " + cols[i] + " " + op[i] + " '" + values[i] + "'";
        }
        Debug.Log(sql);

        return ExecuteSql(sql);
    }


}
