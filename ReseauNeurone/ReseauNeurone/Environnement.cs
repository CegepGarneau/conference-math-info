using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ReseauNeurone
{
    class Environnement
    {
        /// <summary>
        /// Nombre de boutons dans la simulation
        /// </summary>
        public const int NB_BOUTONS = 4;

        /// <summary>
        /// Les récompenses pour chaque bouton
        /// </summary>
        private static readonly double[] RECOMPENSES = new double[NB_BOUTONS] { 0, 0, 1, 1 };

        /// <summary>
        /// La cible à atteindre
        /// </summary>
        private const double CIBLE = 2;

        /// <summary>
        /// Evalue la précision d'un ensemble de poids, en donnant l'erreur
        /// par rapport à la cible.
        /// </summary>
        /// <param name="p">Des poids</param>
        /// <returns>
        /// La distance entre la cible à atteindre et la récompense 
        /// associée à "p".
        /// </returns>
        public static double CalculerErreur(double[] p)
        {
            return CIBLE - Recompenser(p);
        }

        /// <summary>
        /// Donne une récompense en fonction de poids donnés
        /// </summary>
        /// <param name="p">Des poids</param>
        /// <returns>
        /// Une récompense en fonction des poids donnés dans p
        /// </returns>
        public static double Recompenser(double[] p)
        {
            Debug.Assert(p.Length == NB_BOUTONS, "p doit contenir " + NB_BOUTONS + " éléments");

            double resultat = 0;
            for (int i = 0; i < p.Length; i++)
            {
                resultat += (RECOMPENSES[i] * p[i]);
            }
            return resultat;
        }
    }
}
