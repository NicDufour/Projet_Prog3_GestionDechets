using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Gestion_Dechets
{
    class Leger : Vaisseau
    {
        public Leger() : base()
        {
            
        }

        protected override void SetCapacite()
        {
            capacite = 367;
        }
    }
}
