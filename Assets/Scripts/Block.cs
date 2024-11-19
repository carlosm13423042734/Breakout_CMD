using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour, IDamagable
{
    private int hits = 1;
    private BlockType type;
    void Awake() {
        switch (type)
        {
            case BlockType.Normal:

                break;

            case BlockType.Big:

                break;

            case BlockType.Small:

                break;

        }
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
            Destroy(this.gameObject);
        }
        GameManager.Instance.CountBlocks();
    }

}
public enum BlockType { 
    Big,
    Normal,
    Small

}
