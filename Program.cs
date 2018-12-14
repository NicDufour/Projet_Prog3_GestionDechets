using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Gestion_Dechets
{
    class Program
    {
        static void Main(string[] args)
        {
            OrganisationCentreTriage Organisation = new OrganisationCentreTriage(10000, 50);
            Organisation.DemarerSimulation();


            Console.ReadKey();
        }
    }
    
}
