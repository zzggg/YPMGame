using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

using System;
using System.Data;

public class SqlManager : MonoBehaviour {
    
    public static SqlManager instance;

    private string path;
    private SqliteConnection conn;
    private SqliteCommand cmd;
    private SqliteDataReader reader;

    private void Awake()
    {
        instance = this;
        path = "data source =" + Application.streamingAssetsPath + "/YPMGame.sqlite";
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
     * 执行查询sql语句
     */
    public SqliteDataReader ExecuteSelect(string sql)
    {
        cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        reader = cmd.ExecuteReader();
        return reader;
    }

    /*
     * 执行增删改
     */
    public void ExecuteI_D_U(string sql)
    {
        cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    /*
     * 创建表
     */
    public void CreateTable(string tableName,string[] cols,string[] colTypes)
    {
        if (cols.Length != colTypes.Length) throw new Exception("length error!");

        if (cols.Length == 0) throw new Exception("cols is Null");

        string sql = "CREATE TABLE " + tableName + "(" + cols[0] + " " + colTypes[0];
        for (int i = 1; i < cols.Length; i++)
        {
            sql += "," + cols[i] + " " + colTypes[i];
        }
        sql += ")";

        Debug.Log(sql);

        ExecuteI_D_U(sql);
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
        //Debug.Log(sql);

        return ExecuteSelect(sql);
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
        if(len == 0)
        {
            sql += " FROM " + tableName;
        }
        else
        {
            sql += " FROM " + tableName + " WHERE " + cols[0] + " " + op[0] + " '" + values[0] + "'";
            for (int i = 1; i < len; i++)
            {
                sql += " " + connector + " " + cols[i] + " " + op[i] + " '" + values[i] + "'";
            }
        }
        
        //Debug.Log(sql);

        return ExecuteSelect(sql);
    }

    /*
     * 向表中插入数据
     * cols 表字段
     * values 字段对应的值
     * 
     * 假设cols与该表字段名一致，未检测不一致错误
     */
    public void InsertInto(string tableName,string[] values,string[] cols = null)
    {
        string sql = "INSERT INTO " + tableName;
        if (cols == null)
        {
            sql += " ";
        }else
        {
            if (cols.Length != values.Length)
            {
                throw new Exception("Length Error!");
            }

            if(cols.Length == 0)
            {
                throw new Exception("INSERT NULL");
            }

            sql += "(" + cols[0];
            for(int i = 1; i < cols.Length; i++)
            {
                sql += "," + cols[i];
            }
            sql += ") ";
        }
        sql += "VALUES('" + values[0];
        for(int i = 1; i < values.Length; i++)
        {
            sql += "','" + values[i];
        }
        sql += "')";

        //Debug.Log(sql);

        ExecuteI_D_U(sql);
    }

    /*
     * 删除表中数据
     */
    public void Delete(string tableName,string[] cols,string[] op,string[] values,
        string connector = Global.AND)
    {
        if (cols.Length != op.Length || op.Length != values.Length) throw new Exception("length error!");

        if (cols.Length == 0)
        {
            DeleteAllTable(tableName);
            return;
        }

        string sql = "DELETE FROM " + tableName + " WHERE " + cols[0] + " " + op[0] + " '" + values[0]+"'";
        for(int i = 1; i < cols.Length; i++)
        {
            sql += " " + connector + " " + cols[i] + " " + op[i] + " '" + values[i]+"'";
        }

        //Debug.Log(sql);

        ExecuteI_D_U(sql);
    }

    //删除整个表数据
    //保留表结构
    public void DeleteAllTable(string tableName)
    {
        string sql = "DELETE FROM " + tableName;
        ExecuteI_D_U(sql);
    }

    /*
     * 更新数据
     * cols = 'values'
     * _key _op _value  更新条件
     */
    public void UpdateData(string tableName,string[] cols,string[] values,
        string _key,string _op,string _value)
    {
        if (cols.Length != values.Length) throw new Exception("length error!");

        if (cols.Length == 0) throw new Exception("Don't have new data Update");

        string sql = "UPDATE " + tableName + " SET " + cols[0] + " = '" + values[0] + "'";
        for(int i = 1; i < cols.Length; i++)
        {
            sql += "," + cols[i] + " = '" + values[i] + "'";
        }
        sql += " WHERE " + _key + " " + _op + " '" + _value + "'";

        Debug.Log(sql);

        ExecuteI_D_U(sql);
    }
}
