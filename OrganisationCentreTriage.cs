using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;

namespace Projet_Gestion_Dechets
{
    class OrganisationCentreTriage
    {
        private int nbVaisseau;
        private int nbCentreTri;
        public ListeCentresTriages listeCentres;
        public static int qtsFinal = 0;
        private Random random = new Random();

        public static void AddFinal()
        {
            qtsFinal++;
        }

        public OrganisationCentreTriage(int _nbVaisseau, int _nbCentreTriage)
        {
            listeCentres = new ListeCentresTriages();
            nbCentreTri = _nbCentreTriage;
            nbVaisseau = _nbVaisseau;           
        }

        public void DemarerSimulation()
        {
            CreerCentreTriage();
            EnvoyerVesseau();

            AfficherResultat();

            AfficherResultat();
        }

        private void CreerCentreTriage()
        {
            

            for(int Cpt = 1; Cpt <= nbCentreTri; Cpt++)
            {
                CentreTriage mCentre = listeCentres.CreerNoeud(Cpt);
                listeCentres.Ajouter(mCentre);
            }
        }
        private void EnvoyerVesseau()
        {
            for (int noVaisseau = 1; noVaisseau <= nbVaisseau; noVaisseau++)
            {
                int type = random.Next(1, 3);

                if (type == 1)
                {
                    listeCentres.Ancre.AjouterVaisseauCentreTrie(new Cargo());
                }
                else
                {
                    listeCentres.Ancre.AjouterVaisseauCentreTrie(new Leger());
                }
            }
        }

        private void AfficherDonnee()
        {
            CentreTriage centre = null;

            for(int cpt = 1; cpt <= listeCentres.CptNoeuds; cpt++)
            {
                centre = listeCentres.Consulter(cpt);

                int Plutonium, Uranium, TerreContamine, MetauxLourd, CombustibleFossile;

                if(centre.Pile_Plutonium is null)
                {
                    Plutonium = 0;
                }
                else
                {
                    Plutonium = centre.Pile_Plutonium.Taille_Pile();
                }
                if (centre.Pile_Uranium is null)
                {
                    Uranium = 0;
                }
                else
                {
                    Uranium = centre.Pile_Uranium.Taille_Pile();
                }
                if (centre.Pile_TerreContamine is null)
                {
                    TerreContamine = 0;
                }
                else
                {
                    TerreContamine = centre.Pile_TerreContamine.Taille_Pile();
                }
                if (centre.Pile_MetauxLourd is null)
                {
                    MetauxLourd = 0;
                }
                else
                {
                    MetauxLourd = centre.Pile_MetauxLourd.Taille_Pile();
                }
                if(centre.Pile_CombustibleFossile is null)
                {
                    CombustibleFossile = 0;
                }
                else
                {
                    CombustibleFossile = centre.Pile_CombustibleFossile.Taille_Pile();
                }
                Console.WriteLine("|    " + centre.NoCentreTriage + "      " + centre.File_Depart.Taille_File() + "        " + Plutonium + "        " + Uranium + "        " + TerreContamine + "      " + MetauxLourd + "     " + CombustibleFossile);
            }
        }

        public void AfficherResultat()
        {
            Console.WriteLine("|----------------|-----------------------|---------------------------------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|No Centre triage|  Nb Vaisseau Restant  | Piles de matières Restante:                                                                                               |");
            Console.WriteLine("|----------------|-----------------------|--------------------------------------------------------------------------------------------------------- -----------------|");
            Console.WriteLine("|                |                       |      Plutonium      |      Uranium        |     Terrre Contamin      |    Metaux lourd      |      Commbustible Fossiles  |");

            AfficherDonnee();
        }

        
    }
}
