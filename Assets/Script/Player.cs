using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D playerRigid;

    private Vector3 step;

    public Vector2 inputVector;
    private Transform playerTransform;
    private SpriteRenderer playerSprite;

    private Animator playerAnim;

    private void Awake()
    {
        playerTransform = GetComponent<Transform>();
        playerRigid = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        move();
    }

    private void LateUpdate()           // LateUpdate is called after Update each frame
    {
        flipSprite();
    }

    void OnMove(InputValue value)   // onMove 라는 이름은 playerInput 에서 설정한 Action 의 이름에 들어있다.
    {
        inputVector = value.Get<Vector2>();
    }

    //    functions 
    private void move()
    {
        Vector3 moveDirection = new Vector3(inputVector.x, inputVector.y, 0);                                   // Get the direction
        playerTransform.transform.position += moveDirection * speed * Time.deltaTime;   // Move the player

    }

    private void flipSprite()
    {
        if (inputVector.x != 0)
        {
            playerSprite.flipX = inputVector.x < 0; // moceInput.x < 0 is true when the player is moving left
        }

        playerAnim.SetFloat("Speed", inputVector.magnitude);          // maganitude is the length of the vector
    }



}
