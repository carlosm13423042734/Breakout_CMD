using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour, IDamagable
{
    [SerializeField]
    private float velocidad = 5.5f;
    [SerializeField]
    private GameObject paredIzq = null;
    [SerializeField]
    private GameObject paredDerecha = null;

    private float limiteIzquierdo = 0f;

    private float limiteDerecho = 0f;

    void Start()
    {
        ExtraerLimites();
    }

   
    void Update()
    {
        MovimientoPala();
    }

    private void ExtraerLimites() {

        var anchoPala = this.GetComponent<SpriteRenderer>().bounds.size.x;
        var anchoIzquierda = this.paredIzq.GetComponent<SpriteRenderer>().bounds.size.x;
        var anchoDerecha = this.paredDerecha.GetComponent<SpriteRenderer>().bounds.size.x;

        limiteDerecho = this.paredDerecha.transform.position.x + anchoDerecha / 2 - anchoPala / 2;
        limiteIzquierdo = this.paredIzq.transform.position.x + anchoIzquierda / 2 + anchoPala / 2;
    }

    private void MovimientoPala() {
        float direccionMovimiento = Input.GetAxisRaw("Horizontal");
        float posicionActualX = this.transform.position.x;
        float nuevaPosicionX = direccionMovimiento * this.velocidad * Time.deltaTime + posicionActualX;
        nuevaPosicionX = Mathf.Clamp(nuevaPosicionX, limiteIzquierdo, limiteDerecho);
        this.transform.position = new Vector2(nuevaPosicionX, this.transform.position.y);
    }
    public void TakeDamage() {
        /*Ball ball = FindObjectOfType<Ball>(); 

        if (ball != null)
        {
            Rigidbody2D ballRigidbody = ball.GetComponent<Rigidbody2D>();
            float xDifference = ball.transform.position.x - transform.position.x;

            float normalizedPosition = xDifference / (GetComponent<BoxCollider2D>().bounds.size.x / 2);

            float angle = normalizedPosition * 45f; 
            Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.up;

            ballRigidbody.velocity = direction * ballRigidbody.velocity.magnitude;
        }*/
    }
}
