using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

public class ReadManager {

    // path  相对与StreamingAssets的路径
    public static List<T> ReaderCSV<T>(string path)
    {
        CsvDataCached.CachedCsvFile<T>(path);
        Dictionary<int, T> dataDic = CsvDataCached.GetCsvFileDatas<T>();
        List<T> list = new List<T>();
        foreach (T item in dataDic.Values)
        {
            list.Add(item);
        }
        return list;
    }

    /// <summary>
    /// 数据库表数据映射到对象
    /// </summary>
    /// <param name="dic">数据库表   字段名-行数据</param>
    public static void TypeChange<T>(T t, Dictionary<string, string> dic)
    {
        PropertyInfo[] props = typeof(T).GetProperties();

        foreach (var p in props)
        {
            if (dic.ContainsKey(p.Name))
                p.SetValue(t, Convert.ChangeType(dic[p.Name], p.PropertyType), null);
        }
    }

}
