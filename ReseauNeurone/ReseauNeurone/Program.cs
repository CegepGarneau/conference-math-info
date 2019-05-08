using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ReseauNeurone
{
    class Program
    {
        private static readonly double[] RECOMPENSES = new double[] { 0, 0, 5, 12 };

        private const double CIBLE              = 1.1;
        private const double TAUX_APPRENTISSAGE = 0.1;

        private static readonly Random Rnd = new Random();

        /// <summary>
        /// Evalue l'a précision d'un ensemble de poids, en donnant l'erreur par rapport à la cible.
        /// </summary>
        /// <param name="p">Des poids</param>
        /// <returns>Une récompense en fonction des poids donnés dans p</returns>
        private static double Evaluer(double[] p)
        {
            return CalculerErreur(CIBLE, Recompenser(p));
        }

        /// <summary>
        /// Donne une récompense en fonction de poids donnés
        /// </summary>
        /// <param name="p">Des poids</param>
        /// <returns>Une récompense en fonction des poids donnés dans p</returns>
        private static double Recompenser(double[] p)
        {
            Debug.Assert(p.Length == RECOMPENSES.Length);

            double resultat = 0;
            for (int i = 0; i < p.Length; i++)
            {
                resultat += (RECOMPENSES[i] * p[i]);
            }
            return resultat;
        }

        /// <summary>
        /// Calcule l'erreur entre une valeur cible et une valeur réelle
        /// </summary>
        /// <param name="valCible">Valeur à atteindre</param>
        /// <param name="valReelle">Valeur obtenue</param>
        /// <returns>La différence entre valCible et valReelle</returns>
        private static double CalculerErreur(double valCible, double valReelle)
        {
            return (valCible - valReelle);
        }

        /// <summary>
        /// Fait l'apprentissage en modifiant p pour atteindre CIBLE.
        /// </summary>
        /// <param name="p">Poids</param>
        private static void Apprendre(ref double[] p)
        {
            Debug.Assert(p.Length == RECOMPENSES.Length);
            
            double erreur = CalculerErreur(CIBLE, Recompenser(p));
            if (erreur != 0)
            {
                // 2. Une copie conforme des poids
                double[] nouveauxPoids = p.ToArray();

                // 3. Modification d'un poids
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
                var nouvelleErreur = CalculerErreur(CIBLE, Recompenser(nouveauxPoids));
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
            double[] poids = new double[] { 0, 0, 0, 0 };
            double erreur = double.MaxValue;

            for (int nbEssais = 0; (nbEssais < 50) && (erreur != 0); nbEssais++)
            {
                Console.WriteLine("### Apprentissage " + nbEssais + " ###");
                double resultat = Recompenser(poids);
                erreur = CalculerErreur(CIBLE, resultat);

                Console.WriteLine("Résultat avant : " + resultat);
                Console.WriteLine("Erreur   avant : " + erreur);

                Apprendre(ref poids);
                Console.WriteLine("[ " + string.Join(", ", poids) + " ]");

                resultat = Recompenser(poids);
                erreur = CalculerErreur(CIBLE, resultat);

                Console.WriteLine("Résultat après : " + resultat);
                Console.WriteLine("Erreur   après : " + erreur);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
