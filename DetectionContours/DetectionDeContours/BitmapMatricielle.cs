#region MÉTADONNÉES

// Nom du fichier : BitmapMatricielle.cs
// Auteur : Stéphane Lapointe (slapointe)
// Date de création : 2019-04-29
// Date de modification : 2019-05-01

#endregion

#region USING

using System;
using System.Drawing;
using System.Drawing.Imaging;

#endregion

namespace Cours_420_216
{
    /// <summary>
    /// Classe représentant une image bitmap et permettant la manipulation de ses pixels avec la
    /// notation matricielle.
    /// </summary>
    public class BitmapMatricielle
    {
        #region ATTRIBUTS

        /// <summary>
        /// Image bitmap que représente l'objet.
        /// </summary>
        private Bitmap _imageBitmap;

        #endregion

        #region PROPRIÉTÉS ET INDEXEURS

        /// <summary>
        /// Image bitmap que représente l'objet.
        /// </summary>
        public Bitmap ImageBitmap
        {
            get { return this._imageBitmap; }
            set { this._imageBitmap = value; }
        }

        /// <summary>
        /// Hauteur de l'image.
        /// </summary>
        public int Hauteur
        {
            get { return this._imageBitmap.Height; }
        }

        /// <summary>
        /// Largeur de l'image.
        /// </summary>
        public int Largeur
        {
            get { return this._imageBitmap.Width; }
        }

        /// <summary>
        /// Indexeur qui permet d'accéder au pixel sur la ligne i et la colonne j.
        /// </summary>
        /// <param name="i">Numéro de ligne du pixel (en base 0).</param>
        /// <param name="j">Numéro de colonne du pixel (en base 0).</param>
        /// <returns>La couleur du pixel à la position [i,j].</returns>
        public Color this[int i, int j]
        {
            get
            {
                if (this.ImageBitmap == null)
                    throw new NullReferenceException(
                        "L'image bitmap associée à l'image matricielle ne doit pas être nulle.");

                if (i < 0 || i >= this.Hauteur)
                    throw new IndexOutOfRangeException("Le premier indice (i) n'est pas valide.");

                if (j < 0 || j >= this.Largeur)
                    throw new IndexOutOfRangeException("Le deuxième indice (j) n'est pas valide.");

                return this.ImageBitmap.GetPixel(j, i);
            }
            set
            {
                if (this.ImageBitmap == null)
                    throw new NullReferenceException(
                        "L'image bitmap associée à l'image matricielle ne doit pas être nulle.");

                if (i < 0 || i >= this.Hauteur)
                    throw new IndexOutOfRangeException("Le premier indice (i) n'est pas valide.");

                if (j < 0 || j >= this.Largeur)
                    throw new IndexOutOfRangeException("Le deuxième indice (j) n'est pas valide.");

                this.ImageBitmap.SetPixel(j, i, value);
            }
        }

        #endregion

        #region CONSTRUCTEURS

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public BitmapMatricielle()
        {
            this.ImageBitmap = null;
        }

        /// <summary>
        /// Constructeur qui initialise l'objet avec l'image bitmap reçu en paramètre.
        /// </summary>
        /// <param name="imageBitmap">Bitmap que représente l'objet.</param>
        public BitmapMatricielle(Bitmap imageBitmap)
        {
            this.ImageBitmap = imageBitmap;
        }

        /// <summary>
        /// Constructeur qui initialise l'objet avec un bitmap vide de la dimension spécifiée.
        /// </summary>
        /// <param name="largeur">Largeur de l'image.</param>
        /// <param name="hauteur">Hauteur de l'image.</param>
        public BitmapMatricielle(short largeur, short hauteur)
        {
            this.ImageBitmap = new Bitmap(largeur, hauteur, PixelFormat.Format24bppRgb);
            //this.ImageBitmap = new Bitmap(largeur, hauteur, PixelFormat.Format16bppGrayScale);
        }

        #endregion

        #region MÉTHODES

        /// <summary>
        /// Permet de calculer le produit de convolution sur le pixel à la ligne i et colonne j.
        /// </summary>
        /// <param name="bm">BitmapMatricielle.</param>
        /// <param name="noyau">Noyau de convolution 3x3.</param>
        /// <param name="i">Ligne du pixel dans l'image.</param>
        /// <param name="j">Colonne du pixel dans l'image.</param>
        /// <returns>La valeur correspondant au produit de convolution.</returns>
        public static int CalculerProdConvolutionSurPixel(BitmapMatricielle bm, int[,] noyau, int i, int j)
        {
            int valeurConv = 0;
            for (int iOffset = -1; iOffset <= 1; iOffset++)
            {
                for (int jOffset = -1; jOffset <= 1; jOffset++)
                {
                    int vc = noyau[iOffset + 1, jOffset + 1];
                    valeurConv += vc * bm[i + iOffset, j + jOffset].R;
                }
            }

            return valeurConv;
        }

        /// <summary>
        /// Permet d'appliquer une convolution à l'image selon un certain noyau.
        /// </summary>
        /// <param name="noyau">Noyau de convolution.</param>
        /// <param name="facteurNorm">Facteur de normalisation.</param>
        /// <param name="modifierImage">Indique si l'image BitmapMatricielle doit être modifié (true)
        /// ou bien retournée (false).</param>
        /// <param name="valeurAbsolue">Indique si on doit prendre la valeur absolue (true)
        /// de la valeur de convolution ou non (false).</param>
        public BitmapMatricielle AppliquerConvolution(int[,] noyau, int facteurNorm, bool modifierImage, bool valeurAbsolue)
        {
            BitmapMatricielle imageTransfo = new BitmapMatricielle((short) this.Largeur, (short) this.Hauteur);

            for (int i = 0; i < this.Hauteur; i++)
            {
                for (int j = 0; j < this.Largeur; j++)
                {
                    // Aucune convolution sur les bords de l'image.
                    if (i > 0 && i < this.Hauteur - 1 && j > 0 && j < this.Largeur - 1)
                    {
                        // Obtention de la valeur de convolution.
                        int valeurConv = BitmapMatricielle.CalculerProdConvolutionSurPixel(this, noyau, i, j);
                        // Normalisation.
                        valeurConv = valeurConv / facteurNorm;
                        // Filtrage.
                        int nivGris;
                        if (valeurAbsolue)
                            nivGris = Math.Min(255, Math.Abs(valeurConv));
                        else
                            nivGris = Math.Max(0, Math.Min(255, valeurConv));
                        // Création du pixel dans l'image transformée.
                        imageTransfo[i, j] = Color.FromArgb(nivGris, nivGris, nivGris);
                    }
                }
            }

            if (modifierImage)
            {
                // Modification du bitmap de l'image transformée.
                this.ImageBitmap = imageTransfo.ImageBitmap;
                return null;
            }
            else
            {
                return imageTransfo;
            }
        }

        #endregion
    }
}