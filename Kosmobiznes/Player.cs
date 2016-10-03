using System.Drawing;

namespace Kosmobiznes
{
    /// <summary>
    /// Stores all relevant information about a player.
    /// </summary>
    class Player
    {
        #region Konstruktor klasy Player
        /// <summary>
        /// Constructor method for Player class.
        /// </summary>
        /// <param name="number">Integer defining the order in which the players move on the board.</param>
        /// <param name="name">String defining the player's name</param>
        /// <param name="color">Defines the color of the player</param>
        public Player(int number, string name, Image logo)
        {
            playerNumber   = number;
            playerCash     = 5000;
            playerPosition = 0;
            playerName     = name;
            playerLogo     = logo;
        }
        #endregion

        #region Deklaracja zmiennych
        /// <summary>The playerName property represents player's name.</summary> 
        /// <value>The playerName property gets/sets the value of the string field, playerName.</value> 
        public string playerName        { get; set; }

        /// <summary>The playerLogo property represents the player's logo.</summary> 
        /// <value>The playerLogo property gets/sets the value of the Image field, playerLogo.</value> 
        public Image  playerLogo       { get; set; }

        /// <summary>The playerNumber property represents the player's number - a different way to refer to a player than <paramref name="playerName"/>.</summary> 
        /// <value>The playerNumber property gets/sets the value of the integer field, playerNumber.</value> 
        public int    playerNumber      { get; set; }

        /// <summary>The playerCash property represents the player's cash amount.</summary> 
        /// <value>The playerCash property gets/sets the value of the integer field, playerCash.</value> 
        public int    playerCash        { get; set; }

        /// <summary>The playerPosition property represents the player's position on the board.</summary> 
        /// <value>The playerPosition property gets/sets the value of the integer field, playerPosition.</value> 
        public int    playerPosition    { get; set; }

        /// <summary>The playerValue property represents the player's company value.</summary> 
        /// <value>The playerValue property gets/sets the value of the integer field, playerValue.</value> 
        public int    playerValue       { get; set; }

        /// <summary>The playerBoardOwned property represents the percent of board a player owns.</summary> 
        /// <value>The playerBoardOwned property gets/sets the value of the float field, playerBoardOwned.</value> 
        public float  playerBoardOwned { get; set; }

        /// <summary>The playerShipsWar property represents the amount of warships a player possesses.</summary> 
        /// <value>The playerShipsWar property gets/sets the value of the integer field, playerShipsWar.</value> 
        public int    playerShipsWar       { get; set; }

        /// <summary>The playerShipsTrade property represents the amount of trade ships a player possesses.</summary> 
        /// <value>The playerShipsTrade property gets/sets the value of the integer field, playerShipsTrade.</value>
        public int    playerShipsTrade { get; set; }

        /// <summary>The playerDust property represents the amount of Space Dust a player possesses.</summary> 
        /// <value>The playerDust property gets/sets the value of the integer field, playerDust.</value> 
        public int    playerDust        { get; set; }

        /// <summary>The playerNectar property represents the amount of Space Nectar a player possesses.</summary> 
        /// <value>The playerNectar property gets/sets the value of the integer field, playerNectar.</value> 
        public int    playerNectar      { get; set; }

        /// <summary>The playerCrystal property represents the amount of Space Crystals a player possesses.</summary> 
        /// <value>The layerpCrystal property gets/sets the value of the integer field, playerCrystal.</value> 
        public int    playerCrystal     { get; set; }
        #endregion
    }
}