using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ReseauNeurone
{
    /// <summary>
    /// Programme développé pour montré l'usage des mathématiques et de méthodes
    /// numériques en intelligence artificielle, plus précisemment en réseaux 
    /// de neurones.
    /// </summary>
    /// <see cref="https://becominghuman.ai/making-a-simple-neural-network-2ea1de81ec20"/>
    class Program
    {
        /// <summary>
        /// Modifie la vitesse à laquelle l'apprentissage se fait. Doit être positif.
        /// </summary>
        private const double TAUX_APPRENTISSAGE = 0.1;

        private static readonly Random Rnd = new Random();

        /// <summary>
        /// Fait l'apprentissage en modifiant p pour atteindre CIBLE.
        /// </summary>
        /// <param name="p">Poids</param>
        private static void Apprendre(ref double[] p)
        {
            Debug.Assert(p.Length == Environnement.NB_BOUTONS);
            
            // 1. Évaluer l'erreur courante :
            double erreur = Environnement.CalculerErreur(p);
            if (erreur != 0)
            {
                // 2. Une copie conforme des poids :
                double[] nouveauxPoids = p.ToArray();

                // 3. Modification d'un poids :
                int indice = Rnd.Next(0, p.Length);
                if (erreur > 0)
                {
                    nouveauxPoids[indice] = p[indice] + TAUX_APPRENTISSAGE;
                    if (nouveauxPoids[indice] > 1)
                    {
                        nouveauxPoids[indice] = 1;
                    }
                }
                else
                {
                    nouveauxPoids[indice] = p[indice] - TAUX_APPRENTISSAGE;
                    if (nouveauxPoids[indice] < 0)
                    {
                        nouveauxPoids[indice] = 0;
                    }
                }

                // 4. Est-ce qu'on diminue l'erreur ?
                var nouvelleErreur = Environnement.CalculerErreur(nouveauxPoids);
                if (Math.Abs(nouvelleErreur) < Math.Abs(erreur))
                {
                    p = nouveauxPoids;
                }
            }
        }

        /// <summary>
        /// Point d'entrée du programme
        /// </summary>
        static void Main()
        {
            Debug.Assert(TAUX_APPRENTISSAGE > 0, "Le taux d'apprentissage doit être > 0");

            double[] poids = new double[] { 0, 0, 0, 0 };
            double erreur = double.MaxValue;

            for (int numEssai = 0; (numEssai < 50) && (erreur != 0); numEssai++)
            {
                Console.WriteLine("### Apprentissage " + numEssai + " ###");

                Apprendre(ref poids);
                Console.WriteLine("[ " + string.Join(", ", poids) + " ]");

                double recompense = Environnement.Recompenser(poids);
                erreur = Environnement.CalculerErreur(poids);

                Console.WriteLine("Récompense : " + recompense);
                Console.WriteLine("Erreur     : " + erreur);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
