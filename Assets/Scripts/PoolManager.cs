﻿using System;
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

	private void IncreasePoolSize(GameObject prefab)
	{
		int poolKey = prefab.GetInstanceID();
		for (int i = 0; i < basicPoolSize; ++i)
		{
			GameObject newObject = Instantiate(prefab) as GameObject;
			newObject.SetActive(false);
			pool[poolKey].Add(newObject);
		}
	}

	public void ReuseObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        int poolKey = prefab.GetInstanceID();
        if (pool.ContainsKey(poolKey))
        {
			int i = 0;
			GameObject objectToReuse;
			for (; i < pool[poolKey].Count; ++i)
			{
				if (!pool[poolKey][i].activeInHierarchy)
				{
					objectToReuse = pool[poolKey][i];
					objectToReuse.SetActive(true);
					objectToReuse.transform.position = position;
					objectToReuse.transform.rotation = rotation;
					return;
				}
			}

			IncreasePoolSize(prefab);
			objectToReuse = pool[poolKey][i];
			objectToReuse.SetActive(true);
			objectToReuse.transform.position = position;
			objectToReuse.transform.rotation = rotation;
		}
    }
}