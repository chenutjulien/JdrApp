using System;
using System.Collections.Generic;
using System.Text;

namespace JdrApp.Models
{
    public class ArcherJungle: AvatarJungle
    {
        public ArcherJungle(string nom): base(nom)
        {
            pointsDeVie = 150;
            pvMax = 150;
            degatsMin = 25;
            degatsMax = 35;
            intelligence = 5;
            vivacite = 7;
            cocoID = 3;
        }
    }
}
