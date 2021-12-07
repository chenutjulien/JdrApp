using System;
using System.Collections.Generic;
using System.Text;

namespace JdrApp.Models
{
    public class AvatarJungle : EntiteJungle //Définition des attributs de l'avatar
    {
        public int niveau;
        public int experience;

        public AvatarJungle(string nom) : base(nom)
        {
            this.nom = nom;
            niveau = 1;
            experience = 0;
            potionsSoins = 0;
            potionsSoinsMiraculeux = 0;
        }
        public void GagnerExperience(int experience) //Méthode qui permet de passer de niveau et gagner des caractéristiques en fonction de la classe et du niveau pair/impair
        {
            
            this.experience += experience;
            while (this.experience >= ExperienceRequise())
            {
                if (cocoID == 1) //Gain de niveau pour le Justicier
                {
                    Console.WriteLine("Bravo : Vous avez atteint le niveau " + niveau + " !");
                    string messageGainNiveau = "Kawabounga, vous avez atteint le niveau " + niveau + " !";
                    messageGainNiveau.ToString();

                    niveau += 1;
                    pvMax += 20;
                    pointsDeVie += 20;
                    degatsMin += 5;
                    degatsMax += 9;
                    piecesOr += 10;
                    if (niveau % 2 == 0)
                    {
                        intelligence += 1;
                        vivacite += 1;
                    }
                }
                else if (cocoID == 2) //Gain de niveau pour le Prêtre
                {
                    Console.WriteLine("Bravo : Vous avez atteint le niveau " + niveau + " !");
                    string messageGainNiveau = "Kawabounga, vous avez atteint le niveau " + niveau + " !";
                    messageGainNiveau.ToString();

                    niveau += 1;
                    pvMax += 15;
                    pointsDeVie += 15;
                    degatsMin += 4;
                    degatsMax += 6;
                    piecesOr += 10;
                    if (niveau % 2 == 0)
                    {
                        intelligence += 2;
                        vivacite += 1;
                    }
                }
                else //Gain de niveau pour l'Archer
                {
                    Console.WriteLine("Bravo : Vous avez atteint le niveau " + niveau + " !");
                    string messageGainNiveau = "Kawabounga, vous avez atteint le niveau " + niveau + " !";
                    messageGainNiveau.ToString();

                    niveau += 1;
                    pvMax += 10;
                    pointsDeVie += 10;
                    degatsMin += 4;
                    degatsMax += 8;
                    piecesOr += 10;
                    if (niveau % 2 == 0)
                    {
                        intelligence += 1;
                        vivacite += 2;
                    }
                }
            }
        }
        public double ExperienceRequise() //Méthode qui permet de définir la montée des niveaux (basé sur Pokemon)
        {
            return Math.Round(4 * (Math.Pow(niveau, 3) / 5));
        }
        public int StatutID() //Méthode qui permet de savoir quelle classe est joué
        {
            return cocoID;
        }
        public int PointsDeVie() //Méthode qui affiche les points de vie du héros
        {
            return pointsDeVie;
        }
        public int Experience() //Méthode qui affiche les XP du héros
        {
            return experience;
        }
        public int Niveau() //Méthode qui affiche le niveau du héros
        {
            return niveau;
        }
        public int Vivacite() //Méthode qui affiche la vivacité du héros
        {
            return vivacite;
        }
        public int Intelligence() //Méthode qui affiche l'intelligence du héros
        {
            return intelligence;
        }
        public string Attaque() //Méthode qui affiche les dégats du héros
        {
            return "Attaque: " + degatsMin + "-" + degatsMax;
        }
        public int Richesse() //Methode qui permet de décrire la richesse du héros
        {
            return piecesOr;
        }
        public string Potions() //Méthode qui permet de décrire le stock de potions
        {
            return potionsSoins + " / " + potionsSoinsMiraculeux;
        }
        public int Blessure() //Méthode pour avoir une blessure légère sur un nombre aléatoire
        {
            Random bobo = new Random();
            return pointsDeVie -= bobo.Next(8, 16);
        }
        public int PerdrePointsDeVie() //Méthode pour avoir une blessure moyenne sur un nombre aléatoire
        {
            Random blessure = new Random();
            return pointsDeVie -= blessure.Next(15, 25);
        }
        public int PerdreBeaucoupPointsDeVie() //Méthode pour avoir une blessure moyenne sur un nombre aléatoire
        {
            Random hemorragie = new Random();
            return pointsDeVie -= hemorragie.Next(30, 45);
        }
        public int GagnerPotionsSoins() //Méthode qui permet de gagner des potions de soins
        {
            Random gainPopo = new Random();
            return potionsSoins += gainPopo.Next(1, 3);
        }
        public int GagnerPotionsSoinMiraculeux() //Methode qui permet de gagner 1 potion de soin miraculeux
        {
            return potionsSoinsMiraculeux++;
        }
        public int GagnerPiecesOr() //Méthode qui permet de gagner des pièces d'or
        {
            Random gainPiecesOr = new Random();
            return piecesOr += gainPiecesOr.Next(30, 40);
        }
        public int GagnerBeaucoupOr() //Méthode qui permet de gagner beaucoup de pièces d'or
        {
            Random grosGainOr = new Random();
            return piecesOr += grosGainOr.Next(80, 100);
        }
        public void RecupererPVPotionDeSoin() //Méthode pour recupérer des PV via les potions de soins avec conditions pour pas dépasser les pv max.
        {
            if (potionsSoins >= 1)
            {
                potionsSoins -= 1;
                Random gainPvPopo = new Random();
                pointsDeVie += gainPvPopo.Next(25, 35);
                if (pointsDeVie > pvMax)
                {
                    pointsDeVie = pvMax;
                }
            }
        }
        public void RecupererPVPotionDeSoinMiraculeux() //Méthode pour recupérer des PV via les potions de soins miraculeux avec conditions pour pas dépasser les pv max.
        {
            if (potionsSoinsMiraculeux >= 1)
            {
                potionsSoinsMiraculeux -= 1;
                Random gainPvPopoMiraculeux = new Random();
                pointsDeVie += gainPvPopoMiraculeux.Next(55, 85);
            }
            if (pointsDeVie > pvMax)
            {
                pointsDeVie = pvMax;
            }
        }
        public void PendentifVivacité() //Méthode pour gagner de la vivacité via le <<Pendentif de Vivacité>>
        {
            vivacite++;
        }
        public void AnneauLiberte() //Méthode pour gagner de l'intelligence via l'<<Anneau de Liberté>>
        {
            intelligence++;
        }
    }
}
