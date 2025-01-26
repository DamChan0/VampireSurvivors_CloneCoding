using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] prefabs;

    public List<GameObject>[] poolList;



    private void Awake()
    {
        poolList = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < prefabs.Length; i++)
        {
            poolList[i] = new List<GameObject>();

        }
    }


    public GameObject GetGameObject(int index)
    {
        GameObject obj = null;

        foreach (GameObject item in poolList[index])
        {
            if (!item.activeSelf)
            {
                obj = item;
                obj.SetActive(true);
                break;
            }
        }

        if (obj == null)
        {
            obj = Instantiate(prefabs[index], transform);
            poolList[index].Add(obj);
        }

        return obj;
    }
}
