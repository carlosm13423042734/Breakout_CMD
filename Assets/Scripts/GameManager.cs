using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Esta clase es la que maneja el numero de vidas y los puntos que tiene el jugador en cada partida.
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int lives;
    private int points;
    private int bloquesRestantes = 0;
    public static GameManager Instance { get; private set; }

    public int Lives { get { return lives; } }
    public int Points { get { return points; } }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else { 
            Destroy(this.gameObject);
        }
        this.lives = 3;
        this.points = 0;
        
    }
    public void SubstractLives(){
        this.lives--;
        if (this.lives <= 0) {
            SceneManager.LoadScene("GameOver");
            this.lives = 3;
            this.points = 0;
        }
    }
    public void addLives() { 
        this.lives++;
    }
    public void CountBlocks() {
        int numeroBloques = GameObject.FindGameObjectsWithTag("block").Length;
    }
    public void addPoints() {
        this.points += 100;
    }
}
