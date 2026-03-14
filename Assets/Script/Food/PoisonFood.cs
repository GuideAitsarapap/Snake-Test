using UnityEngine;
using System.Collections;

public class PoisonFood : Food
{
    [SerializeField] private float lifeTime = 3f;

    void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(lifeTime);
        GameManager.Instance.foodSpawner.RemoveFood(gameObject);

        Destroy(gameObject);
        GameManager.Instance.foodSpawner.SpawnFood();
    }

    public override void OnEat(SnakeHead snake)
    {
        snake.Die();

        base.OnEat(snake);
    }
}
