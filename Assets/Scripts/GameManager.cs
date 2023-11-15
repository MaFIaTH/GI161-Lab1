using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private int playerScore;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform[] ballPositions;

    public int PlayerScore
    {
        get => playerScore;
        set
        {
            playerScore = value;
        }
    }

    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else 
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ballPositions.Length; i++)
        {
            SetBall((BallColor)i, i);
        }
    }

    private void SetBall(BallColor color, int posIndex)
    {
        Ball ball = Instantiate(ballPrefab, 
            ballPositions[posIndex].position, 
            Quaternion.identity).GetComponent<Ball>();
        ball.SetColorAndPoint(color);
    }
}
