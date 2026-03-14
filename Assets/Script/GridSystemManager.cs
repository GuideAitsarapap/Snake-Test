using System.Collections.Generic;
using UnityEngine;

public class GridSystemManager : MonoBehaviour
{
    [Header("Grid Size")]
    [SerializeField] public int width;
    [SerializeField] public int height;

    [Header("Border")]
    [SerializeField] private GameObject borderPrefab;
    [SerializeField] private Transform borderParent;

    void Start()
    {
        GenerateBorder();
    }

    void GenerateBorder()
    {
        int leftEdge = -width / 2;
        int rightEdge = width / 2;
        int topEdge = height / 2;
        int bottomEdge = -height / 2;

        // TOP
        for (int x = leftEdge; x <= rightEdge; x++)
        {
            CreateBorder(new Vector2(x, topEdge));
        }

        // RIGHT
        for (int y = topEdge - 1; y >= bottomEdge; y--)
        {
            CreateBorder(new Vector2(rightEdge, y));
        }

        // BOTTOM
        for (int x = rightEdge - 1; x >= leftEdge; x--)
        {
            CreateBorder(new Vector2(x, bottomEdge));
        }

        // LEFT
        for (int y = bottomEdge + 1; y < topEdge; y++)
        {
            CreateBorder(new Vector2(leftEdge, y));
        }
    }

    void CreateBorder(Vector2 gridPos)
    {
        GameObject border = Instantiate(borderPrefab);
        border.transform.position = GridToWorld(gridPos);
        
        border.transform.parent = borderParent;
    }

    public Vector3 GridToWorld(Vector2 gridPosition)
    {
        return new Vector3(gridPosition.x, gridPosition.y, 0);
    }
}
