using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Gestion_Dechets
{
    class Materiau
    {
        private Materiau _materiauSuivant = null;
        private int typeMateriau;

        public enum Listemateriaux
        {
            COMBUSTIBLES_FOSSILLE = 1,
            METAUX_LOURD = 2,
            PLUTONIUM = 3,
            TERRE_CONTAMINE = 4,
            URANIUM = 5
        }

        public Materiau(int noMatiere)
        {
            typeMateriau = (int)VerifierType(noMatiere);
        }

        private int VerifierType(int noMatiere)
        {
            int type = 1;

            switch (noMatiere)
            {
                case ((int)Listemateriaux.COMBUSTIBLES_FOSSILLE):
                    type = (int)Listemateriaux.COMBUSTIBLES_FOSSILLE;
                    break;
                case ((int)Listemateriaux.METAUX_LOURD):
                    type = (int)Listemateriaux.METAUX_LOURD;
                    break;
                case ((int)Listemateriaux.PLUTONIUM):
                    type = (int)Listemateriaux.PLUTONIUM;
                    break;
                case ((int)Listemateriaux.TERRE_CONTAMINE):
                    type = (int)Listemateriaux.TERRE_CONTAMINE;
                    break;
                case ((int)Listemateriaux.URANIUM):
                    type = (int)Listemateriaux.URANIUM;
                    break;
            }

            return type;
        }

        public Materiau MateriauSuivant
        {
            get { return _materiauSuivant; }
            set { _materiauSuivant = value; }
        }

        public int TypeMateriau
        {
            get { return typeMateriau; }
            set { typeMateriau = value; }
        }


    }
}
