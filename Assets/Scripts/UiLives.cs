using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiLives : MonoBehaviour
{
    private Text text;
   
    private void Awake()
    {
        this.text = GetComponent<Text>();
    }

    private void LateUpdate()
    {
        if (this.text != null)
        {
            this.text.text = $"Vidas: {GameManager.Instance.Lives}";
        }
    }
}
