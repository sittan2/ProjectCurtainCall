using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DataManager
{
    GamePlayData gamePlayData;
    public GamePlayData GamePlayData => gamePlayData;

    public void Init()
    {
        var taskDic = ReadTaskCSV();
        gamePlayData = new GamePlayData(taskDic);
    }

    #region Parse

    //public static T ParseEnum<T>(string value, T defaultValue) where T : struct, IConvertible
    //{
    //    if (!typeof(T).IsEnum) throw new ArgumentException("T must be an enumerated type");
    //    if (string.IsNullOrEmpty(value)) return defaultValue;

    //    foreach (T item in Enum.GetValues(typeof(T)))
    //    {
    //        if (item.ToString().ToLower().Equals(value.Trim().ToLower())) return item;
    //    }
    //    return defaultValue;
    //}

    //public static T ParseEnum<T>(object value)
    //{
    //    return ParseEnum<T>(value.ToString());
    //}

    public static T ParseEnum<T>(string value)
    {
        if (value == "")
        {
            Debug.Log("ParseEnum Dafault : " + typeof(T).ToString());
            return (T)Enum.Parse(typeof(T), "0", true);
        }
        else
            return (T)Enum.Parse(typeof(T), value, true);
    }

    //public static bool ParseBool(object p_value)
    //{
    //    string value = p_value.ToString();

    //    return ParseBool(value);
    //}

    //public static bool ParseBool(string p_value)
    //{
    //    if (p_value == "") return false;

    //    if (p_value == "TRUE" || p_value == "true")
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    public static int ParseInt(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return 0;
        }
        else
        {
            return int.Parse(value);
        }
    }

    public static T ParseEnum<T>(Dictionary<string, object> item, string header) where T : struct
    {
        if (item.TryGetValue(header, out object value))
        {
            if (Enum.TryParse(value.ToString(), true, out T result))
            {
                return result;
            }
            else
            {
                Debug.Log("ParseEnum Default : " + header);
                return (T)Enum.Parse(typeof(T), "none", true);
            }
        }
        else
        {
            Debug.LogWarning("ParseEnum Header Error : " + header);
            return (T)Enum.Parse(typeof(T), "none", true);
        }
    }

    public static bool ParseBool(Dictionary<string, object> item, string header, bool defaultValue = false)
    {
        if (item.TryGetValue(header, out object value))
        {
            if (bool.TryParse(value.ToString(), out bool result))
            {
                return result;
            }
            else
            {
                Debug.Log("ParseBool Default : " + header);
                return defaultValue;
            }
        }
        else
        {
            Debug.LogWarning("ParseBool Header Error : " + header);
            return defaultValue;
        }
    }


    public static int ParseInt(Dictionary<string, object> item, string header)
    {
        if (item.TryGetValue(header, out object value))
        {
            if (int.TryParse(value.ToString(), out int result))
            {
                return result;
            }
            else
            {
                Debug.Log("ParseInt Default : " + header);
                return 0;
            }
        }
        else
        {
            Debug.LogWarning("ParseInt Header Error : " + header);
            return 0;
        }
    }

    public static float ParseFloat(Dictionary<string, object> item, string header)
    {
        if (item.TryGetValue(header, out object value))
        {
            if (float.TryParse(value.ToString(), out float result))
            {
                return result;
            }
            else
            {
                Debug.Log("ParseFloat Default : " + header);
                return 0;
            }
        }
        else
        {
            Debug.LogWarning("ParseFloat Header Error : " + header);
            return 0;
        }
    }

    public static string ParseString(Dictionary<string, object> item, string header)
    {
        if (item.TryGetValue(header, out object value))
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                Debug.Log("ParseString Default : " + header);
                return "";
            }
            else
            {
                return value.ToString();
            }
        }
        else
        {
            Debug.LogWarning("ParseString Header Error : " + header);
            return "";
        }
    }



    public static List<string> ParseList(Dictionary<string, object> item, string preHeader)
    {
        List<string> list = new List<string>();
        int num = 1;
        string header = preHeader + num;

        while (item.ContainsKey(header))
        {
            if (!string.IsNullOrEmpty(item[header].ToString()))
                list.Add(item[header].ToString());


            num++;
            header = preHeader + num;
        }
        return list;
    }



    #endregion Parse

    #region Read

    public static Dictionary<string, Task> ReadTaskCSV()
    {
        string path = "CSV/Task";

        var data = CSVReader.Read(path);
        var dic = new Dictionary<string, Task>();
        int num = 0;

        foreach (var item in data)
        {
            string id = "Task_" + num.ToString("0000");
            num++;

            float startTime = ParseFloat(item, "startTime");
            float intervalTime = ParseFloat(item, "intervalTime");
            int value = ParseInt(item, "value");
            var propType = ParseEnum<Define.PropType>(item, "propType");
            int number = ParseInt(item, "number");
            var actionType = ParseEnum<Define.ActionType>(item, "actionType");
            int parameter = ParseInt(item, "parameter");

            Task task = new(id, startTime, intervalTime, value, propType, number, actionType, parameter);

            dic.Add(id, task);
        }

        return dic;
    }

    #endregion
}