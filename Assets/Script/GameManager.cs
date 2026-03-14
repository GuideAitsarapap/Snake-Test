using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GridSystemManager gridManager;
    
    [Header("UI")]
    [SerializeField] private GameObject startText;
    
    [Header("Game State")]
    public GameState currentState;
    
    [Header("Game Objects")]
    [SerializeField] private SnakeHead snakeHead;
    [SerializeField] private Food food;
    
    
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        InitializeGame();
    }
    
    void InitializeGame()
    {
        currentState = GameState.Start;
        Instantiate(snakeHead, Vector2.zero, Quaternion.identity);
        startText.SetActive(true);
    }
    
    void Update()
    {
        switch (currentState)
        {
            case GameState.Start:
                // Handle fisrt movement to start game
                if (!snakeHead.isDead && snakeHead.isMoving)
                {
                    food.Spawn();
                    startText.SetActive(false);
                    currentState = GameState.Playing;
                }
                break;
            case GameState.Playing:
                // Update game logic
                if (snakeHead.isDead)
                {
                    snakeHead.isMoving = false;
                    currentState = GameState.GameOver;
                }

                break;
            case GameState.GameOver:
                // Show game over screen
                break;
        }
    }
}
public enum GameState
{
    Start,
    Playing,
    GameOver
}