using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class rePosition : MonoBehaviour
{
    Collider2D collider;
    SpriteRenderer sprite;
    private void Awake()
    {
        collider = GetComponent<Collider2D>();
    }
    private bool isEnemyAlive = true;
    void OnTriggerExit2D(Collider2D collider)
    {

        if (!collider.CompareTag("Area"))
        {
            return;
        }

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;

        float diffX = Math.Abs(playerPos.x - myPos.x);
        float diffY = Math.Abs(playerPos.y - myPos.y);

        Vector3 playDirection = GameManager.instance.player.inputVector;
        float xDirection = playDirection.x < 0 ? -1 : 1;
        float yDirection = playDirection.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if (diffX > diffY)
                {
                    Vector3 position1 = transform.position;
                    transform.Translate(Vector3.right * xDirection * 40);
                    Vector3 position2 = transform.position;

                }
                else if (diffY > diffX)
                {
                    Vector3 position1 = transform.position;
                    transform.Translate(Vector3.up * yDirection * 40);
                    Vector3 position2 = transform.position;

                }
                break;
            case "Enemy":
                if (collider.enabled)
                {
                    transform.Translate(playDirection * 20 + new Vector3(UnityEngine.Random.Range(-3f, 3f), UnityEngine.Random.Range(-3f, 3f), 0));
                }
                break;

        }



    }


}