using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class PowerUpNuevoBloque : PowerUp
    {
       
        public override void Execute()
        {
            var bloque = GameObject.FindGameObjectWithTag("block");
            if (bloque != null)
            {
                var bloqueScipt = bloque.GetComponent<Block>();
                bloqueScipt.GenerarBloque();
            }
        }
    }
}
