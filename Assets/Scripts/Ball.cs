using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
   
{

    private bool isLaunched = false;
    private float launchSpeed = 12.0f;
    private Rigidbody2D rigidbody2D;
    private Transform paddle;
    private Vector2 initialLocalPosition;
    GameManager gameManager;

    // Al empezar, deja la boola en su posición inicial
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
    //Cuando la pelota choca contra el elemento vacío de abajo, el jugador pierde una vida y devuelve la bola a la posición inicial
    private void OnTriggerEnter2D(Collider2D collision)
    {      
          GameManager.Instance.SubstractLives();
          this.ResetBallPosition();     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si el objeto con el que choca tiene implementada la interfaz IDamagable, ejecutará el método TakeDamage
        var objectDamagable = collision.gameObject.GetComponent<IDamagable>();
        if (objectDamagable != null)
        {
            objectDamagable.TakeDamage();
        }
        //Esto es para que al chocar con la pala, devuelva la bola con una dirección determinada
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
    //Método para lanzar la bola al pulsar el espacio y empezar a jugar. Se lanza con una dirección aleatoria y también lo separa del paddle
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
    //Método para cuando el usuario pierde una vida o empieza el juego, ponga la bola en su lugar y como hija del paddle.
    public void ResetBallPosition() {
        isLaunched = false;
        rigidbody2D.velocity = Vector2.zero;
        transform.parent = paddle; 
        transform.localPosition = initialLocalPosition;
    }
}
