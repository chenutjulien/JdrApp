using JdrApp.Models;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;

namespace JdrApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Donjon02 : ContentPage
    {
        private int tentative = 0; // Sert de compteur pour la méthode des enigmes
        private int nbrChoix = 0; // Sert de compteur pour la méthode du vol des objets (CheckBox)
        private int nbrChoixMax = 1; // Limite à 2 tentatives le vol d'objets (CheckBox)
        private int nbrCombat = 1; //Sert de compteur pour le tournoi de lutte
        List<Monstre> monstres = new List<Monstre>(); //Sert à créer une liste de lutteur pour le tournoi de lutte
        Random random = new Random(); //Un random tout bête qui sert pour l'instant pour le tournoi de lutte

        Personnage monPerso = new Personnage("");

        public Donjon02()
        {
            InitializeComponent();
            monstres.Add(new Monstre("Balouf", 75, 35, 35));
            monstres.Add(new Monstre("Pilaf", 85, 25, 30));
            monstres.Add(new Monstre("Mastor", 100, 35, 40));
            monstres.Add(new Monstre("Gringo", 50, 45, 45));
            monstres.Add(new Monstre("Brutor", 150, 10, 15));
        }
        //Méthode pour annoncer le gain de niveau en fonction du nombre de points d'expérience
        public void AnnonceNiveau()
        {
            if (monPerso.experience > 1 && monPerso.experience < 6) /*Niveau 2*/
            {
                TextSupplementaireHaut.Text = "Kawabounga, vous avez gagnez un niveau ! Vous etes de niveau " + monPerso.niveau + " !";
                TextSupplementaireHaut.IsVisible = true;
            }
            else if (monPerso.experience >= 6 && monPerso.experience < 22) /*Niveau 3*/
            {
                TextSupplementaireHaut.Text = "Kawabounga, vous avez gagnez un niveau ! Vous etes de niveau " + monPerso.niveau + " !";
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.TextColor = Color.Blue;
            }
            else if (monPerso.experience >= 22 && monPerso.experience < 51) /*Niveau 4*/
            {
                TextSupplementaireHaut.Text = "Kawabounga, vous avez gagnez un niveau ! Vous etes de niveau " + monPerso.niveau + " !";
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.TextColor = Color.GreenYellow;
            }
            else if (monPerso.experience >= 51 && monPerso.experience < 100) /*Niveau 5*/
            {
                TextSupplementaireHaut.Text = "Kawabounga, vous avez gagnez un niveau ! Vous etes de niveau " + monPerso.niveau + " !";
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.TextColor = Color.DarkRed;
            }
            else if (monPerso.experience >= 100 && monPerso.experience < 173) /*Niveau 6*/
            {
                TextSupplementaireHaut.Text = "Kawabounga, vous avez gagnez un niveau ! Vous etes de niveau " + monPerso.niveau + " !";
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.TextColor = Color.DeepPink;
            }
            else if (monPerso.experience >= 173 && monPerso.experience < 274) /*Niveau 7*/
            {
                TextSupplementaireHaut.Text = "Kawabounga, vous avez gagnez un niveau ! Vous etes de niveau " + monPerso.niveau + " !";
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.TextColor = Color.LightSeaGreen;
            }
            else if (monPerso.experience >= 274 && monPerso.experience < 410) /*Niveau 8*/
            {
                TextSupplementaireHaut.Text = "Kawabounga, vous avez gagnez un niveau ! Vous etes de niveau " + monPerso.niveau + " !";
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.TextColor = Color.Firebrick;
            }
            else if (monPerso.experience >= 410 && monPerso.experience < 583) /*Niveau 9*/
            {
                TextSupplementaireHaut.Text = "Kawabounga, vous avez gagnez un niveau ! Vous etes de niveau " + monPerso.niveau + " !";
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.TextColor = Color.MistyRose;
            }
            else if (monPerso.experience >= 583 && monPerso.experience < 800) /*Niveau 10*/
            {
                TextSupplementaireHaut.Text = "Kawabounga, vous avez gagnez un niveau ! Vous etes de niveau " + monPerso.niveau + " !";
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.TextColor = Color.DodgerBlue;
            }
            else if (monPerso.experience >= 800 && monPerso.experience < 1065) /*Niveau 11*/
            {
                TextSupplementaireHaut.Text = "Kawabounga, vous avez gagnez un niveau ! Vous etes de niveau " + monPerso.niveau + " !";
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.TextColor = Color.Fuchsia;
            }
            else if (monPerso.experience >= 1065 && monPerso.experience < 1382) /*Niveau 12*/
            {
                TextSupplementaireHaut.Text = "Kawabounga, vous avez gagnez un niveau ! Vous etes de niveau " + monPerso.niveau + " !";
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.TextColor = Color.PaleVioletRed;
            }
        }
        public class DetectShakeTest
        {
            // Set speed delay for monitoring changes.
            SensorSpeed speed = SensorSpeed.Game;

            public DetectShakeTest()
            {
                // Register for reading changes, be sure to unsubscribe when finished
                Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
            }

            void Accelerometer_ShakeDetected(object sender, EventArgs e)
            {
                // Process shake event
            }

            public void ToggleAccelerometer()
            {
                try
                {
                    if (Accelerometer.IsMonitoring)
                        Accelerometer.Stop();
                    else
                        Accelerometer.Start(speed);
                }
                catch (FeatureNotSupportedException fnsEx)
                {
                    // Feature not supported on device
                }
                catch (Exception ex)
                {
                    // Other error has occurred.
                }
            }
        }

        //Methode qui renvoie sur la page d'accueil quand on perd
        private async void RecommencerClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(DonjonAccueil));
        }
        //Méthode qui permet de lancer un D10
        public int DeAleatoire()
        {
            Random deAlea = new Random();
            return deAlea.Next(1, 11);
        }
        //Methode qui permet de choisir son personnage avec des caractéristiques différentes pour l'aventure (Guerrier)
        public void ChoisirGuerrier(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            personnageLabel.Text = $"Vous avez choisi: {button.Content}";
            monPerso = new Guerrier(button.Content + ": Olafmegabaff");
            ChoixHeros.Text = $"Vous êtes un puissant:\n" + monPerso.Caracteristiques();
        }
        //Methode qui permet de choisir son personnage avec des caractéristiques différentes pour l'aventure (Archer)
        public void ChoisirArcher(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            personnageLabel.Text = $"Vous avez choisi: {button.Content}";
            monPerso = new Archer(button.Content + ": Waylander");
            ChoixHeros.Text = $"Vous êtes un habile:\n" + monPerso.Caracteristiques();
        }
        //Methode qui permet de choisir son personnage avec des caractéristiques différentes pour l'aventure (Voleur)
        public void ChoisirVoleur(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            personnageLabel.Text = $"Vous avez choisi: {button.Content}";
            monPerso = new Voleur(button.Content + ": Renshaw");
            ChoixHeros.Text = $"Vous êtes un rapide:\n" + monPerso.Caracteristiques();
        }
        //Methode pour valider le heros et débuter le scénario
        public void DebuterAventureClicked(object sender, EventArgs e)
        {
            ChoixPerso.IsVisible = false;
            ChoixHeros.IsVisible = false;
            DebuterAventure.IsVisible = false;
            Avatar.IsVisible = false;
            Action01A.IsVisible = true;
            Action01B.IsVisible = true;
            Histoire.IsVisible = true;
            Histoire.Text = "Vous arrivez devant le Donjon et face à vous, une porte sombre et imposante se dresse. Cela semble être la seule entrée.Mais on dirait que l'on peut faire le tour extérieur du donjon.\nQu'allez vous décider ?";
        }
        //Methode pour faire avancer le scénario
        public void ActionButton01AClicked(object sender, EventArgs e)
        {
            Histoire.TextColor = Color.Black;
            Histoire.Text = "Bravo, vous avez l'air malin à frapper à la porte d'un donjon. Mais cela semble marcher vu que la porte s'ouvre ! Une fois à l'interieur, vous commencez à avancer dans un couloir et au bout, deux choix s'offre à vous.";
            Action01A.IsVisible = false;
            Action01B.IsVisible = false;
            ActionButton02A.IsVisible = true;
            ActionButton02B.IsVisible = true;
        }
        //Methode pour faire avancer le scénario mais sanctionné par l'échec si mauvais choix
        public void ActionButton01BClicked(object sender, EventArgs e)
        {
            Histoire.TextColor = Color.DarkRed;
            Action01A.IsVisible = false;
            Histoire.Text = "A force de roder avec plus ou moins de discretion autour du donjon pour trouver une entrée secrète, vous vous faites alpaguer par une patrouille qui vous jette dans les oubliettes.\nAinsi s'achève votre carrière d'aventurier !";
            DisplayAlert("Echec", "Vous avez perdu", "Recommencer");
            Action01B.IsVisible = false;
            Recommencer.IsVisible = true;
        }
        //Methode pour faire avancer le scénario
        public void ActionButton02AClicked(object sender, EventArgs e)
        {
            Histoire.TextColor = Color.Black;
            Histoire.Text = "En prenant à droite, vous avancez dans un couloir assez sombre quand vous entendez un couinementetouffé devant vous.\nCela semble être un gobelin ! Qu'allez vous faire ?";
            ActionButton02A.IsVisible = false;
            ActionButton02B.IsVisible = false;
            ActionButton04A.IsVisible = true;
            ActionButton04B.IsVisible = true;
        }
        //Methode pour faire avancer le scénario
        public void ActionButton02BClicked(object sender, EventArgs e)
        {
            Histoire.TextColor = Color.Black;
            Histoire.Text = "Vous prenez en face et trouvez un escalier dont vous commencez à escalader les marches. Une fois la dizaine de marche de l'escalier franchie, vous arrivez devant une porte fermé. Sur le coté, une plaque gravé attire votre attention sur laquelle il est écrit:\n\n''Jamais je ne suis loin de mon autre jumelle, on m'associe souvent au parfum vomitif d'une partie du corps qui n'est pas vraiment belle, localisée fort loin de l'organe olfactif !''\n\nC'est une enigme, pas le choix, il faut la résoudre pour ouvrir la porte.";
            ActionButton02A.IsVisible = false;
            ActionButton02B.IsVisible = false;
            ActionButton03A.IsVisible = true;
            ActionButton03B.IsVisible = true;
        }
        //Méthode qui lance la première enigme
        public void ActionButton03AClicked(object sender, EventArgs e)
        {
            Enigme01.IsVisible = true;
            Histoire.IsVisible = false;
            TextSupplementaireBas.Text = "Jamais je ne suis loin de mon autre jumelle, on m'associe souvent au parfum vomitif d'une partie du corps qui n'est pas vraiment belle, localisée fort loin de l'organe olfactif !";
            TextSupplementaireBas.IsVisible = true;
            ActionButton03A.IsVisible = false;
            ActionButton03B.IsVisible = false;
        }
        //Méthode qui refuse l'enigme et impose le combat vs gobelin
        public void ActionButton03BClicked(object sender, EventArgs e)
        {
            Histoire.TextColor = Color.Black;
            Histoire.Text = "L'enigme semble trop difficile pour vous, vous preferez faire demi tour et prendre l'embranchement de droite et sans crier garde...";
            ActionButton04A.IsVisible = true;
            ActionButton03A.IsVisible = false;
            ActionButton03B.IsVisible = false;
        }
        //Methode qui permet le combat en cliquant sur le bouton avec gain d'expérience.
        //Permet ensuite d'afficher la suite de l'aventure selon les choix précédents.
        //Condition pour afficher le gain de niveau selon l'expérience
        public void ActionButton04AClicked(object sender, EventArgs e)
        {
            Gobelin gobelin = new Gobelin("Gobelin", 60, 5, 10);
            bool victoire = true;

            while (!gobelin.EstMort())
            {
                Console.WriteLine(gobelin.ToString());
                monPerso.Attaquer(gobelin);
                if (monPerso.EstMort())
                {
                    victoire = false;
                    break;
                }
                if (!gobelin.EstMort())
                {
                    gobelin.Attaquer(monPerso);
                }

            }
            if (victoire)
            {
                monPerso.GagnerExperience(4);
                monPerso.GagnerPiecesOr();
                Histoire.Text = "Victoire, vous triomphez de ce premier combat !\n" + monPerso.Caracteristiques();
                ActionButton04A.IsVisible = false;
                ActionButton04B.IsVisible = false;
                AnnonceNiveau();
                ActionButton05C.IsVisible = true;
                ActionButton05D.IsVisible = true;
            }
        }
        //Methode qui amene l'échec (la fuite c'est mal !)
        public void ActionButton04BClicked(object sender, EventArgs e)
        {
            Histoire.TextColor = Color.Black;
            Histoire.Text = "Vous jugez préférable de fuir devant le monstre pour éviter le combat, mais celui-ci sort un tromblon et vous tire dans le dos.\nAinsi s'achève votre carrière d'aventurier !";
            ActionButton04A.IsVisible = false;
            ActionButton04B.IsVisible = false;
            DisplayAlert("Echec", "Vous avez perdu", "Recommencer");
        }
        //Methode pour gerer l'enigme 01 avec nombre de tentative et gain d'expérience
        //Limité à 3 tentatives avec un compteur et une variable globale déclarée au début
        //Condition pour afficher le gain de niveau selon l'expérience
        public void Enigme01_Completed(object sender, EventArgs e)
        {
            var reponseEnigme01 = Enigme01.Text;
            int tentativeMax = 3;
            string soluce1 = "chaussette";
            Histoire.IsVisible = false;
            var bingo = soluce1.Replace(" ", "") ;
            if ((bingo != reponseEnigme01) & (tentative < tentativeMax))
            {
                DisplayAlert("Info:", "Mauvaise réponse", "ok");
                tentative++;
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.Text = "Essayez encore, il vous reste " + (tentativeMax - tentative) + " essais !";
            }
            else if (tentative == tentativeMax)
            {
                TextSupplementaireHaut.TextColor = Color.DarkRed;
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.Text = "A force de cogiter pour trouver la réponse, vous ne voyez pas les gardes arriver. Ils vous attrapent et finisser ainsi votre carrière d'aventurier dans une geôle.";
                Enigme01.IsVisible = false;
                DisplayAlert("Echec", "Vous avez perdu", "Recommencer");
            }
            else
            {
                reponseEnigme01 = bingo;
                monPerso.GagnerExperience(5);
                Histoire.TextColor = Color.DarkGreen;
                Histoire.IsVisible = true;
                Histoire.Text = "Bravo, vous avez résolu l'enigme et gagné des XP !\n" + monPerso.Caracteristiques();
                Enigme01.IsVisible = false;
                TextSupplementaireHaut.IsVisible = false;
                TextSupplementaireBas.IsVisible = false;
                AnnonceNiveau();
                ActionButton05A.IsVisible = true;
                ActionButton05B.IsVisible = true;
            }
        }
        //Methode qui permet de gagner des objets (fouiller, c'est bien) et qui prépare la seconde enigme
        //Methode implémenté dans Personnage.cs
        public void ActionButton05AClicked(object sender, EventArgs e)
        {
            if (ActionButton05B.IsFocused || ActionButton05C.IsFocused || ActionButton05D.IsFocused)
            {
                Histoire.Text = "Vous traversez sans rien toucher.";
                ActionButton05B.IsVisible = false;
                Histoire.IsVisible = true;
            }
            else
            {
                monPerso.GagnerPotionsSoins();
                monPerso.GagnerPiecesOr();
                Histoire.Text = "Superbe ! Dans tout ce bazar, vous trouvez des <<potions de soins>> et quelques <<pièces d'or>> !\n" + monPerso.Caracteristiques() + "\nAu bout de temps temps, vous arrivez devant une grille fermée et vous voyez une plaque à coté avec marqué : Enigme 2.\n ''Prononcez l'allocution habituelle des situations désastreuses !''";
                Histoire.TextColor = Color.DarkGreen;
                ActionButton05B.IsVisible = false;
                ActionButton05A.IsVisible = false;
                Histoire.IsVisible = true;
                TextSupplementaireHaut.IsVisible = false;
                ActionButton07A.IsVisible = true;
                ActionButton07B.IsVisible = true;
            }
        }
        //Methode pour faire avancer le scénario
        //Passer sans fouiller
        public void ActionButton05BClicked(object sender, EventArgs e)
        {
            if (ActionButton05A.IsFocused || ActionButton05C.IsFocused || ActionButton05D.IsFocused)
            {
                ActionButton05A.IsVisible = false;
            }
            else
            {
                Histoire.Text = "Vous traversez sans rien toucher mais vous avez le sentiment d'avoir raté quelque chose.\nAu bout de temps temps, vous arrivez devant une grille fermée et vous voyez une plaque à coté avec marqué : Enigme 2.\n ''Prononcez l'allocution habituelle des situations désastreuses !''";
                ActionButton05A.IsVisible = false;
                ActionButton05B.IsVisible = false;
                Histoire.IsVisible = true;
                TextSupplementaireHaut.IsVisible = false;
                ActionButton07A.IsVisible = true;
                ActionButton07B.IsVisible = true;

            }
        }
        //Methode pour faire avancer le scénario
        //Allumer le feu
        public void ActionButton05CClicked(object sender, EventArgs e)
        {
            if (ActionButton05D.IsFocused)
            {
                ActionButton05D.IsVisible = false;
            }
            else
            {
                Histoire.IsVisible = true;
                ActionButton05C.IsVisible = false;
                ActionButton05D.IsVisible = false;
                TextSupplementaireHaut.IsVisible = false;
                Histoire.Text = "Vous allumez prestement une torche et avancez prudement. Vous faites bien car vous entendez un raclement et une goule apparait au loin.\nElle est aveugle et craint le feu, le combat devrait être facile !";
                Text07BCombat.IsVisible = true;
            }
        }
        //Methode pour faire avancer le scénario
        //Prendre un autre chemin
        public void ActionButton05DClicked(object sender, EventArgs e)
        {
            if (ActionButton05C.IsFocused)
            {
                ActionButton05D.IsVisible = false;
            }
            else
            {
                Histoire.IsVisible = true;
                Histoire.Text = "Ce couloir semble accueillant et vous l'empruntez pendant un petit moment jusqu'a ce que vous arriviez à une grande salle avec plusieurs possibilités.\nDans cette grande salle, vous apercevez une solide porte en bois avec marqué ~~Frappez et attendez~~.\nSur le coté, vous voyez que le couloir continue encore.";
                TextSupplementaireHaut.IsVisible = false;
                ActionButton05C.IsVisible = false;
                ActionButton05D.IsVisible = false;
                ActionButton07E.IsVisible = true;
                ActionButton07F.IsVisible = true;
            }
        }
        //Methode qui permet d'affronter une goule et de gagner du XP
        //Le heros attaque en premier
        public void BastonGouleClicked(object sender, EventArgs e)
        {
            Goule goule = new Goule("Gouly", 25, 10, 15);
            bool victoire = true;

            while (!goule.EstMort())
            {
                monPerso.Attaquer(goule);
                if (monPerso.EstMort())
                {
                    victoire = false;
                    break;
                }
                if (!goule.EstMort())
                {
                    goule.Attaquer(monPerso);
                }
            }
            if (victoire)
            {
                monPerso.GagnerExperience(3);
                Text07BCombat.IsVisible = false;
                Histoire.IsVisible = true;
                Histoire.Text = "Vous triomphez facilement de la goule et gagnez <<3 XP>>. Vous pouvez soit fouiller la goule soit passer votre chemin.\n" + monPerso.Caracteristiques();
                AnnonceNiveau();
                ActionButton07C.IsVisible = true;
                ActionButton07D.IsVisible = true;
            }
        }
        //Méthode pour accepter l'enigme
        public void ActionButton07AClicked(object sender, EventArgs e)
        {
            Enigme02.IsVisible = true;
            Enigme02.IsEnabled = true;
            ActionButton07B.IsVisible = false;
            ActionButton07A.IsVisible = false;
            Histoire.IsVisible = false;
            TextSupplementaireBas.Text = "Prononcez l'allocution des situations désastreuses !";
            TextSupplementaireBas.IsVisible = true;
        }
        //méthode pour contraindre à répondre à l'enigme
        public void ActionButton07BClicked(object sender, EventArgs e)
        {
            Histoire.Text = "Vous n'avez pas le choix, vous entendez des bruits de pas au loin, vous devez trouver la soluce sous peine d'être capturé !";
            ActionButton07B.IsVisible = false;
        }
        //Methode qui permet de gagner beaucoup plus d'or et permet d'avancer
        public void ActionButton07CClicked(object sender, EventArgs e)
        {
            if (ActionButton07D.IsFocused)
            {
                Histoire.IsVisible = true;
                Histoire.Text = "C'est vraiment trop répugnant, vous passez votre chemin sans fouiller le cadavre de la goule et continuer votre exploration.";
                ActionButton07C.IsVisible = false;
            }
            else
            {
                monPerso.GagnerBeaucoupOr();
                Histoire.IsVisible = true;
                Histoire.Text = "C'est un peu répugnant de fouiller la goule mais vous faites bien car vous y trouvez une <<Petite Bourse>> contenant pas mal de pièces d'or !\n" + monPerso.Caracteristiques() + "\nHeureux de votre découverte, vous continuez votre exploration. Après avoir récupéré votre butin, vous continuez votre chemin.\nPeu de temps après, vous arrivez devant une porte fermé avec un blason d'arme dessus. Cela semble être l'armurerie.";
                Histoire.TextColor = Color.DarkGreen;
                ActionButton07C.IsVisible = false;
                ActionButton07D.IsVisible = false;
                TextSupplementaireHaut.IsVisible = false;
                ActionButton11C.IsVisible = true;
                ActionButton11D.IsVisible = true;
                TextSupplementaireHaut.IsVisible = false;
            }
        }
        //Methode pour faire avancer le scénario
        public void ActionButton07DClicked(object sender, EventArgs e)
        {
            Histoire.IsVisible = true;
            Histoire.Text = "C'est vraiment trop répugnant, vous passez votre chemin sans fouiller le cadavre de la goule et continuer votre exploration. Peu de temps après, vous arrivez devant une porte fermé avec un blason d'arme dessus. Cela semble être l'armurerie.";
            ActionButton07C.IsVisible = false;
            ActionButton07D.IsVisible = false;
            TextSupplementaireHaut.IsVisible = false;
            ActionButton11C.IsVisible = true;
            ActionButton11D.IsVisible = true;
        }
        public void ActionButton07EClicked(object sender, EventArgs e)
        {
            if (ActionButton07F.IsFocused)
            {
                ActionButton07E.IsVisible = false;
                Histoire.Text = "Vous vous désinterressez de la porte et continuez votre chemin jusqu'a ce que vous aperceviez des gardes patibulaires. Dans un grand cri, ils s'élancent à votre poursuite.";
                Histoire.IsVisible = true;
            }
            else
            {
                ActionButton07F.IsVisible = false;
                ActionButton07E.IsVisible = false;
                Histoire.IsVisible = true;
                Histoire.Text = "Après avoir frappé à la porte, une jeune femme avenante et au sourire niais ouvre la porte. Elle vous souhaite le bonjour et vous demande si vous voulez acheter des objets.\nMais pour cela, il vous faut compter votre argent.";
                ActionButton09C.IsVisible = true;
                ActionButton09D.IsVisible = true;

            }
        }
        //Methode pour faire avancer le scénario
        public void ActionButton07FClicked(object sender, EventArgs e)
        {
            if (ActionButton07E.IsFocused)
            {
                ActionButton07F.IsVisible = false;
                Histoire.IsVisible = true;
                Histoire.Text = "Après avoir frappé à la porte, une jeune femme avenante et au sourire niais ouvre la porte. Elle vous souhaite le bonjour et vous demande si vous voulez acheter des objets.\nMais pour cela, il vous faut compter votre argent.";

            }
            else
            {
                ActionButton07F.IsVisible = false;
                ActionButton07E.IsVisible = false;
                Histoire.IsVisible = true;
                Histoire.Text = "Vous vous désinterressez de la porte et continuez votre chemin jusqu'a ce que vous aperceviez des gardes patibulaires. Dans un grand cri, ils s'élancent à votre poursuite.\nIl faudra lancer les dés pour faire un jet de dextérité. Faites 5 ou plus et c'est gagné !";
                ActionButton09E.IsVisible = true;

            }
        }
        //Methode qui permet de résoudre la seconde enigme. Limité à 3 tentatives via un compteur
        //La variable tentative est déclarée en globale au début
        public void Enigme02_Completed(object sender, EventArgs e)
        {
            var reponseEnigme02 = Enigme02.Text;
            int tentativeMax = 3;
            string soluce2 = "crotte";
            var bingo = soluce2.Replace(" ", "");
            Histoire.IsVisible = false;

            if ((bingo != reponseEnigme02) & (tentative < tentativeMax))
            {
                DisplayAlert("Info:", "Mauvaise réponse", "ok");
                tentative++;
                TextSupplementaireHaut.Text = "Essayez encore, il vous reste " + (tentativeMax - tentative) + " essais !";
                TextSupplementaireHaut.IsVisible = true;
            }
            else if (tentative == tentativeMax)
            {
                TextSupplementaireHaut.TextColor = Color.DarkRed;
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.Text = "A force de cogiter pour trouver la réponse, vous ne voyez pas les gardes arriver. Ils vous attrapent et finisser ainsi votre carrière d'aventurier dans une geôle.";
                Enigme02.IsVisible = false;
                DisplayAlert("Echec", "Vous avez perdu", "Recommencer");
            }
            else
            {
                reponseEnigme02 = bingo;
                monPerso.GagnerExperience(5);
                Histoire.TextColor = Color.DarkGreen;
                Histoire.IsVisible = true;
                Histoire.Text = "Bravo, vous avez trouvé la solution, la grille se lève et vous gagner <<5 XP>> !\n" + monPerso.Caracteristiques() + "\nVous continuez votre chemin pendant quelques temps et vous arrivez devant une grande salle circulaire assez sombre à l'odeur nauséabonde. Sur le sol, de la paille et des détritus sont répandus. On dirait la tanière d'une bête puante !";
                Enigme02.IsVisible = false;
                TextSupplementaireHaut.IsVisible = false;
                TextSupplementaireBas.IsVisible = false;
                AnnonceNiveau();
                ActionButton11A.IsVisible = true;
                ActionButton11B.IsVisible = true;
            }
        }
        //Methode qui permet d'afficher le nombre de pièces d'or et va débloquer la liste des achats possible (RadioButton)
        public void ActionButton09CClicked(object sender, EventArgs e)
        {
            if (ActionButton09D.IsFocused)
            {
                Histoire.IsVisible = true;
                Histoire.Text = "Vous n'avez vraiment pas envie de compter vos pièces et vous avez une meilleure idée : le bourre-pif pour assomer la vendeuse et vous servir !";
                ActionButton09C.IsVisible = false;
            }
            else
            {
                ActionButton09D.IsVisible = false;
                ActionButton09C.IsVisible = false;
                Histoire.IsVisible = false;
                TextSupplementaireBas.IsVisible = true;
                TextSupplementaireBas.Text = "Vous faite le compte de vos possessions et vous voyez que vous n'avez que " + monPerso.Richesse() + " pièces d'or. Ce n'est pas énorme ! Elle vous accueille donc avec une petite moue déçue en voyant votre pauvreté.";
                ChoisirAchat.IsVisible = true;
                Achat01.IsVisible = true;
                Achat02.IsVisible = true;
                Achat03.IsVisible = true;
            }
        }
        //Methode qui permet de frapper la vendeuse et d'afficher la liste des vols possibles (CheckBox)
        public void ActionButton09DClicked(object sender, EventArgs e)
        {
            if (ActionButton09C.IsFocused)
            {
                Histoire.IsVisible = true;
                Histoire.Text = "Vous faite le compte de vos possessions et vous voyez que vous n'avez que " + monPerso.Richesse() + " pièces d'or. Ce n'est pas énorme !";
                ActionButton09D.IsVisible = false;
            }
            else
            {
                ActionButton09D.IsVisible = false;
                ActionButton09C.IsVisible = false;
                Histoire.IsVisible = false;
                TextSupplementaireBas.IsVisible = true;
                TextSupplementaireBas.Text = "Vous n'avez vraiment pas envie de compter vos pièces et avez une meilleure idée : le bourre-pif pour assomer la vendeuse et vous servir ! Et cela marche ! Elle tombe dans vos bras et le magasin est grand ouvert pour vous.";
                ChoisirVol.IsVisible = true;
                Vol01.IsVisible = true;
                Vol02.IsVisible = true;
                Vol03.IsVisible = true;
                ObjetVol01.IsVisible = true;
                ObjetVol02.IsVisible = true;
                ObjetVol03.IsVisible = true;

            }
        }
        //Methode qui simule et affiche un lancer de D10 qui détermine la réussite ou non de la fuite
        //Pour réussir, faire 5 ou plus
        public void ActionButton09EClicked(object sender, EventArgs e)
        {
            var resultatDeAleatoire = DeAleatoire();
            if (resultatDeAleatoire >= 5)
            {
                Histoire.IsVisible = true;
                Console.WriteLine("Votre lancer de dé est " + resultatDeAleatoire);
                Histoire.Text = "Bravo, votre dexterité vous permet d'échapper aux gardes. Habile fuite ! Vous avez fait un " + resultatDeAleatoire + " !\nPar contre, votre course dans les couloirs vous a perdu et vous vous retrouvez devant une grande salle à l'odeur nauséabonde. Qu'allez vous faire ?";
                Histoire.TextColor = Color.DarkGreen;
                ActionButton09E.IsVisible = false;
                ActionButton11A.IsVisible = true;
                ActionButton11B.IsVisible = true;
            }
            else
            {
                Console.WriteLine("Votre lancer de dé est " + resultatDeAleatoire);
                Histoire.Text = "Dommage, malgré une course effrenée, les gardes vous capturent et vous jettent dans une geôle sombre et humide, ainsi s'achève votre carrière d'aventuerier ! Vous avez fait un " + resultatDeAleatoire + " !";
                Histoire.IsVisible = true;
                Histoire.TextColor = Color.DarkRed;
                ActionButton09E.IsVisible = false;
                DisplayAlert("Echec", "Vous avez perdu", "Recommencer");
            }
        }
        //Methode qui permet de fouiller et gagner beaucoup d'or
        public void ActionButton11AClicked(object sender, EventArgs e)
        {
            if (ActionButton11B.IsFocused)
            {
                Histoire.IsVisible = true;
                Histoire.Text = "Vous voulez éviter tout risque et vous traverser rapidement la salle quand un grondement sur le coté vous stoppe net.";
                ActionButton11A.IsVisible = false;
                ActionButton11B.IsVisible = false;
            }
            else
            {
                monPerso.GagnerBeaucoupOr();
                Histoire.IsVisible = true;
                Histoire.Text = "Vous fouillez rapidement les détritus et vous recuperez une <<bourse d'or>> assez abimé mais qui tinte joyeusement du bruit des pièces d'or. Vous avez maintenant " + monPerso.Richesse() + " pièces d'or\nMalheureusement, tout occupé à votre trouvaille, vous ne voyez pas qu'un troll vient vers vous. Son grondement vous fait relever la tête.\nPlus le choix, il faut le combattre.";
                ActionButton11A.IsVisible = false;
                ActionButton11B.IsVisible = false;
                ActionButton12A.IsVisible = true;
                TextSupplementaireHaut.IsVisible = false;
            }
        }
        //Methode qui fait traverser un couloir sans rien gagner
        public void ActionButton11BClicked(object sender, EventArgs e)
        {
            if (ActionButton11A.IsFocused)
            {
                monPerso.GagnerBeaucoupOr();
                Histoire.IsVisible = true;
                Histoire.Text = "Vous fouillez rapidement les détritus et vous recuperez une bourse d'or assez abimé mais qui tinte joyeusement du bruit des pièces d'or. Vous avez maintenant " + monPerso.Richesse() + " pièces d'or\nMalheureusement, tout occupé à votre trouvaille, vous ne voyez pas qu'un troll vient vers vous. Son grondement vous fait relever la tête.\nPlus le choix, il faut le combattre.";
                ActionButton11A.IsVisible = false;
                ActionButton11B.IsVisible = false;
            }
            else
            {
                Histoire.IsVisible = true;
                Histoire.Text = "Vous voulez éviter tout risque et vous traverser rapidement la salle quand un grondement sur le coté vous stoppe net.";
                ActionButton11A.IsVisible = false;
                ActionButton11B.IsVisible = false;
                ActionButton12A.IsVisible = true;
                TextSupplementaireHaut.IsVisible = false;
            }
        }
        //Methode qui permet de fouiller et gagner un Gantelet de Force
        public void ActionButton11CClicked(object sender, EventArgs e)
        {
            if (ActionButton11D.IsFocused)
            {
                Histoire.IsVisible = true;
                ActionButton11C.IsVisible = false;
                ActionButton11D.IsVisible = false;
                Histoire.Text = "N'ayant pas confiance dans le fait que l'armurerie soit vide, vous faites discrètment demi-tour à la recherche d'un autre passage.\nVous faites bien car vous découvrez un moellon dans le mur qui semble bizarre. A vous de jouer pour débloquer cela !";
            }
            else
            {
                Histoire.IsVisible = true;
                ActionButton11C.IsVisible = false;
                ActionButton11D.IsVisible = false;
                monPerso.GanteletForce();
                Histoire.TextColor = Color.DarkGreen;
                Histoire.Text = "Vous fouillez parmi toutes les pièces d'armure et les armes entassés sur les racks et les étagères quand vous laissez échapper un cri d'exclamation. Vous venez de mettre la main sur <<Gantelet de force>>.\nVous le mettez immédiatement et sentez une puissance accrue affluer.Les ennemis n'ont qu'a bien se tenir.\nContent de cette découverte, vous sortez de l'autre coté de la pièce et avez le choix, soit descendre un escalier, soit tourner sur le coté.\n" + monPerso.Caracteristiques();
                ActionButton12B.IsVisible = true;
                ActionButton12C.IsVisible = true;
            }
        }
        //Méthode pour refuser d'entrer dans l'armurerie
        public void ActionButton11DClicked(object sender, EventArgs e)
        {
            if (ActionButton11C.IsFocused)
            {
                Histoire.IsVisible = true;
                ActionButton11C.IsVisible = false;
                ActionButton11D.IsVisible = false;
                monPerso.GanteletForce();
                Histoire.Text = "Vous fouillez parmi toutes les pièces d'armure et les armes entassés sur les racks et les étagères quand vous laissez échapper un cri d'exclamation. Vous venez de mettre la main sur <<Gantelet de force>>.\nVous le mettez immédiatement et sentez une puissance accrue affluer.Les ennemis n'ont qu'a bien se tenir.\nContent de cette découverte, vous sortez de l'autre coté de la pièce et avez le choix, soit descendre un escalier, soit tourner sur le coté.\n" + monPerso.Caracteristiques();
            }
            else
            {
                Histoire.IsVisible = true;
                ActionButton11C.IsVisible = false;
                ActionButton11D.IsVisible = false;
                Histoire.Text = "N'ayant pas confiance dans le fait que l'armurerie soit vide, vous faites discrètment demi-tour à la recherche d'un autre passage.\nVous faites bien car vous découvrez un moellon dans le mur qui semble bizarre. A vous de jouer pour débloquer cela !\nLancez votre dé et faites plus de 4 pour débloquer !";
                ActionButton12D.IsVisible = true;
            }
        }
        //Methode pour acheter 1 seul objet et le rentrer dans l'inventaire (potion de soin miraculeux)
        //Condition pour acheter via le nombre de pieces d'or possedé sur le RadioButton
        public void ChoisirAchat01(object sender, CheckedChangedEventArgs e)
        {

            if (monPerso.Richesse() <= 25)
            {
                TextSupplementaireHaut.Text = "Vous n'avez pas assez d'or pour cet achat";
                TextSupplementaireHaut.IsVisible = true;
            }
            else
            {
                RadioButton button = sender as RadioButton;
                monPerso.GagnerPotionsSoinMiraculeux();
                monPerso.Achat01();
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.TextColor = Color.Black;
                TextSupplementaireHaut.Text = $"Vous avez choisi: <<{button.Content}>>";
                Achat01.IsVisible = false;
                Achat02.IsVisible = false;
                Achat03.IsVisible = false;
                Histoire.IsVisible = true;
                TextSupplementaireBas.IsVisible = false;
                Histoire.Text = monPerso.Inventaire() + "\nVous avez " + monPerso.Richesse() + " pièces d'or.\n" + "Après avoir fait votre achat, vous entendez un remue menage dehors, les gardes ont retrouvé votre trace.\nVite, choisissez entre vous enfuir ou vous battre !";
                ActionButton12E.IsVisible = true;
                ActionButton12F.IsVisible = true;
            }
        }
        //Methode pour acheter 1 seul objet et le rentrer dans l'inventaire (casque de puissance)
        //Condition pour acheter via le nombre de pieces d'or possedé sur le RadioButton
        public void ChoisirAchat02(object sender, CheckedChangedEventArgs e)
        {
            if (monPerso.Richesse() <= 30)
            {
                TextSupplementaireHaut.Text = "Vous n'avez pas assez d'or pour cet achat";
                TextSupplementaireHaut.IsVisible = true;
            }
            else
            {
                RadioButton button = sender as RadioButton;
                monPerso.CasquePuissance();
                monPerso.Achat02();
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.TextColor = Color.Black;
                TextSupplementaireHaut.Text = $"Vous avez choisi: <<{button.Content}>>";
                Achat01.IsVisible = false;
                Achat02.IsVisible = false;
                Achat03.IsVisible = false;
                Histoire.IsVisible = true;
                TextSupplementaireBas.IsVisible = false;
                Histoire.Text = monPerso.Caracteristiques() + "\nAprès avoir fait votre achat, vous entendez un remue menage dehors, les gardes ont retrouvé votre trace.\nVite, choisissez entre vous enfuir ou vous battre !";
                ActionButton12E.IsVisible = true;
                ActionButton12F.IsVisible = true;
            }
        }
        //Methode pour acheter 1 seul objet et le rentrer dans l'inventaire (dé pipé)
        //Condition pour acheter via le nombre de pieces d'or possedé sur le RadioButton
        public void ChoisirAchat03(object sender, CheckedChangedEventArgs e)
        {
            if (monPerso.Richesse() <= 15)
            {
                TextSupplementaireHaut.Text = "Vous n'avez pas assez d'or pour cet achat";
                TextSupplementaireHaut.IsVisible = true;
            }
            else
            {
                RadioButton button = sender as RadioButton;
                monPerso.GagnerDePipe();
                monPerso.Achat03();
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.TextColor = Color.Black;
                TextSupplementaireHaut.Text = $"Vous avez choisi: <<{button.Content}>>";
                Achat01.IsVisible = false;
                Achat02.IsVisible = false;
                Achat03.IsVisible = false;
                Histoire.IsVisible = true;
                TextSupplementaireBas.IsVisible = false;
                Histoire.Text = "Vous avez " + monPerso.Richesse() + " pièces d'or.\n" + "Après avoir fait votre achat, vous entendez un remue menage dehors, les gardes ont retrouvé votre trace.\nVite, choisissez entre vous enfuir ou vous battre !";
                ActionButton12E.IsVisible = true;
                ActionButton12F.IsVisible = true;
            }
        }
        //Methode pour choisir un objet parmi la check box possible et le rentrer dans l'inventaire (2 sur 3 seulement)
        //Condition pour empecher de tout choisir, choix limité à 2.
        public void ChoisirVol01(object sender, CheckedChangedEventArgs e)
        {

            if (nbrChoix <= nbrChoixMax)
            {
                CheckBox check = sender as CheckBox;
                nbrChoix++;
                monPerso.EpeeJustice();
                TextSupplementaireBas.IsVisible = true;
                Vol01.IsEnabled = false;
                TextSupplementaireBas.Text = $"Vous avez choisi: <<{check.BindingContext}>>" + monPerso.Statistiques();
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.TextColor = Color.Black;
                TextSupplementaireHaut.Text = "Après avoir volé des objets, vous entendez un remue menage dehors, les gardes ont retrouvé votre trace.\nVite, choisissez entre vous enfuir ou vous battre !";
                if (nbrChoixMax >= nbrChoix)
                {
                    ActionButton12E.IsVisible = false;
                    ActionButton12F.IsVisible = false;
                }
                else
                {
                    ActionButton12E.IsVisible = true;
                    ActionButton12F.IsVisible = true;
                    TextSupplementaireBas.IsVisible = false;
                }
            }
            else
            {
                CheckBox check = sender as CheckBox;
                DisplayAlert("Info", "Vous n'avez pas le temps de tout prendre !", "OK");
                Vol01.IsEnabled = false;
                Vol02.IsEnabled = false;
                Vol03.IsEnabled = false;
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.Text = "Après avoir volé des objets, vous entendez un remue menage dehors, les gardes ont retrouvé votre trace.\nVite, choisissez entre vous enfuir ou vous battre !";
                ActionButton12E.IsVisible = true;
                ActionButton12F.IsVisible = true;
            }

        }
        //Methode pour choisir un objet parmi la check box possible et le rentrer dans l'inventaire (2 sur 3 seulement)
        //Condition pour empecher de tout choisir, choix limité à 2.
        public void ChoisirVol02(object sender, CheckedChangedEventArgs e)
        {
            if (nbrChoix <= nbrChoixMax)
            {
                CheckBox check = sender as CheckBox;
                nbrChoix++;
                monPerso.GagnerPotionsSoinMiraculeux();
                TextSupplementaireBas.IsVisible = true;
                Vol02.IsEnabled = false;
                TextSupplementaireBas.Text = $"Vous avez choisi: <<{check.BindingContext}>>\n" + monPerso.Inventaire();
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.TextColor = Color.Black;
                TextSupplementaireHaut.Text = "Après avoir volé des objets, vous entendez un remue menage dehors, les gardes ont retrouvé votre trace.\nVite, choisissez entre vous enfuir ou vous battre !";
                if (nbrChoixMax >= nbrChoix)
                {
                    ActionButton12E.IsVisible = false;
                    ActionButton12F.IsVisible = false;
                }
                else
                {
                    ActionButton12E.IsVisible = true;
                    ActionButton12F.IsVisible = true;
                    TextSupplementaireBas.IsVisible = false;
                }

            }
            else
            {
                CheckBox check = sender as CheckBox;
                DisplayAlert("Info", "Vous n'avez pas le temps de tout prendre !", "OK");
                Vol01.IsEnabled = false;
                Vol02.IsEnabled = false;
                Vol03.IsEnabled = false;
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.Text = "Après avoir volé des objets, vous entendez un remue menage dehors, les gardes ont retrouvé votre trace.\nVite, choisissez entre vous enfuir ou vous battre !";
                ActionButton12E.IsVisible = true;
                ActionButton12F.IsVisible = true;
            }
        }
        //Methode pour choisir un objet parmi la check box possible et le rentrer dans l'inventaire (2 sur 3 seulement)
        //Condition pour empecher de tout choisir, choix limité à 2.
        public void ChoisirVol03(object sender, CheckedChangedEventArgs e)
        {
            if (nbrChoix <= nbrChoixMax)
            {
                CheckBox check = sender as CheckBox;
                nbrChoix++;
                monPerso.BotteRapidité();
                TextSupplementaireBas.IsVisible = true;
                Vol03.IsEnabled = false;
                TextSupplementaireBas.Text = $"Vous avez choisi: <<{check.BindingContext}>>\n" + monPerso.Statistiques();
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.TextColor = Color.Black;
                TextSupplementaireHaut.Text = "Après avoir volé des objets, vous entendez un remue menage dehors, les gardes ont retrouvé votre trace.\nVite, choisissez entre vous enfuir ou vous battre !";
                if (nbrChoixMax >= nbrChoix)
                {
                    ActionButton12E.IsVisible = false;
                    ActionButton12F.IsVisible = false;
                }
                else
                {
                    ActionButton12E.IsVisible = true;
                    ActionButton12F.IsVisible = true;
                    TextSupplementaireBas.IsVisible = false;
                }
            }
            else
            {
                CheckBox check = sender as CheckBox;
                DisplayAlert("Info", "Vous n'avez pas le temps de tout prendre !", "OK");
                Vol01.IsEnabled = false;
                Vol02.IsEnabled = false;
                Vol03.IsEnabled = false;
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.Text = "Après avoir volé des objets, vous entendez un remue menage dehors, les gardes ont retrouvé votre trace.\nVite, choisissez entre vous enfuir ou vous battre !";
                ActionButton12E.IsVisible = true;
                ActionButton12F.IsVisible = true;
            }
        }
        //Methode pour taper un troll et gagner de l'or
        public void ActionButton12AClicked(object sender, EventArgs e)
        {
            Troll troll = new Troll("Troll chaotique", 30, 20, 30);
            bool victoire = true;

            while (!troll.EstMort())
            {
                monPerso.Attaquer(troll);
                if (monPerso.EstMort())
                {
                    victoire = false;
                    break;
                }
                if (!troll.EstMort())
                {
                    troll.Attaquer(monPerso);
                }

            }
            if (victoire)
            {
                monPerso.GagnerExperience(15);
                monPerso.GagnerPiecesOr();
                Histoire.Text = "Rude combat mais vous avez triomphé et vous gangez <<15 xp>>. Voulez vous continuer votre chemin ou explorer l'antre du troll ?\n" + monPerso.Caracteristiques();
                Histoire.IsVisible = true;
                TextSupplementaireHaut.IsVisible = true;
                AnnonceNiveau();
                ActionButton12A.IsVisible = false;
                ActionButton13A.IsVisible = true;
                ActionButton13B.IsVisible = true;
            }
        }
        //Méthode qui fait avancer le scénario
        public void ActionButton12BClicked(object sender, EventArgs e)
        {
            if (ActionButton12C.IsFocused)
            {
                Histoire.IsVisible = true;
                Histoire.Text = "Après avoir tourné, vous avancez pendant un long moment sans rien voir de notable.";
                ActionButton13E.IsVisible = true;
                ActionButton12B.IsVisible = false;
            }
            else
            {
                Histoire.IsVisible = true;
                Histoire.Text = "Vous descendez prudement les marches mais vous avez une drôle d'impression. Le danger serait-il pas loin ? Il serait peut etre prudent de détecter les pieges ?";
                ActionButton13C.IsVisible = true;
                ActionButton13D.IsVisible = true;
                ActionButton12C.IsVisible = false;
                ActionButton12B.IsVisible = false;
            }
        }
        //Méthode qui fait avancer le scénario
        public void ActionButton12CClicked(object sender, EventArgs e)
        {
            if (ActionButton12B.IsFocused)
            {
                Histoire.IsVisible = true;
                Histoire.Text = "Vous descendez prudement les marches mais vous avez une drôle d'impression. Le danger serait-il pas loin ? Il serait peut etre prudent de détecter les pieges ?";
                ActionButton13C.IsVisible = true;
                ActionButton13D.IsVisible = true;
                ActionButton12C.IsVisible = false;

            }
            else
            {
                Histoire.IsVisible = true;
                Histoire.Text = "Après avoir tourné, vous avancez pendant un long moment sans rien voir de notable. Au loin, vous entendez des tambours.";
                ActionButton13E.IsVisible = true;
                ActionButton12C.IsVisible = false;
                ActionButton12B.IsVisible = false;
            }
        }
        //Méthode qui permet de débloquer le passage secret avec un lancer de dé.
        //Limité à 5 tentatives avant l'échec.
        public void ActionButton12DClicked(object sender, EventArgs e)
        {
            var resultatDeAleatoire = DeAleatoire();
            int tentativeMax = 5;

            if ((resultatDeAleatoire <= 4) & (tentative < tentativeMax))
            {
                DisplayAlert("Info", "Raté, vite, vite, recommencez vite", "ok");
                Histoire.IsVisible = true;
                Histoire.Text = "Continuez à chercher, mais ne trainez pas, les gardes peuvent arriver d'un moment à l'autre !\n Vous avez fait " + resultatDeAleatoire;
            }
            else if ((resultatDeAleatoire >= 4) & (tentative < tentativeMax))
            {
                Histoire.IsVisible = true;
                ActionButton12D.IsVisible = false;
                Histoire.Text = "Hourra, vous avez trouvé le mecanisme et un passage s'ouvre dans le mur, vous aviez fait " + resultatDeAleatoire + "." + "\nA peine engouffré dedans, celui-ci se referme ne vous laissant que le choix d'avancer.\nPlus loin, vous entendez un appel : un type louche sort d'un recoin sombre et vous propose un trésor extraordinaire pour seulement 100 pièces d'or.\nDécidez, soit vous marchandez, soit vous payez.\nVous avez " + monPerso.Richesse() + " pièces d'or.";
                ActionButton13F.IsVisible = true;
                ActionButton13G.IsVisible = true;
            }
            else
            {
                Histoire.IsVisible = true;
                Histoire.TextColor = Color.DarkRed;
                Histoire.Text = "Dommage, vous avez perdu trop de temps et les gardes finissent par vous coincer. Ainsi s'achève votre carrière d'aventurier.";
                ActionButton12D.IsVisible = false;
                DisplayAlert("Echec", "Vous avez perdu", "Recommencer");
            }
        }
        //Methode pour avancer dans le scénario
        public void ActionButton12EClicked(object sender, EventArgs e)
        {
            TextSupplementaireBas.IsVisible = false;
            TextSupplementaireHaut.IsVisible = false;
            ChoisirVol.IsVisible = false;
            Histoire.IsVisible = true;
            Histoire.Text = "Vous trouvez rapidement sous un tapis une trappe pour vous enfuir. La ruse est grossière mais vous donne l'avantage pour vous échapper\nPeu de temps après, vous entendez les gardes qui ont retrouvé votre trace. Seulement, vous voyez un panneau intriguant, qu'est ce que c'est ?";
            ActionButton12F.IsVisible = false;
            ActionButton13H.IsVisible = true;
        }
        //Méthode qui permet d'affronter simultanément 2 ennemis. D'abord le heros attaque l'ennemi 01 qui ripostera si il n'est pas mort puis le heros attaque l'ennemi 02 qui agira pareil
        //A la fin du combat, gain d'expérience, d'or et de potions de soins
        public void ActionButton12FClicked(object sender, EventArgs e)
        {
            TextSupplementaireBas.IsVisible = false;
            TextSupplementaireHaut.IsVisible = false;
            ChoisirVol.IsVisible = false;
            Orc orc01 = new Orc("Zog Zog", 70, 20, 25);
            Orc orc02 = new Orc("Zag Zag", 70, 20, 25);
            bool victoire = true;
            ActionButton12E.IsVisible = false;

            while (!orc01.EstMort() && !orc02.EstMort())
            {
                monPerso.Attaquer(orc01);
                if (monPerso.EstMort())
                {
                    victoire = false;
                    break;
                }
                if (!orc01.EstMort())
                {
                    orc01.Attaquer(monPerso);
                }
                monPerso.Attaquer(orc02);
                if (monPerso.EstMort())
                {
                    victoire = false;
                    break;
                }
                if (!orc02.EstMort())
                {
                    orc02.Attaquer(monPerso);
                }
            }
            if (victoire)
            {
                monPerso.GagnerExperience(20);
                monPerso.GagnerPotionsSoins();
                monPerso.GagnerBeaucoupOr();
                AnnonceNiveau();
                Histoire.IsVisible = true;
                Histoire.Text = "Quelle belle baston !! C'était chaud mais vous avez triomphé. Peut etre faudrait-il prendre une potion pour récupérer un peu ? En même temps, vous remarquez sous un tapis une trappe, l'aventure continue !\n" + monPerso.Caracteristiques();
                ActionButton12F.IsVisible = false;
                ActionButton13I.IsVisible = true;

            }
        }
        //Méthode qui permet de gagner l'Armure de Vie en fouillant ainsi que des pièces d'or
        public void ActionButton13AClicked(object sender, EventArgs e)
        {
            if (ActionButton13B.IsFocused)
            {
                ActionButton13A.IsVisible = false;
                Histoire.IsVisible = true;
                Histoire.Text = "Vous traversez rapidement l'antre du troll et un peu plus loin, vous voyez une porte d'où proviennent des chants et des rires." + "\nEn poussant la porte, vous découvrez l'entrée de la taverne et c'est la fête dedans ! En entrant, vous voyez un conours de lutte tandis qu'une serveuse vous propose de vous restaurer.";
            }
            else
            {
                monPerso.GagnerBeaucoupOr();
                monPerso.GagnerArmureDeVie();
                TextSupplementaireHaut.IsVisible = false;
                Histoire.IsVisible = true;
                Histoire.TextColor = Color.DarkGreen;
                ActionButton13A.IsVisible = false;
                ActionButton13B.IsVisible = false;
                Histoire.Text = "Incroyable ! En fouillant dans la tanière, sous un tas de déchets, vous trouvez une <<Armure de Vie>>, elle semble faites pour vous et quand vous la mettez, vous sentez la puissance et une régénération affluer en vous.\nSur cette bonne nouvelle, vous continuez votre chemin et un peu plus loin, vous voyez une porte d'où proviennent des chants et des rires.\n" + monPerso.Caracteristiques() + "\nEn poussant la porte, vous découvrez l'entrée de la taverne et c'est la fête dedans ! En entrant, vous voyez un conours de lutte tandis qu'une serveuse vous propose de vous restaurer.";
                ActionButton14A.IsVisible = true;
                ActionButton14B.IsVisible = true; ;
            }
        }
        //Méthode pour faire avancer le scénario
        public void ActionButton13BClicked(object sender, EventArgs e)
        {
            if (ActionButton13A.IsFocused)
            {
                Histoire.IsVisible = true;
                Histoire.TextColor = Color.DarkGreen;
                ActionButton13A.IsVisible = false;
                ActionButton13B.IsVisible = false;
                Histoire.Text = "Incroyable ! En fouillant dans la tanière, sous un tas de déchets, vous trouvez une <<Armure de Vie>>, elle semble faites pour vous et quand vous la mettez, vous sentez la puissance et une régénération affluer en vous.\nSur cette bonne nouvelle, vous continuez votre chemin et un peu plus loin, vous voyez une porte d'où proviennent des chants et des rires." + "\nEn poussant la porte, vous découvrez l'entrée de la taverne et c'est la fête dedans ! En entrant, vous voyez un conours de lutte tandis qu'une serveuse vous propose de vous restaurer.";
            }
            else
            {
                Histoire.IsVisible = true;
                TextSupplementaireHaut.IsVisible = false;
                Histoire.Text = "Vous ne souhaitez pas vous attarder dans cette salle et vous la traversez rapidement, vous continuez votre chemin et un peu plus loin, vous voyez une porte d'où proviennent des chants et des rires." + "\nEn poussant la porte, vous découvrez l'entrée de la taverne et c'est la fête dedans ! En entrant, vous voyez un conours de lutte tandis qu'une serveuse vous propose de vous restaurer.";
                ActionButton14A.IsVisible = true;
                ActionButton14B.IsVisible = true;
            }
        }
        //Méthode de détection des pièges avec un random de DeAleatoire(), si <=3, inflige des blessures via PerdreDesPointsDeVie()
        //Sinon, léger gain d'expérience
        public void ActionButton13CClicked(object sender, EventArgs e)
        {
            var resultatDe = DeAleatoire();
            if (ActionButton13D.IsFocused)
            {
                ActionButton13C.IsVisible = false;
                Histoire.IsVisible = true;
                ActionButton14C.IsVisible = true;
                ActionButton14D.IsVisible = true;
                Histoire.Text = "Dans votre précipitation, vous ne faites pas attention au clic entendu et vous prenez dans la jambe une fleche qui vous blesse ! Vous perdez des points de vie.\nAprès avoir pesté contre votre négligence, vous continuez et au loin, vous entendez une mélopée sinistre.\n" + monPerso.Caracteristiques();
            }
            else
            {
                if (resultatDe >= 3)
                {
                    Histoire.IsVisible = true;
                    monPerso.GagnerExperience(3);
                    Console.WriteLine(resultatDe);
                    ActionButton13D.IsVisible = false;
                    ActionButton13C.IsVisible = false;
                    ActionButton14C.IsVisible = true;
                    ActionButton14D.IsVisible = true;
                    Histoire.Text = "Bien joué, votre prudence paie, vous reperez une dalle suspecte et pouvez désarmorcer le piège.Vous vous sentez un peu plus malin et gagner <<3 XP>>.\nVous pouvez continuer votre exploration surtout qu'un nouveau choix s'offre à vous. Au loin, vous entendez une mélopée sinistre.\nCe sont des sorciers, ils sont 4 en train de préparer une incantation maléfique ! Qu'allez vous faire ?";
                }
                else if (resultatDe < 3)
                {
                    Histoire.IsVisible = true;
                    monPerso.PerdrePointsDeVie();
                    Console.WriteLine(resultatDe);
                    ActionButton13D.IsVisible = false;
                    ActionButton13C.IsVisible = false;
                    ActionButton14C.IsVisible = true;
                    ActionButton14D.IsVisible = true;
                    Histoire.TextColor = Color.DarkOrchid;
                    Histoire.Text = "Dommage, vous aviez bien repéré le piège mais votre dextérité laisse à désirer, vous déclenchez le piège et vous êtes blessé par une flèche. Vous perdez des points de vie.\nAprès avoir pesté contre votre négligence, vous continuez et au loin, vous entendez une mélopée sinistre.\nCe sont des sorciers, ils sont 4 en train de préparer une incantation maléfique ! Qu'allez vous faire ?" + monPerso.Caracteristiques();
                }
            }
        }
        //Méthode qui permet d'etre blessé
        public void ActionButton13DClicked(object sender, EventArgs e)
        {
            ActionButton13D.IsVisible = false;
            ActionButton13C.IsVisible = false;
            Histoire.IsVisible = true;
            ActionButton14C.IsVisible = true;
            ActionButton14D.IsVisible = true;
            monPerso.PerdrePointsDeVie();
            Histoire.Text = "Dans votre précipitation, vous ne faites pas attention au clic entendu et vous prenez dans la jambe une fleche qui vous blesse ! Vous perdez des points de vie.\nAprès avoir pesté contre votre négligence, vous continuez et au loin, vous entendez une mélopée sinistre.\n Ce sont des sorciers, ils sont 4 en train de préparer une incantation maléfique ! Qu'allez vous faire ?" + monPerso.Caracteristiques();
        }
        //Méthode qui fait avancer le scénario
        public void ActionButton13EClicked(object sender, EventArgs e)
        {
            Histoire.IsVisible = true;
            Histoire.Text = "Vous avancez prudement sans rien remarquer et un peu plus loin, vous voyez une porte d'où proviennent des chants et des rires. ";
            ActionButton13E.IsVisible = false;
            ActionButton12C.IsVisible = false;
        }
        //Méthode pour marchander avec le ruffian : 4 cas de figure possible
        //Else if remplace le switch case : si (cas1) sinon si(cas2) sinon si(cas3) sinon(cas4)
        public void ActionButton13FClicked(object sender, EventArgs e)
        {
            var resultatDeHeros = DeAleatoire();
            var resultatDeRuffian = DeAleatoire();

            if (resultatDeHeros <= resultatDeRuffian && monPerso.Richesse() > 110)
            {
                Histoire.IsVisible = true;
                monPerso.GagnerAnneauUnique();
                monPerso.PayerRuffianSansRemise();
                Histoire.Text = "Dommage, vous perdez la partie de dés. Vous faites " + resultatDeHeros + " tandis que le coquin fait " + resultatDeRuffian + ".\nVous devez payer le prix fort: <<110 pièces d'or>> !\nVous empochez donc après une grimace un superbe <<Anneau Unique>>, quelle puissance coule en vous après l'avoir mis.\n" + monPerso.Caracteristiques() + "\nContinuant votre" +
                "trajet, vous arrivez plus loin devant une porte avec une vieille serrure. Au dessus, sur un panneau est écrit 'Un trésor dans un coffre sans serrure, qui suis-je ?' A vous de décider !";
                ActionButton13F.IsVisible = false;
                ActionButton13G.IsVisible = false;
                ActionButton14E.IsVisible = true;
                ActionButton14F.IsVisible = true;
                Console.WriteLine("moi: " + resultatDeHeros + " lui: " + resultatDeRuffian);
            }
            else if (resultatDeHeros > resultatDeRuffian && monPerso.Richesse() > 75)
            {
                Histoire.IsVisible = true;
                monPerso.GagnerAnneauUnique();
                monPerso.PayerRuffianRemise();
                Histoire.Text = "Vous jouez une remise sur le fameux trésor avec une partie de dé et la chance vous sourit. Vous faites " + resultatDeHeros + " tandis que le coquin fait " + resultatDeRuffian + ".\nIl accepte donc de baisser le prix de son trésor à <<75 pièces d'or>> !\nVous empochez donc un superbe <<Anneau Unique>>, quelle puissance coule en vous après l'avoir mis.\n" + monPerso.Caracteristiques() + "\nContinuant votre" +
                "trajet, vous arrivez plus loin devant une porte avec une vieille serrure. Au dessus, sur un panneau est écrit 'Un trésor dans un coffre sans serrure, qui suis-je ?' A vous de décider !";
                ActionButton13F.IsVisible = false;
                ActionButton13G.IsVisible = false;
                ActionButton14E.IsVisible = true;
                ActionButton14F.IsVisible = true;
                Console.WriteLine("moi: " + resultatDeHeros + " lui: " + resultatDeRuffian);
            }
            else if (resultatDeHeros > resultatDeRuffian && monPerso.Richesse() < 75)
            {
                Histoire.Text = "C'est bien la peine de gagner aux dés car malgré sa remise, vous vous rendez compte que vous n'avez pas asser d'or !" + "\nContinuant votre" +
                "trajet, vous arrivez plus loin devant une porte avec une vieille serrure. Au dessus, sur un panneau est écrit 'Un trésor dans un coffre sans serrure, qui suis-je ?' A vous de décider !";
                Histoire.IsVisible = true;
                ActionButton13F.IsVisible = false;
                ActionButton13G.IsVisible = false;
                ActionButton14E.IsVisible = true;
                ActionButton14F.IsVisible = true;
                Console.WriteLine("moi: " + resultatDeHeros + " lui: " + resultatDeRuffian);
            }
            else
            {
                Histoire.IsVisible = true;
                Histoire.Text = "Dommage, non seulement vous perdez mais en plus vous êtes trop pauvre. Vous repartez donc sous les quolibets du ruffian !" + "\nContinuant votre" +
                "trajet, vous arrivez plus loin devant une porte avec une vieille serrure. Au dessus, sur un panneau est écrit 'Un trésor dans un coffre sans serrure, qui suis-je ?' A vous de décider !";
                ActionButton13F.IsVisible = false;
                ActionButton13G.IsVisible = false;
                ActionButton14E.IsVisible = true;
                ActionButton14F.IsVisible = true;
                Console.WriteLine("moi: " + resultatDeHeros + " lui: " + resultatDeRuffian);
            }
        }
        //Méthode pour acheter le trésor du ruffian (Anneau Unique)
        public void ActionButton13GClicked(object sender, EventArgs e)
        {
            Histoire.IsVisible = true;
            monPerso.GagnerAnneauUnique();
            monPerso.PayerRuffian();
            ActionButton13F.IsVisible = false;
            ActionButton13G.IsVisible = false;
            ActionButton14E.IsVisible = true;
            ActionButton14F.IsVisible = true;
            Histoire.Text = "Vous acceptez le prix du malandrin, attiré par le trésor et vous lui donnez le prix indiqué. Vous empochez donc un superbe <<Anneau Unique>>, quelle puissance coule en vous après l'avoir mis.\n" + monPerso.Caracteristiques() + "\nContinuant votre" +
                "trajet, vous arrivez plus loin devant une porte avec une vieille serrure. Au dessus, sur un panneau est écrit 'Un trésor dans un coffre sans serrure, qui suis-je ?' A vous de décider !";
        }
        //Méthode pour examiner un panneau
        public void ActionButton13HClicked(object sender, EventArgs e)
        {
            ActionButton13H.IsVisible = false;
            ActionButton13I.IsVisible = false;
            ActionButton12E.IsVisible = false;
            Histoire.IsVisible = true;
            Histoire.Text = "En regardant de plus près, vous voyez qu'il est écrit {Bureau de Reivax au fond à droite}";
            ActionButton14H.IsVisible = true;
            ActionButton14G.IsVisible = true;
        }
        //Méthode qui permet de récupérer des pv
        public void ActionButton13IClicked(object sender, EventArgs e)
        {
            monPerso.RecupererPVPotionDeSoin();
            Histoire.IsVisible = true;
            ActionButton13H.IsVisible = false;
            ActionButton13I.IsVisible = false;
            Histoire.Text = "Vous recupérez un peu d'énergie avec cette potion de soins et vous pouvez ensuite prendre la poudre d'escampette par la trappe que vous avez repéré précédemment.\n" + monPerso.Caracteristiques();
            ActionButton14H.IsVisible = true;
            ActionButton14G.IsVisible = true;
        }
        //Méthode qui permet de manger un ours à la bière
        public void ActionButton14AClicked(object sender, EventArgs e)
        {
            monPerso.OursBiere();
            Histoire.Text = "Vous commandez auprès de la serveuse un ours à la bière, cela vous en coute 10 pièces d'or mais il faut reconnaitre qu'il est succulent et qu'il vous retape efficacement !\n" + monPerso.Statistiques() + " Elle vous indique ensuite un concours de bières au comptoir ou de l'écouter pendant qu'elle frotte les tables.";
            Histoire.IsVisible = true;
            ActionButton14A.IsVisible = false;
            ActionButton14B.IsVisible = false;
        }
        //Méthode qui permet de participer à un concours de lutte
        public void ActionButton14BClicked(object sender, EventArgs e)
        {
            Monstre Barguil = new Monstre("Barguil", 75, 35, 35);
            bool victoire = true;

            while (!Barguil.EstMort())
            {
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.Text = "Vous affrontez votre premier lutteur. C'est\n" + Barguil.ToString();
                Histoire.IsVisible = true;
                Histoire.Text = "L'organisateur du combat annonce que si vous arrivez à remporter 5 combats de suite, vous serez champion et gagnerez une sacrée récompense.";
                monPerso.Attaquer(Barguil);
                if (monPerso.EstMort())
                {
                    victoire = false;
                    Histoire.IsVisible = true;
                    ActionButton14A.IsVisible = false;
                    ActionButton14B.IsVisible = false;
                    LutterEncore.IsVisible = false;
                    StopLutte.IsVisible = false;
                    break;
                }
                if (!Barguil.EstMort())
                {
                    Barguil.Attaquer(monPerso);
                }
                if (victoire)
                {
                    monPerso.GagnerExperience(5);
                    Histoire.Text = "Bravo, vous remportez votre premier combat. A vous de choisir de continuer ou d'arreter !";
                    Histoire.IsVisible = true;
                    ActionButton14A.IsVisible = false;
                    ActionButton14B.IsVisible = false;
                    LutterEncore.IsVisible = true;
                    StopLutte.IsVisible = true;
                }
            }
        }
        //Methode pour enchainer les combats de lutte
        //Limité avec un compteur à 5 combats aléatoire, tiré d'une liste et dont chaque unité est supprimé après utilisation
        //Voir if(monstres.Count == 0) & (monstres.Any()) pour cesser les combats [fait bug]
        public void LutterEncoreClicked(object sender, EventArgs e)
        {
            bool victoire = true;
            nbrCombat++;
            var lutteAleatoire = random.Next(monstres.Count);
            var lutteur = monstres[lutteAleatoire];

                while (!lutteur.EstMort())
                {
                    TextSupplementaireHaut.IsVisible = true;
                    TextSupplementaireHaut.Text = "Vous affrontez un nouveau lutteur. C'est\n" + lutteur.ToString() + "\n" + monPerso.Statistiques();
                    monPerso.Attaquer(lutteur);

                    if (monPerso.EstMort())
                    {
                        victoire = false;
                        Histoire.Text = "Dommage, vous avez présummé de vos forces et vous voila au tapis.";
                        Histoire.IsVisible = true;
                        DisplayAlert("Echec", "Vous avez perdu, recommencez", "OK");
                        ActionButton14A.IsVisible = false;
                        ActionButton14B.IsVisible = false;
                        LutterEncore.IsVisible = false;
                        StopLutte.IsVisible = false;
                        break;
                    }
                    if (!lutteur.EstMort())
                    {
                        lutteur.Attaquer(monPerso);
                    }
                    if (victoire)
                    {
                        monPerso.GagnerExperience(5);
                        Histoire.IsVisible = true;
                        Histoire.Text = "Vous remportez ce " + nbrCombat + "° combat, à vous de choisir si vous continuez ou vous arretez." + monPerso.Statistiques();
                        ActionButton14A.IsVisible = false;
                        ActionButton14B.IsVisible = false;
                        LutterEncore.IsVisible = true;
                        StopLutte.IsVisible = true;
                        monstres.Remove(lutteur);
                   
                        if (!monstres.Any())
                        {
                        
                        Histoire.Text = "Bravo, vous avez envoyé au tapis tous vos adversaires. Vous gagnez une bien belle récompense ! Vous gagnez une belle bourse d'or et surtout une splendide <<Epée de Justice>>. C'est trop la classe." +
                                        "\nVous récuperez aussi une <<Potion de soin miraculeuse>> que vous buvez de suite. Cela fait du bien. Qu'allez vous faire maintenant ?" + monPerso.Caracteristiques();
                        Histoire.IsVisible = true;
                        monPerso.GagnerExperience(30);
                        monPerso.GagnerBeaucoupOr();
                        monPerso.GagnerPotionsSoinMiraculeux();
                        monPerso.RecupererPVPotionDeSoinMiraculeux();
                        ActionButton14A.IsVisible = false;
                        ActionButton14B.IsVisible = false;
                        LutterEncore.IsVisible = false;
                        StopLutte.IsVisible = false;
                        ActionButton15A.IsVisible = true;
                        ActionButton15B.IsVisible = true;
                    }
                        
                    }
                }
        }
        //Méthode pour arreter le tournoi de lutte et avoir le lot de consolation
        public void StopLutteClicked(object sender, EventArgs e)
        {
            Histoire.IsVisible = true;
            Histoire.Text = "Vous décidez de jetter l'éponge.Dommage, la récompense aurait surement valu le coup. Mais l'organisateur du tournoi est sympa, il vous offre des potions de soins et vous en prenez une direct pour vous retaper." +
                "\nQu'allez vous faire ?";
            monPerso.GagnerPotionsSoins();
            monPerso.RecupererPVPotionDeSoin();
            TextSupplementaireHaut.IsVisible = false;
            ActionButton15A.IsVisible = true;
            ActionButton15B.IsVisible = true;
            StopLutte.IsVisible = false;
            LutterEncore.IsVisible = false;
        }
        //Méthode qui permet d'observer les sorciers selon le lancer de dé
        //vous fait agir différment - Echec critique à réussite
        public void ActionButton14CClicked(object sender, EventArgs e)
        {
            var resultatDe = DeAleatoire();

            if (resultatDe < 1)
            {
                Histoire.IsVisible = true;
                Histoire.Text = "La discrétion n'est pas votre fort. Vous avez " + resultatDe + ". C'est le drame, un des sorciers vous entend et incante aussitot une boule\n" +
                    " de feu qui explose dessus. Elle vous laisse chancelant. C'est l'echec critique !!";
                ActionButton14C.IsVisible = false;
                ActionButton14D.IsVisible = false;
                ActionButton14Dbis.IsVisible = false;
                DisplayAlert("Echec", "Vous avez perdu, recommencez", "OK");
            }
            else if (resultatDe >= 1 && resultatDe <= 9)
            {
                Histoire.IsVisible = true;
                Histoire.Text = "Pas très discret l'aventurier ! Vous faites " + resultatDe + ". Un des sorciers vous entend et incante aussiôt une boule de feu. Heureusement, vos réflexes vous permettent" +
                    " de pouvoir vous jetter derriere le mur et d'éviter le gros des dégats. Vous ne perdez quelques points de vie. Par contre, le combat s'annonce costaud ! Vous ne beneficiez pas de la surprise.";
                monPerso.PerdrePointsDeVie();
                ActionButton14C.IsVisible = false;
                ActionButton14D.IsVisible = false;
                ActionButton14Dbis.IsVisible = true;
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.Text = "Vous n'aurez pas l'avantage pour ce prochain combat.\n" + monPerso.Statistiques();
            }
            else
            {
                Histoire.IsVisible = true;
                Histoire.Text = " Avec " + resultatDe + ", votre discrétion vous permet de pouvoir les observer tranquillement et de remarquer un détail. Trois des quatre sorciers sont endormis, un seul est eveillé. Ca devient facile de se faufiler sans se faire repérer pour" +
                    " un aventurier discret comme vous. Bien joué, vous sentez que vous avez progressé ! ";
                monPerso.GagnerExperience(10);
                ActionButton14C.IsVisible = false;
                ActionButton14D.IsVisible = false;
                ActionButton14Dbis.IsVisible = false;
                ActionButton15D.IsVisible = true;
            }
        }
        //Attaque des sorciers par surprise
        //Le héros joue en premier pour les 3° sorciers
        public void ActionButton14DClicked(object sender, EventArgs e)
        {
            Sorcier sorcier1 = new Sorcier("Sorcier 1", 45, 20, 30);
            Sorcier sorcier2 = new Sorcier("Sorcier 2", 45, 20, 30);
            Sorcier sorcier3 = new Sorcier("Sorcier 3", 45, 20, 30);
            Sorcier sorcier4 = new Sorcier("Sorcier 4", 45, 20, 30);
            bool victoire = true;
            TextSupplementaireHaut.IsVisible = false;

            while (!sorcier1.EstMort())
            {
                monPerso.Attaquer(sorcier1); // Attaque 01
                if (monPerso.EstMort())
                {
                    victoire = false;
                    break;
                }
                if (!sorcier1.EstMort())
                {
                    sorcier1.Attaquer(monPerso);
                }
            }
            while (!sorcier2.EstMort())
            {
                monPerso.Attaquer(sorcier2); // Attaque 02
                if (monPerso.EstMort())
                {
                    victoire = false;
                    break;
                }
                if (!sorcier2.EstMort())
                {
                    sorcier2.Attaquer(monPerso);
                }
            }
            while (!sorcier3.EstMort())
            {
                monPerso.Attaquer(sorcier3); // Attaque 03
                if (monPerso.EstMort())
                {
                    victoire = false;
                    break;
                }
                if (!sorcier3.EstMort())
                {
                    sorcier3.Attaquer(monPerso);
                }
            }
            while (!sorcier4.EstMort())
            {
                sorcier4.Attaquer(monPerso); // Attaque 04
                if (monPerso.EstMort())
                {
                    victoire = false;
                    break;
                }
                monPerso.Attaquer(sorcier4);
                if (!sorcier4.EstMort())
                {
                    monPerso.Attaquer(sorcier4);
                }
            }
            if (sorcier4.EstMort() && sorcier3.EstMort() && sorcier2.EstMort() && sorcier1.EstMort())
            {
                monPerso.GagnerExperience(30);
                monPerso.GagnerBeaucoupOr();
                AnnonceNiveau();
                Histoire.Text = "Victoire, une belle bataille malgré que ce soit des chochottes en pantoufles et robes de chambres ! Vous savourez ce moment et vous décidez de la suite !\n"
                    + monPerso.Caracteristiques();
                ActionButton15C.IsVisible = true;
                ActionButton15D.IsVisible = true;
            }
            else
            {
                Histoire.Text = "Défaite, malgré une résistance héroique, vous succombez sous les attaques magiques des sorciers, c'est quand même un peu la honte de se faire battre" +
                    "par des gars en robe de chambre ?";
                DisplayAlert("Echec", "Dommage, vous avez perdu, il faut recommencer", "OK");
            }
        }
        //Méthode qui permet de riposter à l'attaque des sorciers puis le heros attaque chacun d'eux avec une riposte ennemie à chaque fois
        //Les sorciers attaquent en premier puis ripostent aux attaques du héros
        public void ActionButton14DbisClicked(object sender, EventArgs e)
        {
            Sorcier sorcier1 = new Sorcier("Sorcier 1", 30, 20, 30);
            Sorcier sorcier2 = new Sorcier("Sorcier 2", 30, 20, 30);
            Sorcier sorcier3 = new Sorcier("Sorcier 3", 30, 20, 30);
            Sorcier sorcier4 = new Sorcier("Sorcier 4", 30, 20, 30);
            bool victoire = true;
            TextSupplementaireHaut.IsVisible = false;

            while (!sorcier1.EstMort() && !sorcier2.EstMort() & !sorcier3.EstMort() & !sorcier4.EstMort())
            {
                sorcier1.Attaquer(monPerso); // Round 01 Attaque 01
                if (monPerso.EstMort())
                {
                    victoire = false;
                    break;
                }
                sorcier2.Attaquer(monPerso); //Round 01 Attaque 02
                if (monPerso.EstMort())
                {
                    victoire = false;
                    break;
                }
                sorcier3.Attaquer(monPerso); // Round 01 Attaque 03
                if (monPerso.EstMort())
                {
                    victoire = false;
                    break;
                }
                sorcier4.Attaquer(monPerso); // Round 01 Attaque 04
                if (monPerso.EstMort())
                {
                    victoire = false;
                    break;
                }
                monPerso.Attaquer(sorcier1); // Round 02 Attaque 01
                if (monPerso.EstMort())
                {
                    victoire = false;
                    break;
                }
                if (!sorcier1.EstMort()) 
                {
                    sorcier1.Attaquer(monPerso);
                }
                monPerso.Attaquer(sorcier2); // Round 02 Attaque 02
                if (monPerso.EstMort())
                {
                    victoire = false;
                    break;
                }
                if (!sorcier2.EstMort())
                {
                    sorcier2.Attaquer(monPerso);
                }
                monPerso.Attaquer(sorcier3); // Round 02 Attaque 03
                if (monPerso.EstMort())
                {
                    victoire = false;
                    break;
                }
                if (!sorcier3.EstMort())
                {
                    sorcier3.Attaquer(monPerso);
                }
                monPerso.Attaquer(sorcier4); // Round 02 Attaque 04
                if (monPerso.EstMort())
                {
                    victoire = false;
                    break;
                }
                if (!sorcier4.EstMort())
                {
                    sorcier4.Attaquer(monPerso);
                }
            }
            if (sorcier1.EstMort() && sorcier2.EstMort() & sorcier3.EstMort() & sorcier4.EstMort())
            {
                monPerso.GagnerExperience(30);
                monPerso.GagnerBeaucoupOr();
                AnnonceNiveau();
                Histoire.Text = "Victoire ! Ce combat vous laisse bien blessé, il faut dire que vous n'avez pas pu les attaquer en premier. Heureusement, les sorciers, ce sont des tafioles en robe de" +
                    "de chambre et pantoufles. Ca n'encaisse rien du tout.\nMaintenant, qu'allez vous décider ?" + monPerso.Caracteristiques();
                //ActionButton15C.IsVisible = true;
                //ActionButton15D.IsVisible = true;
            }
            else
            {
                Histoire.Text = "Défaite, malgré une résistance héroique, vous succombez sous les attaques magiques des sorciers, c'est quand même un peu la honte de se faire battre" +
                    "par des gars en robe de chambre ?";
                DisplayAlert("Echec", "Dommage, vous avez perdu, il faut recommencer", "OK");
            }
        }
        //Méthode qui lance la 3° enigme
        public void ActionButton14EClicked(object sender, EventArgs e)
        {
            Enigme03.IsVisible = true;
            Histoire.IsVisible = false;
            TextSupplementaireBas.IsVisible = true;
            TextSupplementaireBas.Text = "Un trésor dans un coffre sans serrure, qui suis-je ?";
            ActionButton14E.IsVisible = false;
            ActionButton14F.IsVisible = false;
        }
        public void Enigme03_Completed(object sender, EventArgs e)
        {
            var reponseEnigme03 = Enigme03.Text;
            int tentativeMax = 3;
            string soluce1 = "oeuf";
            Histoire.IsVisible = false;
            var bingo = soluce1.Replace(" ", "");
            ActionButton14E.IsVisible = false;
            ActionButton14F.IsVisible = false;

            if ((bingo != reponseEnigme03) & (tentative < tentativeMax))
            {
                DisplayAlert("Info:", "Mauvaise réponse", "ok");
                tentative++;
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.Text = "Essayez encore, il vous reste " + (tentativeMax - tentative) + " essais !";
                TextSupplementaireBas.IsVisible = true;
                TextSupplementaireBas.Text = "Un trésor dans un coffre sans serrure, qui suis-je ?";
            }
            else if (tentative == tentativeMax)
            {
                TextSupplementaireHaut.TextColor = Color.DarkRed;
                TextSupplementaireHaut.IsVisible = true;
                TextSupplementaireHaut.Text = "A force de cogiter pour trouver la réponse, vous ne voyez pas les gardes arriver. Ils vous attrapent et finisser ainsi votre carrière d'aventurier dans une geôle.";
                Enigme03.IsVisible = false;
                DisplayAlert("Echec", "Vous avez perdu", "Recommencer");
                ActionButton14E.IsVisible = false;
                ActionButton14F.IsVisible = false;
                Recommencer.IsVisible = true;
            }
            else
            {
                reponseEnigme03 = bingo;
                monPerso.GagnerExperience(5);
                Histoire.TextColor = Color.DarkGreen;
                Histoire.IsVisible = true;
                Histoire.Text = "Bravo, vous avez résolu l'enigme et gagné des XP !\n" + monPerso.Caracteristiques() + "\n Vous pénétrez dans une vaste salle. A peine vous avez le temps de regarder que vous êtes apostrophé par un..." +
                    "\n .... GOLBARG !! Aie aie, on est mal ! Que faire ?";
                Enigme03.IsVisible = false;
                TextSupplementaireHaut.IsVisible = false;
                TextSupplementaireBas.IsVisible = false;
                ActionButton14E.IsVisible = false;
                ActionButton14F.IsVisible = false;
                ActionButton15E.IsVisible = true;
                ActionButton15F.IsVisible = true;
            }
        }
        //Méthode pour crocheter une serrure si jet de réussite ok
        public void ActionButton14FClicked(object sender, EventArgs e)
        {
            var crochetage = DeAleatoire();

            if (crochetage > 4)
            {
                Histoire.IsVisible = true;
                Histoire.Text = "Vous avez fait: " + crochetage + ". Votre dexterité fait des merveilles, vous crochetez sans soucis la serrure et pénétrez dans une vaste salle. A peine vous avez le temps de regarder que vous êtes apostrophé par un..." +
                    "\n .... GOLBARG !! Il vous demande ce que vous faites ici. Aie aie, on est mal ! Que faire ?";
                ActionButton15E.IsVisible = true;
                ActionButton15F.IsVisible = true;
                ActionButton14E.IsVisible = false;
                ActionButton14F.IsVisible = false;
            }
            else
            {
                Histoire.IsVisible = true;
                Histoire.Text = "Vous avez fait: " + crochetage + ". Votre dexterité fait défaut, vous échouez et décidez qu'un bon coup d'épaule fera aussi bien l'affaire. Tant pis pour la discretion et vous pénétrez dans une vaste salle. A peine vous avez le temps de regarder que vous êtes apostrophé par un..." +
                    "\n .... GOLBARG !!\n Celui-ci semble mécontent d'être déranger par ce vacarme. Aie aie, on est mal ! Que faire ?";
                ActionButton15E.IsVisible = true;
                ActionButton15F.IsVisible = true;
                ActionButton14E.IsVisible = false;
                ActionButton14F.IsVisible = false;
            }
        }
        //Méthode pour arriver sur Reiwaxx
        public void ActionButton14GClicked(object sender, EventArgs e)
        {
            if (ActionButton14H.IsFocused)
            {
                ActionButton14H.IsVisible = false;
                Histoire.IsVisible = true;
                Histoire.Text = "En prenant à droite, vous avancez rapidement et vous tombez nez à nez sur un petit bonhomme bizarre, on dirait un semi-homme. Il sort d'une pièce à la porte richement décoré et semble surpris de vous voir.\nQu'allez vous faire ?";
            }
            else
            {
                ActionButton14G.IsVisible = false;
                Histoire.IsVisible = true;
                Histoire.Text = "Vous continuez rapidement en espérant semer les gardes. Toute à votre précipitation, vous ne faites pas attention et au détour d'un croisement, vous tombez sur une patrouille de 3 gardes. Tous, vous vous regardez en chien de faïence...Il faut agir !";
                ActionButton15I.IsVisible = true;
                ActionButton15J.IsVisible = true;
            }
        }
        //Méthode qui permet de tomber sur des gardes
        public void ActionButton14HClicked(object sender, EventArgs e)
        {
            if (ActionButton14G.IsFocused)
            {
                ActionButton14G.IsVisible = false;
                Histoire.IsVisible = true;
                Histoire.Text = "Vous continuez rapidement en espérant semer les gardes. Toute à votre précipitation, vous ne faites pas attention et au détour d'un croisement, vous tombez sur une patrouille de 3 gardes. Tous, vous vous regardez en chien de faïence...Il faut agir !";
                ActionButton15I.IsVisible = true;
                ActionButton15J.IsVisible = true;
            }
            else
            {
                ActionButton14H.IsVisible = false;
                Histoire.IsVisible = true;
                Histoire.Text = "En prenant à droite, vous avancez rapidement et vous tombez nez à nez sur un petit bonhomme bizarre, on dirait un semi-homme. Il sort d'une pièce à la porte richement décoré et semble surpris de vous voir.\nQu'allez vous faire ?";
            }
        }
        //Méthode qui permet d'écouter une serveuse
        public void ActionButton15AClicked(object sender, EventArgs e)
        {
            Histoire.IsVisible = true;
            Histoire.Text = "Après avoir mangé, vous écoutez la serveuse vous raconter ses histoires et vous apprenez que l'objet de votre quête se trouve au sommet du Donjon, gardé par le Maitre qui possède de puissants pouvoirs." +
                "\nEn glissant une piece sur la table, elle semble devenir encore plus loquace et vous donne même un dé pipé. Elle vous dit que cela servira.";
            monPerso.AcheterServeuse();
        }
        //Méthode pour faire un concours de bière
        public void ActionButton15BClicked(object sender, EventArgs e)
        {
                if (DeAleatoire() > 8)
                {
                    Histoire.IsVisible = true;
                    Histoire.Text = "Bien fatigué après ce combat, un peu de détente ferait du bien. Ca tombe bien, au comptoir, deux lascars en train de se piquer la ruche vous interpelle pour faire un concours de bière." +
                        "\nIl faut croire que vous tenez vraiment bien l'alcool car les deux compères s'affalent sur le comptoir. Vous en profitez pour prendre leurs bourses, payer les boissons et garder le reste pour vous.";
                    monPerso.GagnerPiecesOr();
                }
                else
                {
                    Histoire.IsVisible = true;
                    Histoire.Text = "Bien fatigué après ce combat, un peu de détente ferait du bien.Ca tombe bien, au comptoir, deux lascars en train de se piquer la ruche vous interpelle pour faire un concours de bière." +
                        "\nHelas, vous ne tenez pas face aux deux compères qui vous mettent minable, vous tombez de votre tabouret, vous entaillant le front et en plus, les compères vous font les poches et partent.\nUn peu plus tard, vous" +
                        "reprenez conscience en vous promettant de plus boire.";
                    monPerso.Blessure();
                    monPerso.SeFaireVoler();
                }
        }
        //Méthode pour fouiller les sorciers
        public void ActionButton15CClicked(object sender, EventArgs e)
        {
            Histoire.IsVisible = true;
            Histoire.Text = "Vous fouillez les sorciers et vous récupérez pas mal de choses. Vous faites le tri et vous ne gardez que les <<potions de soins>>, les pièces d'or et surtout, une <<Bague de Chance>>. Bizarre que le sorcier ne le portait pas" +
                "mais vu comme elle est affreuse, ca peux se comprendre.\nPuis vous conitnuez votre chemin !";
            monPerso.GagnerPiecesOr();
            monPerso.GagnerPotionsSoins();
            monPerso.GagnerAnneauDeChance();
        }
        //Méthode pour avancer sans trainer
        public void ActionButton15DClicked(object sender, EventArgs e)
        {
            Histoire.IsVisible = true;
            Histoire.Text = "Vous ne voulez pas vous attarder au cas où des gardes auraient entendu le vacarme. Vous prenez vite la poudre d'escampette et continuer votre chemin.";
        }
        //Méthode pour se faire tuer par un Golbarg, la fuite c'est mal(on l'a déjà dit!)
        public void ActionButton15EClicked (object sender, EventArgs e)
        {
            Histoire.IsVisible = true;
            Histoire.Text = "En voyant le Golbarg se dresser devant vous, vous n'avez qu'un seul reflexe : vous enfuir ! Bien mal vous en a pris, ce dernier d'un véloce coup de fouet vous attrape" +
                "par le coup et s'en est fini de votre vie d'aventurier";
            DisplayAlert("Echec", "Vous avez perdu, recommencez", "OK");
        }
        //Méthode pour taper la discut avec un Golbarg      
        public void ActionButton15FClicked(object sender, EventArgs e)
        {
            Histoire.IsVisible = true;
            Histoire.Text = "Bravement, vous commencez à engager la conversation avec le Golbarg et surprise, celui-ci semble être bavard !";
            ActionButton15E.IsVisible = false;
            ActionButton15F.IsVisible = false;
            CommentCaButton.IsVisible = true;
            OrcBruyantsButton.IsVisible = true;
        }
        //Méthodes pour le dialogue du Golbarg ---------------------------------------------------------------------//
        public void CommentCaClicked (object sender, EventArgs e)
        {
            Histoire.IsVisible = true;
            Histoire.Text = "Qu'est ce vous croyez ! Avec tout ce boucan, il n'est pas possible de dormir ! Toujours du rafut dans cette tour. N'est-ce pas ?";
            CommentCaButton.IsVisible = false;
            OrcBruyantsButton.IsVisible = false;
            AcquieserButton.IsVisible = true;
            LaisserTranquilleButton.IsVisible = true;
        }
        public void OrcBruyantsClicked (object sender, EventArgs e)
        {
            Histoire.IsVisible = true;
            Histoire.Text = "En effet, cette racaille ne sait faire que du bruit et en plus, ce sont des pleutres ! Si on pouvait s'en débarrasser";
            CommentCaButton.IsVisible = false;
            OrcBruyantsButton.IsVisible = false;
            TueurOrc.IsVisible = true;
            RigolerBetement.IsVisible = true;
        }
        //Fin de dialogue avec faible XP et sans objet
        public void AcquieserClicked (object sender, EventArgs e)
        {
            Histoire.IsVisible = true;
            Histoire.Text = "Enfin un aventurier qui comprend la détresse des autres, il est important de pouvoir se repose au calme. Comme vous m'avez l'air d'un aventurier" +
                " sympa et discret, je vous laisse passer et vous trouverez l'objet de votre quête au dernier étage !\nSurpris, vous passez l'antre du Golbarg sans encombre et continuez votre aventure et prenez l'escalier plus loin."
                + monPerso.Statistiques();
            monPerso.GagnerExperience(6);
            AcquieserButton.IsVisible = false;
            LaisserTranquilleButton.IsVisible = false;
        }
        //Fin de dialogue avec défaite
        public void LaisserTranquilleClicked (object sender, EventArgs e)
        {
            Histoire.IsVisible = true;
            Histoire.Text = "Bien sur, dites le que je vous ennnuie avec mes affaires ?! Bah tiens, j'ai bien envie de vous massacrer pour la peine !\nIl joint les actes à la parole" +
                        "d'un rapide coup de fouet, vous fait passer de vie à trépas.";
            DisplayAlert("Echec", "Vous avez perdu, recommencez", "OK");
            AcquieserButton.IsVisible = false;
            RigolerBetement.IsVisible = false;
        }
        //Fin de dialogue avec bon XP et gain d'objet
        public void TueurOrcClicked (object sender, EventArgs e)
        {
            Histoire.IsVisible = true;
            Histoire.Text = "Vous annoncez que vous êtes un tueur d'orc et que vous en avez beaucoup tabassé.\n" +
                "Ah, c'est bien ca ! Voila donc le dératiseur. Enfin cette bicoque va être nettoyé de sa vermine. Je vais vous donner un objet qui pourra vous aider et il vous faudra monter au sommet de la tour ! Heureux de ce " +
                "dénouement, vous pouvez continuer votre aventure " + monPerso.Caracteristiques();
            TueurOrc.IsVisible = false;
            RigolerBetement.IsVisible = false;
            monPerso.GagnerExperience(10);
            monPerso.BotteRapidité();
        }
        //fin de dialogue avec combat et récompense
        public void RigolerBetementClicked (object sender, EventArgs e)
        {
            TueurOrc.IsVisible = false;
            RigolerBetement.IsVisible = false;

            if (monPerso.DeAleatoireChanceux() >= 5)
            {
                Golbarg goldberg = new Golbarg("Goldberg", 90, 30, 35);
                bool victoire = true;
                while (!goldberg.EstMort())
                {
                    goldberg.Attaquer(monPerso);
                    if (monPerso.EstMort())
                    {
                        victoire = false;
                        break;
                    }
                    if (!goldberg.EstMort())
                    {
                        monPerso.Attaquer(goldberg);
                    }
                }
                if (victoire)
                {
                    monPerso.GagnerExperience(13);
                    monPerso.GagnerPiecesOr();
                    Histoire.IsVisible = true;
                    Histoire.Text = "Et vous trouvez ca drôle ?! Raah, ca m'énerve des crétins pareils ! J'vais me défouler sur vous. Mais vos reflexes vous permettent de pouvoir riposter" +
                        " et après un dur combat, vous triomphez et recuperez seulement de l'or. Vous n'avez plus qu'a continuer votre chemin." + monPerso.Caracteristiques();
                }
            }
            else
            {
                Histoire.IsVisible = true;
                Histoire.Text = "'Et vous trouvez ca drôle ?! Raah, ca m'énerve des crétins pareils ! J'vais me défouler sur vous.'Aussitôt dit, aussitôt fait, d'un rapide coup de fouet, il" +
                        "vous passe l'envie de ricaner pour toujours";
                DisplayAlert("Echec", "Vous avez perdu, recommencez", "OK");
            }
        }
        //---------------------------------------------------------------------------------------------------------//
        //Méthode pour accoster Reiwaxx
        public void ActionButton15GClicked (object sender, EventArgs e)
        {
            Histoire.Text = "Vous l'accostez en lui demandant qu'il est et ce qu'il fait ici. Vu sa taille et son allure, vous ne risquez rien.";
            Histoire.IsVisible = true;
            ActionButton15G.IsVisible = false;
            ActionButton15H.IsVisible = false;
        }
        //Méthode pour attaquer Reiwaxx, condition avec lancer de dé pour déterminer le type d'attaque
        public void ActionButton15HClicked (object sender, EventArgs e)
        {
            if (monPerso.DeAleatoireChanceux() > 6)
            {
                Histoire.Text = "Bouge pas raclure ! Et d'un bond rapide, vous foncez sur le drole de type pour lui régler son compte avant qu'il puisse donner l'alerte. Votre vivacité vous" +
                    "permet de l'atteindre avant qu'il puisse réagir et il s'écroule dans un gargouillis. En le fouillant, vous récuperez une clé et de l'or.";
                Histoire.IsVisible = true;
                monPerso.GagnerCleArgent();
                monPerso.GagnerPiecesOr();
                monPerso.GagnerExperience(3);
                ActionButton15G.IsVisible = false;
                ActionButton15H.IsVisible = false;
            }
            else
            {
                Histoire.Text = "Bouge pas raclure ! Et d'un bond rapide, vous foncez sur le drole de type mais vous n'aviez pas vu la flaque visqueuse et vous glissez dessus. Vous tombez sur votre" +
                    "épée, vous blessant tout seul avec. Heureusement, le bonhomme s'évanouit en voyant votre blessure !";
                Histoire.IsVisible = true;
                ActionButton15G.IsVisible = false;
                ActionButton15H.IsVisible = false;
                monPerso.PerdreBeaucoupPointsDeVie();
            }
        }
        public void ActionButton15IClicked (object sender, EventArgs e)
        {
            Orc zigzig = new Orc("Zig Zig", 80, 20, 25);
            Orc zugzug = new Orc("Zug Zug", 80, 20, 25);
            Orc zegzeg = new Orc("Zeg Zeg", 80, 20, 25);
            bool victoire = true;

            while (!zigzig.EstMort() & !zugzug.EstMort() && !zegzeg.EstMort())
            {
                monPerso.Attaquer(zigzig);
                if (monPerso.EstMort())
                {
                    victoire = false;
                    break;
                }
                if (!zigzig.EstMort())
                {
                    zigzig.Attaquer(monPerso);
                }
                monPerso.Attaquer(zugzug);
                if (monPerso.EstMort())
                {
                    victoire = false;
                    break;
                }
                if (!zugzug.EstMort())
                {
                    zugzug.Attaquer(monPerso);
                }
                monPerso.Attaquer(zegzeg);
                if (monPerso.EstMort())
                {
                    victoire = false;
                    break;
                }
                if (!zegzeg.EstMort())
                {
                    zegzeg.Attaquer(monPerso);
                }
            }
            if (zigzig.EstMort() & zugzug.EstMort() && zegzeg.EstMort())
            {
                Histoire.IsVisible = true;
                Histoire.Text = "Bravo, belle victoire";
            }
            else
            {
                Histoire.IsVisible = true;
                Histoire.Text = "Dommage, vous avez perdu le combat";
                DisplayAlert("Echec", "Vous avez perdu, recommencez", "OK");
            }
        }
        public void ActionButton15JClicked (object sender, EventArgs e)
        {
            Histoire.IsVisible = true;
            Histoire.Text = "Vous jetter" + monPerso.JetterOr() + " pièces d'or.";
        }
    }
}