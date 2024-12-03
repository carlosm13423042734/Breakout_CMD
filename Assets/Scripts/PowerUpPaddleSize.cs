﻿using UnityEngine;

public class PowerUpPaddleSize : PowerUp
{
    public override void Execute()
    {
        var paddle = GameObject.FindGameObjectWithTag("Paddle");
        if (paddle != null)
        {
            var paddleScript = paddle.GetComponent<Paddle>();
            Transform paddleTransform = paddle.transform;
            Vector3 originalScale = paddleTransform.localScale;
            float nuevoX = Random.Range(1.7f, 3.5f);
            paddleTransform.localScale = new Vector3(nuevoX, originalScale.y, originalScale.z);
            paddleScript.ExtraerLimites();
            

        }
    }
}