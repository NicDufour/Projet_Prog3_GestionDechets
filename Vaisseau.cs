using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Gestion_Dechets
{
    abstract class Vaisseau
    {
        protected int capacite;
        protected Random ramdom;
        protected List<Materiau> listeMateriaux;
        private Vaisseau _suivant = null;


        public Vaisseau()
        {
            ramdom = new Random();
            SetCapacite();
            listeMateriaux = new List<Materiau>();
            RemplirVaisseau();
      
        }

        protected virtual void SetCapacite()
        {

        }
        protected void RemplirVaisseau()
        {
            
            for(int noMateriau = 1; noMateriau < 6; noMateriau++)
            {
                listeMateriaux.Add(new Materiau(noMateriau));
            }
            
            for(int cpt = 0; cpt < capacite; cpt++)
            {
                listeMateriaux.Add(new Materiau(ramdom.Next(1, 6)));
            }
        }
        public Vaisseau Suivant
        {
            get { return _suivant; }
            set { _suivant = value; }
        }

        public int Capacite
        {
            get { return capacite; }
            set { capacite = value; }
        }

        public List<Materiau> LisetMateriau
        {
            get { return listeMateriaux; }
            set { listeMateriaux = value; }
        }


    }
}
