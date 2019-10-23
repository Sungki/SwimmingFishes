using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class Toolbox : MonoBehaviour
{
    private static Toolbox _instance;

    Dictionary<string, GameObject> dict = new Dictionary<string, GameObject>();

    public static Toolbox GetInstance()
    {
        if (Toolbox._instance == null)
        {
            var go = new GameObject("Toolbox");
            DontDestroyOnLoad(go);
            Toolbox._instance = go.AddComponent<Toolbox>();
        }
        return Toolbox._instance;
    }

    void Awake()
    {
        if (Toolbox._instance != null)
        {
            Destroy(this);
        }

        CreateManager<AudioManager>();
        CreateManager<DisplayManager>();
        CreateManager<GameManager>();
    }

    private void CreateManager<T>() where T : MonoBehaviour
    {
        var go = new GameObject(typeof(T).ToString());
        go.transform.parent = this.gameObject.transform;
        go.AddComponent<T>();
        dict.Add(typeof(T).ToString(), go);
    }

    public T GetManager<T>() where T : MonoBehaviour
    {
        string key = typeof(T).ToString();
        return this.dict[key].GetComponent<T>();
    }
}
