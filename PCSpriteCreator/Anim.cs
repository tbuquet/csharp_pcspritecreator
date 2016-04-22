using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PCSpriteCreator
{
    /// <summary>
    /// Object embedding all the properties to make an animation usable by Replica Studio
    /// </summary>
    public class Anim
    {
        #region Members
        /// <summary>
        /// Name of the character, private member
        /// </summary>
        private string name;

        /// <summary>
        /// Name of the animation, private member
        /// </summary>
        private string anim;
        #endregion

        #region Properties
        /// <summary>
        /// Character Up animation
        /// </summary>
        public List<Sprite> SpritesUp
        {
            get;
            set;
        }

        /// <summary>
        /// Character Down animation
        /// </summary>
        public List<Sprite> SpritesDown
        {
            get;
            set;
        }

        /// <summary>
        /// Character Left animation
        /// </summary>
        public List<Sprite> SpritesLeft
        {
            get;
            set;
        }

        /// <summary>
        /// Character Right animation
        /// </summary>
        public List<Sprite> SpritesRight
        {
            get;
            set;
        }

        /// <summary>
        /// Character Up Left animation
        /// </summary>
        public List<Sprite> SpritesUpLeft
        {
            get;
            set;
        }

        /// <summary>
        /// Character Up Right animation
        /// </summary>
        public List<Sprite> SpritesUpRight
        {
            get;
            set;
        }

        /// <summary>
        /// Character Down Left animation
        /// </summary>
        public List<Sprite> SpritesDownLeft
        {
            get;
            set;
        }

        /// <summary>
        /// Character Down Right animation
        /// </summary>
        public List<Sprite> SpritesDownRight
        {
            get;
            set;
        }

        /// <summary>
        /// Maximum Dimensions of an animation
        /// </summary>
        public Size MaxSize
        {
            get;
            set;
        }

        /// <summary>
        /// Character name
        /// </summary>
        public string CharacterName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// Animation name
        /// </summary>
        public string AnimName
        {
            get
            {
                return anim;
            }
            set
            {
                anim = value;
            }
        }

        /// <summary>
        /// Filename
        /// </summary>
        public string Filename
        {
            get
            {
                return name + "_" + anim + "_{0}ways_{1}width.png";
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Main constructor
        /// </summary>
        public Anim()
        {
            SpritesDown = new List<Sprite>();
            SpritesDownLeft = new List<Sprite>();
            SpritesDownRight = new List<Sprite>();
            SpritesLeft = new List<Sprite>();
            SpritesRight = new List<Sprite>();
            SpritesUp = new List<Sprite>();
            SpritesUpLeft = new List<Sprite>();
            SpritesUpRight = new List<Sprite>();
        }
        #endregion
    }
}
