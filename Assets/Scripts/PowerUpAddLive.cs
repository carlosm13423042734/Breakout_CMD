using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Scripts
{
    public class PowerUpAddLive : PowerUp
    {
        public override void Execute()
        {
            //Potenciador que añade una vida si tienes menos de 5
            if (GameManager.Instance.Lives < 5)
            {
                GameManager.Instance.addLives();
                Debug.Log("Tienes " + GameManager.Instance.Lives);
            }
        }
    }
}
