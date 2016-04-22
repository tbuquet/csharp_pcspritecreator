using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PCSpriteCreator
{
    /// <summary>
    /// Form that offers a preview of a final animation
    /// </summary>
    public partial class Preview : Form
    {
        #region Members
        /// <summary>
        /// Current animation
        /// </summary>
        public Anim animation;
        #endregion

        #region Properties
        /// <summary>
        /// Selected Sprite
        /// </summary>
        public Sprite SelectedSprite { get; set; }

        /// <summary>
        /// Color of Transparency
        /// </summary>
        public Color TransparentColor { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Main constructor
        /// </summary>
        public Preview()
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>
        /// EventHandler that creates a target during the preview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimPreview_Paint(object sender, PaintEventArgs e)
        {
            if (animation != null)
            {
                int posX = AnimPreview.Width / 2 - animation.MaxSize.Width / 2;
                int posY = AnimPreview.Height / 2 - animation.MaxSize.Height / 2;
                e.Graphics.FillRectangle(Brushes.Black, new Rectangle(posX, posY, 1, animation.MaxSize.Height));
                e.Graphics.FillRectangle(Brushes.Black, new Rectangle(posX + animation.MaxSize.Width, posY, 1, animation.MaxSize.Height));
                e.Graphics.FillRectangle(Brushes.Black, new Rectangle(posX, posY, animation.MaxSize.Width, 1));
                e.Graphics.FillRectangle(Brushes.Black, new Rectangle(posX, posY + animation.MaxSize.Height, animation.MaxSize.Width, 1));
                e.Graphics.FillRectangle(Brushes.Red, new Rectangle(0, AnimPreview.Height / 2, AnimPreview.Width, 1));
                e.Graphics.FillRectangle(Brushes.Red, new Rectangle(AnimPreview.Width / 2, 0, 1, AnimPreview.Height));
            }
        }

        /// <summary>
        /// Event raised during the loading of the form
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            if (SelectedSprite != null)
            {
                Image newImage = new Bitmap(Tools.TransparentBackground);
                Graphics el = Graphics.FromImage(newImage);
                int posX = AnimPreview.Width / 2 - animation.MaxSize.Width / 2;
                int posY = AnimPreview.Height / 2 - animation.MaxSize.Height / 2;
                el.DrawImage(SelectedSprite.Image, new Point(posX + SelectedSprite.Position.X, posY + SelectedSprite.Position.Y));
                if (AnimPreview.Image != null)
                    AnimPreview.Image.Dispose();
                AnimPreview.Image = newImage;
                el.Dispose();
            }
        }
    }
}
