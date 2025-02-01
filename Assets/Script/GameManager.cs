using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    public static GameManager instance;
    public float GameTime;
    public float MaxGameTime = 60 * 2;

    public PoolManager poolManager;
    // Update is called once per frame

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple GameManager instances found!");
            Destroy(gameObject);
        }
        if (GameManager.instance.player == null)
        {
            Debug.LogError("Player reference is not set in GameManager!");
        }

    }

    void Update()
    {
        GameTime += Time.deltaTime;
        if (GameTime > MaxGameTime)
        {
            GameTime = MaxGameTime;
        }

    }
}
