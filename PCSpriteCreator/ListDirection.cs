using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PCSpriteCreator
{
    /// <summary>
    /// User control that handles a list of sprites
    /// </summary>
    public partial class ListDirection : UserControl
    {
        #region Properties
        /// <summary>
        /// Title
        /// </summary>
        public string Label
        {
            get;
            set;
        }

        /// <summary>
        /// Liste of sprites
        /// </summary>
        public List<Sprite> Sprites
        {
            get;
            set;
        }

        /// <summary>
        /// Current selected sprite
        /// </summary>
        public Sprite SelectedSprite
        {
            get;
            set;
        }

        /// <summary>
        /// Current selected animation
        /// </summary>
        public Anim SelectedAnim
        {
            get;
            set;
        }
        #endregion

        #region Events
        public event EventHandler ItemSelected;
        public event EventHandler ItemDeleted;
        #endregion

        #region Constructors
        /// <summary>
        /// Main constructor
        /// </summary>
        public ListDirection()
        {
            InitializeComponent();
            lblDirection.Text = Label;
            listBox1.DragDrop += new DragEventHandler(listBox1_DragDrop);
            listBox1.DragEnter += new DragEventHandler(listBox1_DragEnter);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Refresh the list
        /// </summary>
        public void RefreshList()
        {
            listBox1.Items.Clear();
            if (Sprites != null)
            {
                foreach (Sprite key in Sprites)
                {
                    listBox1.Items.Add(key.Name);
                }
            }
        }

        /// <summary>
        /// Generate a new name for the sprite
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int GetNameInt(int value)
        {
            int i = value;
            foreach (Sprite sprite in Sprites)
            {
                if (sprite.Name == "Anim " + value)
                {
                    return GetNameInt(value + 1);
                }
            }
            return i;
        }
        #endregion

        #region EventHandlers
        /// <summary>
        /// Event raised during the loading of the form
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            lblDirection.Text = Label;
        }

        /// <summary>
        /// Event handler that changes the icon to copy when drag & dropping a picture file into the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                string ext = Path.GetExtension(file).ToLower();
                if (ext != ".jpg" && ext != ".png")
                    return;
            }
            e.Effect = DragDropEffects.Copy;
        }

        /// <summary>
        /// Event handler that create a new sprite when drag & dropping a picture into the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                Bitmap image = Tools.FromFileThenClose(file);
                Sprite sprite = LoadNewSprite(image, false);

                Color color = Tools.GuessTransparentColor(image);
                for (int i = 0; i < sprite.Width; i++)
                {
                    for (int j = 0; j < sprite.Height; j++)
                    {
                        Color colorPix = image.GetPixel(i, j);
                        if (color == colorPix)
                            image.SetPixel(i, j, Color.Transparent);
                    }
                }
            }
            RefreshList();
        }

        /// <summary>
        /// Event handler that refresh the lists when its enable property changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListDirection_EnabledChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        /// <summary>
        /// Event handler that trigger a ItemSelect event when an item of the list is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                SelectedSprite = Sprites.Find(p => p.Name == (string)listBox1.SelectedItem.ToString());
                if (ItemSelected != null)
                    this.ItemSelected(this, new EventArgs());
            }
        }

        /// <summary>
        /// Event handler that moves a sprite of an animation to the top of the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                int index = listBox1.SelectedIndex;
                if (listBox1.SelectedIndex > 0)
                {
                    string tempItem = (string)listBox1.SelectedItem.ToString();
                    listBox1.Items[index] = listBox1.Items[index - 1];
                    listBox1.Items[index - 1] = tempItem;
                    listBox1.SelectedIndex = index - 1;

                    Sprite tempSprite = Sprites.Find(p => p.Name == tempItem);
                    Sprites[index] = Sprites[index - 1];
                    Sprites[index - 1] = tempSprite;
                }
            }
        }

        /// <summary>
        /// Event handler that moves a sprite of an animation to the bottom of the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                int index = listBox1.SelectedIndex;
                if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
                {
                    string tempItem = (string)listBox1.SelectedItem.ToString();
                    listBox1.Items[index] = listBox1.Items[index + 1];
                    listBox1.Items[index + 1] = tempItem;
                    listBox1.SelectedIndex = index + 1;

                    Sprite tempSprite = Sprites.Find(p => p.Name == tempItem);
                    Sprites[index] = Sprites[index + 1];
                    Sprites[index + 1] = tempSprite;
                }
            }
        }

        /// <summary>
        /// Event handler that triggers when leaving the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListDirection_Leave(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
        }

        /// <summary>
        /// Event handler that triggers when deleting a sprite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(SelectedSprite != null)
            {
                SelectedSprite.Image.Dispose();
                listBox1.Items.Remove(SelectedSprite.Name);
                Sprites.Remove(SelectedSprite);
                SelectedSprite = null;
            }
            if (Sprites.Count > 0)
            {
                listBox1.SelectedIndex = 0;
            }
            listBox1_SelectedIndexChanged(null, new EventArgs());
            if (this.ItemDeleted != null)
                this.ItemDeleted(this, new EventArgs());
            
        }
        #endregion

        /// <summary>
        /// Create a new sprite
        /// </summary>
        /// <param name="image">Picture to be used for the sprite</param>
        /// <param name="load">Not used</param>
        /// <returns>A new sprite object</returns>
        public Sprite LoadNewSprite(Bitmap image, bool load)
        {
            Sprite sprite = new Sprite();
            sprite.Rectangle = new Rectangle(0, 0, image.Width, image.Height);

            int spriteWidth = sprite.Rectangle.Width;
            int spriteHeight = sprite.Rectangle.Height;
            /*if (!load)
            {
                spriteWidth *= 2;
                spriteHeight *= 2;
            }*/

            sprite.Image = image;
            sprite.Name = "Anim " + GetNameInt(0);
            sprite.Parent = Sprites;
            if (SelectedAnim.MaxSize.Width < spriteWidth)
                SelectedAnim.MaxSize = new System.Drawing.Size(spriteWidth, SelectedAnim.MaxSize.Height);
            if (SelectedAnim.MaxSize.Height < spriteHeight)
                SelectedAnim.MaxSize = new System.Drawing.Size(SelectedAnim.MaxSize.Width, spriteHeight);
            Sprites.Add(sprite);

            return sprite;
        }

        /// <summary>
        /// Load a picture in memory and create its Sprite object
        /// </summary>
        /// <param name="image">Bitmap picture</param>
        /// <param name="row">Row setted</param>
        /// <param name="ways">Nbr ways setted</param>
        /// <param name="width">Current width setted</param>
        public void LoadPicture(Bitmap image, int row, int ways, int width)
        {
            int numbRows = image.Width / width;
            int height = image.Height / ways;
            for (int i = 0; i < numbRows; i++)
            {
                Bitmap newSprite = new Bitmap(width, height);
                Graphics e = Graphics.FromImage(newSprite);
                e.DrawImage(image, new Rectangle(0, 0, width, height), new Rectangle(i * width, height * row, width, height), GraphicsUnit.Pixel);
                LoadNewSprite(newSprite, true);
                e.Dispose();
            }
            RefreshList();
        }

        /// <summary>
        /// Get the sprite maximum size
        /// </summary>
        /// <param name="actual">Current size</param>
        /// <returns>Maximum Size</returns>
        public Size GetNewMaxSize(Size actual)
        {
            foreach (Sprite sprite in Sprites)
            {
                int spriteWidth = sprite.Rectangle.Width;
                int spriteHeight = sprite.Rectangle.Height;

                if (SelectedAnim.MaxSize.Width < spriteWidth)
                    actual = new System.Drawing.Size(spriteWidth, SelectedAnim.MaxSize.Height);
                if (SelectedAnim.MaxSize.Height < spriteHeight)
                    actual = new System.Drawing.Size(SelectedAnim.MaxSize.Width, spriteHeight);
            }

            return actual;
        }
    }
}
