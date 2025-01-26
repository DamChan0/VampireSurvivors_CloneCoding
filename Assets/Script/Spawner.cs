using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    Transform[] spawnPoint;
    private int level = 0;
    private float runnigTime = 0;

    public EnemyStatus[] enemyStatus;
    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>(true);
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Spawn();
        }

        runnigTime += Time.deltaTime;

    }

    void Spawn()
    {
        Int32 random = UnityEngine.Random.Range(0, 2);
        GameObject spawnedObject = GameManager.instance.poolManager.GetGameObject(random);
        // 현재 각 풀에는 1개의 오브젝트만 들어가 있음
        // 따라서 풀의 종류에따라 다른 오브젝트가 생성됨
        float len = spawnPoint.Length;
        int randomPosition = (int)UnityEngine.Random.Range(1, len);
        spawnedObject.transform.position = spawnPoint[randomPosition].position;

    }

}


[System.Serializable]
public class EnemyStatus
{
    public float speed = 0f;
    public int enemySprite;
    public bool isAlive = true;
    public float health = 0;
    public float damage = 0;



}
