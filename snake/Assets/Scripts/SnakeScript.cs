using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SnakeScript : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    private Vector2 playerMovement;
    //[SerializeField]float powerTimerMax = 10f;
    public float powerTimer=0;

    private List<Transform> segments;
    public Transform segmentPrefab;

    public int scorePowerMultiplyer=1;

    public int score=0;

    [SerializeField] float moveTimerMax = 0.1f;
    float moveTimer;

    public GameObject walls;
    public GameObject timerText;
    public GameObject lostCanvas;
    private void Awake()
    {
        moveTimer = moveTimerMax;
        
    }
    private void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);
    }
    private void Update()
    {
        if (direction.x == 1&&playerMovement != Vector2.left)
            playerMovement = Vector2.right;
        else if (direction.x == -1&&playerMovement != Vector2.right)
            playerMovement = Vector2.left;
        else if (direction.y == 1 && playerMovement != Vector2.down)
            playerMovement = Vector2.up;
        else if (direction.y == -1 && playerMovement != Vector2.up)
            playerMovement = Vector2.down;

        moveTimer += Time.deltaTime;
        if (moveTimer>moveTimerMax)
        {
            for (int i = segments.Count - 1; i > 0; i--)
            {
                segments[i].position = segments[i - 1].position;
            }

            if (playerMovement == Vector2.right)
            {
                transform.position = new Vector2(transform.position.x + 1, transform.position.y);
                GetComponentInChildren<Transform>().eulerAngles = new Vector3(0, 0, 0);
            }
            else if (playerMovement == Vector2.left)
            {
                transform.position = new Vector2(transform.position.x - 1, transform.position.y);
                GetComponentInChildren<Transform>().eulerAngles = new Vector3(0, 0, 180);
            }
            else if (playerMovement == Vector2.up)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 1);
                GetComponentInChildren<Transform>().eulerAngles = new Vector3(0, 0, 90);
            }
            else if (playerMovement == Vector2.down)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 1);
                GetComponentInChildren<Transform>().eulerAngles = new Vector3(0, 0, 270);
            }
            moveTimer = 0;
            
        }

        //loop around when out of bounds for the power fruit
        if (transform.position.x<-16)
        {
            transform.position = new Vector2(16, transform.position.y);
        }
        else if (transform.position.x>16)
        {
            transform.position = new Vector2(-16, transform.position.y);
        }
        else if (transform.position.y<-8)
        {
            transform.position = new Vector2(transform.position.x, 8);
        }
        else if (transform.position.y>8)
        {
            transform.position = new Vector2(transform.position.x, -8);
        }

        if (scorePowerMultiplyer==2)
        {
            powerTimer -= Time.deltaTime;
            timerText.SetActive(true);
        }
        if (powerTimer < 0)
        {
            walls.SetActive(true);
            scorePowerMultiplyer = 1;
            powerTimer = 10;
            timerText.SetActive(false);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("food"))
        {
            Grow();
            score = score+1*scorePowerMultiplyer ;
            moveTimerMax = moveTimerMax * 0.95f;
        }
        else if (collision.gameObject.CompareTag("obstacle"))
        {
            lostCanvas.SetActive(true);
            Destroy(gameObject);
        }
    }
    void OnMove (InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }
}
