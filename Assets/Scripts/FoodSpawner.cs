using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public Vector3 _spawnPos;
    [SerializeField] public Tile _objectToSpawn;
    public Snake snake;
    
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        RandomPosition();
        Instantiate(_objectToSpawn, _spawnPos, Quaternion.identity);
    }

    private void RandomPosition()
    {
        _spawnPos = new Vector3(Random.Range(1, 14), Random.Range(1, 14));
        foreach (var tile in snake.snakeBody)
        {
            if (tile.transform.position == _spawnPos)
            {
                RandomPosition();
            }
        }
    }
}
