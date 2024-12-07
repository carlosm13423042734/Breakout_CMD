
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour, IDamagable
{
    private int hits = 1;
    public GameObject block; 
    public float minX = -4.4f;
    public float maxX = 4.1f;
    public float minY = 1.5f;
    public float maxY = 3.8f;
    SpriteRenderer spriteRenderer;

    private PowerUp powerUp;
   
    //Método de la interfaz IDamagable donde al chocar con la bola, pierde la vida que tiene, se destruyem suma los puntos y genera un nuevo bloque
    public void TakeDamage() {

        this.hits--;
        if (this.hits <= 0) {
            Destroy(this.gameObject);
            GameManager.Instance.addPoints();
            this.spriteRenderer = GetComponent<SpriteRenderer>();
            this.powerUp = PowerUpFactory.CreatePowerUp();
            GenerarBloque();
           
        }
        
    }
    //Este método instancia un nuevo bloque en una posición vacía y que esté dentro de unos límites
    public void GenerarBloque()
    {
        bool posicionValida = false;
        Vector3 vector = Vector3.zero;

        while (!posicionValida)
        {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            vector = new Vector3(x, y, 0);
            Vector2 blockSize = new Vector2(x, y);
            blockSize = block.GetComponent<SpriteRenderer>().bounds.size;
            Collider2D[] colliders = Physics2D.OverlapBoxAll(vector, blockSize, 0);
            if (colliders.Length == 0)
            {
                posicionValida = true;
            }
        }
        GameObject blockClone = (GameObject)Instantiate(block, vector, Quaternion.identity);
        blockClone.AddComponent<BoxCollider2D>();
        blockClone.AddComponent<Block>();
    }


}
