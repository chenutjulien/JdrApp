using System;
using Xamarin.Essentials;
using System.Threading.Tasks;
using JdrApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SendGrid.Helpers.Mail;

namespace JdrApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Jungle01 : ContentPage
    {
        private int tentative = 0; // Sert de compteur pour la méthode des enigmes
        private int nbrChoix = 0; // Sert de compteur pour la méthode du vol des objets (CheckBox)
        private int nbrChoixMax = 1; // Limite à 2 tentatives le vol d'objets (CheckBox)

        AvatarJungle monHeros = new AvatarJungle("");
        public Jungle01()
        {
            InitializeComponent();
        }
        //Méthode qui permet de lancer un D10
        public int DeAleatoire10()
        {
            Random deAlea10 = new Random();
            return deAlea10.Next(1, 11);
        }
        //Méthode qui permet de lancer un D20
        public int DeAleatoire20()
        {
            Random deAlea20 = new Random();
            return deAlea20.Next(1, 21);
        }
        //Méthode qui permet l'affichage des statuts
        public void AffichageStatut()
        {
            StatutPv.Text = $"PV: " + monHeros.PointsDeVie();
            StatutAttaque.Text = monHeros.Attaque();
            StatutExperience.Text = $"XP: " + monHeros.Experience();
            StatutIntelligence.Text = $"Intelligence: " + monHeros.Intelligence();
            StatutNiveau.Text = $"Niveau: " + monHeros.Niveau();
            StatutVivacité.Text = $"Vivacité: " + monHeros.Vivacite();
            StatutOr.Text = $"Or: " + monHeros.Richesse();
            StatutPotions.Text = $"Potions: " + monHeros.Potions();
        }
        //Méthode qui permet de choisir son personnage avec des caractéristiques différentes pour l'aventure (Justicier)
        public void ChoisirJusticier(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            ChoixAvatar.Text = $"Vous avez choisi: {button.Content}";
            ExplicationAvatar.Text = "Le justicier est un solide combattant, fort et endurant, il combat au corps à corps avec de puissantes armes.\n\nCapacité spéciale: Déchaînement ";
            monHeros = new Justicier(button.Content + ": Grimnir");
            StatutPv.Text = $"PV: " + monHeros.PointsDeVie();
            StatutAttaque.Text = monHeros.Attaque();
            StatutExperience.Text = $"XP: " + monHeros.Experience();
            StatutIntelligence.Text = $"Intelligence: " + monHeros.Intelligence();
            StatutNiveau.Text = $"Niveau: " + monHeros.Niveau();
            StatutVivacité.Text = $"Vivacité: " + monHeros.Vivacite();
        }
        //Méthode qui permet de choisir son personnage avec des caractéristiques différentes pour l'aventure (Prêtre)
        public void ChoisirPretre(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            ChoixAvatar.Text = $"Vous avez choisi: {button.Content}";
            ExplicationAvatar.Text = "Le pretre, d'une intelligence supérieure, est le gardien d'antiques savoirs qui aide son prochain.\n\nCapacité spéciale: Prodige ";
            monHeros = new Pretre(button.Content + ": Aran");
            StatutPv.Text = $"PV: " + monHeros.PointsDeVie();
            StatutAttaque.Text = monHeros.Attaque();
            StatutExperience.Text = $"XP: " + monHeros.Experience();
            StatutIntelligence.Text = $"Intelligence: " + monHeros.Intelligence();
            StatutNiveau.Text = $"Niveau: " + monHeros.Niveau();
            StatutVivacité.Text = $"Vivacité: " + monHeros.Vivacite();
        }
        //Méthode qui permet de choisir son personnage avec des caractéristiques différentes pour l'aventure (Archer)
        public void ChoisirArcher(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            ChoixAvatar.Text = $"Vous avez choisi: {button.Content}";
            ExplicationAvatar.Text = "L'archer, tireur d'élite par excellence va priviligier la suppression de ces cibles à distance. Tres rapide et agile, il joue sur la discrétion.\n\nCapacité spéciale : Fulgurance";
            monHeros = new ArcherJungle(button.Content + ": Heeru");
            StatutPv.Text = $"PV: " + monHeros.PointsDeVie();
            StatutAttaque.Text = monHeros.Attaque();
            StatutExperience.Text = $"XP: " + monHeros.Experience();
            StatutIntelligence.Text = $"Intelligence: " + monHeros.Intelligence();
            StatutNiveau.Text = $"Niveau: " + monHeros.Niveau();
            StatutVivacité.Text = $"Vivacité: " + monHeros.Vivacite();
        }
        //Méthode qui lance l'aventure
        public void DebuterAventureClicked(object sender, EventArgs e)
        {
            BlocChoixAvatar.IsVisible = false;
            BlocExplicationAvatar.IsVisible = false;
            BlocTitreChoixAvatar.IsVisible = false;
            DebuterAventure.IsVisible = false;
            BlocHistoire.IsVisible = true;
            Histoire.Text = "C'est le drame chez vous ! De retour d'un voyage au loin, vous découvrez votre domestique à l'extérieur, adossé à un muret. Celui-ci se tient le ventre, une importante blessure laissant " +
                            "échapper du sang. Dans un souffle, il vous dit qu'une bande de pillard est arrivé, l'ont attaqué et enlevé votre femme et votre enfant. C'est dans vos bras que votre fidèle serviteur rend son " +
                            "dernier soupir.\nQu'allez vous faire ?";
            ActionButton01A.IsVisible = true;
            ActionButton01B.IsVisible = true;
        }
        //Méthode qui permet de fouiller la maison et de récuperer des items
        public void ActionButton01AClicked(object sender, EventArgs e)
        {
            Histoire.Text = "En fouillant dans la maison, vous récuperez quelques richesses, des potions de soins et une potion miraculeuse et le <<Pendentif de Vivacité>> de votre femme. Vous ne comprenez pas pourquoi ils n'ont pas pris vos objets de valeurs " +
                " mais seulement votre famille.\nDehors, en examinant les traces, vous voyez qu'elles sont nombreuses et s'enfoncent dans la jungle.\nQu'allez vous faire maintenant ?";
            monHeros.GagnerBeaucoupOr();
            monHeros.GagnerPotionsSoins();
            monHeros.GagnerPotionsSoinMiraculeux();
            monHeros.PendentifVivacité();
            AffichageStatut();
            ActionButton01A.IsVisible = false;
            ActionButton01B.IsVisible = false;
            ActionButton02A.IsVisible = true;
            ActionButton02B.IsVisible = true;
        }
        //Méthode pour aller au village et obtenir des infos
        public void ActionButton01BClicked(object sender, EventArgs e)
        {
            Histoire.Text = "Vous laissez vos affaires sur place et vous partez rapidement vers le village. Après deux heures de marche rapide, vous arrivez au village et allez directement à la taverne pour avoir " +
                "des informations.\nVous apprenez qu'une secte de cultiste est installé dans les profondeurs de la jungle et font des razzias sur les maisons isolées. Rien d'autre d'interressant.\nPar contre, deux malandrins " +
                "avinés commencent à se moquer de vous.\nQu'allez vous faire ?";
            ActionButton01A.IsVisible = false;
            ActionButton01B.IsVisible = false;
            ActionButton02C.IsVisible = true;
            ActionButton02D.IsVisible = true;
        }
        //Méthode qui permet de suivre des traces dans la jungle
        public void ActionButton02AClicked(object sender, EventArgs e)
        {
            Histoire.Text = "Vous décidez de ne pas perdre de temps et partez de suite en utilisant vos compétences de pistage pour suivre les traces qui semblent aller au coeur de la jungle. Vu les marques, vous supposez qu'elles datent de quelques heures, cela fait du retard " +
                "à rattraper. Le nombre d'empreintes que vous relevez vous inquiètent un peu car cela ressemble à une sacrée troupe.\nTout à votre poursuite, vous ne négligez pas d'ouvrir l'oeil et vous faites bien; un jaguar" +
                " apparait devant vous, sortant d'un taillis. Il se met à feuler !\nQu'allez vous faire ?";
            ActionButton02A.IsVisible = false;
            ActionButton02B.IsVisible = false;
            ActionButton03A.IsVisible = true;
            ActionButton03B.IsVisible = true;
        }
        //Méthode qui permet d'enterrer le serviteur et de récupérer un item
        public void ActionButton02BClicked(object sender, EventArgs e)
        {
            Histoire.Text = "Vous ne voulez pas perdre de temps mais vous ne pouvez pas laisser votre fidèle serviteur à la portée des charognards. Vous prenez donc le temps de l'enterrer et au passage, vous lui retirer " +
                "son <<Anneau de Liberté>> le garder, peut-être pourrait vous le donner à sa famille plus tard.\n Puis vous prenez le chemin des traces, fort nombreuses et qui s'enfoncent dans la jungle à la poursuite de" +
                " ces ravisseurs.\nVotre vigilance est mise à l'épreuve quand un jaguar sort d'un fourré et se met à feuler en vous voyant.\nQu'allez vous faire ?";
            ActionButton02A.IsVisible = false;
            ActionButton02B.IsVisible = false;
            ActionButton03A.IsVisible = true;
            ActionButton03B.IsVisible = true;
            monHeros.AnneauLiberte();
            AffichageStatut();
        }
        //Méthode qui permet de combattre des malandrins
        public void ActionButton02CClicked(object sender, EventArgs e)
        {
            Malandrin antifa = new Malandrin("Crasseux", 15, 15, 20);
            Malandrin punk = new Malandrin("Pouilleux", 15, 15, 20);
            bool victoire = true;
            var jetVivacite = DeAleatoire10();

            if (monHeros.Vivacite() > jetVivacite)
            {
                while (!punk.EstMort() && !antifa.EstMort())
                {
                    monHeros.Attaquer(antifa);
                    if (monHeros.EstMort())
                    {
                        victoire = false;
                        break;
                    }
                    else if (!antifa.EstMort())
                    {
                        antifa.Attaquer(monHeros);
                    }
                    monHeros.Attaquer(punk);
                    if (monHeros.EstMort())
                    {
                        victoire = false;
                        break;
                    }
                    else if (!punk.EstMort())
                    {
                        punk.Attaquer(monHeros);
                    }
                }
                if (punk.EstMort() && antifa.EstMort())
                {
                    Histoire.IsVisible = true;
                    Histoire.Text = "Vous avez fait " + jetVivacite + " sur votre jet de vivacité. C'est réussi, vous attaquez en premier !" + Environment.NewLine + "Rapidement, vous vous debarrassez des deux malandrins sans grande difficultés" +
                    " et pour la peine, vous les delestez de leurs bourses. Puis vous décidez de partir à la poursuite des pillards.\nAvant, vous décidez soit d'aller acheter du materiel à l'échoppe ou de partir directement.";
                    monHeros.GagnerExperience(5);
                    monHeros.GagnerBeaucoupOr();
                    AffichageStatut();
                    ActionButton02C.IsVisible = false;
                    ActionButton02D.IsVisible = false;
                }
            }
            else
            {
                ResultatDe.IsVisible = true;
                ResultatDe.Text = "Vous avez fait " + jetVivacite + ". C'est raté, vous attaquez en dernier !";
                while (!punk.EstMort() && !antifa.EstMort())
                {
                    antifa.Attaquer(monHeros);
                    if (monHeros.EstMort())
                    {
                        victoire = false;
                        break;
                    }
                    else if (!antifa.EstMort())
                    {
                        monHeros.Attaquer(antifa);
                    }
                    punk.Attaquer(monHeros);
                    if (monHeros.EstMort())
                    {
                        victoire = false;
                        break;
                    }
                    else if (!punk.EstMort())
                    {
                        monHeros.Attaquer(punk);
                    }
                }
                if (punk.EstMort() && antifa.EstMort())
                {
                    Histoire.IsVisible = true;
                    Histoire.Text = "Vous avez fait " + jetVivacite + " sur votre jet de vivacité. C'est raté, vous attaquez en dernier !\nRapidement, vous vous debarrassez des deux malandrins sans grandes difficultés" +
                    " et pour la peine, vous les delestez de leurs bourses. Puis vous décidez de partir à la poursuite des pillards.\nAvant, vous décidez soit d'aller acheter du materiel à l'échoppe ou de partir directement.";
                    monHeros.GagnerExperience(5);
                    monHeros.GagnerBeaucoupOr();
                    AffichageStatut();
                    ActionButton02C.IsVisible = false;
                    ActionButton02D.IsVisible = false;
                }
            }
        }
        //Méthode qui permet de quitter une taverne sans combattre
        public void ActionButton02DClicked(object sender, EventArgs e)
        {
            Histoire.Text = "Vous faites fi des provocations et tournez le dos à ces ivrognes et sortez de l'auberge. Vous avez envie d'aller chercher du matériel mais avec regret, vous vous souvenez que vous êtes partis " +
            "sans votre bourse et que vous n'avez pas une pièce d'or.\nIl ne vous reste plus qu'a retourner chez vous et commencez la traque de ces cultistes.\nUne fois chez vous, qu'allez vous faire ?";
            ActionButton02C.IsVisible = false;
            ActionButton02D.IsVisible = false;
            ActionButton02A.IsVisible = true;
            ActionButton02B.IsVisible = true;
        }
        //Méthode pour amadouer un jaguar
        public void Actionbutton03AClicked(object sender, EventArgs e)
        {
            var jetIntelligence = DeAleatoire20();
            ActionButton03A.IsVisible = false;
            ActionButton03B.IsVisible = false;
            if (monHeros.StatutID() == 2)
            {
                Histoire.Text = "Méfiant, vous estimez avoir affaire à un jaguar d'une bonne centaine de kilos, autant dire un sacré adversaire. Vous faites donc appel à vos pouvoirs de prêtre pour amadouer le jaguar.";
                if (monHeros.Intelligence() > jetIntelligence)
                {
                    Histoire.Text = "Méfiant, vous estimez avoir affaire à un jaguar d'une bonne centaine de kilos, autant dire un sacré adversaire. Vous faites donc appel à vos pouvoirs de prêtre pour amadouer le jaguar." +
                        "\nVotre jet d'intelligence est de " + jetIntelligence + "\nVotre concentration et votre lien avec votre Dieu est forte, cela vous permet de faire un prodige !";
                    ActionButtonProdige.IsVisible = true;
                }
                else
                {
                    Histoire.Text = "Méfiant, vous estimez avoir affaire à un jaguar d'une bonne centaine de kilos, autant dire un sacré adversaire. Vous faites donc appel à vos pouvoirs de prêtre pour amadouer le jaguar."
                        + Environment.NewLine + "Dommage, votre concentration est troublée par le jaguard et vous ne pouvez faire appel aux prodiges divins. IL va falloir vous battre à l'ancienne."
                        + Environment.NewLine + "Votre jet d'intelligence est de " + jetIntelligence;
                    ActionButton03B.IsVisible = true;
                }
            }
            else
            {
                Histoire.Text = "Dommage, vous n'avez pas de prodiges divins à disposition et votre morceau de viande séchée ne l'interresse pas du tout, il va falloir se battre !";
                ActionButton03B.IsVisible = true;
            }
        }
        //Méthode pour lancer un prodige !!
        public  void ActionButtonProdigeClicked(object sender, EventArgs e)
        {
            MainThread.InvokeOnMainThreadAsync(async () => await ExecutePokemonAnimationAndNavigationToPage4());
            Histoire.Text = "Votre concentration sans faille vous permet de demander à votre Dieu d'intercéder et celui répond de toute sa puissance ! Un halo de lumière tombe sur le jaguar.\nCelui-ci vous regarde hébété" +
                " et ferme les yeux, soudainement, il s'affale par terre, pris par un profond sommeil surnaturel.\nQuelle puissance que votre Dieu !";
            ActionButtonProdige.IsVisible = false;
            monHeros.GagnerExperience(5);
            AffichageStatut();
        }
        //Méthode pour attaquer un jaguar
        public void ActionButton03BClicked(object sender, EventArgs e)
        {

        }
        //Méthode pour négocier des prix
        public void ActionButton03CClicked(object sender, EventArgs e)
        {

        }
        //Méthode pour acheter des objets
        public void Actionbutton03DClicked(object sender, EventArgs e)
        {

        }



        private void ViewPokemon_Clicked(object sender, EventArgs e)
        {
            MainThread.InvokeOnMainThreadAsync(async () => await ExecutePokemonAnimationAndNavigationToPage4());
        }

        private async Task ExecutePokemonAnimationAndNavigationToPage4()
        {
            // Animation appearing
            new Animation
            {
                { 0, 0.1, new Animation(v => pokemonTransitionAnimation.IsVisible = true) },
                { 0.1, 1, new Animation(v => pokemonTransitionAnimation.TranslateTo(0, 0)) }
            }.Commit(this, "openingAnimation", 60, 150, Easing.Linear);


            // Lines animations
            new Animation
            {
                { 0, 1, new Animation(v => line1.TranslationX = v, 0, 500) }
            }.Commit(this, "line1", rate: 60, length: 300, easing: Easing.Linear, finished: (v, c) => line1.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line2.TranslationX = v, 0, 500) }
            }.Commit(this, "line2", rate: 60, length: 700, easing: Easing.Linear, finished: (v, c) => line2.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line3.TranslationX = v, 0, 500) },
                { 0, 1, new Animation(v => line4.TranslationX = v, 0, 500) },
                { 0, 1, new Animation(v => line5.TranslationX = v, 0, 500) },
            }.Commit(this, "bigLine1", rate: 60, length: 900, easing: Easing.Linear, finished: (v, c) =>
            {
                line3.TranslationX = 0;
                line4.TranslationX = 0;
                line5.TranslationX = 0;
            },
            repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line6.TranslationX = v, 0, 500) }
            }.Commit(this, "line6", rate: 60, length: 200, easing: Easing.Linear, finished: (v, c) => line6.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line7.TranslationX = v, 0, 500) }
            }.Commit(this, "line7", rate: 60, length: 500, easing: Easing.Linear, finished: (v, c) => line7.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line8.TranslationX = v, 0, 500) }
            }.Commit(this, "line8", rate: 60, length: 650, easing: Easing.Linear, finished: (v, c) => line8.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line9.TranslationX = v, 0, 500) }
            }.Commit(this, "line9", rate: 60, length: 824, easing: Easing.Linear, finished: (v, c) => line9.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line10.TranslationX = v, 0, 500) }
            }.Commit(this, "line10", rate: 60, length: 621, easing: Easing.Linear, finished: (v, c) => line10.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line11.TranslationX = v, 0, 500) },
                { 0, 1, new Animation(v => line12.TranslationX = v, 0, 500) },
                { 0, 1, new Animation(v => line13.TranslationX = v, 0, 500) },
            }.Commit(this, "bigLine2", rate: 60, length: 210, easing: Easing.Linear, finished: (v, c) =>
            {
                line11.TranslationX = 0;
                line12.TranslationX = 0;
                line13.TranslationX = 0;
            },
            repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line14.TranslationX = v, 0, 500) }
            }.Commit(this, "line14", rate: 60, length: 521, easing: Easing.Linear, finished: (v, c) => line14.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line15.TranslationX = v, 0, 500) }
            }.Commit(this, "line15", rate: 60, length: 436, easing: Easing.Linear, finished: (v, c) => line15.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line16.TranslationX = v, 0, 500) }
            }.Commit(this, "line16", rate: 60, length: 324, easing: Easing.Linear, finished: (v, c) => line16.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line17.TranslationX = v, 0, 500) }
            }.Commit(this, "line17", rate: 60, length: 221, easing: Easing.Linear, finished: (v, c) => line17.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line18.TranslationX = v, 0, 500) },
                { 0, 1, new Animation(v => line19.TranslationX = v, 0, 500) },
                { 0, 1, new Animation(v => line20.TranslationX = v, 0, 500) },
            }.Commit(this, "bigLine3", rate: 60, length: 550, easing: Easing.Linear, finished: (v, c) =>
            {
                line18.TranslationX = 0;
                line19.TranslationX = 0;
                line20.TranslationX = 0;
            },
            repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line21.TranslationX = v, 0, 500) }
            }.Commit(this, "line21", rate: 60, length: 661, easing: Easing.Linear, finished: (v, c) => line21.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line22.TranslationX = v, 0, 500) }
            }.Commit(this, "line22", rate: 60, length: 580, easing: Easing.Linear, finished: (v, c) => line22.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line23.TranslationX = v, 0, 500) }
            }.Commit(this, "line23", rate: 60, length: 721, easing: Easing.Linear, finished: (v, c) => line23.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line24.TranslationX = v, 0, 500) }
            }.Commit(this, "line24", rate: 60, length: 521, easing: Easing.Linear, finished: (v, c) => line24.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line25.TranslationX = v, 0, 500) },
                { 0, 1, new Animation(v => line26.TranslationX = v, 0, 500) },
                { 0, 1, new Animation(v => line27.TranslationX = v, 0, 500) },
            }.Commit(this, "bigLine4", rate: 60, length: 419, easing: Easing.Linear, finished: (v, c) =>
            {
                line25.TranslationX = 0;
                line26.TranslationX = 0;
                line27.TranslationX = 0;
            },
            repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line28.TranslationX = v, 0, 500) }
            }.Commit(this, "line28", rate: 60, length: 650, easing: Easing.Linear, finished: (v, c) => line28.TranslationX = 0, repeat: () => true);
            new Animation
            {
                { 0, 1, new Animation(v => line29.TranslationX = v, 0, 500) }
            }.Commit(this, "line29", rate: 60, length: 852, easing: Easing.Linear, finished: (v, c) => line29.TranslationX = 0, repeat: () => true);


            // Pokemon animation
            new Animation
            {
                { 0, 0.1, new Animation(v => charizard.IsVisible = true) },
                { 0.3, 0.7, new Animation(v => charizard.TranslateTo(0, 0)) },
                { 0.7, 0.8, new Animation(v => charizard.TranslateTo(-50, 0)) },
                { 0.8, 1, new Animation(v => charizard.TranslateTo(500, 0)) },
                { 0.81, 1, new Animation(v => pokemonTransitionAnimation.TranslateTo(500, 0)) }
            }.Commit(this, "pokemonAnimation", 60, 7500, Easing.Linear);

            await Task.Delay(7000);
            
        }


    }
}