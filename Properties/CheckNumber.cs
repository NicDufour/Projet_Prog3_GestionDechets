using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Gestion_Dechets.Properties
{
    public static class CheckNumber
    {
        public static bool IsPair(Int32 n)
        {
            return (bool)((n & 1) == 1);//Retourne vrai si impair et faux si
        }

        public static bool IsPrime(int nb)
        {
            if (nb < 0)
                return IsPrime(-nb);
            else if (nb <= 3)
                return true;
            else
            {
                int sqrt_int = (int)Math.Sqrt(nb);
                for (int i = 2; i <= sqrt_int; i++)
                {
                    if (nb % i == 0)
                        return false;
                }

                return true;
            }
        }

        public static bool isDivibleBy5(int nb)
        {
            if (nb != 0 && (nb % 5 == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

