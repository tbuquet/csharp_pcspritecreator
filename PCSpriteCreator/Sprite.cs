using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PCSpriteCreator
{
    /// <summary>
    /// Object embedding all the properties to make a sprite usable by Replica Studio
    /// </summary>
    public class Sprite
    {
        #region Members
        /// <summary>
        /// Dimensions of the sprite animation, private member
        /// </summary>
        private Rectangle rectangle;
        #endregion

        #region Properties
        /// <summary>
        /// Binary representing the sprite
        /// </summary>
        public Image Image
        {
            get;
            set;
        }

        /// <summary>
        /// Name of the sprite
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        //List of sprites associated
        public List<Sprite> Parent
        {
            get;
            set;
        }

        /// <summary>
        /// Dimensions of the sprite animation
        /// </summary>
        public Rectangle Rectangle
        {
            get
            {
                return rectangle;
            }
            set
            {
                rectangle = value;
            }
        }

        /// <summary>
        /// Current X position of the animation
        /// </summary>
        public int X
        {
            get
            {
                return rectangle.X;
            }
        }

        /// <summary>
        /// Current Y position of the animation
        /// </summary>
        public int Y 
        {
            get
            {
                return rectangle.Y;
            }
        }

        /// <summary>
        /// Location of the selected sprite animation
        /// </summary>
        public Point Position
        {
            get
            {
                return rectangle.Location;
            }
        }

        /// <summary>
        /// Width of a sprite animation
        /// </summary>
        public int Width
        {
            get
            {
                return rectangle.Width;
            }
        }

        /// <summary>
        /// Height of a sprite animation
        /// </summary>
        public int Height
        {
            get
            {
                return rectangle.Height;
            }
        }

        /// <summary>
        /// Size of a sprite animation
        /// </summary>
        public Size Size
        {
            get
            {
                return rectangle.Size;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Main constructor
        /// </summary>
        public Sprite()
        {
        }
        #endregion
    }
}
