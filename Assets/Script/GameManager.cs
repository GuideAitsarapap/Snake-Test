using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GridSystemManager gridManager;
    
    [Header("UI")]
    [SerializeField] private GameObject startText;
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverText;
    public int score;
    
    [Header("Game State")]
    public GameState currentState;
    
    [Header("Game Objects")]
    [SerializeField] private SnakeHead snakeHeadPrefab;
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

    void OnEnable()
    {
        SnakeHead.OnEat += UpdateScore;
    }

    void OnDisable()
    {
        SnakeHead.OnEat -= UpdateScore;
    }

    void UpdateScore()
    {
        scoreText.text = $"Score: {score}";
    }

    void Start()
    {
        InitializeGame();
    }
    
    void InitializeGame()
    {
        // Clean up existing snake if it exists
        if (SnakeHead.Instance != null)
        {
            Destroy(SnakeHead.Instance.gameObject);
            SnakeHead.Instance = null;
        }
        
        // Clean up any remaining body segments
        GameObject[] bodySegments = GameObject.FindGameObjectsWithTag("BodySegment");
        foreach (GameObject segment in bodySegments)
        {
            Destroy(segment);
        }
        
        // Clean up any existing food
        Food existingFood = FindObjectOfType<Food>();
        if (existingFood != null)
        {
            Destroy(existingFood.gameObject);
        }
        
        // Reset game state
        score = 0;
        scoreText.text = $"Score: {score}";
        currentState = GameState.Start;
        Time.timeScale = 1f;
        
        // Hide UI elements
        startText.SetActive(true);
        gameOverText.SetActive(false);
        
        // Create new snake
        SnakeHead.Instance = Instantiate(snakeHeadPrefab, Vector2.zero, Quaternion.identity);
    }
    
    void Update()
    {
        switch (currentState)
        {
            case GameState.Start:
                // Handle fisrt movement to start game
                if (SnakeHead.Instance.isMoving)
                {
                    Instantiate(food);
                    food.Spawn();
                    startText.SetActive(false);
                    currentState = GameState.Playing;
                }
                break;
            case GameState.Playing:
                if (SnakeHead.Instance.isDead)
                {
                    SnakeHead.Instance.isMoving = false;
                    currentState = GameState.GameOver;
                    Time.timeScale = 0f;
                    gameOverText.SetActive(true);
                }

                break;
            case GameState.GameOver:
                // Show game over screen
                Time.timeScale = 0f;
                gameOverText.SetActive(true);
                if (Input.anyKeyDown)
                {
                    RestartGame();
                }
                break;
        }
    }
    
    void RestartGame()
    {
        InitializeGame();
    }
}
public enum GameState
{
    Start,
    Playing,
    GameOver
}