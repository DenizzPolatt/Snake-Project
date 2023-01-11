using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    [SerializeField] public Queue<Tile> snakeBody = new Queue<Tile>();
    private Tile[] positions; 
    [SerializeField] private Tile _tile;
    private Vector3 head = new Vector3(4, 3);
    [SerializeField] private FoodSpawner foodSpawner;
    [SerializeField] private Material snakeMaterial;

    private bool up;
    private bool down;
    private bool left;
    private bool right;
    
    public TextMeshProUGUI GameOverText;
    public Button RestartButton;
    // Start is called before the first frame update
    void Start()
    {
        
        snakeBody.Enqueue(Instantiate(_tile, new Vector3(4, 0), Quaternion.identity));
        snakeBody.Enqueue(Instantiate(_tile, new Vector3(4, 1), Quaternion.identity));
        snakeBody.Enqueue(Instantiate(_tile, new Vector3(4, 2), Quaternion.identity));
        snakeBody.Enqueue(Instantiate(_tile, new Vector3(4, 3), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        _tile._renderer.material = snakeMaterial;
        Move();
        EatFood();
        Compare();
        CheckGameOver();
    }
    
    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            up = true;
            down = false;
            left = false;
            right = false;
            head = new Vector3(head.x, head.y + 1);
            Destroy(snakeBody.Peek().gameObject);
            snakeBody.Dequeue();
            snakeBody.Enqueue(Instantiate(_tile, head, Quaternion.identity));
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            left = true;
            up = right = down = false;
            head = new Vector3(head.x - 1, head.y);
            Destroy(snakeBody.Peek().gameObject);
            snakeBody.Dequeue();
            snakeBody.Enqueue(Instantiate(_tile, head, Quaternion.identity));
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            right = true;
            up = down = left = false;
            head = new Vector3(head.x + 1, head.y);
            Destroy(snakeBody.Peek().gameObject);
            snakeBody.Dequeue();
            snakeBody.Enqueue(Instantiate(_tile, head, Quaternion.identity));
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            down = true;
            up = left = right = false;
            head = new Vector3(head.x, head.y - 1);
            Destroy(snakeBody.Peek().gameObject);
            snakeBody.Dequeue();
            snakeBody.Enqueue(Instantiate(_tile, head, Quaternion.identity));
        }
    }

    private void EatFood()
    {
        if (foodSpawner._spawnPos == head)
        {
            var _food = GameObject.Find("FoodTile(Clone)");
            Destroy(_food);
            if (up) head = new Vector3(head.x, head.y + 1);
            else if (down) head = new Vector3(head.x, head.y - 1);
            else if (right) head = new Vector3(head.x + 1, head.y);
            else if (left) head = new Vector3(head.x - 1, head.y);
            snakeBody.Enqueue(Instantiate(_tile, head, Quaternion.identity));
            
            foodSpawner.Spawn();
        }
    }

    private void CheckGameOver()
    {
        if (head.x < 0 || head.x > 14 || head.y < 0 || head.y > 14)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        left = right = up = down = false;
        GameOverText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void Compare()
    {
        positions = snakeBody.ToArray();
        for (int i = 0; i < positions.Length - 1; ++i)
        {
            if (Vector3.Distance(positions[i].transform.position,head) < 0.1f) GameOver();
        }
    }
}
