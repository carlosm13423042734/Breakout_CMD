using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPoints : MonoBehaviour
{

    private Text text;
    void Start()
    {
        this.text = GetComponent<Text>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (this.text != null)
        {
            this.text.text = $"PUNTOS: {GameManager.Instance.Points}";
        }
    }
}
