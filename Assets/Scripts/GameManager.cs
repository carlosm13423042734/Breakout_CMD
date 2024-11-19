using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int lives;
    private int bloquesRestantes = 0;
    public static GameManager Instance { get; private set; }

    public int Lives { get { return lives; } }
    

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
        
    }
    public void SubstractLives(){
        this.lives--;
        if (this.lives <= 0) {
            Debug.Log("Game over");
            SceneManager.LoadScene("GameOver");
            
        }
    }
    public void addLives() { 
        this.lives++;
    }
    public void CountBlocks() {
        int numeroBloques = GameObject.FindGameObjectsWithTag("block").Length;
    }
}
