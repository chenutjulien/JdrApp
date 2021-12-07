using System;
using System.Collections.Generic;
using System.Text;

namespace JdrApp.Models
{
    public class Pretre: AvatarJungle
    {
        public Pretre(string nom): base(nom)
        {
            pointsDeVie = 200;
            pvMax = 200;
            degatsMin = 15;
            degatsMax = 20;
            intelligence = 17;
            vivacite = 5;
            cocoID = 2;
        }
    }
}
