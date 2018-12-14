using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projet_Gestion_Dechets.Properties;

namespace Projet_Gestion_Dechets
{
    class CentreTriagePair : CentreTriage
    {

        private bool nbPremier;
        private bool nbDiv5;

        public CentreTriagePair(int idCentreTri) : base(idCentreTri)
        {
            nbPremier = false;
            nbDiv5 = false;
        }

        protected override void ConfigurationMateriauxTraite()
        {
            if(CheckNumber.IsPrime(noCentreTriage))
            {
                //Application propriete d'un centre de tri composé d'un nombre premier.
                nbPremier = true;

                SetCapaciteMax((int)Materiau.Listemateriaux.URANIUM, 857);
                SetCapaciteMax((int)Materiau.Listemateriaux.METAUX_LOURD, 3456);
            }
            if (CheckNumber.isDivibleBy5(noCentreTriage))
            {
                //Application des propriete d'un centre de tri composé d'un multiple de 5.
                nbDiv5 = true;

                SetCapaciteMax((int)Materiau.Listemateriaux.TERRE_CONTAMINE, 457);
                SetCapaciteMax((int)Materiau.Listemateriaux.PLUTONIUM, 1003);
            }
            if (!nbDiv5 && !nbPremier)
            {
                //Centre de tri pair sans condition secondaire
                SetCapaciteMax((int)Materiau.Listemateriaux.URANIUM, 857);
                SetCapaciteMax((int)Materiau.Listemateriaux.METAUX_LOURD, 3456);
                SetCapaciteMax((int)Materiau.Listemateriaux.TERRE_CONTAMINE, 457);
                SetCapaciteMax((int)Materiau.Listemateriaux.PLUTONIUM, 1003);
                SetCapaciteMax((int)Materiau.Listemateriaux.COMBUSTIBLES_FOSSILLE, 639);
            }
        }

    }
}
