using System;
using System.Collections.Generic;
using System.Text;

namespace JdrApp.Models
{
    public class Justicier: AvatarJungle
    {
        public Justicier(string nom): base(nom)
        {
            pointsDeVie = 250;
            pvMax = 250;
            degatsMin = 30;
            degatsMax = 35;
            intelligence = 3;
            vivacite = 3;
            cocoID = 1;
        }
    }
}
