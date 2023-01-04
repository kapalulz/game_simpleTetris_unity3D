using System;
using System.Collections;
using UnityEngine;

public class Tetrominoes : MonoBehaviour
{
    public Vector3 rotationPoint;
    public float fallTime = 0.8f;
    public float previousTime;
    public Sprite sprite;
    public Animator anim;
    
    private static int height = 20;
    private static int width = 10;
    private float _timer;
    private static Transform[,] grid = new Transform[width, height];
    

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        _timer += Time.deltaTime;
        
        if (Input.GetKey(KeyCode.A) && _timer >= 0.2f)
        {
            _timer = 0;
            transform.position += new Vector3(-1, 0, 0);
            if (!ValidMove())
                transform.position -= new Vector3(-1, 0, 0);
        }
        
        if (Input.GetKey(KeyCode.Space) && _timer >= 0.01f)
        {
            _timer = 0;
            transform.position += new Vector3(0, -1, 0);
            if (!ValidMove())
                transform.position -= new Vector3(0, -1, 0);
        }
        
        else if (Input.GetKey(KeyCode.D) && _timer >= 0.2f)
        {
            _timer = 0;
            transform.position += new Vector3(1, 0, 0);
            if (!ValidMove())
                transform.position -= new Vector3(1, 0, 0);
        }


        if (Time.time - previousTime > (Input.GetKey(KeyCode.S) ? fallTime / 10 : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
       
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                CheckForLines();
                this.enabled = false;
                FindObjectOfType<Spawn>().GoAgain();
            }

            previousTime = Time.time;
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0,0,1), 90);
            if (!ValidMove())
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
        }
    }
    void CheckForLines()
    {
        for (int i = height-1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
            }
        }
    }
    
    void CheckForHeightLine()
    {
        FindObjectOfType<PauseMenu>().Dead();
    }
    
    bool HasLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            if (grid[j, i] == null)
                return false;
        }

        return true;
    }
    void DeleteLine(int i)
    {
        
        for (int j = 0; j < width; j++)
        {
            grid[j, i].GetComponent<Animation>().Play();
            //Time.timeScale = 0f;
            StartCoroutine(Explode());
            
            Destroy(grid[j,i].gameObject);
            grid[j, i] = null;
        }
       
        // Check for Score
        var score = FindObjectOfType<Score>();
        score.Check();
        score.PlaySound();
        
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(3.3f);
    }

    void RowDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int j = 0; j < width; j++)
            {
                if (grid[j, y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }
    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if (roundedY > 19)
            {
                CheckForHeightLine();
            }
            else
                grid[roundedX, roundedY] = children;
        }
    }
    bool ValidMove()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
            {
                return false;
            }

            if (grid[roundedX, roundedY] != null)
             return false;
            
        }

        return true;
    }
    
}

    

