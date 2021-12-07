using System;
namespace JdrApp.Models
{
    public class Personnage : Entite //Définition des attributs Personnage
    {
        public int niveau;
        public int experience;
        public bool victoireBrasDeFer = true;
        public Personnage(string nom) : base(nom)
        {
            this.nom = nom;
            niveau = 1;
            experience = 0;
            potionsSoins = 0;
            potionsSoinsMiraculeux = 0;
            dePipe = 0;
            anneauDeChance = 0;
            cleArgent = 0;
        }
        public void GagnerExperience(int experience) //Méthode qui permet de passer de niveau et gagner des caractéristiques.
        {
            
            this.experience += experience;
            while (this.experience >= ExperienceRequise())
            {
                Console.WriteLine("Bravo : Vous avez atteint le niveau " + niveau + " !");
                string messageGainNiveau = "Kawabounga, vous avez atteint le niveau " + niveau + " !";
                messageGainNiveau.ToString();

                niveau += 1;
                pvMax += 10;
                pointsDeVie += 10;
                degatsMin += 4;
                degatsMax += 6;
            }
        }
        public double ExperienceRequise() //Methode qui permet de définir la montée des niveaux (basé sur Pokemon)
        {
            return Math.Round(4 * (Math.Pow(niveau, 3) / 5));
        }        
        public int DeAleatoireChanceux()
        {
            Random deChance = new Random();
            if (anneauDeChance >= 1)
            {
                return deChance.Next(1,11) + 2;
            }
            else
            {
                return deChance.Next(1,11);
            }
        }
        public string DegatsMin() //Méthode pour afficher seulement les dégatsMin pour le Bras de Fer
        {
            return "Vous avez " + degatsMin + " en force";
        }
        public string Caracteristiques() //Méthode qui permet de décrire le statut du héros
        {
            return nom + "\n" + "Niveau: " + niveau + "\n" + "Pv: " + pointsDeVie + " / " + pvMax + " pv\n" + "Points d'expérience: (" + experience + "/" + ExperienceRequise() + ")\n" + "Dégats: [" + degatsMin + "-" + degatsMax + "]\n" + "Vous possedez " + potionsSoins + " potions de soins et " + potionsSoinsMiraculeux + " potions de soins miraculeux et " + piecesOr + " pièces d'or.";
        }
        public string Statistiques() //Méthode qui permet de décrire les dégats et pv du héros
        {
            return nom + " avec " + pointsDeVie + " PV et " + "Dégats: [" + degatsMin + "-" + degatsMax + "]" + "\nPoints d'expérience: (" + experience + "/" + ExperienceRequise() + ") ";
        }
        public int Richesse() //Methode qui permet de décrire la richesse du héros
        {
            return piecesOr;
        }
        public string Inventaire() //Méthode qui permet de décrire le stock de potions
        {
            return "Vous avez maintenant " + potionsSoins + " potions de soins et " + potionsSoinsMiraculeux + " potions de soins miraculeuses.";
        }
        public int Blessure() //Méthode pour avoir une blessure légère
        {
            Random bobo = new Random();
            return pointsDeVie -= bobo.Next(8, 16);
        }
        public int PerdrePointsDeVie() //Méthode qui permet de perdre des PV sur un nombre aléatoire
        {
            Random blessure = new Random();
            return pointsDeVie -= blessure.Next(15, 20);
        }
        public int PerdreBeaucoupPointsDeVie()
        {
            Random hemorragie = new Random();
            return pointsDeVie -= hemorragie.Next(30,40);
        }
        public int GagnerPotionsSoins() //Méthode qui permet de gagner des potions de soins
        {
            Random gainPopo = new Random();
            return potionsSoins += gainPopo.Next(1,3);
        }
        public int GagnerPotionsSoinMiraculeux() //Methode qui permet de gagner 1 potion de soin miraculeux
        {
            return potionsSoinsMiraculeux++;
        }
        public int GagnerCleArgent()
        {
            return cleArgent++;
        }
        public int GagnerDePipe() //Methode qui permet de gagner 1 dés pipés
        {
            return dePipe++;
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
        public int Achat01() //Methode qui permet de payer l'achat de potion de soin miraculeux
        {
            return piecesOr -= 25;
        }
        public int Achat02() //Methode qui permet de payer l'achat du Casque de Puissance
        {
            return piecesOr -= 30;
        }
        public int Achat03() //Methode qui permet de payer l'achat des dés pipés
        {
            return piecesOr -= 15;
        }
        public void GanteletForce() //Methode qui permet de gagner de la puissance d'attaque via le Gantelet de force
        {
            degatsMin += 3;
            degatsMax += 5;
        }
        public void CasquePuissance() //Methode qui permet de gagner de la puissance d'attaque via le Casque de Puissance
        {
            degatsMin += 2;
            degatsMax += 3;
        }
        public void EpeeJustice() //Methode qui permet de gagner de la puissance d'attaque via l'Epée de Justice
        {
            degatsMin += 4;
            degatsMax += 5;
        }
        public void BotteRapidité() //Methode qui permet de gagner de la puissance d'attaque via les Bottes de Rapidité
        {
            degatsMin += 2;
            degatsMax += 2;
        }
        public void GagnerArmureDeVie() //Méthode qui permet de gagner de la puissance d'attaque et des PV via l'Armure de Vie
        {
            degatsMin += 1;
            degatsMax += 3;
            pointsDeVie += 10;
        }
        public void GagnerAnneauUnique() //Méthode pour avoir l'Anneau Unique
        {
            degatsMin += 2;
            degatsMax += 9;
        }
        public void GagnerAnneauDeChance() //Méthode pour avoir l'Anneau de Chance qui permettra d'avoir de meilleur jet de dé(voir méthode DeAleatoireChanceux)
        {
            anneauDeChance++;
        }
        public void GagnerCollierBalrog() //Methode pour avoir le Collier du Balrog qui augmente aussi les pv max
        {
            degatsMin += 3;
            degatsMax += 3;
            pvMax += 15;
        }
        public void PayerRuffianRemise() //Méthode pour payer le ruffian avec une remise
        {
            piecesOr -= 75;
        }
        public void PayerRuffianSansRemise() //Methode pour payer le ruffian plus cher(echec du marchandage)
        {
            piecesOr -= 110;
        }
        public void PayerRuffian() //Méthode pour payer le ruffian normalement
        {
            piecesOr -= 100;
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
        public void OursBiere() //Méthode pour payer un ours à la bière qui redonne de l'energie
        {
            piecesOr -= 10;
            pointsDeVie += 25;
            degatsMin += 1;
        }
        public void AcheterServeuse() //Méthode ppur acheter la serveuse et avoir des tuyaux sur la quete.
        {
            piecesOr -= 5;
            dePipe += 1;
        }
        public void SeFaireVoler()
        {
            Random vol = new Random();
            piecesOr -= vol.Next(20 - 60);
            if (piecesOr < 0)
            {
                piecesOr = 0;
            }
        }
        public int JetterOr()
        {
            Random perteOr = new Random();
            return piecesOr -= perteOr.Next(20, 40);
        }
    }
}
