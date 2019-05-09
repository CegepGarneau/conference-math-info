#region MÉTADONNÉES

// Nom du fichier : FormDetectionContours.cs
// Auteur : Stéphane Lapointe (slapointe)
// Date de création : 2019-04-29
// Date de modification : 2019-05-01

#endregion

#region USING

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Cours_420_216;

#endregion

namespace TP_3_Test
{
    /// <summary></summary>
    public partial class FormDetectionContours : Form
    {
        #region PROPRIÉTÉS ET INDEXEURS

        /// <summary>
        /// Image Source (à gauche dans l'interface).
        /// </summary>
        private BitmapMatricielle ImageSource { get; set; }

        /// <summary>
        /// Image transformée (à droite dans l'interface).
        /// </summary>
        private BitmapMatricielle ImageTransfo { get; set; }

        #endregion

        #region CONSTRUCTEURS

        /// <summary></summary>
        public FormDetectionContours()
        {
            InitializeComponent();
        }

        #endregion

        #region MÉTHODES

        /// <summary></summary>
        private void FormDetectionContour_Load(object sender, EventArgs e)
        {
            // Création des BitmapMatricielle.
            this.ImageSource = new BitmapMatricielle();
            this.ImageTransfo = new BitmapMatricielle();
        }

        /// <summary></summary>
        private void chargerImageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            String cheminFichierImage;
            if (Utilitaire.DemanderSelectionnerFichierImage(out cheminFichierImage))
            {
                // Créer le Bitmap en niveau de gris.
                Bitmap bitmapOriginal = new Bitmap(Image.FromFile(cheminFichierImage));
                Bitmap bitmapNivGris = ConvertirBitmapEnNiveauxDeGris(bitmapOriginal);

                // Configurer l'image source.
                this.ImageSource.ImageBitmap = bitmapNivGris;
                this.pboImageSource.Image = this.ImageSource.ImageBitmap;

                // Configurer l'image transformée.
                ReinitialiserImageTransfo();
            }
        }

