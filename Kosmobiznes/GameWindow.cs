using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Kosmobiznes
{
    public partial class GameWindow : Form
    {
        #region Konstruktor klasy GameWindow
        public GameWindow()
        {
            InitializeComponent();
            myInitialize();
        }
        #endregion

        #region Metoda malująca na planszy
        private void paintOnBoard(object sender, PaintEventArgs e)
        {
            if (gameStarted)
            {
                gboard.paintFieldAndBasicPreview(sender, e);
                gboard.paintPlayers(sender, e, playerList);
            }
            e.Dispose();
        }
        #endregion

        #region Metoda wykonywana przy zmianie ilości graczy
        private void playerAmountValueChange(object sender, EventArgs e)
        {
            foreach (TextBox item in playerNameTextBoxList)
                item.Enabled = (playerNameTextBoxList.IndexOf(item) < playerAmountNumeric.Value) ? true : false;
            foreach (ComboBox item in playerLogoComboBoxList)
                item.Enabled = (playerLogoComboBoxList.IndexOf(item) < playerAmountNumeric.Value) ? true : false;
        }
        #endregion

        #region Metoda wykonywana po naciśnięciu przycisku 'Start' w zakładce 'Opcje gry'
        private void StartButtonClick(object sender, EventArgs e)
        {
            
            dice = new Dice();
            gameStarted = true;
            currentPlayer = 0;
            for (int i = 0; i < playerAmountNumeric.Value; i++)
            {
                selImage = playerLogoComboBoxList.ElementAt(i).SelectedIndex;
                switch (selImage)
	            {
                    case 0: {playerSelectedImage = gboard.playerlogo_1Label; break;}
                    case 1: {playerSelectedImage = gboard.playerlogo_2Label; break;}
                    case 2: {playerSelectedImage = gboard.playerlogo_3Label; break;}
                    case 3: {playerSelectedImage = gboard.playerlogo_4Label; break;}
                    case 4: {playerSelectedImage = gboard.playerlogo_5Label; break;}
                    case 5: {playerSelectedImage = gboard.playerlogo_6Label; break;}
	            	default: break;
	            }
                playerList.Add(new Player(i, playerNameTextBoxList.ElementAt(i).Text, playerSelectedImage));
                pictureBoxList.ElementAt(i).Image = playerSelectedImage;
            }
            foreach (Control control in tabOptions.Controls)
                control.Enabled = false;
            testCombo.AppendText(string.Format("SelectedItem: {0}\n", winCondition3List.SelectedItem));
            testCombo.AppendText(string.Format("SelectedItem parsed to int: {0}\n", (float.Parse(winCondition3List.SelectedItem.ToString().Replace("%", ""))) / 100));
            
            tabControl.SelectedTab = tabBoard;
            refreshAllLabels();
        }
        #endregion

        #region Metoda wykonywana po naciśnięciu przycisku 'Rzut kostką'
        private void diceThrowButton_Click(object sender, EventArgs e)
        {
            diceThrowButtonPressed = true;
            buttonStateControl();
            dice.ThrowDiceXTimes(howManyDiceThrows);
            diceThrowLabel.Text = "Wynik: ";
            for (int i = 0; i < howManyDiceThrows; i++)
                diceThrowLabel.Text = diceThrowLabel.Text + dice.diceThrowResult[i].ToString() + "  ";
            diceThrowSumLabel.Text = "Suma: " + dice.diceThrowSum;
            lastPosition = playerList.ElementAt(currentPlayer).playerPosition;
            changePlayerPosition();
            playerList.ElementAt(currentPlayer).playerPosition = newPosition;
            gboard.currentlySelected = newPosition;
            gboard.cardList.ElementAt(lastSelected).selected = false;
            gboard.cardList.ElementAt(newPosition).selected = true;
            tabBoard.Invalidate(gboard.cardList.ElementAt(lastPosition).rectangle);
            tabBoard.Invalidate(gboard.cardList.ElementAt(lastSelected).rectangle);
            tabBoard.Invalidate(gboard.cardPreview);
            foreach (var player in playerList)
            {
                tabBoard.Invalidate(gboard.cardList.ElementAt(player.playerPosition).rectangle);
            }
            lastSelected = newPosition;
            testCombo.Text = gboard.cardTxtAndGfx.line.ElementAt(1);
            disablePlayerInteractions();

        }
        #endregion

        #region Metoda zmieniająca aktywnego gracza
        private void changeCurrentPlayer()
        {
            if (currentPlayer < playerAmountNumeric.Value - 1)
                currentPlayer++;
            else
                currentPlayer = 0;
        }
        #endregion

        #region Metoda zmieniająca pole gracza
        private void changePlayerPosition()
        {
            newPosition = playerList.ElementAt(currentPlayer).playerPosition + dice.diceThrowSum;
            if (newPosition > gboard.cardList.Count-3)
                newPosition = newPosition - gboard.cardList.Count+2;
        }
        #endregion

        #region Metoda wykonywana gdy kursor porusza się po planszy
        private void moveOverBoard(object sender, MouseEventArgs e)
        {
            mousePosition = e.Location;
        }
        #endregion

        #region Metoda wykonywana gdy nastąpi kliknięcie myszą na planszy
        private void tabBoard_Click(object sender, EventArgs e)
        {
            if (gameStarted)
            {
                currentlySelected = gboard.cardList.FindIndex(x => x.rectangle.Contains(mousePosition));
                if (currentlySelected != -1)
                {
                    gboard.cardList.ElementAt(lastSelected).selected = false;
                    gboard.currentlySelected = currentlySelected;
                    gboard.cardList.ElementAt(currentlySelected).selected = true;
                    tabBoard.Invalidate(gboard.cardList.ElementAt(lastSelected).rectangle);
                    lastSelected = currentlySelected;
                    
                }
                else if (currentlySelected == -1 && gboard.cardPreview.Contains(mousePosition)) { }
                else
                {
                    gboard.cardList.ElementAt(lastPosition).selected = false;
                    gboard.cardList.ElementAt(lastSelected).selected = false;
                }
                foreach (var player in playerList)
                {
                    tabBoard.Invalidate(gboard.cardList.ElementAt(player.playerPosition).rectangle);
                }
                tabBoard.Invalidate(gboard.cardList.ElementAt(lastSelected).rectangle);
                tabBoard.Invalidate(gboard.cardPreview);
            }
        }
        #endregion

        #region Metoda wykonująca inne niż domyślne operacje inicjalizujące
        private void myInitialize()
        {
            gboard = new Board();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, tabBoard, new object[] { true });
            //Dodanie do list textboxów i comboboxów oraz kolorów
            playerNameTextBoxList.Add(player1Name);
            playerNameTextBoxList.Add(player2Name);
            playerNameTextBoxList.Add(player3Name);
            playerNameTextBoxList.Add(player4Name);
            playerNameTextBoxList.Add(player5Name);
            playerNameTextBoxList.Add(player6Name);
            playerLogoComboBoxList.Add(player1Logo);
            playerLogoComboBoxList.Add(player2Logo);
            playerLogoComboBoxList.Add(player3Logo);
            playerLogoComboBoxList.Add(player4Logo);
            playerLogoComboBoxList.Add(player5Logo);
            playerLogoComboBoxList.Add(player6Logo);
            //Dodanie do list pictureboxów logo playerów
            pictureBoxList.Add(pictureBox1);
            pictureBoxList.Add(pictureBox2);
            pictureBoxList.Add(pictureBox3);
            pictureBoxList.Add(pictureBox4);
            pictureBoxList.Add(pictureBox5);
            pictureBoxList.Add(pictureBox6);
            //Dodanie do list zakłądek playerów
            playerPageList.Add(playerTab1);
            playerPageList.Add(playerTab2);
            playerPageList.Add(playerTab3);
            playerPageList.Add(playerTab4);
            playerPageList.Add(playerTab5);
            playerPageList.Add(playerTab6);
            //Ustawienie domyślnych wartości w ComboBoxach
            winCondition1List.SelectedIndex = 0;
            winCondition2List.SelectedIndex = 0;
            winCondition3List.SelectedIndex = 0;
            #region ComboBox'y wybierania loga dla gracza
            DropDownItem pl1 = new DropDownItem();
            DropDownItem pl2 = new DropDownItem();
            DropDownItem pl3 = new DropDownItem();
            DropDownItem pl4 = new DropDownItem();
            DropDownItem pl5 = new DropDownItem();
            DropDownItem pl6 = new DropDownItem();
            pl1.Image = new Bitmap(gboard.playerlogo_1Label, new Size(20,20));
            pl2.Image = new Bitmap(gboard.playerlogo_2Label, new Size(20,20));
            pl3.Image = new Bitmap(gboard.playerlogo_3Label, new Size(20,20));
            pl4.Image = new Bitmap(gboard.playerlogo_4Label, new Size(20,20));
            pl5.Image = new Bitmap(gboard.playerlogo_5Label, new Size(20,20));
            pl6.Image = new Bitmap(gboard.playerlogo_6Label, new Size(20,20));

            player1Logo.ItemHeight = 20;
            player1Logo.Width = 10;
            player1Logo.DropDownHeight = 500;
            player1Logo.DropDownWidth = 10;
            player1Logo.Size = new Size(45, 10);
            player1Logo.Location = new Point(161, 42);
            player1Logo.Items.Add(pl1);
            player1Logo.Items.Add(pl2);
            player1Logo.Items.Add(pl3);
            player1Logo.Items.Add(pl4);
            player1Logo.Items.Add(pl5);
            player1Logo.Items.Add(pl6);
            player1Logo.SelectedIndex = 0;

            player2Logo.ItemHeight = 20;
            player2Logo.Width = 10;
            player2Logo.DropDownHeight = 500;
            player2Logo.DropDownWidth = 10;
            player2Logo.Size = new Size(45, 10);
            player2Logo.Location = new Point(161, 69);
            player2Logo.Items.Add(pl1);
            player2Logo.Items.Add(pl2);
            player2Logo.Items.Add(pl3);
            player2Logo.Items.Add(pl4);
            player2Logo.Items.Add(pl5);
            player2Logo.Items.Add(pl6);
            player2Logo.SelectedIndex = 1;

            player3Logo.Enabled = false;
            player3Logo.ItemHeight = 20;
            player3Logo.Width = 10;
            player3Logo.DropDownHeight = 500;
            player3Logo.DropDownWidth = 10;
            player3Logo.Size = new Size(45, 10);
            player3Logo.Location = new Point(161, 96);
            player3Logo.Items.Add(pl1);
            player3Logo.Items.Add(pl2);
            player3Logo.Items.Add(pl3);
            player3Logo.Items.Add(pl4);
            player3Logo.Items.Add(pl5);
            player3Logo.Items.Add(pl6);
            player3Logo.SelectedIndex = 2;

            player4Logo.Enabled = false;
            player4Logo.ItemHeight = 20;
            player4Logo.Width = 10;
            player4Logo.DropDownHeight = 500;
            player4Logo.DropDownWidth = 10;
            player4Logo.Size = new Size(45, 10);
            player4Logo.Location = new Point(161, 123);
            player4Logo.Items.Add(pl1);
            player4Logo.Items.Add(pl2);
            player4Logo.Items.Add(pl3);
            player4Logo.Items.Add(pl4);
            player4Logo.Items.Add(pl5);
            player4Logo.Items.Add(pl6);
            player4Logo.SelectedIndex = 3;

            player5Logo.Enabled = false;
            player5Logo.ItemHeight = 20;
            player5Logo.Width = 10;
            player5Logo.DropDownHeight = 500;
            player5Logo.DropDownWidth = 10;
            player5Logo.Size = new Size(45, 10);
            player5Logo.Location = new Point(161, 150);
            player5Logo.Items.Add(pl1);
            player5Logo.Items.Add(pl2);
            player5Logo.Items.Add(pl3);
            player5Logo.Items.Add(pl4);
            player5Logo.Items.Add(pl5);
            player5Logo.Items.Add(pl6);
            player5Logo.SelectedIndex = 4;

            player6Logo.Enabled = false;
            player6Logo.ItemHeight = 20;
            player6Logo.Width = 10;
            player6Logo.DropDownHeight = 500;
            player6Logo.DropDownWidth = 10;
            player6Logo.Size = new Size(45, 10);
            player6Logo.Location = new Point(161, 177);
            player6Logo.Items.Add(pl1);
            player6Logo.Items.Add(pl2);
            player6Logo.Items.Add(pl3);
            player6Logo.Items.Add(pl4);
            player6Logo.Items.Add(pl5);
            player6Logo.Items.Add(pl6);
            player6Logo.SelectedIndex = 5;

            groupBox1.Controls.Add(player1Logo);
            groupBox1.Controls.Add(player2Logo);
            groupBox1.Controls.Add(player3Logo);
            groupBox1.Controls.Add(player4Logo);
            groupBox1.Controls.Add(player5Logo);
            groupBox1.Controls.Add(player6Logo);
            #endregion
        }
        #endregion

        #region Deklaracja zmiennych:
        LogoSelector player1Logo = new LogoSelector();
        LogoSelector player2Logo = new LogoSelector();
        LogoSelector player3Logo = new LogoSelector();
        LogoSelector player4Logo = new LogoSelector();
        LogoSelector player5Logo = new LogoSelector();
        LogoSelector player6Logo = new LogoSelector();
        private Dice             dice;
        private Board            gboard;
        private Point            mousePosition; 
        private List<TextBox>    playerNameTextBoxList   = new List<TextBox>();
        private List<ComboBox>   playerLogoComboBoxList  = new List<ComboBox>();
        private List<Color>      colorList               = new List<Color>();
        private List<Player>     playerList              = new List<Player>();
        private List<PictureBox> pictureBoxList          = new List<PictureBox>();
        private List<TabPage>    playerPageList          = new List<TabPage>();

        private bool           gameStarted             = false;
        private int            currentPlayer           { get; set; }
        private int            howManyDiceThrows       = 2;
        private int            currentlySelected       = 0;
        private int            lastSelected            = 0;
        private int            lastPosition            = 0;
        private int            newPosition             = 0;
        private int            selImage;
        private Image          playerSelectedImage;
        private bool           diceThrowButtonPressed  = false;
        private bool           turnButtonPressed       = false;
        DialogResult           dialogResult;

        #endregion

        #region Akcja na zakończenie tury:
        private void endTurnButton_Click(object sender, EventArgs e)
        {
            turnButtonPressed = true;
            buttonStateControl();
            changeCurrentPlayer();
            playerMenu.SelectedTab = playerPageList.ElementAt(currentPlayer);
        }
        #endregion

        #region Zarządzanie stanem przycisków - ogólne:
        private void buttonStateControl()
        {
            if (diceThrowButtonPressed && !turnButtonPressed)
            {
                diceThrowButton.Enabled = false;
                cardBuyButton.Enabled = true;
                levelUpButton.Enabled = true;
                cannonUpButton.Enabled = true;
                mortgageButton.Enabled = true;
                tradeGoodsButton.Enabled = true;
                tradePlayerButton.Enabled = true;
                endTurnButton.Enabled = true;
                shipMarketButton.Enabled = true;
                diceThrowButtonPressed = false;
            }
            else if (!diceThrowButtonPressed && turnButtonPressed)
            {
                diceThrowButton.Enabled = true;
                cardBuyButton.Enabled = false;
                levelUpButton.Enabled = false;
                cannonUpButton.Enabled = false;
                mortgageButton.Enabled = false;
                tradeGoodsButton.Enabled = false;
                tradePlayerButton.Enabled = false;
                endTurnButton.Enabled = false;
                shipMarketButton.Enabled = false;
                turnButtonPressed = false;
            }
        }

        #endregion

        #region Zarządzanie stanem przycisków - szczegółowe dla aktwynego playera:
        private void disablePlayerInteractions()
        {
                 
            switch (gboard.cardList.ElementAt(newPosition).type)
            {
                //obsługa przycisków jeśli gracz będzie na polu PLANETY
                case (int)(Board.CardType.Planet):
                    {
                        if (gboard.cardList.ElementAt(newPosition).owner!=currentPlayer)
                        {
                            shipMarketButton.Enabled = false;
                            levelUpButton.Enabled = false;
                            if (gboard.cardList.ElementAt(newPosition).owner == -1)
                            {
                                shipMarketButton.Enabled = false;
                                levelUpButton.Enabled = false;
                            }
                            else if (gboard.cardList.ElementAt(newPosition).owner != -1)
                            {
                                cardBuyButton.Enabled = false;
                                levelUpButton.Enabled = false;
                            }
                        }
                        else
                        {
                            cardBuyButton.Enabled = false;
                        }
                        if (playerList.ElementAt(currentPlayer).playerCash < int.Parse(gboard.cardTxtAndGfx.cardTextList.ElementAt(newPosition).cost))
                            cardBuyButton.Enabled = false;
                        break;
                    }
                //obsługa przycisków jeśli gracz będzie na polu SATELITY N
                case (int)(Board.CardType.Satelite_N):
                    {
                        shipMarketButton.Enabled = false;
                        levelUpButton.Enabled = false;
                        if (gboard.cardList.ElementAt(newPosition).owner != -1)
                        {
                            cardBuyButton.Enabled = false;
                        }
                        if (playerList.ElementAt(currentPlayer).playerCash < int.Parse(gboard.cardTxtAndGfx.cardTextList.ElementAt(newPosition).cost))
                            cardBuyButton.Enabled = false;
                        break;
                    }
                //obsługa przycisków jeśli gracz będzie na polu SATELITY T
                case (int)(Board.CardType.Satelite_T):
                    {
                        shipMarketButton.Enabled = false;
                        levelUpButton.Enabled = false;
                        if (gboard.cardList.ElementAt(newPosition).owner != -1)
                        {
                            cardBuyButton.Enabled = false;
                        }
                        if (playerList.ElementAt(currentPlayer).playerCash < int.Parse(gboard.cardTxtAndGfx.cardTextList.ElementAt(newPosition).cost))
                            cardBuyButton.Enabled = false;
                        break;
                    }
                //obsługa przycisków jeśli gracz będzie na polu SATELITY W
                case (int)(Board.CardType.Satelite_W):
                    {
                        shipMarketButton.Enabled = false;
                        levelUpButton.Enabled = false;
                        if (gboard.cardList.ElementAt(newPosition).owner != -1)
                        {
                            cardBuyButton.Enabled = false;
                        }
                        if (playerList.ElementAt(currentPlayer).playerCash < int.Parse(gboard.cardTxtAndGfx.cardTextList.ElementAt(newPosition).cost))
                            cardBuyButton.Enabled = false;
                        break;
                    }

                //obsługa przycisków jeśli gracz będzie na polu:
                case (int)(Board.CardType.GCH):         {cardBuyButton.Enabled = false; shipMarketButton.Enabled = false; levelUpButton.Enabled = false; break; }
                case (int)(Board.CardType.OtherChance): {cardBuyButton.Enabled = false; shipMarketButton.Enabled = false; levelUpButton.Enabled = false; break; }
                case (int)(Board.CardType.Other):       {cardBuyButton.Enabled = false; shipMarketButton.Enabled = false; levelUpButton.Enabled = false; break; }
                case (int)(Board.CardType.Event):       {cardBuyButton.Enabled = false; shipMarketButton.Enabled = false; levelUpButton.Enabled = false; break; }

                default: break;
            }

        }

        #endregion


        private void tabSelecting_Players(object sender, TabControlCancelEventArgs e)
        {
            if (playerMenu.SelectedIndex >= playerAmountNumeric.Value)
            {
                e.Cancel = true;
            }
        }

        private void tabSelecting_Board(object sender, TabControlCancelEventArgs e)
        {
            if (gameStarted == false)
            {
                e.Cancel = true;
            }
        }
        //obsługa przycisku kup kartę
        private void cardBuyButton_Click(object sender, EventArgs e)
        {
            dialogResult = MessageBox.Show("Czy na pewno chcesz to kupić?", "", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                playerList.ElementAt(currentPlayer).playerCash = playerList.ElementAt(currentPlayer).playerCash - int.Parse(gboard.cardTxtAndGfx.cardTextList.ElementAt(newPosition).cost);
                cardBuyButton.Enabled = false;
                gboard.cardList.ElementAt(newPosition).owner = currentPlayer;
                gboard.cardTxtAndGfx.cardTextList.ElementAt(newPosition).ownerName = playerList.ElementAt(currentPlayer).playerName;
                playerList.ElementAt(currentPlayer).playerBoardOwned = playerList.ElementAt(currentPlayer).playerBoardOwned + 1;
                tabBoard.Invalidate(gboard.cardPreview);
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
            refreshAllLabels();





        }
        //łopatologiczne szybsze rozwiązanie
        private void refreshAllLabels()
        {
            //Info o graczach
            if (playerAmountNumeric.Value == 2)
            {
                p1_cash.Text = playerList.ElementAt(0).playerCash.ToString();
                p2_cash.Text = playerList.ElementAt(1).playerCash.ToString();

                p1_NameLabel.Text = playerList.ElementAt(0).playerName.ToString();
                p2_NameLabel.Text = playerList.ElementAt(1).playerName.ToString();

                p1_BoardOwnedLabel.Text = ((int)Math.Round((playerList.ElementAt(0).playerBoardOwned / gboard.buyableCardsCount * 100), 0)).ToString();
                p2_BoardOwnedLabel.Text = ((int)Math.Round((playerList.ElementAt(1).playerBoardOwned / gboard.buyableCardsCount * 100), 0)).ToString();
            }
            else if (playerAmountNumeric.Value == 3)
            {
                p1_cash.Text = playerList.ElementAt(0).playerCash.ToString();
                p2_cash.Text = playerList.ElementAt(1).playerCash.ToString();
                p3_cash.Text = playerList.ElementAt(2).playerCash.ToString();

                p1_NameLabel.Text = playerList.ElementAt(0).playerName.ToString();
                p2_NameLabel.Text = playerList.ElementAt(1).playerName.ToString();
                p3_NameLabel.Text = playerList.ElementAt(2).playerName.ToString();

                p1_BoardOwnedLabel.Text = ((int)Math.Round((playerList.ElementAt(0).playerBoardOwned / gboard.buyableCardsCount * 100), 0)).ToString();
                p2_BoardOwnedLabel.Text = ((int)Math.Round((playerList.ElementAt(1).playerBoardOwned / gboard.buyableCardsCount * 100), 0)).ToString();
                p3_BoardOwnedLabel.Text = ((int)Math.Round((playerList.ElementAt(2).playerBoardOwned / gboard.buyableCardsCount * 100), 0)).ToString();

            }
            else if (playerAmountNumeric.Value == 4)
            {
                
                p1_cash.Text = playerList.ElementAt(0).playerCash.ToString();
                p2_cash.Text = playerList.ElementAt(1).playerCash.ToString();
                p3_cash.Text = playerList.ElementAt(2).playerCash.ToString();
                p4_cash.Text = playerList.ElementAt(3).playerCash.ToString();

                p1_NameLabel.Text = playerList.ElementAt(0).playerName.ToString();
                p2_NameLabel.Text = playerList.ElementAt(1).playerName.ToString();
                p3_NameLabel.Text = playerList.ElementAt(2).playerName.ToString();
                p4_NameLabel.Text = playerList.ElementAt(3).playerName.ToString();

                p1_BoardOwnedLabel.Text = ((int)Math.Round((playerList.ElementAt(0).playerBoardOwned / gboard.buyableCardsCount * 100), 0)).ToString();
                p2_BoardOwnedLabel.Text = ((int)Math.Round((playerList.ElementAt(1).playerBoardOwned / gboard.buyableCardsCount * 100), 0)).ToString();
                p3_BoardOwnedLabel.Text = ((int)Math.Round((playerList.ElementAt(2).playerBoardOwned / gboard.buyableCardsCount * 100), 0)).ToString();
                p4_BoardOwnedLabel.Text = ((int)Math.Round((playerList.ElementAt(3).playerBoardOwned / gboard.buyableCardsCount * 100), 0)).ToString();

            }
            else if (playerAmountNumeric.Value == 5)
            {
                p1_cash.Text = playerList.ElementAt(0).playerCash.ToString();
                p2_cash.Text = playerList.ElementAt(1).playerCash.ToString();
                p3_cash.Text = playerList.ElementAt(2).playerCash.ToString();
                p4_cash.Text = playerList.ElementAt(3).playerCash.ToString();
                p5_cash.Text = playerList.ElementAt(4).playerCash.ToString();

                p1_NameLabel.Text = playerList.ElementAt(0).playerName.ToString();
                p2_NameLabel.Text = playerList.ElementAt(1).playerName.ToString();
                p3_NameLabel.Text = playerList.ElementAt(2).playerName.ToString();
                p4_NameLabel.Text = playerList.ElementAt(3).playerName.ToString();
                p5_NameLabel.Text = playerList.ElementAt(4).playerName.ToString();

                p1_BoardOwnedLabel.Text = ((int)Math.Round((playerList.ElementAt(0).playerBoardOwned / gboard.buyableCardsCount * 100), 0)).ToString();
                p2_BoardOwnedLabel.Text = ((int)Math.Round((playerList.ElementAt(1).playerBoardOwned / gboard.buyableCardsCount * 100), 0)).ToString();
                p3_BoardOwnedLabel.Text = ((int)Math.Round((playerList.ElementAt(2).playerBoardOwned / gboard.buyableCardsCount * 100), 0)).ToString();
                p4_BoardOwnedLabel.Text = ((int)Math.Round((playerList.ElementAt(3).playerBoardOwned / gboard.buyableCardsCount * 100), 0)).ToString();
                p5_BoardOwnedLabel.Text = ((int)Math.Round((playerList.ElementAt(4).playerBoardOwned / gboard.buyableCardsCount * 100), 0)).ToString();

            }
            else if (playerAmountNumeric.Value == 6)
            {
                p1_cash.Text = playerList.ElementAt(0).playerCash.ToString();
                p2_cash.Text = playerList.ElementAt(1).playerCash.ToString();
                p3_cash.Text = playerList.ElementAt(2).playerCash.ToString();
                p4_cash.Text = playerList.ElementAt(3).playerCash.ToString();
                p5_cash.Text = playerList.ElementAt(4).playerCash.ToString();
                p6_cash.Text = playerList.ElementAt(5).playerCash.ToString();

                p1_NameLabel.Text = playerList.ElementAt(0).playerName.ToString();
                p2_NameLabel.Text = playerList.ElementAt(1).playerName.ToString();
                p3_NameLabel.Text = playerList.ElementAt(2).playerName.ToString();
                p4_NameLabel.Text = playerList.ElementAt(3).playerName.ToString();
                p5_NameLabel.Text = playerList.ElementAt(4).playerName.ToString();
                p6_NameLabel.Text = playerList.ElementAt(5).playerName.ToString();

                p1_BoardOwnedLabel.Text = ((int)Math.Round((playerList.ElementAt(0).playerBoardOwned / gboard.buyableCardsCount * 100), 0)).ToString();
                p2_BoardOwnedLabel.Text = ((int)Math.Round((playerList.ElementAt(1).playerBoardOwned / gboard.buyableCardsCount * 100), 0)).ToString();
                p3_BoardOwnedLabel.Text = ((int)Math.Round((playerList.ElementAt(2).playerBoardOwned / gboard.buyableCardsCount * 100), 0)).ToString();
                p4_BoardOwnedLabel.Text = ((int)Math.Round((playerList.ElementAt(3).playerBoardOwned / gboard.buyableCardsCount * 100), 0)).ToString();
                p5_BoardOwnedLabel.Text = ((int)Math.Round((playerList.ElementAt(4).playerBoardOwned / gboard.buyableCardsCount * 100), 0)).ToString();
                p6_BoardOwnedLabel.Text = ((int)Math.Round((playerList.ElementAt(5).playerBoardOwned / gboard.buyableCardsCount * 100), 0)).ToString();
            }

        }

        #region obsługa przycisku KUP STATEK na planecie (do ogarnięcia nowe wyskakujące okno)
        //obsługa przycisku kup statek //pojawia sie nowe okno, gdzei są do wyboru: -kup statek wojskowy -sprzedaj satek wojskowy -kup statek handlowy -sprzedaj satek handlowy

        private void shipMarketButton_Click(object sender, EventArgs e)
        {
            //dialogResult = MessageBox.Show("Witaj w stoczni. Tu możesz wyprodukować statki handlowe. /nCzy chcesz wypr", "", MessageBoxButtons.YesNo);

            //if (dialogResult == DialogResult.Yes)
            //{
            //    playerList.ElementAt(currentPlayer).playerCash = playerList.ElementAt(currentPlayer).playerCash - int.Parse(gboard.cardTxtAndGfx.cardTextList.ElementAt(newPosition).cost);
            //    cardBuyButton.Enabled = false;
            //    gboard.cardList.ElementAt(newPosition).owner = currentPlayer;
            //    gboard.cardTxtAndGfx.cardTextList.ElementAt(newPosition).ownerName = playerList.ElementAt(currentPlayer).playerName;
            //    playerList.ElementAt(currentPlayer).playerBoardOwned = playerList.ElementAt(currentPlayer).playerBoardOwned + 1;
            //    tabBoard.Invalidate(gboard.cardPreview);
            //}
            //else if (dialogResult == DialogResult.No)
            //{

            //}

            //refreshAllLabels();
        }

        #endregion



        #region obsługa przycisku Inwestycji na planecie
        // nowe wartości opłat na planetach
        // cena planety = x
        // koszt inwestycji = 2,5 * x
        // opłata podstawowa = 0,25 * x
        // opłata z 1 inw. = 1 * x
        // opłata z 2 inw. = 2 * x
        // opłata z 3 inw. = 3 * x
        // opłata z 4 inw. = 4 * x
        // opłata z 5 inw. = 5 * x

        private void levelUpButton_Click(object sender, EventArgs e)
        {
            dialogResult = MessageBox.Show("Czy na pewno chcesz zainwestować na tej planecie?", "", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                playerList.ElementAt(currentPlayer).playerCash = (playerList.ElementAt(currentPlayer).playerCash) - int.Parse(gboard.cardTxtAndGfx.cardTextList.ElementAt(newPosition).value2);
                gboard.cardTxtAndGfx.cardTextList.ElementAt(newPosition).level = gboard.cardTxtAndGfx.cardTextList.ElementAt(newPosition).level + 1;
                gboard.cardTxtAndGfx.cardTextList.ElementAt(newPosition).value0 = gboard.cardTxtAndGfx.cardTextList.ElementAt(newPosition).value1;
                int newValue1 = int.Parse(gboard.cardTxtAndGfx.cardTextList.ElementAt(newPosition).value1) + int.Parse(gboard.cardTxtAndGfx.cardTextList.ElementAt(newPosition).cost);
                gboard.cardTxtAndGfx.cardTextList.ElementAt(newPosition).value1 = newValue1.ToString();
                
                levelUpButton.Enabled = false;
                tabBoard.Invalidate(gboard.cardPreview); 
            }

            //  co to jest i co to tu robi????
            //        gboard.cardList.ElementAt(newPosition).owner = currentPlayer;
            //        gboard.cardTxtAndGfx.cardTextList.ElementAt(newPosition).ownerName = playerList.ElementAt(currentPlayer).playerName;
            //        playerList.ElementAt(currentPlayer).playerBoardOwned = playerList.ElementAt(currentPlayer).playerBoardOwned + 1;
            //        tabBoard.Invalidate(gboard.cardPreview);
            //    }
            else if (dialogResult == DialogResult.No)
            {

            }
                refreshAllLabels();
        }
        #endregion



    }
}

// TO DO - zaimplementować dla wszystkich zmiennych które są wpisywane w label'e (przedewszystkim info o playerach)
//int _theVariable;
//public int TheVariable
//{
//    get { return _theVariable; }
//    set
//    {

//        p3_cash.Text = value
//    }
//}