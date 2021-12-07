using System;
using System.Collections.Generic;
using System.Text;

namespace JdrApp.Models
{
    public abstract class EntiteJungle
    {
        protected string nom;
        protected bool estMort = false;
        protected int pointsDeVie;
        protected int pvMax;
        protected int degatsMin;
        protected int degatsMax;
        protected int vivacite;
        protected int intelligence;
        protected int potionsSoins;
        protected int potionsSoinsMiraculeux;
        protected int piecesOr;
        protected int cocoID;

        protected Random random = new Random();
        //Constructeur avec 1 seul paramètre pour gérer les personnages et si il y a SEULEMENT 1 monstre
        public EntiteJungle(string nom)
        {
            this.nom = nom;
        }
        //constructeur avec 4 paramètres pour gérer une liste aléatoire de monstres
        public EntiteJungle(string nom, int pointsDeVie, int degatsMin, int degatsMax) : this(nom)
        {
            this.nom = nom;
            this.pointsDeVie = pointsDeVie;
            this.degatsMin = degatsMin;
            this.degatsMax = degatsMax;
        }
        //Methode qui permet d'attaquer, se sert de la classe Entité (Monstre & Personnage) avec des dégats aléatoire entre les dégats min et dégats max
        public void Attaquer(EntiteJungle uneEntiteJungle)
        {
            int degats = random.Next(degatsMin, degatsMax);
            uneEntiteJungle.PerdrePointsDeVie(degats);

            Console.WriteLine(this.nom + "(" + this.pointsDeVie + ")" + " attaque: " + uneEntiteJungle.nom);
            Console.WriteLine(uneEntiteJungle.nom + " a perdu " + degats + " points de vie");
            Console.WriteLine("Il reste " + uneEntiteJungle.pointsDeVie + " point de vie à " + uneEntiteJungle.nom);
            if (uneEntiteJungle.estMort)
            {
                Console.WriteLine(uneEntiteJungle.nom + " est mort !");
            }
        }
        //Methode qui permet de perdre les PV, indique quand on est mort et bloque les pv à 0 en cas de perte négative
        protected void PerdrePointsDeVie(int pointsDeVie)
        {
            this.pointsDeVie -= pointsDeVie;
            if (this.pointsDeVie <= 0)
            {
                this.pointsDeVie = 0;
                estMort = true;
            }
        }
        public bool EstMort()
        {
            return this.estMort;
        }
    }
}
