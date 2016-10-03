using System;

namespace Kosmobiznes
{
    /// <summary>
    /// Represents a dice.
    /// </summary>
    class Dice
    {
        #region Metoda zwracająca wynik rzutu kostką 'times' razy.
        /// <summary>
        /// Throws a dice t number of times.
        /// </summary>
        /// <param name="t">Defines the number of times a dice will be thrown.</param>
        /// <returns>Returns the outcome of t dice throws.</returns>
        public int[] ThrowDiceXTimes(int t)
        {
            diceThrowSum    = 0;
            diceThrowResult = new int[t];
            random          = new Random();

            for (int i = 0; i < t; i++)
            {
                diceThrowResult[i] = random.Next(1, 7);
                diceThrowSum       = diceThrowSum + diceThrowResult[i];
            }
            return diceThrowResult;
        }
        #endregion

        #region Deklaracja zmiennych
        /// <summary>The diceThrowResult property represents the outcome of throwing a dice a given number of times.</summary> 
        /// <value>The diceThrowResult property gets/sets the value of the integer field, diceThrowResult.</value> 
        public  int[]  diceThrowResult { get; private set; }

        /// <summary>The diceThrowSum property represents the sum of a given number of dice throws.</summary> 
        /// <value>The diceThrowSum property gets/sets the value of the integer field, diceThrowSum.</value> 
        public  int    diceThrowSum    { get; private set; }
        private Random random;
        #endregion
    }
}