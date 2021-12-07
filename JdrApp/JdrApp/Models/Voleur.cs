using System;
using System.Collections.Generic;
using System.Text;

namespace JdrApp.Models
{
    public class Voleur: Personnage
    {
        public Voleur(string nom) : base(nom)
        {
            pointsDeVie = 200;
            degatsMin = 30;
            degatsMax = 35;
            pvMax = 200;
        }
    }
}
