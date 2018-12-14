using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Projet_Gestion_Dechets.Properties;

namespace Projet_Gestion_Dechets
{
    class CentreTriage
    {
        protected int noCentreTriage;
        protected bool etatCentreTriage;

        //Énumération des différente pile de matière du centre de triage
        private enum ListePilesMateriaux
        {
            COMBUSTIBLES_FOSSILLE = 1,
            METAUX_LOURD = 2,
            PLUTONIUM = 3,
            TERRE_CONTAMINE = 4,
            URANIUM = 5
        }
       
        //Déclaration des variables contenant la capacité de chaque matéraiux que le centre de tri peut acceuillir selon le type de centre de tri.
        private int capaciteMaxPlutonium;
        private int capaciteMaxUranium;
        private int capaciteMaxMetauxLourd;
        private int capaciteMaxTerreContamine;
        private int capaciteMaxCombustible;

        //Déclaration des variables corespondant aux pile de matériaux, qui sont par default null étant donné que nous ignorons si le centre de trie les possède tous.
        private PileMateriau pile_CombustibleFossile = null;
        private PileMateriau pile_Plutonium = null;
        private PileMateriau pile_Uranium = null;
        private PileMateriau pile_MetauxLourd = null;
        private PileMateriau pile_TerreContamine = null;

        

        //Déclaration des variables corespondant a la file d'arrivé et à la file de départ de chaque centre de trie.
        private File file_Arrive;
        private File file_Depart;

        //Déclaration des variables qui corespondent au Noeud suivant et précédant de la liste Chainé
        private CentreTriage _suivant;
        private CentreTriage _precedent;

        //Override du constructeur par default qui recois le numero du centre de tri.
        public CentreTriage(int _noCentreTriage)
        {
            _suivant = null;
            _precedent = null;
            pile_CombustibleFossile = null;
            pile_Plutonium = null;
            pile_Uranium = null;
            pile_MetauxLourd = null;
            pile_TerreContamine = null;

        noCentreTriage = _noCentreTriage;
            DeploimentCentreTriage();
        }

        private void DeploimentCentreTriage()
        {
            SetCapaciteDefault();
            ConfigurationMateriauxTraite();
            CreationPilesMatieres();
            SetFilesDepArr();
        }

        //Déclaration de la fonction permettant de mettre la valeur par défault à zéro avant de connaitre les caractéristiques du centre de tri.
        private void SetCapaciteDefault()
        {
            capaciteMaxPlutonium = 0;
            capaciteMaxUranium = 0;
            capaciteMaxMetauxLourd = 0;
            capaciteMaxTerreContamine = 0;
            capaciteMaxCombustible = 0;
        }

        //Déclaration de la fonction qui permet de créer les piles du centre de trie selon le type de centre de tri.
        void CreationPilesMatieres()
        {
            if(capaciteMaxPlutonium !=0)
            {
                pile_Plutonium = new PileMateriau(capaciteMaxPlutonium);
            }
            if(capaciteMaxMetauxLourd != 0)
            {
                pile_MetauxLourd = new PileMateriau(capaciteMaxMetauxLourd);           
            }
            if(capaciteMaxCombustible != 0)
            {
                pile_CombustibleFossile = new PileMateriau(capaciteMaxCombustible);
            }
            if(capaciteMaxTerreContamine != 0)
            {
                pile_TerreContamine = new PileMateriau(capaciteMaxCombustible);
            }
            if(capaciteMaxUranium != 0)
            {
                pile_Uranium = new PileMateriau(capaciteMaxUranium);
            }         
        }

        //Déclaration de la fonction qui permet de créer les files pour l'arrivé et de départ des vaisseaux.
        private void SetFilesDepArr()
        {
            file_Arrive = new File();
            file_Depart = new File();
        }

        /* Déclaration de la fonction permmettant de configurer la qquantité maximum d'une matière. 
         * Reçoit en paramètre: 
         *      - Id de la matière récupéré dans l'enum de la liste des matières.
         *      - La quantité maximum de la de cette matière selon le fait que c'est un centre de tri pair ou impair.
         */
        protected void SetCapaciteMax(int _noMatiere, int _qtsMax)
        {
            switch (_noMatiere)
            {
                case 1:
                    capaciteMaxCombustible = _qtsMax;
                    break;
                case 2:
                    capaciteMaxMetauxLourd = _qtsMax;
                    break;
                case 3:
                    capaciteMaxPlutonium = _qtsMax;
                    break;
                case 4:
                    capaciteMaxTerreContamine = _qtsMax;
                    break;
                case 5:
                    capaciteMaxUranium = _qtsMax;
                    break;                    
            }
        }

        //Méthode virtuel qui permet de configurer les matériaux traité dans le centre de tri selon le type d'objet d'éclaré ( Pair ou Impair )
        protected virtual void ConfigurationMateriauxTraite()
        {

        }

        //Déclaration de la fonction permettant de faire entre un vaisseau dans la file d'attente du centre de trie.
        public void AjouterVaisseauCentreTrie(Vaisseau mVaisseau)
        {
            File_Arrive.Enfiler(mVaisseau);

            if(etatCentreTriage == false)
            {
                DemarageProcessusTriage();
            }
        }

        //           |Gestion des opérations dans le centre de triage|
        //---------------------------------------------------------------------------------------------------------/


