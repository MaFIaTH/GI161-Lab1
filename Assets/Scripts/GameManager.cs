using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private int playerScore;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform[] ballPositions;
    [SerializeField] private GameObject cueBall;
    [SerializeField] private GameObject ballLine;
    [SerializeField] private float xInput;
    [SerializeField] private TMP_Text scoreText;

    private Rigidbody _rigidbody;
    private GameObject _camera;

    public int PlayerScore
    {
        get => playerScore;
        set
        {
            playerScore = value;
            UpdateScore();
        }
    }

    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else 
            Destroy(gameObject);
        _rigidbody = cueBall.GetComponent<Rigidbody>();
        _camera = Camera.main.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ballPositions.Length; i++)
        {
            SetBall((BallColor)i + 1, i);
        }
        CameraBehindCueBall();
        UpdateScore();
    }

    private void Update()
    {
        RotateBall();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBall();
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StopBall();
        }
    }

    private void SetBall(BallColor color, int posIndex)
    {
        Ball ball = Instantiate(ballPrefab, 
            ballPositions[posIndex].position, 
            Quaternion.identity).GetComponent<Ball>();
        ball.SetColorAndPoint(color);
    }

    private void RotateBall()
    {
        xInput = Input.GetAxis("Horizontal");
        cueBall.transform.Rotate(new Vector3(0f, xInput / 7f, 0f));
    }

    private void ShootBall()
    {
        _camera.transform.parent = null;
        _rigidbody.AddRelativeForce(Vector3.forward * 50f, ForceMode.Impulse);
        ballLine.SetActive(false);
        
    }

    private void CameraBehindCueBall()
    {
        _camera.transform.parent = cueBall.transform;
        _camera.transform.position = cueBall.transform.position + new Vector3(0, 7f, -10f);
        _camera.transform.rotation = Quaternion.Euler(30f, 0f, 0f);
    }

    public void StopBall()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        cueBall.transform.eulerAngles = Vector3.zero;
        CameraBehindCueBall();
        ballLine.SetActive(true);
    }

    private void UpdateScore()
    {
        scoreText.text = $"Score: {playerScore}";
    }
}
