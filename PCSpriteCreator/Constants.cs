using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;

namespace PCSpriteCreator
{
    /// <summary>
    /// Constants for the project
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Image format
        /// </summary>
        public const PixelFormat PERF_BITSPERPIXEL = PixelFormat.Format32bppArgb;

        /// <summary>
        /// Transparency color 1
        /// </summary>
        public static Color DEFAULT_TRANSPARENT_COLOR_1 = Color.White;

        /// <summary>
        /// Transparency color 2
        /// </summary>
        public static Color DEFAULT_TRANSPARENT_COLOR_2 = Color.Gray;
    }
}
