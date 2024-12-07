using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Clase donde muestra los puntos al usuario
public class UIPoints : MonoBehaviour
{

    private Text text;
    void Start()
    {
        this.text = GetComponent<Text>();
    }

    void LateUpdate()
    {
        if (this.text != null)
        {
            this.text.text = $"PUNTOS: {GameManager.Instance.Points}";
        }
    }
}
