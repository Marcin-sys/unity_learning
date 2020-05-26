using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

	private Dictionary<int, List<GameObject>> pool = new Dictionary<int, List<GameObject>>();

	[SerializeField] private int basicPoolSize = 10;

	[SerializeField] private GameObject bullet;

	private static PoolManager _instance;
    public static PoolManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PoolManager>(); 
            }
            return _instance;
        }
    }

	private void Start()
	{
		CreatePool(bullet);
	}

	private void CreatePool(GameObject prefab)
    {
        int poolKey = prefab.GetInstanceID();
        if (!pool.ContainsKey(poolKey))
        {
            pool.Add(poolKey, new List<GameObject>());

			IncreasePoolSize(prefab);
        }
    }

	private GameObject IncreasePoolSize(GameObject prefab)
	{
		int poolKey = prefab.GetInstanceID();
		GameObject newObject = null;
		for (int i = 0; i < basicPoolSize; ++i)
		{
			newObject = Instantiate(prefab) as GameObject;
			newObject.SetActive(false);
			pool[poolKey].Add(newObject);
		}
		return newObject;
	}

	public GameObject ReuseObject(GameObject prefab)
    {
		int poolKey = prefab.GetInstanceID();
		return pool[poolKey].Find(e => !e.activeInHierarchy) ?? IncreasePoolSize(prefab);
	}
}