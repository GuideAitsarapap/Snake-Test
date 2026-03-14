using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class SnakeHead : MonoBehaviour
{
    public static SnakeHead Instance;
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float moveInterval = 0.2f;
    public float MoveInterval
    {
        get => moveInterval;
        set => moveInterval = value;
    }

    [SerializeField] private float timer;
    
    [Header("Direction")]
    private Vector2 direction;
    public bool isDead = false;
    public bool isMoving = false;

    [Header("Body")]
    [SerializeField]private GameObject bodyPrefabs;
    private List<Transform> bodySegment = new List<Transform>();

    public static Action OnEat;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if(isDead) return;
        timer += Time.deltaTime;

        if (timer >= moveInterval)
        {
            Move();
            timer = 0f;
        }
        HandleInput();
    }

    void Move()
    {
        if(direction == Vector2.zero) 
        return;

        if(direction != Vector2.zero)
        {
            isMoving = true;
        }
        Vector2 newPosition = (Vector2)transform.position + direction;
        
        // Move body segments from back to front
        for(int i = bodySegment.Count - 1; i > 0; i--)
        {
            bodySegment[i].position = bodySegment[i - 1].position;
        }
        
        // Move first body segment to current head position
        if(bodySegment.Count > 0)
        {
            bodySegment[0].position = transform.position;
        }
        
        // Move head to new position
        transform.position = newPosition;
    }

    void HandleInput()
    {
        Vector2 newDirection;
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            newDirection = Vector2.up;
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            newDirection = Vector2.down;
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            newDirection = Vector2.left;
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            newDirection = Vector2.right;
        else
            return;
        
        if (newDirection != -direction)
        {
            direction = newDirection;
        }
    }

    public void Grow()
    {
        GameObject body = Instantiate(bodyPrefabs, transform.position, Quaternion.identity);

        Vector3 spawnPosition;

        if (bodySegment.Count > 0)
        {
            Transform lastSegment = bodySegment[bodySegment.Count - 1];
            spawnPosition = lastSegment.position;
        }
        else
        {
                spawnPosition = transform.position;
        }
        body.transform.position = spawnPosition;

        Collider2D col = body.GetComponent<Collider2D>();
        col.enabled = false;

        StartCoroutine(EnableColliderLater(col));

        bodySegment.Add(body.transform);
    }
    
    IEnumerator EnableColliderLater(Collider2D col)
    {
        yield return new WaitForSeconds(1f);
        col.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Food food = collision.GetComponent<Food>();

        if(food != null)
        {
            food.OnEat(this);
            OnEat?.Invoke();  
        }

        if (collision.CompareTag("Walls") || collision.CompareTag("BodySegment"))
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
    }
}