        private void DemarageProcessusTriage() //Appelé automatiquement lorsqu'un vaisseau arrive dans la file d'arrivé.
        {
            Vaisseau vaisseauEntraitement;

            while(file_Arrive.Taille_File() > 0)
            {
                etatCentreTriage = true;

                vaisseauEntraitement = EnvoyerVaisseauQuaiDechargement();
                DechargerVaisseau(vaisseauEntraitement);
            }

            etatCentreTriage = false; //Plus de vaisseaux dans la file d'errivé du centre.
        }

        private Vaisseau EnvoyerVaisseauQuaiDechargement()//Appelé automatiquement tant qu'il reste des vesseau dans la file d'arrivé.
        {
            Vaisseau vaisseauEnTraitement;

            vaisseauEnTraitement = file_Arrive.Defiler();

            return vaisseauEnTraitement;
        }

        private void DechargerVaisseau(Vaisseau vaisseau)
        {           
            foreach(Materiau mMateriau in vaisseau.LisetMateriau.ToList())
            {
                switch (mMateriau.TypeMateriau)
                {
                    case (int)Materiau.Listemateriaux.COMBUSTIBLES_FOSSILLE:
                        TrierMateriau(ref pile_CombustibleFossile, mMateriau);
                        vaisseau.LisetMateriau.Remove(mMateriau);
                        break;
                    case (int)Materiau.Listemateriaux.METAUX_LOURD:
                        TrierMateriau(ref pile_MetauxLourd, mMateriau);
                        vaisseau.LisetMateriau.Remove(mMateriau);
                        break;
                    case (int)Materiau.Listemateriaux.PLUTONIUM:
                        TrierMateriau(ref pile_Plutonium, mMateriau);
                        vaisseau.LisetMateriau.Remove(mMateriau);
                        break;
                    case (int)Materiau.Listemateriaux.TERRE_CONTAMINE:
                        TrierMateriau(ref pile_TerreContamine, mMateriau);
                        vaisseau.LisetMateriau.Remove(mMateriau);
                        break;
                    case (int)Materiau.Listemateriaux.URANIUM:
                        TrierMateriau(ref pile_Uranium, mMateriau);
                        vaisseau.LisetMateriau.Remove(mMateriau);
                        break;
                }               
            }

            //Mettre vesseau dans la file de départ.
            file_Depart.Enfiler(vaisseau);
        }

        private void TrierMateriau(ref PileMateriau mPile, Materiau mMateriau)
        {
            if (!(mPile is null))
            {
                if (mPile.VerifierPilePleine())
                {
                    mPile.EmpilerMateriau(mMateriau);
                   
                }
                else
                {
                    ViderPileCentre(ref mPile);
                    mPile.EmpilerMateriau(mMateriau);
                }
            }         
        }

        private void ViderPileCentre(ref PileMateriau mPile)
        {
            Vaisseau mVaisseau;

            while (file_Depart.Taille_File() > 0)
            {
                mVaisseau = file_Depart.Defiler();

                for(int cpt = mVaisseau.LisetMateriau.Count(); cpt < mVaisseau.Capacite && mPile.Taille_Pile() > 0; cpt++) //Vérifier pour le cpt
                {
                    mVaisseau.LisetMateriau.Add(mPile.DepilerMateriau());
                }
                
                if(!(_suivant is null)) //Envoi dans le centre de trie suivant.
                {
                    Suivant.AjouterVaisseauCentreTrie(mVaisseau);
                }
                else
                {
                    mVaisseau = null; //Le vaisseau est détruit, mais on pourrais le considérer repartie dans l'espace.
                    OrganisationCentreTriage.AddFinal();
                }

                
            }          
        }

        private bool VerifierDepart(Vaisseau vaisseau)
        {
            if(vaisseau.LisetMateriau.Count() == vaisseau.Capacite)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //            |Création des accesseurs|
        //----------------------------------------------------------------------------------------------------/

        // La file d'arrivé
        public File File_Arrive
        {
            get { return file_Arrive; }
            set { file_Arrive = value; }
        }

        //La file de départ
        public File File_Depart
        {
            get { return file_Depart; }
            set { file_Depart = value; }
        }

        //L'état du centre de trie soit actif ou inactif.
        public bool Statue_Centre_Triage
        {
            get { return etatCentreTriage; }
            set { etatCentreTriage = value; }
        }

        //Le centre de triage suivant dans la liste
        public CentreTriage Suivant
        {
            get { return _suivant; }
            set { _suivant = value; }
        }

        //le centre de triage précédant dans la liste.
        public CentreTriage Precedent
        {
            get { return _precedent; }
            set { _precedent = value; }
        }

        //Le numéro de centre de triage.
        public int NoCentreTriage
        {
            get { return noCentreTriage; }
            set { noCentreTriage = value; }
        }

        //La pile de combustible fossiles.
        public PileMateriau Pile_CombustibleFossile
        {
            get { return pile_CombustibleFossile; }
            set { pile_CombustibleFossile = value; }
        }

        //La pile de plutonium
        public PileMateriau Pile_Plutonium
        {
            get { return pile_Plutonium; }
            set { pile_Plutonium = value; }
        }

        //La pile d'uranium
        public PileMateriau Pile_Uranium
        {
            get { return pile_Uranium; }
            set { pile_Uranium = value; }
        }

        //La pile métaux lourd
        public PileMateriau Pile_MetauxLourd
        {
            get { return pile_MetauxLourd; }
            set { pile_MetauxLourd = value; }
        }

        //La pile de terre contaminé
        public PileMateriau Pile_TerreContamine
        {
            get { return pile_TerreContamine; }
            set { pile_TerreContamine = value; }
        }
    }
}
