using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PCSpriteCreator
{
    /// <summary>
    /// Delivers a few tool functions for loading a picture, and creating a transparency background
    /// </summary>
    public class Tools
    {
        #region Static Properties
        /// <summary>
        /// Transparency brush
        /// </summary>
        public static Brush TransparentBrush { get; set; }

        /// <summary>
        /// Transparent background (saved in memory)
        /// </summary>
        public static Image TransparentBackground { get; set; }
        #endregion

        #region Transparency
        /// <summary>
        /// Create a transparency background
        /// </summary>
        /// <param name="width">Width of the background</param>
        /// <param name="height">Height of the background</param>
        public static void CreateTransparentBackground(int width, int height)
        {
            if (TransparentBrush == null)
                MakeTransparentBlocs(8);

            Image mainBackground = new Bitmap(width, height, Constants.PERF_BITSPERPIXEL);
            Graphics graphic = Graphics.FromImage(mainBackground);
            graphic.FillRectangle(TransparentBrush, new Rectangle(new Point(0, 0), new Size(width, height)));
            graphic.Dispose();

            TransparentBackground = mainBackground;
        }

        /// <summary>
        /// Créer un Brush de transparence
        /// </summary>
        /// <param name="pSize">Taille des blocs</param>
        private static void MakeTransparentBlocs(int size)
        {
            Image mainImage = new Bitmap(size * 2, size * 2, Constants.PERF_BITSPERPIXEL);
            Graphics graphic = Graphics.FromImage(mainImage);
            Image transparentBlock = new Bitmap(size, size, Constants.PERF_BITSPERPIXEL);
            Image transparentBlockAlt = new Bitmap(size, size, Constants.PERF_BITSPERPIXEL);
            Graphics transparentGraphic = Graphics.FromImage(transparentBlock);
            transparentGraphic.FillRectangle(new SolidBrush(Constants.DEFAULT_TRANSPARENT_COLOR_1), new Rectangle(new Point(0, 0), transparentBlock.Size));
            Graphics transparentAltGraphic = Graphics.FromImage(transparentBlockAlt);
            transparentAltGraphic.FillRectangle(new SolidBrush(Constants.DEFAULT_TRANSPARENT_COLOR_2), new Rectangle(new Point(0, 0), transparentBlockAlt.Size));
            graphic.DrawImage(transparentBlock, new Point(0, 0));
            graphic.DrawImage(transparentBlock, new Point(size, size));
            graphic.DrawImage(transparentBlockAlt, new Point(0, size));
            graphic.DrawImage(transparentBlockAlt, new Point(size, 0));
            graphic.Dispose();
            transparentBlock.Dispose();
            transparentBlockAlt.Dispose();
            transparentGraphic.Dispose();
            transparentAltGraphic.Dispose();

            TransparentBrush = new TextureBrush(mainImage);
        }
        #endregion

        /// <summary>
        /// Load a picture in memory
        /// </summary>
        /// <param name="url">Url de l'image</param>
        /// <returns>Picture in memory</returns>
        public static Bitmap FromFileThenClose(string url)
        {
            Image i = Image.FromFile(url);
            Bitmap output = new Bitmap(i);
            i.Dispose();
            return output;
        }

        /// <summary>
        /// Try to guess the transparent color given a Bitmap
        /// </summary>
        /// <param name="bitmap">Picture in memory</param>
        /// <returns>Color to be used for transparency</returns>
        public static Color GuessTransparentColor(Bitmap bitmap)
        {
            Dictionary<Color, int> dict = new Dictionary<Color, int>();
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color colorPix = bitmap.GetPixel(i, j);
                    if (dict.ContainsKey(colorPix))
                    {
                        dict[colorPix] += 1;
                    }
                    else
                    {
                        dict.Add(colorPix, 1);
                    }
                }
            }

            Color transparent = Color.Black;
            int num = 0;
            foreach (Color key in dict.Keys)
            {
                if (dict[key] > num)
                {
                    num = dict[key];
                    transparent = key;
                }
            }

            return transparent;
        }
    }
}
