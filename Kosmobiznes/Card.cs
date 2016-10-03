using System.Drawing;

namespace Kosmobiznes
{
    /// <summary>
    /// Stores information about positions and sizes of a card and it's preview, aswell as some other basic parameters.
    /// </summary>
    class Card
    {
        #region Konstruktor klasy Card
        /// <summary>
        /// Constructor method of Card class.
        /// </summary>
        /// <param name="begin">Defines the upper left corner of where the card is on the board.</param>
        /// <param name="sector">Defines which sector the card belongs to.</param>
        /// <param name="last">Defines whether the card is last in it's sector.</param>
        /// <param name="image">Defines the image linked to this card.</param>
        public Card(Point begin, int sector, bool last, Image image)
        {
            this.selected = false;
            this.begin    = begin;
            this.sector   = sector;
            this.last     = last;
            this.image    = image;
            begin2        = new Point(begin.X + 1, begin.Y + 1);
            if (sector == 1 || sector == 3 || sector == 5)
            {
                height = 100;
                width  = (!last) ? 57 : 82;
            }
            else if (sector == 2 || sector == 4)
            {
                width  = 100;
                height = (!last) ? 57 : 82;
            }
            size          = new Size(width, height);
            rectangle     = new Rectangle(begin, size);
            sizeFill      = new Size(width - 1, height - 1);
            rectangleFill = new Rectangle(begin2, sizeFill);
        }
        #endregion

        #region Deklaracja zmiennych
        /// <summary>Contains the Image object for this class.</summary> 
        /// <value>Gets the value of the Image field, image.</value>
        public Image      image;

        /// <summary>Contains the Rectangle of a board field for this card.</summary> 
        /// <value>This property gets/sets the value of the Rectangle field, rectangle.</value>
        public Rectangle  rectangle     { get; private set; }

        /// <summary>Contains the Rectangle to be filled when the card is selected.</summary> 
        /// <value>This property gets/sets the value of the Rectangle field, rectangleFill.</value>
        public Rectangle  rectangleFill { get; private set; }

        /// <summary>Contains the Size of the rectangle of a board field for this card.</summary> 
        /// <value>This property gets/sets the value of the Size field, size.</value>
        public Size       size          { get; private set; }

        /// <summary>Contains the Size of the rectangle to be filled when the card is selected.</summary> 
        /// <value>This property gets/sets the value of the Size field, sizeFill.</value>
        public Size       sizeFill      { get; private set; }

        /// <summary>Contains the starting Point of the card field on the board.</summary> 
        /// <value>This property gets/sets the value of the Point field, begin.</value>
        public Point      begin         { get; private set; }

        /// <summary>Contains the starting Point of a Rectangle to be filled for the card if it's selected.</summary> 
        /// <value>This property gets/sets the value of the Point field, begin2.</value>
        public Point      begin2        { get; private set; }

        /// <summary>Contains the height of the card's field on the board</summary> 
        /// <value>This property gets/sets the value of the integer field, height.</value>
        public int        height        { get; private set; }

        /// <summary>Contains the width of the card's field on the board</summary> 
        /// <value>This property gets/sets the value of the integer field, width.</value>
        public int        width         { get; private set; }

        /// <summary>Contains a number defining the player owning this card.</summary> 
        /// <value>The playerColor property gets/sets the value of the integer field, owner.</value>
        public int        owner         { get; set; }

        /// <summary>Contains the number of cannons located on this card.</summary> 
        /// <value>This property gets/sets the value of the integer field, cannons.</value>
        public int        cannons       { get; set; }

        /// <summary>Contains the number representing the level of this card.</summary> 
        /// <value>This property gets/sets the value of the integer field, level.</value>
        public int        level         { get; set; }

        /// <summary>Contains a number representing the sector of the board this card belongs to.</summary> 
        /// <value>This property gets/sets the value of the integer field, sector.</value>
        public int        sector        { get; private set; }

        /// <summary>Contains a boolean value defining whether this card is last in the sector.</summary> 
        /// <value>This property gets/sets the value of the bool field, last.</value>
        public bool       last          { get; private set; }

        /// <summary>Contains a boolean value defining whether the card is currently selected.</summary> 
        /// <value>This property gets/sets the value of the bool field, selected.</value>
        public bool       selected      { get; set; }

        /// <summary>Defines which size of a cover graphic this card will use.</summary> 
        /// <value>This property gets/sets the value of the integer field, largeCover.</value>
        public int        largeCover    { get; set; }

        /// <summary>Defines the type of this card.</summary> 
        /// <value>This property gets/sets the value of the integer field, type.</value>
        public int        type          { get; set; }
        #endregion
    }
}