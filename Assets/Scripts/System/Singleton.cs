using UnityEngine;
using System.Collections;
using System;

[AttributeUsage(AttributeTargets.Class, Inherited = true)]
public class PrefabAttribute : Attribute
{
    public readonly string Name;
    public readonly bool Persistent;

    public PrefabAttribute(string Name, bool Persistent)
    {
        this.Name = Name;
        this.Persistent = Persistent;
    }

    public PrefabAttribute(string Name)
    {
        this.Name = Name;
        this.Persistent = false;
    }
}

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static bool _instantiated;

    private static T Instance
    {
        get
        {
            return _instance;
        }
        set
        {
            _instance = value;
            _instantiated = value != null;
        }
    }

    /// <summary>
    /// <para>Return an instance of type T. If the instance doesn't exist, it will instantiate one.</para>
    /// <para>This is very useful when debugging a scene without starting from the scene that instantiate a needed manager.</para>
    /// </summary>
    /// <returns></returns>
    public static T GetInstance()
    {
        if (_instantiated)
            return Instance;

        Type Type = typeof(T);
        T[] Objects = FindObjectsOfType<T>();

        if (Objects.Length > 0)
        {
            Instance = Objects[0];
            if (Objects.Length > 1)
            {
                //Debug.Log("There is more than one instance of Singleton of type \"" + Type + "\". Keeping the first, destroying the others.");
                for (int i = 1; i < Objects.Length; ++i)
                    DestroyImmediate(Objects[i].gameObject);
            }
            _instantiated = true;
            return Instance;
        }

        PrefabAttribute attribute = Attribute.GetCustomAttribute(Type, typeof(PrefabAttribute)) as PrefabAttribute;
        if (attribute == null)
        {
            Debug.LogError("There is no Prefab Attribute for Singleton of type \"" + Type + "\".");
            return null;
        }

        string PrefabName = attribute.Name;
        if (string.IsNullOrEmpty(PrefabName))
        {
            Debug.LogError("Prefab name is empty for Singleton of type \"" + Type + "\".");
            return null;
        }

        GameObject GA = Instantiate(Resources.Load<GameObject>("Prefabs/" + PrefabName)) as GameObject;
        if (GA == null)
        {
            Debug.LogError("Could not find prefab \"" + PrefabName + "\" on Resources for Singleton of type \"" + Type + "\".");
            return null;
        }
        GA.name = PrefabName;
        Instance = GA.GetComponent<T>();
        if (!_instantiated)
        {
            //Debug.Log("There's wasn't a component of type \"" + Type + "\" inside prefab \"" + PrefabName + "\". Creating one.");
            Instance = GA.AddComponent<T>();
        }

        //if (attribute.Persistent)
            DontDestroyOnLoad(Instance.gameObject);
            //Debug.Log("There's no instance of type \"" + Type + "\" in the scene. Instanciated one.");
        return Instance;
    }

    private void Awake()
    {
        if (_instantiated)
        {
            //Debug.Log("There already is an instance of Singleton of type \"" + typeof(T) + "\". Deleting myself.");
            DestroyImmediate(gameObject);
            return;
        }

        PrefabAttribute attribute = Attribute.GetCustomAttribute(typeof(T), typeof(PrefabAttribute)) as PrefabAttribute;
       // if (attribute.Persistent)
            DontDestroyOnLoad(this);
    }

   /* private void OnEnable()
    {
        if (_instantiated)
        {
           // //Debug.Log("There already is an instance of Singleton of type \"" + typeof(T) + "\". Deleting myself.");
            DestroyImmediate(gameObject);
            return;
        }

    }*/

    private void OnDestroy()
    {
        _instantiated = false;
    }

    protected void CallSingletonAwake()
    {
        this.Awake();
    }
}