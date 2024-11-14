using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int lives;
    private int bloquesRestantes;
    public static GameManager Instance { get; private set; }

    public int Lives { get { return lives; } }
    public int BloquesRestantes { get; set; }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        this.lives = 3;
    }
    public void SubstractLives(){
        this.lives--;
        if (this.lives <= 0) {
            Debug.Log("Game over");
        }
    }
    public void addLives() { 
        this.lives++;
    }
    public void CountBlocks() {
        int numeroBloques = GameObject.FindGameObjectsWithTag("Block").Length;
    }
}
