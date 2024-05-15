using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// クラスの配列をJsonUtilityでデシリアライズするヘルパー
/// http://forum.unity3d.com/threads/how-to-load-an-array-with-jsonutility.375735/
/// </summary>
public class JsonHelper {
    /// <summary>
    /// 配列になっているJSONデータをデシリアライズする
    /// ex)YouObject[] objects = JsonHelper.getJsonArray<YouObject> (jsonString);
    /// </summary>
    /// <typeparam name="T">配列になっているデータの型</typeparam>
    /// <param name="json">json文字列</param>
    /// <returns>FromJsonで生成されたオブジェクトの配列</returns>
    public static T[] getJsonArray<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }

    [Serializable]
    private class Wrapper<T>
    {
#pragma warning disable 649
        public T[] array;
    }
}

