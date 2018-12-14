using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projet_Gestion_Dechets.Properties;

namespace Projet_Gestion_Dechets
{
    class ListeCentresTriages
    {
        private CentreTriage _ancre;
        private CentreTriage _queue;
        private int _cpt_noeuds;

        public ListeCentresTriages()
        {
            _ancre = null;
            _queue = null;
            _cpt_noeuds = 0;
        }

        public int CptNoeuds
        {
            get { return _cpt_noeuds; }
        }

        public CentreTriage CreerNoeud(int noCentre)
        {
            
            if (CheckNumber.IsPair(noCentre)) //Retourne vrai si nombre impair
            {
                return new CentreTriageImpair(noCentre);
            }
            else
            {
                return new CentreTriagePair(noCentre);
            }
        }

        public void AjouterEnDebutDeChaine(CentreTriage nou)
        {
            if (_ancre == null)
            {
                nou.Suivant = _ancre;
                _ancre = nou;
                 _queue = nou;
            }
            else
            {
                nou.Suivant = _ancre;
                _ancre.Precedent = nou;
                _ancre = nou;
            }

            _cpt_noeuds++;
        }

        public void AjouterEnFinDeChaine(CentreTriage nou)
        {
            _queue.Suivant = nou;
            nou.Precedent = _queue;
            _queue = nou;
            if (_cpt_noeuds == 0) { _ancre = nou; }
            _cpt_noeuds++;
        }

        public void Ajouter(CentreTriage nou)
        {
            CentreTriage _actuel, _temp;

            _actuel = _ancre;
            _temp = null;

            if (_cpt_noeuds == 0)
            {
                AjouterEnDebutDeChaine(nou);
            }
            else
            {
                AjouterEnFinDeChaine(nou);
            }
        }

        public void RetireDebut()
        {
            CentreTriage _aRetirer;

            _aRetirer = _ancre;
            _ancre = _aRetirer.Suivant;
            _ancre.Precedent = null;

            _cpt_noeuds--;

            if (_cpt_noeuds == 0) { _queue = _ancre; }
        }

        public void RetireFin()
        {
            CentreTriage _aRetirer;

            _aRetirer = _queue;
            _queue = _aRetirer.Precedent;
            _queue.Suivant = null;

            _cpt_noeuds--;

            if (_cpt_noeuds == 0) { _ancre = _queue; }
        }

        public void Retire(int valeur)
        {
            CentreTriage _actuel, _aRetirer;

            _actuel = Consulter(valeur);

            if (_actuel == null)
            { }
            else if (_actuel == _ancre)
            {
                RetireDebut();
            }
            else if (_actuel == _queue)
            {
                RetireFin();
            }
            else
            {
                _aRetirer = _actuel;
                _actuel = _actuel.Suivant;
                _actuel.Precedent = _aRetirer.Precedent;
                _actuel.Precedent.Suivant = _actuel;

                _cpt_noeuds--;
            }
        }
        public CentreTriage Consulter(int valeur)
        {
            CentreTriage _actuel;

            _actuel = _ancre;

            while (_actuel != null)
            {
                if (_actuel.NoCentreTriage == valeur)
                {
                    return _actuel;
                }
                else
                {
                    _actuel = _actuel.Suivant;
                }
            }
            return _actuel;
        }

        public CentreTriage ConsulterDebut()
        { return _ancre; }
        public CentreTriage ConsulterFin()
        { return _queue; }

        public void VideListe()
        {
            _ancre = _queue = null;
            _cpt_noeuds = 0;
        }

        public void AfficherNoeud(CentreTriage noeud)
        {
            Console.WriteLine("La valeur du noeud est  " + noeud.NoCentreTriage);
        }

        public void AfficherListe()
        {
            CentreTriage noeud = _ancre;

            while (noeud != null)
            {
                AfficherNoeud(noeud);
                noeud = noeud.Suivant;
            }

        }

        public CentreTriage Ancre
        {
            get { return _ancre; }
            set { _ancre = value; }
        }
    }
}
