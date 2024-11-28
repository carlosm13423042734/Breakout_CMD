
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
   

    private PowerUp powerUp;
    void Awake() {
        //this.spriteRenderer = GetComponent<SpiteRenderer>();
        //this.SetInitialSprite();
        //this.powerUp = PowerUpFactory.CreatePowerUp();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
       
    }
    public void TakeDamage() {

        this.hits--;
        if (this.hits <= 0) {
            //if (potenciador != null)
            //{
            //    potenciador.Ejecuta();
            //}
            Destroy(this.gameObject);
            GenerarBloque();
           
        }
        GameManager.Instance.CountBlocks();
        
    }
    private void SetInitialSprite() {

        //this.normalSprite = Resources.Load<Sprite>($"Sprites/{type}"):
        //this.brokenSprite = Resource.Load<Sprite>($"Sprites/{type}Broken");
        //this.spriteRenderer.sprite = normalSprite;
    }
    private void GenerarBloque()
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
