using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallColor
{
    White = 0,
    Red = 1,
    Yellow = 2,
    Green = 3,
    Brown = 4,
    Blue = 5,
    Pink = 6,
    Black = 7
}
public class Ball : MonoBehaviour
{
    [SerializeField] private int point;
    [SerializeField] private BallColor ballColor;

    private MeshRenderer _meshRenderer;
    public int Point => point;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetColorAndPoint(BallColor ballColor)
    {
        point = (int)ballColor;
        switch (ballColor)
        {
            case BallColor.White:
                _meshRenderer.material.color = Color.white;
                break;
            case BallColor.Red:
                _meshRenderer.material.color = Color.red;
                break;
            case BallColor.Yellow:
                _meshRenderer.material.color = Color.yellow;
                break;
            case BallColor.Green:
                _meshRenderer.material.color = Color.green;
                break;
            case BallColor.Brown:
                _meshRenderer.material.color = new Color32(181, 101, 29, 255);
                break;
            case BallColor.Blue:
                _meshRenderer.material.color = Color.blue;
                break;
            case BallColor.Pink:
                _meshRenderer.material.color = new Color32(255, 15, 192, 255);
                break;
            case BallColor.Black:
                _meshRenderer.material.color = Color.black;
                break;
        }
    }
    
}