        /// <summary></summary>
        private void réinitialiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ImageTransfo.ImageBitmap == null)
                return;
            ReinitialiserImageTransfo();
        }

        /// <summary>
        /// Permet de réinitialiser l'image transformée.
        /// </summary>
        private void ReinitialiserImageTransfo()
        {
            this.ImageTransfo.ImageBitmap = new Bitmap(this.ImageSource.ImageBitmap);
            this.pboImageTransfo.Image = this.ImageTransfo.ImageBitmap;
        }

        /// <summary></summary>
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        /// <summary>
        /// Permet de convertir l'image bitmap en niveaux de gris.
        /// </summary>
        /// <param name="bitmapOriginal">Bitmap original.</param>
        /// <returns>Bitmap en niveau de gris.</returns>
        private Bitmap ConvertirBitmapEnNiveauxDeGris(Bitmap bitmapOriginal)
        {
            Bitmap bitmapNivGris = new Bitmap(bitmapOriginal.Width, bitmapOriginal.Height, PixelFormat.Format24bppRgb);
            Color couleurOriginal;
            int valeurGris;

            for (int i = 0; i < bitmapOriginal.Height; i++)
            {
                for (int j = 0; j < bitmapOriginal.Width; j++)
                {
                    couleurOriginal = bitmapOriginal.GetPixel(j, i);
                    valeurGris = (int) (couleurOriginal.R * 0.299 + couleurOriginal.G * 0.587 +
                                        couleurOriginal.B * 0.114);
                    bitmapNivGris.SetPixel(j, i, Color.FromArgb(valeurGris, valeurGris, valeurGris));
                }
            }

            return bitmapNivGris;
        }

        /// <summary></summary>
        private void DeriveeHorizontaleEnXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ImageTransfo.ImageBitmap == null)
                return;

            // Dérivée horizontale en X (filtre de Sobel).
            int[,] noyau =
            {
                {-1, 0, 1},
                {-2, 0, 2},
                {-1, 0, 1}
            };
            const int facteurNorm = 1;

            ReinitialiserImageTransfo();
            this.ImageTransfo.AppliquerConvolution(noyau, facteurNorm, true, true);
            this.pboImageTransfo.Image = this.ImageTransfo.ImageBitmap;
        }

        /// <summary></summary>
        private void DeriveeVerticaleEnYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ImageTransfo.ImageBitmap == null)
                return;

            // Dérivée verticale en Y (filtre de Sobel).
            int[,] noyau =
            {
                {-1, -2, -1},
                {0,  0,  0},
                {1,  2,  1}
            };
            const int facteurNorm = 1;

            ReinitialiserImageTransfo();
            this.ImageTransfo.AppliquerConvolution(noyau, facteurNorm, true, true);
            this.pboImageTransfo.Image = this.ImageTransfo.ImageBitmap;
        }

        /// <summary></summary>
        private void gradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ImageTransfo.ImageBitmap == null)
                return;

            ReinitialiserImageTransfo();

            // Flou ==> Pré-traitement.
            //int[,] noyau =
            //{
            //    {1, 1, 1},
            //    {1, 1, 1},
            //    {1, 1, 1}
            //};
            //this.ImageTransfo.AppliquerConvolution(noyau, 9, true, false);

            // Noyau pour la dérivée horizontale en X (filtre de Sobel).
            int[,] noyauDeriveeEnX =
            {
                {-1, 0, 1},
                {-2, 0, 2},
                {-1, 0, 1}
            };
            // Noyau pour la dérivée verticale en Y (filtre de Sobel).
            int[,] noyauDeriveeEnY =
            {
                {-1, -2, -1},
                { 0,  0,  0},
                { 1,  2,  1}
            };
            // Matrice pour la dérivée en X.
            int[,] matDeriveeEnX = new int[this.ImageTransfo.Hauteur, this.ImageTransfo.Largeur];
            // Matrice pour la dérivée en Y.
            int[,] matDeriveeEnY = new int[this.ImageTransfo.Hauteur, this.ImageTransfo.Largeur];

            // Calcul des dérivées en X et Y.
            for (int i = 0; i < this.ImageTransfo.Hauteur; i++)
            {
                for (int j = 0; j < this.ImageTransfo.Largeur; j++)
                {
                    // Aucune convolution sur les bords de l'image.
                    if (i > 0 && i < this.ImageTransfo.Hauteur - 1 && j > 0 && j < this.ImageTransfo.Largeur - 1)
                    {
                        // Obtention de la valeur de convolution.
                        matDeriveeEnX[i, j] =
                            BitmapMatricielle.CalculerProdConvolutionSurPixel(this.ImageTransfo, noyauDeriveeEnX, i, j);
                        matDeriveeEnY[i, j] =
                            BitmapMatricielle.CalculerProdConvolutionSurPixel(this.ImageTransfo, noyauDeriveeEnY, i, j);
                    }
                }
            }

            // Matrice pour la norme du gradient.
            int[,] matNormeGradient = new int[this.ImageTransfo.Hauteur, this.ImageTransfo.Largeur];
            for (int i = 0; i < this.ImageTransfo.Hauteur; i++)
            {
                for (int j = 0; j < this.ImageTransfo.Largeur; j++)
                {
                    matNormeGradient[i, j] =
                        (int) Math.Round(Math.Sqrt(Math.Pow(matDeriveeEnX[i, j], 2) +
                                                   Math.Pow(matDeriveeEnY[i, j], 2)));
                }
            }

            // Déterminer la valeur maximale pour la norme.
            int normeMax = 0;
            for (int i = 0; i < this.ImageTransfo.Hauteur; i++)
            {
                for (int j = 0; j < this.ImageTransfo.Largeur; j++)
                {
                    if (matNormeGradient[i, j] > normeMax)
                        normeMax = matNormeGradient[i, j];
                }
            }

            // Normalisation des valeurs des gradients de sorte à avoir valeurs entre 0 et 255.
            float facteurNorm = 255f / normeMax;
            for (int i = 0; i < this.ImageTransfo.Hauteur; i++)
            {
                for (int j = 0; j < this.ImageTransfo.Largeur; j++)
                {
                    matNormeGradient[i, j] = (int) Math.Round(matNormeGradient[i, j] * facteurNorm);
                }
            }

            BitmapMatricielle bmGradient =
                new BitmapMatricielle((short) this.ImageTransfo.Largeur, (short) this.ImageTransfo.Hauteur);
            for (int i = 0; i < bmGradient.Hauteur; i++)
            {
                for (int j = 0; j < bmGradient.Largeur; j++)
                {
                    bmGradient[i, j] = Color.FromArgb(matNormeGradient[i, j], matNormeGradient[i, j],
                        matNormeGradient[i, j]);
                }
            }

            this.pboImageTransfo.Image = bmGradient.ImageBitmap;
        }

        /// <summary></summary>
        private void flouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ImageTransfo.ImageBitmap == null)
                return;

            // Flou.
            int[,] noyau =
            {
                {1, 1, 1},
                {1, 1, 1},
                {1, 1, 1}
            };
            const int facteurNorm = 9;

            ReinitialiserImageTransfo();
            this.ImageTransfo.AppliquerConvolution(noyau, facteurNorm, true, false);
            this.pboImageTransfo.Image = this.ImageTransfo.ImageBitmap;
        }

        /// <summary></summary>
        private void améliorationDeLaNettetéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ImageTransfo.ImageBitmap == null)
                return;

            // Amélioration de la netteté.
            int[,] noyau =
            {
                {0, -1, 0},
                {-1, 5, -1},
                {0, -1, 0}
            };
            const int facteurNorm = 1;

            ReinitialiserImageTransfo();
            this.ImageTransfo.AppliquerConvolution(noyau, facteurNorm, true, false);
            this.pboImageTransfo.Image = this.ImageTransfo.ImageBitmap;
        }

        /// <summary></summary>
        private void repoussageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ImageTransfo.ImageBitmap == null)
                return;

            // Repoussage : Effet d'embossage (relief).
            int[,] noyau =
            {
                {-2, -1, 0},
                {-1, 1, 1},
                {0, 1, 2}
            };
            const int facteurNorm = 1;

            ReinitialiserImageTransfo();
            this.ImageTransfo.AppliquerConvolution(noyau, facteurNorm, true, false);
            this.pboImageTransfo.Image = this.ImageTransfo.ImageBitmap;
        }

        /// <summary></summary>
        private void renforcementDesBordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ImageTransfo.ImageBitmap == null)
                return;

            // Renforcement des bords.
            int[,] noyau =
            {
                {0, 0, 0},
                {-1, 1, 0},
                {0, 0, 0}
            };
            const int facteurNorm = 1;

            ReinitialiserImageTransfo();
            this.ImageTransfo.AppliquerConvolution(noyau, facteurNorm, true, false);
            this.pboImageTransfo.Image = this.ImageTransfo.ImageBitmap;
        }

        /// <summary></summary>
        private void detectionContours1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ImageTransfo.ImageBitmap == null)
                return;

            // Détection des contours 1.

            const int facteurNorm = 1;
            int[,] noyau =
            {
                {0,  1, 0},
                {1, -4, 1},
                {0,  1, 0}
            };

            ReinitialiserImageTransfo();
            this.ImageTransfo.AppliquerConvolution(noyau, facteurNorm, true, false);
            this.pboImageTransfo.Image = this.ImageTransfo.ImageBitmap;
        }

        /// <summary></summary>
        private void detectionContours2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ImageTransfo.ImageBitmap == null)
                return;

            // Détection des contours 2.
            int[,] noyau =
            {
                {1,  1, 1},
                {1, -8, 1},
                {1,  1, 1}
            };

            const int facteurNorm = 1;

            ReinitialiserImageTransfo();
            this.ImageTransfo.AppliquerConvolution(noyau, facteurNorm, true, false);
            this.pboImageTransfo.Image = this.ImageTransfo.ImageBitmap;
        }

        #endregion
    }
}