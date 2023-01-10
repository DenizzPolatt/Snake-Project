using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private Tile _tilePrefab;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    private void GenerateGrid()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var tile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                tile.name = "Tile " + x + " " + y;

                var colorSet = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                tile.SetColor(colorSet);
            }
        }
    }
    // private void DrawSnake(Tile tile)
    // {
    //     if (snakeBody.Contains(tile.gameObject.transform.position))
    //     {
    //         Debug.Log("hello");
    //         tile._renderer.material = _tilePrefab.snakeColor;
    //     }
    // }
    
}
