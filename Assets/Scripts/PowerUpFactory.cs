using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Clase donde se generan los distintos PowerUps con sus probabilidades
public class PowerUpFactory 
{
    public static PowerUp CreatePowerUp() {

        int random = Random.Range(0, 100);
        if (random < 2)
        {
            Debug.Log("POTENCIADOR BLOQUE");
            var nuevoBloque = new PowerUpNuevoBloque();
            nuevoBloque.Execute();
            return nuevoBloque;

        }
        else if (random < 7) {
            Debug.Log("POTENCIADOR VIDA");
            var nuevaVida = new PowerUpAddLive();
            nuevaVida.Execute();
            return nuevaVida;
        }
        else if (random < 50)
        {
            Debug.Log("POTENCIADOR PALA");
            var paddleSize = new PowerUpPaddleSize();
            paddleSize.Execute();
            return paddleSize;
        }
        return null;
    }
}
