namespace Kosmobiznes
{
    /// <summary>
    /// Stores text to be shown on a card.
    /// </summary>
    class CardText
    {
        #region Deklaracja zmiennych
        /// <summary>This property represents the title of the card.</summary> 
        /// <value>This property gets/sets the value of the string field, titleleft.</value> 
        public string titleleft       { get; set; }

        /// <summary>This property represents the title of the card.</summary> 
        /// <value>This property gets/sets the value of the string field, titlemiddle.</value> 
        public string titlemiddle     { get; set; }

        /// <summary>This property represents the cost of a card.</summary> 
        /// <value>This property gets/sets the value of the string field, cost.</value> 
        public string cost            { get; set; }

        /// <summary>This property represents the currency of the cost value.</summary> 
        /// <value>This property gets/sets the value of the string field, cost_currency.</value> 
        public string cost_currency   { get; set; }

        /// <summary>This property represents the address of a card.</summary> 
        /// <value>This property gets/sets the value of the string field, address.</value> 
        public string address           { get; set; }

        /// <summary>This property represents a parameter description on a card.</summary> 
        /// <value>This property gets/sets the value of the string field, description0.</value> 
        public string description0    { get; set; }

        /// <summary>This property represents a parameter description on a card.</summary> 
        /// <value>This property gets/sets the value of the string field, description1.</value> 
        public string description1    { get; set; }

        /// <summary>This property represents a parameter description on a card.</summary> 
        /// <value>This property gets/sets the value of the string field, description2.</value> 
        public string description2    { get; set; }

        /// <summary>This property represents a parameter description on a card.</summary> 
        /// <value>This property gets/sets the value of the string field, description3.</value> 
        public string description3    { get; set; }

        /// <summary>This property represents the value of description0.</summary> 
        /// <value>This property gets/sets the value of the string field, value0.</value> 
        public string value0          { get; set; }

        /// <summary>This property represents the currency of description0</summary> 
        /// <value>This property gets/sets the value of the string field, value0_currency.</value> 
        public string value0_currency { get; set; }

        /// <summary>This property represents the value of description1.</summary> 
        /// <value>This property gets/sets the value of the string field, value1.</value> 
        public string value1          { get; set; }

        /// <summary>This property represents the currency of description1.</summary> 
        /// <value>This property gets/sets the value of the string field, value1_currency.</value> 
        public string value1_currency { get; set; }

        /// <summary>This property represents the value of description2.</summary> 
        /// <value>This property gets/sets the value of the string field, value2.</value> 
        public string value2          { get; set; }

        /// <summary>This property represents the currency of description2.</summary> 
        /// <value>This property gets/sets the value of the string field, value2_currency.</value> 
        public string value2_currency { get; set; }

        /// <summary>This property represents the value of description3.</summary> 
        /// <value>This property gets/sets the value of the string field, value3.</value> 
        public string value3          { get; set; }

        /// <summary>This property represents the currency of description3.</summary> 
        /// <value>This property gets/sets the value of the string field, value3_currency.</value> 
        public string value3_currency { get; set; }

        /// <summary>This property represents a resource descritpion on a card.</summary> 
        /// <value>This property gets/sets the value of the string field, resource0.</value> 
        public string resource0       { get; set; }

        /// <summary>This property represents a resource descritpion on a card.</summary> 
        /// <value>This property gets/sets the value of the string field, resource1.</value> 
        public string resource1       { get; set; }

        /// <summary>This property represents a resource descritpion on a card.</summary> 
        /// <value>This property gets/sets the value of the string field, resource2.</value> 
        public string resource2       { get; set; }

        /// <summary>This property represents the price of resource0.</summary> 
        /// <value>This property gets/sets the value of the string field, price0.</value> 
        public string price0          { get; set; }

        /// <summary>This property represents the currency of resource0.</summary> 
        /// <value>This property gets/sets the value of the string field, price0_currency.</value> 
        public string price0_currency { get; set; }

        /// <summary>This property represents the price of resource1.</summary> 
        /// <value>This property gets/sets the value of the string field, price1.</value> 
        public string price1          { get; set; }

        /// <summary>This property represents the currency of resource1.</summary> 
        /// <value>This property gets/sets the value of the string field, price1_currency.</value> 
        public string price1_currency { get; set; }

        /// <summary>This property represents the price of resource2.</summary> 
        /// <value>This property gets/sets the value of the string field, price2.</value> 
        public string price2          { get; set; }

        /// <summary>This property represents the currency of resource2.</summary> 
        /// <value>This property gets/sets the value of the string field, price2_currency.</value> 
        public string price2_currency { get; set; }

        /// <summary>This property represents the reputation label on a card.</summary> 
        /// <value>This property gets/sets the value of the string field, reputation.</value> 
        public string reputation      { get; set; }

        /// <summary>This property represents the first reputation owner on a card.</summary> 
        /// <value>This property gets/sets the value of the string field, replogo0.</value> 
        public string replogo0        { get; set; }

        /// <summary>This property represents the second reputation owner on a card.</summary> 
        /// <value>This property gets/sets the value of the string field, replogo1.</value> 
        public string replogo1        { get; set; }

        /// <summary>This property represents the third reputation owner on a card.</summary> 
        /// <value>This property gets/sets the value of the string field, replogo2.</value> 
        public string replogo2        { get; set; }

        /// <summary>This property represents the name of the owner of a card.</summary> 
        /// <value>This property gets/sets the value of the string field, playerName.</value> 
        public string ownerName      { get; set; }

        /// <summary>This property represents the level of the card.</summary> 
        /// <value>This property gets/sets the value of the string field, level.</value> 
        public string level           { get; set; }

        /// <summary>This property represents level of canon defence of a card.</summary> 
        /// <value>This property gets/sets the value of the string field, canonLevel.</value> 
        public string canonLevel      { get; set; }

        /// <summary>This property represents the chance description of a card.</summary> 
        /// <value>This property gets/sets the value of the string field, chancetextit.</value> 
        public string chancetextit    { get; set; }

        /// <summary>This property represents the chance description of a card.</summary> 
        /// <value>This property gets/sets the value of the string field, chancetext.</value> 
        public string chancetext      { get; set; }

        /// <summary>This property represents the text of an interactive label on the bottom of a card.</summary> 
        /// <value>This property gets/sets the value of the string field, dicetext.</value> 
        public string dicetext        { get; set; } 
        #endregion
    }
}