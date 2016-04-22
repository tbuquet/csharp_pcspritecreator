using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace PCSpriteCreator
{
    /// <summary>
    /// Main form
    /// </summary>
    public partial class Main : Form
    {
        #region Members
        /// <summary>
        /// Current path
        /// </summary>
        public string currentPath = string.Empty;

        /// <summary>
        /// Current animation
        /// </summary>
        public Anim animation;

        /// <summary>
        /// Form preview
        /// </summary>
        private Preview preview;

        /// <summary>
        /// Check if a preview is active
        /// </summary>
        private bool inPreview;

        /// <summary>
        /// Frequency Timer
        /// </summary>
        Timer frequencyTimer = null;
        #endregion

        #region Properties
        /// <summary>
        /// Current selected sprite
        /// </summary>
        public Sprite SelectedSprite { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Main constructor
        /// </summary>
        public Main()
        {
            InitializeComponent();
            preview = new Preview();

            rad4Directions.CheckedChanged += new EventHandler(radDirections_CheckedChanged);
            rad8Directions.CheckedChanged += new EventHandler(radDirections_CheckedChanged);
            AnimPreview.Paint += new PaintEventHandler(AnimPreview_Paint);
            listUp.ItemSelected += new EventHandler(list_ItemSelected);
            listUpLeft.ItemSelected += new EventHandler(list_ItemSelected);
            listUpRight.ItemSelected += new EventHandler(list_ItemSelected);
            listDown.ItemSelected += new EventHandler(list_ItemSelected);
            listDownLeft.ItemSelected += new EventHandler(list_ItemSelected);
            listDownRight.ItemSelected += new EventHandler(list_ItemSelected);
            listLeft.ItemSelected += new EventHandler(list_ItemSelected);
            listRight.ItemSelected += new EventHandler(list_ItemSelected);
            listUp.ItemDeleted += new EventHandler(list_ItemDeleted);
            listUpLeft.ItemDeleted += new EventHandler(list_ItemDeleted);
            listUpRight.ItemDeleted += new EventHandler(list_ItemDeleted);
            listDown.ItemDeleted += new EventHandler(list_ItemDeleted);
            listDownLeft.ItemDeleted += new EventHandler(list_ItemDeleted);
            listDownRight.ItemDeleted+= new EventHandler(list_ItemDeleted);
            listLeft.ItemDeleted += new EventHandler(list_ItemDeleted);
            listRight.ItemDeleted += new EventHandler(list_ItemDeleted);

            Tools.CreateTransparentBackground(2048, 2048);

            DeactivateEverything();

            //Timer
            frequencyTimer = new Timer();
            frequencyTimer.Interval = 100;
            frequencyTimer.Tick += new EventHandler(CallBack_Frequency);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Deactivate all controls
        /// </summary>
        private void DeactivateEverything()
        {
            foreach (Control control in this.Controls)
            {
                control.Enabled = false;
            }
            btnLoadAnimation.Enabled = true;
            btnNewAnimation.Enabled = true;
        }

        /// <summary>
        /// Activate all controls
        /// </summary>
        private void ActivateEverything()
        {
            foreach (Control control in this.Controls)
            {
                control.Enabled = true;
            }
            rad4Directions.Checked = true;
        }

        /// <summary>
        /// Refresh a sprite
        /// </summary>
        void RefreshImage()
        {
            if (SelectedSprite != null)
            {
                try
                {
                    Image newImage = new Bitmap(Tools.TransparentBackground);
                    Graphics el = Graphics.FromImage(newImage);

                    int posX = AnimPreview.Width / 2 - animation.MaxSize.Width / 2;
                    int posY = AnimPreview.Height / 2 - animation.MaxSize.Height / 2;
                    el.DrawImage(SelectedSprite.Image, new Point(posX + SelectedSprite.Position.X, posY + SelectedSprite.Position.Y));
                    el.Dispose();
                    if (AnimPreview.Image != null)
                        AnimPreview.Image.Dispose();
                    AnimPreview.Image = newImage;
                }
                catch
                {
                }
            }
        }
        #endregion

        #region EventHandlers
        /// <summary>
        /// Event Handler that reset the lists after deleting an item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void list_ItemDeleted(object sender, EventArgs e)
        {
            animation.MaxSize = new System.Drawing.Size(0, 0);
            animation.MaxSize = listUp.GetNewMaxSize(animation.MaxSize);
            animation.MaxSize = listDown.GetNewMaxSize(animation.MaxSize);
            animation.MaxSize = listLeft.GetNewMaxSize(animation.MaxSize);
            animation.MaxSize = listRight.GetNewMaxSize(animation.MaxSize);
            animation.MaxSize = listUpRight.GetNewMaxSize(animation.MaxSize);
            animation.MaxSize = listUpLeft.GetNewMaxSize(animation.MaxSize);
            animation.MaxSize = listDownRight.GetNewMaxSize(animation.MaxSize);
            animation.MaxSize = listDownLeft.GetNewMaxSize(animation.MaxSize);

            RefreshImage();
        }

        /// <summary>
        /// Event Handler that go on the next sprite after a tick on the timer
        /// </summary>
        /// <param name="e"></param>
        private void CallBack_Frequency(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (animation != null && SelectedSprite != null)
                {
                    if (SelectedSprite.Parent.Count != 0)
                    {
                        RefreshImage();

                        int index = 0;
                        int i = 0;
                        foreach (Sprite sprite in SelectedSprite.Parent)
                        {
                            if (sprite == SelectedSprite)
                            {
                                index = i + 1;
                                i++;
                                break;
                            }
                            i++;
                        }
                        if (i == SelectedSprite.Parent.Count)
                            index = 0;

                        SelectedSprite = SelectedSprite.Parent[index];
                    }
                }
            }
        }

        /// <summary>
        /// Activate/Deactivate the 8 direction lists
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void radDirections_CheckedChanged(object sender, EventArgs e)
        {
            if (rad4Directions.Checked)
            {
                listDownLeft.Enabled = false;
                listDownRight.Enabled = false;
                listUpLeft.Enabled = false;
                listUpRight.Enabled = false;
            }
            else
            {
                listDownLeft.Enabled = true;
                listDownRight.Enabled = true;
                listUpLeft.Enabled = true;
                listUpRight.Enabled = true;
            }
        }

        /// <summary>
        /// Event Handler that initiate a new animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewAnimation_Click(object sender, EventArgs e)
        {
            saveFile.AddExtension = true;
            saveFile.DefaultExt = "png";
            saveFile.Filter = "PNG Files | *.png";
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                currentPath = saveFile.FileName;

                //Traitement du nom du fichier
                string filename = Path.GetFileNameWithoutExtension(currentPath);
                string charName = filename;
                string animName = "standing";
                if (filename.Contains("_"))
                {
                    string[] name = filename.Split("_".ToCharArray());
                    if (name.Length >= 2)
                    {
                        charName = name[0];
                        animName = name[1];
                    }
                }

                animation = new Anim();
                animation.CharacterName = charName;
                animation.AnimName = animName;
                txtCharacterName.Text = animation.CharacterName;
                txtAnimationName.Text = animation.AnimName;
                listDown.Sprites = animation.SpritesDown;
                listDownLeft.Sprites = animation.SpritesDownLeft;
                listDownRight.Sprites = animation.SpritesDownRight;
                listLeft.Sprites = animation.SpritesLeft;
                listRight.Sprites = animation.SpritesRight;
                listUp.Sprites = animation.SpritesUp;
                listUpLeft.Sprites = animation.SpritesUpLeft;
                listUpRight.Sprites = animation.SpritesUpRight;
                listDown.SelectedAnim = animation;
                listDownLeft.SelectedAnim = animation;
                listDownRight.SelectedAnim = animation;
                listLeft.SelectedAnim = animation;
                listRight.SelectedAnim = animation;
                listUp.SelectedAnim = animation;
                listUpLeft.SelectedAnim = animation;
                listUpRight.SelectedAnim = animation;
                SelectedSprite = null;
                listDown.RefreshList();
                listDownLeft.RefreshList();
                listDownRight.RefreshList();
                listLeft.RefreshList();
                listRight.RefreshList();
                listUp.RefreshList();
                listUpLeft.RefreshList();
                listUpRight.RefreshList();
                ActivateEverything();
                AnimPreview.Refresh();
            }
        }

        /// <summary>
        /// Event handler that load an animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadAnimation_Click(object sender, EventArgs e)
        {
            openFile.AddExtension = true;
            openFile.DefaultExt = "png";
            openFile.Filter = "PNG Files | *.png";
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                currentPath = openFile.FileName;

                //Traitement du nom du fichier
                string filename = Path.GetFileNameWithoutExtension(currentPath);
                string charName = filename;
                string animName = "standing";
                int ways = 0;
                int width = 0;
                if (filename.Contains("_"))
                {
                    string[] name = filename.Split("_".ToCharArray());
                    if (name.Length >= 4)
                    {
                        charName = name[0];
                        animName = name[1];
                        ways = Convert.ToInt32(name[2].Replace("ways", string.Empty));
                        width = Convert.ToInt32(name[3].Replace("width", string.Empty));

                        #region Chargement anim
                        animation = new Anim();
                        animation.CharacterName = charName;
                        animation.AnimName = animName;
                        txtCharacterName.Text = animation.CharacterName;
                        txtAnimationName.Text = animation.AnimName;

                        listDown.Sprites = animation.SpritesDown;
                        listDownLeft.Sprites = animation.SpritesDownLeft;
                        listDownRight.Sprites = animation.SpritesDownRight;
                        listLeft.Sprites = animation.SpritesLeft;
                        listRight.Sprites = animation.SpritesRight;
                        listUp.Sprites = animation.SpritesUp;
                        listUpLeft.Sprites = animation.SpritesUpLeft;
                        listUpRight.Sprites = animation.SpritesUpRight;
                        listDown.SelectedAnim = animation;
                        listDownLeft.SelectedAnim = animation;
                        listDownRight.SelectedAnim = animation;
                        listLeft.SelectedAnim = animation;
                        listRight.SelectedAnim = animation;
                        listUp.SelectedAnim = animation;
                        listUpLeft.SelectedAnim = animation;
                        listUpRight.SelectedAnim = animation;
                        SelectedSprite = null;
                        listDown.RefreshList();
                        listDownLeft.RefreshList();
                        listDownRight.RefreshList();
                        listLeft.RefreshList();
                        listRight.RefreshList();
                        listUp.RefreshList();
                        listUpLeft.RefreshList();
                        listUpRight.RefreshList();
                        ActivateEverything();
                        AnimPreview.Refresh();

                        #region Gestion des sprites existants
                        Bitmap image = Tools.FromFileThenClose(currentPath);
                        if (ways == 4)
                        {
                            listUp.LoadPicture(image, 0, ways, width);
                            listRight.LoadPicture(image, 1, ways, width);
                            listDown.LoadPicture(image, 2, ways, width);
                            listLeft.LoadPicture(image, 3, ways, width);
                        }
                        #endregion
                        #endregion

                        ddpWidth.Value = animation.MaxSize.Width;
                        ddpHeight.Value = animation.MaxSize.Height;
                    }
                    else
                    {
                        MessageBox.Show("Le fichier est incompatible ou mal formé.");
                    }
                }
                else
                {
                    MessageBox.Show("Le fichier est incompatible ou mal formé.");
                }
            }
        }

        /// <summary>
        /// Event handler that saves an animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ev"></param>
        private void btnSaveAnimation_Click(object sender, EventArgs ev)
        {
            int maxAnim = 0;
            int direction = 4;
            if (rad8Directions.Checked)
                direction = 8;
            foreach (Control control in this.Controls)
            {
                if (control is ListDirection)
                {
                    ListDirection list = (ListDirection)control;
                    if (maxAnim < list.Sprites.Count)
                        maxAnim = list.Sprites.Count;
                }
            }

            int width = maxAnim * animation.MaxSize.Width;
            int height = direction * animation.MaxSize.Height;

            Image charSet = new Bitmap(width, height);
            Graphics e = Graphics.FromImage(charSet);

            #region Up
            int i = 0;
            int h = 0;
            foreach (Sprite sprite in listUp.Sprites)
            {
                int posX = i * animation.MaxSize.Width;
                int posY = h;
                e.DrawImage(sprite.Image, new Point(posX + sprite.X, posY + sprite.Y));
                i++;
            }
            #endregion

            #region UpRight
            if (direction == 8)
            {
                i = 0;
                h++;
                foreach (Sprite sprite in listUpRight.Sprites)
                {
                    int posX = i * animation.MaxSize.Width;
                    int posY = h * animation.MaxSize.Height;
                    e.DrawImage(sprite.Image, new Point(posX + sprite.X, posY + sprite.Y));
                    i++;
                }
            }
            #endregion

            #region Right
            i = 0;
            h++;
            foreach (Sprite sprite in listRight.Sprites)
            {
                int posX = i * animation.MaxSize.Width;
                int posY = h * animation.MaxSize.Height;
                e.DrawImage(sprite.Image, new Point(posX + sprite.X, posY + sprite.Y));
                i++;
            }
            #endregion

            #region DownRight
            if (direction == 8)
            {
                i = 0;
                h++;
                foreach (Sprite sprite in listDownRight.Sprites)
                {
                    int posX = i * animation.MaxSize.Width;
                    int posY = h * animation.MaxSize.Height;
                    e.DrawImage(sprite.Image, new Point(posX + sprite.X, posY + sprite.Y));
                    i++;
                }
            }
            #endregion

            #region Down
            i = 0;
            h++;
            foreach (Sprite sprite in listDown.Sprites)
            {
                int posX = i * animation.MaxSize.Width;
                int posY = h * animation.MaxSize.Height;
                e.DrawImage(sprite.Image, new Point(posX + sprite.X, posY + sprite.Y));
                i++;
            }
            #endregion

            #region DownLeft
            if (direction == 8)
            {
                i = 0;
                h++;
                foreach (Sprite sprite in listDownLeft.Sprites)
                {
                    int posX = i * animation.MaxSize.Width;
                    int posY = h * animation.MaxSize.Height;
                    e.DrawImage(sprite.Image, new Point(posX + sprite.X, posY + sprite.Y));
                    i++;
                }
            }
            #endregion

            #region Left
            i = 0;
            h++;
            foreach (Sprite sprite in listLeft.Sprites)
            {
                int posX = i * animation.MaxSize.Width;
                int posY = h * animation.MaxSize.Height;
                e.DrawImage(sprite.Image, new Point(posX + sprite.X, posY + sprite.Y));
                i++;
            }
            #endregion

            #region UpLeft
            if (direction == 8)
            {
                i = 0;
                h++;
                foreach (Sprite sprite in listUpLeft.Sprites)
                {
                    int posX = i * animation.MaxSize.Width;
                    int posY = h * animation.MaxSize.Height;
                    e.DrawImage(sprite.Image, new Point(posX + sprite.X, posY + sprite.Y));
                    i++;
                }
            }
            #endregion

            string finalname = Path.GetDirectoryName(currentPath) + "/" + string.Format(animation.Filename, direction, animation.MaxSize.Width);
            charSet.Save(finalname);
            e.Dispose();
        }

        /// <summary>
        /// Event handler when selected an item in one of the lists
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void list_ItemSelected(object sender, EventArgs e)
        {
            ddpPosX.Maximum = animation.MaxSize.Width;
            ddpPosY.Maximum = animation.MaxSize.Height;
            ListDirection list = (ListDirection)sender;
            SelectedSprite = list.SelectedSprite;
            ddpPosX.Value = SelectedSprite.X;
            ddpPosY.Value = SelectedSprite.Y;
            RefreshImage();
            
        }

        /// <summary>
        /// EventHandler that creates a target during the preview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AnimPreview_Paint(object sender, PaintEventArgs e)
        {
            if (animation != null)
            {
                int posX = AnimPreview.Width / 2 - animation.MaxSize.Width / 2;
                int posY = AnimPreview.Height / 2 - animation.MaxSize.Height / 2;
                e.Graphics.FillRectangle(Brushes.Black, new Rectangle(posX, posY, 1, animation.MaxSize.Height));
                e.Graphics.FillRectangle(Brushes.Black, new Rectangle(posX + animation.MaxSize.Width - 1, posY, 1, animation.MaxSize.Height));
                e.Graphics.FillRectangle(Brushes.Black, new Rectangle(posX, posY, animation.MaxSize.Width, 1));
                e.Graphics.FillRectangle(Brushes.Black, new Rectangle(posX, posY + animation.MaxSize.Height - 1, animation.MaxSize.Width, 1));
                e.Graphics.FillRectangle(Brushes.Red, new Rectangle(0, AnimPreview.Height / 2, AnimPreview.Width, 1));
                e.Graphics.FillRectangle(Brushes.Red, new Rectangle(AnimPreview.Width / 2, 0, 1, AnimPreview.Height));
            }
        }

        #region Sprite Position
        /// <summary>
        /// Event handler that moves a sprite to the middle while creating the animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCenter_Click(object sender, EventArgs e)
        {
            int newX = (animation.MaxSize.Width - SelectedSprite.Rectangle.Width) / 2;
            int newY = (animation.MaxSize.Height - SelectedSprite.Rectangle.Height) / 2;

            SelectedSprite.Rectangle = new Rectangle(newX, newY, SelectedSprite.Width, SelectedSprite.Height);

            ddpPosX.Value = SelectedSprite.X;
            ddpPosY.Value = SelectedSprite.Y;
        }

        /// <summary>
        /// Event handler that moves a sprite to the top while creating the animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            int newY = 0;

            SelectedSprite.Rectangle = new Rectangle(SelectedSprite.X, newY, SelectedSprite.Width, SelectedSprite.Height);

            ddpPosX.Value = SelectedSprite.X;
            ddpPosY.Value = SelectedSprite.Y;
        }

        /// <summary>
        /// Event handler that moves a sprite to the bottom while creating the animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            int newY = animation.MaxSize.Height - SelectedSprite.Height;

            SelectedSprite.Rectangle = new Rectangle(SelectedSprite.X, newY, SelectedSprite.Width, SelectedSprite.Height);

            ddpPosX.Value = SelectedSprite.X;
            ddpPosY.Value = SelectedSprite.Y;
        }

        /// <summary>
        /// Event handler that moves a sprite to the left while creating the animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int newX = 0;

            SelectedSprite.Rectangle = new Rectangle(newX, SelectedSprite.Y, SelectedSprite.Width, SelectedSprite.Height);

            ddpPosX.Value = SelectedSprite.X;
            ddpPosY.Value = SelectedSprite.Y;
        }

        /// <summary>
        /// Event handler that moves a sprite to the right while creating the animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRight_Click(object sender, EventArgs e)
        {
            int newX = animation.MaxSize.Width - SelectedSprite.Width;

            SelectedSprite.Rectangle = new Rectangle(newX, SelectedSprite.Y, SelectedSprite.Width, SelectedSprite.Height);

            ddpPosX.Value = SelectedSprite.X;
            ddpPosY.Value = SelectedSprite.Y;
        }

        /// <summary>
        /// Event handler that updates the dimension X of a sprite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddpPosX_ValueChanged(object sender, EventArgs e)
        {
            SelectedSprite.Rectangle = new Rectangle(Convert.ToInt32(ddpPosX.Value), SelectedSprite.Y, SelectedSprite.Width, SelectedSprite.Height);
            RefreshImage();
        }

        /// <summary>
        /// Event handler that updates the dimension X of a sprite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddpPosY_ValueChanged(object sender, EventArgs e)
        {
            SelectedSprite.Rectangle = new Rectangle(SelectedSprite.X, Convert.ToInt32(ddpPosY.Value), SelectedSprite.Width, SelectedSprite.Height);
            RefreshImage();
        }

        /// <summary>
        /// Event handler that updates the width of a sprite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddpWidth_ValueChanged(object sender, EventArgs e)
        {
            animation.MaxSize = new Size((int)ddpWidth.Value, animation.MaxSize.Height);
            RefreshImage();
        }

        /// <summary>
        /// Event handler that updates the height of a sprite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddpHeight_ValueChanged(object sender, EventArgs e)
        {
            animation.MaxSize = new Size(animation.MaxSize.Width, (int)ddpHeight.Value);
            RefreshImage();
        }
        #endregion

        /// <summary>
        /// Handle handler that show a preview of a specific animations by double clicking on it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimPreview_DoubleClick(object sender, EventArgs e)
        {
            preview.animation = animation;
            preview.SelectedSprite = SelectedSprite;
            preview.WindowState = FormWindowState.Maximized;
            preview.ShowDialog();
        }

        /// <summary>
        /// Event handler that updates the character name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCharacterName_TextChanged(object sender, EventArgs e)
        {
            animation.CharacterName = txtCharacterName.Text;
        }

        /// <summary>
        /// Event handler that updates the animation name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAnimationName_TextChanged(object sender, EventArgs e)
        {
            animation.AnimName = txtAnimationName.Text;
        }

        /// <summary>
        /// Event handler that starts an animation by clicking on the preview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (animation != null)
            {
                if (inPreview)
                {
                    btnPreview.Text = "Preview";
                    foreach (Control control in this.Controls)
                    {
                        if (control.Name == "grpRender")
                        {
                            foreach (Control subControl in control.Controls)
                            {
                                subControl.Enabled = true;
                            }
                            continue;
                        }
                        control.Enabled = true;
                    }
                    radDirections_CheckedChanged(null, new EventArgs());
                    inPreview = false;
                    frequencyTimer.Stop();
                }
                else
                {
                    btnPreview.Text = "Stop preview";
                    foreach (Control control in this.Controls)
                    {
                        if (control.Name == "grpRender")
                        {
                            foreach (Control subControl in control.Controls)
                            {
                                subControl.Enabled = false;
                            }
                            continue;
                        }
                        control.Enabled = false;
                    }
                    btnPreview.Enabled = true;
                    inPreview = true;
                    frequencyTimer.Start();
                }
            }
        }
        #endregion
    }
}
