using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Material material1;
    public Material material2;
    public Material snakeColor;
    public SpriteRenderer _renderer;

    public void SetColor(bool changeColor)
    {
        if (changeColor) _renderer.material = material1;
        else
        {
            _renderer.material = material2;
        }
    }

    public void ColorTheSnake()
    {
        _renderer.material = snakeColor;
    }
}
