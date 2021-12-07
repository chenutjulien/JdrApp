using System;
using System.Collections.Generic;
using System.Text;

namespace JdrApp.Models
{
    public class Gobelin : Monstre
    {
        public Gobelin(string nom, int pointsDeVie, int degatsMin, int degatsMax) : base(nom, pointsDeVie, degatsMin, degatsMax)
        {
          
        }

        public override string ToString()
        {
            return "Nom: " + nom + "   Points de Vie: " + pointsDeVie + "  Degats Min: " + degatsMin + "  Degats Max:  " + degatsMax;
        }
    }
}
