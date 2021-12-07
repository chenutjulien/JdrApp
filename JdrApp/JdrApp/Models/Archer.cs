using System;
using System.Collections.Generic;
using System.Text;

namespace JdrApp.Models
{
    public class Archer: Personnage
    {
        public Archer(string nom) : base(nom)
        {
            pointsDeVie = 150;
            degatsMin = 35;
            degatsMax = 40;
            pvMax = 150;
        }
    }
}
