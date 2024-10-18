using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public static class Utility
{
    // Start is called before the first frame update
    public static void myLog(string datatToShow)
    {
        //LogCreator.Instance.AddLog(datatToShow, LogType.Log);
        if (StaticUrlScript.isLoggerEnabled)
        {
            Debug.Log(DateTime.Now.ToLongTimeString() + "  " + datatToShow);
        }
    }

    public static void myLogWarning(string datatToShow)
    {
        //LogCreator.Instance.AddLog(datatToShow, LogType.Warning);
        if (StaticUrlScript.isLoggerEnabled)
        {
            Debug.LogWarning(datatToShow);
        }
    }

    public static void myLogError(string datatToShow)
    {
        //LogCreator.Instance.AddLog(datatToShow, LogType.Error);
        if (StaticUrlScript.isLoggerEnabled)
        {
            Debug.LogError(datatToShow);
        }
    }

    public static void myLog(int datatToShow)
    {
        if (StaticUrlScript.isLoggerEnabled)
        {
            Debug.Log(datatToShow);
        }
    }
    public static string EncryptDecrypt(string Data, int key)
    {
        StringBuilder Encrypt = new StringBuilder(Data.Length);
        for (int i = 0; i < Data.Length; i++)
        {
            char ch = (char)(Data[i] ^ key);
            Encrypt.Append(ch);
        }
        return Encrypt.ToString();
    }

    public static DataTable ToDataTable<T>(this IList<T> data)
    {
        PropertyDescriptorCollection props =
        TypeDescriptor.GetProperties(typeof(T));
        DataTable table = new DataTable();
        for (int i = 0; i < props.Count; i++)
        {
            PropertyDescriptor prop = props[i];
            table.Columns.Add(prop.Name, prop.PropertyType);
        }
        object[] values = new object[props.Count];
        foreach (T item in data)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = props[i].GetValue(item);
            }
            table.Rows.Add(values);
        }
        return table;
    }

    public static string DumpDataTable(DataTable table)
    {
        string data = string.Empty;
        StringBuilder sb = new StringBuilder();
        if (null != table && null != table.Rows)
        {
            foreach (DataRow dataRow in table.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    sb.Append(item); sb.Append(',');
                }
                sb.AppendLine();
            }
            data = sb.ToString();
        }
        return data;
    }

    public static string ComputeSha256Hash(string rawData)
    {
        if (!string.IsNullOrWhiteSpace(rawData))
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData + "k37Ikzn#7$N"));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        else
        {
            return "";
        }
    }
}
