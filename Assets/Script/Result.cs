using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class Result
{
    public const string URL="https://5a30-220-90-110-49.ngrok-free.app/";
    private static Data _result;
    public static string result{
        set{
            _result=JsonUtility.FromJson<Data>(value);
        }
    }
    public static string name{
        get{
            return _result.name;
        }
    }
    public static string descriptiom{
        get{
            return _result.descriptiom;
        }
    }
    public static string img{
        get{
            return _result.img;
        }
    }
    public static Texture2D face;
}

public class Data{
    public string name;
    public string descriptiom;
    public string img;
}