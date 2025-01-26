using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    private Rigidbody2D enemyRigid;
    private Vector3 step;
    private SpriteRenderer enemySprite;

    private bool isAlive = true;

    public Rigidbody2D target;

    void Start()
    {
        enemyRigid = GetComponent<Rigidbody2D>();
        enemySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isAlive)
        {
            move();
        }
    }

    private void move()
    {
        Vector3 enemyDirection = target.position - enemyRigid.position;
        Vector2 enemyStep = enemyDirection.normalized * speed * Time.fixedDeltaTime;
        enemyRigid.MovePosition(enemyRigid.position + enemyStep);
        enemyRigid.velocity = Vector2.zero;

    }

    private void LateUpdate()
    {
        enemySprite.flipX = target.position.x < enemyRigid.position.x;


    }

    void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }
}
