using UnityEngine;
using System.Collections;

public class SpeedFood : Food
{
    public float duration = 3f;
    public float speedMultiplier = 0.5f; 

    public override void OnEat(SnakeHead snake)
    {
        snake.StartCoroutine(SpeedBoost(snake));

        GameManager.Instance.AddScore(50);
        GameManager.Instance.foodSpawner.RemoveFood(gameObject);

        Destroy(gameObject);
    }

    IEnumerator SpeedBoost(SnakeHead snake)
    {
        float originalInterval = snake.MoveInterval;

        snake.MoveInterval *= speedMultiplier;

        yield return new WaitForSeconds(duration);

        snake.MoveInterval = originalInterval;
    }
}
