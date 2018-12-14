using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Gestion_Dechets
{
    class Cargo : Vaisseau
    {
        public Cargo() : base()
        {
            
            
        }

        protected override void SetCapacite()
        {
            capacite = 367;
        }
    }
}
