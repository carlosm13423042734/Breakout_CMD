using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
   
{

    private bool isLaunched = false;
    private float launchSpeed = 12.5f;
    private Rigidbody2D rigidbody2D;
    private Transform paddle;
    private Vector2 initialLocalPosition;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        initialLocalPosition = transform.localPosition;
        paddle = transform.parent;
        ResetBallPosition();
    }

    // Update is called once per frame
    void Update()
    {
        LaunchBall();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject objectGameManager = GameObject.FindGameObjectWithTag("GameManager");
        GameManager gameManager = objectGameManager.GetComponent<GameManager>();
        if (gameManager != null)
        {
            gameManager.SubstractLives();
            this.ResetBallPosition();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        var objectDamagable = collision.gameObject.GetComponent<IDamagable>();
        if (objectDamagable != null)
        {
            objectDamagable.TakeDamage();
        }

        var objectPaddle = collision.gameObject.GetComponent<Paddle>();
        if (objectPaddle != null) { 
        
            Vector3 paddlePosition = collision.collider.transform.position;
            float paddleWidth = collision.collider.bounds.size.x;

            float hitPercent = (transform.position.x - paddlePosition.x) / paddleWidth + 0.5f;

            float minAngle = 45f;
            float maxAngle = 135f;
            float bounceAngle = Mathf.Lerp(maxAngle, minAngle, hitPercent);

            Vector2 newDirection = Quaternion.Euler(0, 0, bounceAngle) * Vector2.right;
            this.rigidbody2D.velocity = newDirection.normalized * this.launchSpeed;

        }

    }
    private void LaunchBall()
    {

        if (Input.GetKeyDown(KeyCode.Space) && !this.isLaunched)
        {
            this.isLaunched = true;
            this.transform.parent = null;
        
            float randomDirection = Random.Range(-1f, 1f);
            Vector3 launchDirection = new Vector3(randomDirection, 1, 0).normalized;

            this.rigidbody2D.velocity = launchDirection * launchSpeed;
        }
    }
    public void ResetBallPosition() {
        isLaunched = false;
        rigidbody2D.velocity = Vector2.zero;
        transform.parent = paddle; 
        transform.localPosition = initialLocalPosition;
    }
}
