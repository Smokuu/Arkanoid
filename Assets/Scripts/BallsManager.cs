﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsManager : MonoBehaviour
{
    #region Singleton

    private static BallsManager _instance;

    public static BallsManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }



    public bool IsGameStarted { get; set; }

    #endregion

    
    [SerializeField]
    private Ball ballPrefab;

    private Ball initialBall;

    public float initialBallSpeed = 250;

    public float horizontalSpeed;

    private Rigidbody2D initialBallRb;

   

    public List<Ball> Balls { get; set;  }

    private void Start()
    {
        InitBall();
    }

    private void Update()
    {
        if (!GameManager.Instance.IsGameStarted)
        {
            Vector3 paddlePosition = Paddle.Instance.gameObject.transform.position;
            Vector3 ballPosition = new Vector3(paddlePosition.x, paddlePosition.y + .27f, 0);
            initialBall.transform.position = ballPosition;

            if (Input.GetMouseButtonDown(0))
            {
                initialBallRb.isKinematic = false;
                initialBallRb.gravityScale = 0;

                initialBallRb.AddForce(new Vector2(Paddle.Instance.distanceTraveled * horizontalSpeed, initialBallSpeed));
                GameManager.Instance.IsGameStarted = true;

            }
        }
    }
    
    private void InitBall()
    {
        Vector3 paddlePosition = Paddle.Instance.gameObject.transform.position;
        Vector3 startingPosition = new Vector3(paddlePosition.x, paddlePosition.y + .27f, 0);
        initialBall = Instantiate(ballPrefab, startingPosition, Quaternion.identity);
        initialBallRb = initialBall.GetComponent<Rigidbody2D>();

        this.Balls = new List<Ball>
        {
            initialBall
        };
    }




}