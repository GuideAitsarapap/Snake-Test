using UnityEngine;

public abstract class Food : MonoBehaviour
{
    public int scoreValue;
    public virtual void OnEat(SnakeHead snake)
    {
        GameManager.Instance.AddScore(scoreValue);

        SnakeHead.OnEat?.Invoke();

        GameManager.Instance.foodSpawner.RemoveFood(gameObject);

        Destroy(gameObject);
    }
}
