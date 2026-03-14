using UnityEngine;

public class Food : MonoBehaviour
{
    public void Spawn()
    {
        //Spawn food at random position
        Vector2 randomPosition = new Vector2(
            Random.Range(-GameManager.Instance.gridManager.width / 2, GameManager.Instance.gridManager.width / 2),
            Random.Range(-GameManager.Instance.gridManager.height / 2, GameManager.Instance.gridManager.height / 2)
        );
        transform.position = randomPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Spawn();
        }
    }
}
