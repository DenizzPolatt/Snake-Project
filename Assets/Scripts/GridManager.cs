using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width;

    [SerializeField] private int height;

    [SerializeField] private Tile _tilePrefab;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var tile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                tile.name = "Tile " + x + " " + y;

                var colorSet = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                tile.SetColor(colorSet);
            }
        }
        
        
    }
}
