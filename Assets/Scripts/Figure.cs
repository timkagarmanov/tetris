using System;
using UnityEngine;

public class Figure : MonoBehaviour
{
    float lastFall = 0;

    public static bool gameOver = false;
    public Sprite sprite;

    public static Action onBlockFall;

    void Start ()
    {        
        if (!isValidGridPos())  // If position spawn is not correct => game over
        {
            gameOver = true;
            Destroy(gameObject);
        }
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))            // Move Left
        {
            transform.position += new Vector3(-1, 0, 0);

            if (isValidGridPos())
                updateGrid();
            else
                transform.position += new Vector3(1, 0, 0);
        }
                                                            
        else if (Input.GetKeyDown(KeyCode.RightArrow))      // Move Right
        {

            transform.position += new Vector3(1, 0, 0);

            if (isValidGridPos())
                updateGrid();
            else
                transform.position += new Vector3(-1, 0, 0);
        }
                                                   
        else if (Input.GetKeyDown(KeyCode.UpArrow))         // Rotate
        {
            transform.Rotate(0, 0, -90);

            if (isValidGridPos())
                updateGrid();
            else
                transform.Rotate(0, 0, 90);
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))       // Fall
        {
            transform.position += new Vector3(0, -1, 0);

            if (isValidGridPos())
            {
                updateGrid();
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);

                Field.DeleteFullRows();

                onBlockFall.Invoke();

                FindObjectOfType<Spawner>().Spawn();

                enabled = false;

                Field.score += 10;                
            }
        }
       
        else if (Input.GetKey(KeyCode.DownArrow) || Time.time - lastFall >= 1)       // Move down quickly
        {
            transform.position += new Vector3(0, -1, 0);

            if (isValidGridPos())
            {
                updateGrid();
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);

                Field.DeleteFullRows();

                onBlockFall.Invoke();

                FindObjectOfType<Spawner>().Spawn();

                enabled = false;

                Field.score += 10;
            }

            lastFall = Time.time;
        }
    }

    bool isValidGridPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 vector = Field.roundVec2(child.position);

            if (!Field.insideBorder(vector))                                             // Out of bounds?
                return false;

            if (Field.grid[(int)vector.x, (int)vector.y] != null &&                      // Block in grid cell (and not part of same group)?
                Field.grid[(int)vector.x, (int)vector.y].parent != transform)
                return false;
        }
        return true;
    }

    void updateGrid()
    {
        for (int y = 0; y < Field.height; ++y)                                           // Remove old figure from grid
            for (int x = 0; x < Field.width; ++x)
                if (Field.grid[x, y] != null)
                    if (Field.grid[x, y].parent == transform)
                        Field.grid[x, y] = null;

        foreach (Transform child in transform)                                           // Add new children to grid
        {
            Vector2 vector = Field.roundVec2(child.position);
            Field.grid[(int)vector.x, (int)vector.y] = child;
        }
    }
}
