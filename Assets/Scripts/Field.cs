using System;
using UnityEngine;

public class Field : MonoBehaviour
{
    public static int score = 0;

    public static int width = 10;
    public static int height = 20;

    public static Action onRowRemoved;

    public static Transform[,] grid = new Transform[width, height];

    public static Vector2 roundVec2(Vector2 vector)                             
    {
        return new Vector2(Mathf.Round(vector.x), Mathf.Round(vector.y));
    }

    public static bool insideBorder(Vector2 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x < width && (int)pos.y >= 0);
    }

    public static void DeleteRow(int y)                                         // Delete row if this full
    {
        for (int x = 0; x < width; ++x)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }

        score += 50;

        onRowRemoved.Invoke();
    }

    public static void DecreaseRow(int y)                                       // Decrease row down
    {
        for (int x = 0; x < width; ++x)
        {
            if (grid[x, y] != null)
            {
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;

                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public static void DecreaseRowsAbove(int y)
    {
        for (int i = y; i < height; ++i)
            DecreaseRow(i);
    }

    public static bool isRowFull(int y)
    {
        for (int x = 0; x < width; ++x)
            if (grid[x, y] == null)
                return false;
        return true;
    }

    public static void DeleteFullRows()
    {
        for (int y = 0; y < height; ++y)
        {
            if (isRowFull(y))
            {
                DeleteRow(y);
                DecreaseRowsAbove(y + 1);
                --y;
            }
        }
    }
}
