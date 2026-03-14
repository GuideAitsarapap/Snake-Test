using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject normalFoodPrefab;
    public GameObject speedFoodPrefab;
    public GameObject poisonFoodPrefab;

    private List<GameObject> currentFoods = new List<GameObject>();

    public void SpawnFood()
    {
        if (currentFoods.Count > 0)
        return;

        GameObject prefab;

        if (GameManager.Instance.score > 1000)
        {
            prefab = GetRandomFood();
        }
        else
        {
            prefab = normalFoodPrefab;
        }

        Spawn(prefab);
    }

    void Spawn(GameObject prefab)
    {
        Vector2 randomPosition = new Vector2(
            Random.Range(-GameManager.Instance.gridManager.width / 2 + 1,
                         GameManager.Instance.gridManager.width / 2),

            Random.Range(-GameManager.Instance.gridManager.height / 2 + 1,
                         GameManager.Instance.gridManager.height / 2)
        );

        GameObject food = Instantiate(prefab, randomPosition, Quaternion.identity);
        currentFoods.Add(food);
    }

    GameObject GetRandomFood()
    {
        int rand = Random.Range(0, 3);

        switch (rand)
        {
            case 0:
                return normalFoodPrefab;

            case 1:
                return speedFoodPrefab;

            case 2:
                return poisonFoodPrefab;
        }

        return normalFoodPrefab;
    }

    public void RemoveFood(GameObject food)
    {
        if (currentFoods.Contains(food))
            currentFoods.Remove(food);
    }

    public void ResetFoods()
    {
        foreach (var food in currentFoods)
        {
            if (food != null)
                Destroy(food);
        }

        currentFoods.Clear();
    }
}
