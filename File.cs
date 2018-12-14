using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Gestion_Dechets
{
    class File
    {
        private Vaisseau _ancre, _queue;
        private int _cpt_noeud;

        public File()
        {
            _ancre = _queue = null;
            _cpt_noeud = 0;
        }
        public void Enfiler(Vaisseau mVaisseau)
        {
            mVaisseau.Suivant = null;

            if (_ancre == null)
            {
                _ancre = mVaisseau;
                _queue = mVaisseau;
            }
            else
            {
                _queue.Suivant = mVaisseau;
                _queue = mVaisseau;
            }
            _cpt_noeud++;
        }

        public bool FileVide()
        {
            if (_ancre == null)
            { return true; }
            else
            { return false; }

        }
        public Vaisseau Defiler()
        {
            Vaisseau mVaisseau;

            if (!FileVide())
            {
                mVaisseau = _ancre;
                _ancre = _ancre.Suivant;
                _cpt_noeud--;
                return mVaisseau;
            }
            else
            {
                return null;
            }
            
        }
        public int Taille_File()
        {
            return _cpt_noeud;
        }
    }
}
