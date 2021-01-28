using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Camera mainCamera;
    private float paddleInitialY;
    private float defaultPaddleWidthInPixels = 200;
        [SerializeField]
    private float defaultLeftClamp = 600;

    [SerializeField]
    private float defaultRightClamp = 675;
    private SpriteRenderer sr;
    
    #region Singleton

    private static Paddle _instance;

    public static Paddle Instance => _instance;

    public float distanceTraveled;

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

    #endregion
    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        paddleInitialY = this.transform.position.y;
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        PaddleMovement();

    }

  //  float mousePositionWorldX = mainCamera

    private void PaddleMovement()
    {
        float currentPosition = transform.position.x;
        float paddleShift = (defaultPaddleWidthInPixels - ((defaultPaddleWidthInPixels / 2) * this.sr.size.x)) / 2;
        float leftClamp = defaultLeftClamp - paddleShift;
        float rightClamp = defaultRightClamp - paddleShift;
        float mousePositionPixels = Mathf.Clamp(Input.mousePosition.x, leftClamp, rightClamp);
        float mousePositionWorldX = mainCamera.ScreenToWorldPoint(new Vector3(mousePositionPixels, 0, 0)).x;
        this.transform.position = new Vector3(mousePositionWorldX, paddleInitialY, 0);
        distanceTraveled = transform.position.x - currentPosition;
    }
 
}
