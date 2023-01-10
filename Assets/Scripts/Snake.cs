using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private Queue<Vector3> snakeBody = new Queue<Vector3>();
    [SerializeField] private Tile _tile;

    [SerializeField] private Material snakeMaterial;
    
    // Start is called before the first frame update
    void Start()
    {
        snakeBody.Enqueue(new Vector3(4, 0));
        snakeBody.Enqueue(new Vector3(4, 1));
        snakeBody.Enqueue(new Vector3(4, 2));
        snakeBody.Enqueue(new Vector3(4, 3));
        
        DrawSnake();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void DrawSnake()
    {
        foreach (var pos in snakeBody)
        {
            var tile = Instantiate(_tile, new Vector3(pos.x, pos.y), Quaternion.identity);
            tile._renderer.material = snakeMaterial;
        }
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            
        }
    }
}
