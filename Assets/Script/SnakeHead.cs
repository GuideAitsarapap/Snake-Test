using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float moveInterval = 0.2f;
    
    [Header("Direction")]
    private Vector2 direction;

    public bool isMoving = false;
    public bool isDead = false;

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleInput();
    }

    void HandleMovement()
    {
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
        isMoving = true;
    }

    void HandleInput()
    {
        Vector2 newDirection = direction;
        
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
}
