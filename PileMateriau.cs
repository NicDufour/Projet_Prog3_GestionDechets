using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Gestion_Dechets
{
    class PileMateriau
    {
        private Materiau _materiau;
        private int _taillePileMateriau;
        private int _cptMateriau;

        //Création d'un nouvelle pile d'objet Materiau
        public PileMateriau(int taillePile)
        {
            _materiau = null;
            _taillePileMateriau = taillePile;
            _cptMateriau = 0;
        }
        public void EmpilerMateriau(Materiau mMateriau)
        {
            if (_taillePileMateriau == _cptMateriau)
            {
                return;
            }
            else
            {
                mMateriau.MateriauSuivant = _materiau;
                _materiau = mMateriau;
                _cptMateriau++;
            }
        }
        public bool PileVide()
        {
            if (_materiau == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public Materiau DepilerMateriau()
        {
            Materiau materiauDepile = null;

            if (!PileVide())
            {
                materiauDepile = _materiau;
                _materiau = _materiau.MateriauSuivant;
                _cptMateriau--;
            }
            else
            {
                Console.WriteLine("Impossible de dépiler un élément, la pile est vide.");
            }

            return materiauDepile;
        }
        public int Taille_Pile()
        {
            return _cptMateriau;
        }

        public int Max_pile()
        {
            return _taillePileMateriau;
        }

        public bool VerifierPilePleine()
        {
            if(_cptMateriau == _taillePileMateriau)
            {
                return false;
            }
            return true;
        }

    }
}
