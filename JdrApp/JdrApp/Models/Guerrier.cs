using System;
using System.Collections.Generic;
using System.Text;

namespace JdrApp.Models
{
    public class Guerrier: Personnage
    {
        public Guerrier (string nom) : base(nom)
        {
            pointsDeVie = 250;
            degatsMin = 25;
            degatsMax = 30;
            pvMax = 250;
        }
    }
}
