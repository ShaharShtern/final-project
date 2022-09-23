using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SnakeScript : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    private Vector2 playerMovement;

    [SerializeField] float moveTimerMax = 1f;
    float moveTimer;

    private void Awake()
    {
        moveTimer = moveTimerMax;
    }
    private void Update()
    {
        if (direction.x == 1)
            playerMovement = Vector2.right;
        else if (direction.x == -1)
            playerMovement = Vector2.left;
        else if (direction.y == 1)
            playerMovement = Vector2.up;
        else if (direction.y == -1)
            playerMovement = Vector2.down;

        moveTimer += Time.deltaTime;
        if (moveTimer>moveTimerMax)
        {
            if (playerMovement == Vector2.right)
                transform.position = new Vector2(transform.position.x+1, transform.position.y);
            else if (playerMovement == Vector2.left)
                transform.position = new Vector2(transform.position.x-1, transform.position.y);
            else if (playerMovement == Vector2.up)
                transform.position = new Vector2(transform.position.x, transform.position.y+1);
            else if (playerMovement == Vector2.down)
                transform.position = new Vector2(transform.position.x, transform.position.y-1);
            moveTimer = 0;
        }

    }
    void OnMove (InputValue value)
    {
        direction = value.Get<Vector2>();
    }
}
