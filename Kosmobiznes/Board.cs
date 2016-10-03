using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using System;
using System.Reflection;

namespace Kosmobiznes
{
    class Board: IDisposable
    {
        #region Konstruktor klasy Board
        public Board()
        {
            stringFormatRight.LineAlignment = StringAlignment.Center;
            stringFormatRight.Alignment = StringAlignment.Far;
            stringFormatLeft.LineAlignment = StringAlignment.Center;
            stringFormatLeft.Alignment = StringAlignment.Near;
            stringFormatCenter.LineAlignment = StringAlignment.Center;
            stringFormatCenter.Alignment = StringAlignment.Center;
            cardPreview = new Rectangle(cardPreviewBegin, cardPreviewSize);
            cardCover1  = new Rectangle(cardPreviewBegin.X + 27, cardPreviewBegin.Y + 81, cardCoverSize1.Width, cardCoverSize1.Height);
            cardCover2  = new Rectangle(cardPreviewBegin.X+2, cardPreviewBegin.Y+61, cardCoverSize2.Width, cardCoverSize2.Height);
            cardCover3  = new Rectangle(cardPreviewBegin.X + 27, cardPreviewBegin.Y + 61, cardCoverSize1.Width, cardCoverSize1.Height);

            #region Tworzenie cardList

            #region Grupa żółta
            for (int i = 0; i < cardsInGroup; i++)
            {
                last = (i != cardsInGroup - 1) ? false : true;
                cardList.Add(new Card(new Point(i * width13 + width24, xybegin), (int)Sector.Yellow, last, cardTxtAndGfx.cardTemplateList.ElementAt(number)));
                number++;
            }
            #endregion

            #region Grupa zielona
            for (int i = 0; i < cardsInGroup; i++)
            {
                last = (i != cardsInGroup-1) ? false : true;
                cardList.Add(new Card(new Point(xyend - width24, i * height24 + height13), (int)Sector.Green, last, cardTxtAndGfx.cardTemplateList.ElementAt(number)));
                number++;
            }
            #endregion

            #region Grupa niebieska
            for (int i = 0; i < cardsInGroup; i++)
            {
                last = (i != cardsInGroup - 1) ? false : true;
                int z = (i != cardsInGroup - 1) ? width13 : width13l;
                cardList.Add(new Card(new Point(xyend - width24 - z - i * width13, xyend - height13), (int)Sector.Blue, last, cardTxtAndGfx.cardTemplateList.ElementAt(number)));
                number++;
            }
            #endregion

            #region Grupa czerwona
            for (int i = 0; i < cardsInGroup; i++)
            {
                last = (i != cardsInGroup - 1) ? false : true;
                int z = (i != cardsInGroup - 1) ? height24 : height24l;
                cardList.Add(new Card(new Point(xybegin, xyend - height13 - z - i * height24), (int)Sector.Red, last, cardTxtAndGfx.cardTemplateList.ElementAt(number)));
                number++;
            }
            #endregion

            #region Grupa czarna
            cardList.Add(new Card(new Point(110, 770), (int)Sector.Black, false, cardTxtAndGfx.cardTemplateList.ElementAt(60)));
            cardList.Add(new Card(new Point(167, 770), (int)Sector.Black, false, cardTxtAndGfx.cardTemplateList.ElementAt(61)));
            #endregion

            #endregion

            //przypisanie braku ownera do każdej karty
            //gittest
            for (int i = 0; i < cardList.Count; i++)
            {
                cardList.ElementAt(i).owner = -1;
            }


            #region Deklaracja wielkości grafiki kart preview
            for (int i = 0; i < cardList.Count; i++)
            {
                switch (i)
                {
                    case 0: case 4: case 8: case 9: case 10: case 18: case 20: case 21: case 25: case 26: case 28: case 36: case 37: case 41: case 42: case 51: case 52: case 53: case 56: case 58: case 60: case 61:
                             { cardList.ElementAt(i).largeCover = 2; break; } //szerokie
                    case 14: case 29: case 44: case 59:
                             { cardList.ElementAt(i).largeCover = 3; break; } //gch
                    default: { cardList.ElementAt(i).largeCover = 1; break; } //wąskie
                }
             
            }
            #endregion

            #region Przypisanie typu karty do włściwej karty z CardList

            cardList.ElementAt (0).type = (int)CardType.Other;
            cardList.ElementAt (1).type = (int)CardType.Planet;
            cardList.ElementAt (2).type = (int)CardType.Planet;
            cardList.ElementAt (3).type = (int)CardType.Satelite_W;
            cardList.ElementAt (4).type = (int)CardType.Other;
            cardList.ElementAt (5).type = (int)CardType.Planet;
            cardList.ElementAt (6).type = (int)CardType.Planet;
            cardList.ElementAt (7).type = (int)CardType.Satelite_T;
            cardList.ElementAt (8).type = (int)CardType.OtherChance;
            cardList.ElementAt (9).type = (int)CardType.Other;
            cardList.ElementAt(10).type = (int)CardType.Event;
            cardList.ElementAt(11).type = (int)CardType.Planet;
            cardList.ElementAt(12).type = (int)CardType.Planet;
            cardList.ElementAt(13).type = (int)CardType.Satelite_N;
            cardList.ElementAt(14).type = (int)CardType.GCH;
            cardList.ElementAt(15).type = (int)CardType.Planet;
            cardList.ElementAt(16).type = (int)CardType.Planet;
            cardList.ElementAt(17).type = (int)CardType.Planet;
            cardList.ElementAt(18).type = (int)CardType.Other;
            cardList.ElementAt(19).type = (int)CardType.Satelite_T;
            cardList.ElementAt(20).type = (int)CardType.OtherChance;
            cardList.ElementAt(21).type = (int)CardType.OtherChance;
            cardList.ElementAt(22).type = (int)CardType.Planet;
            cardList.ElementAt(23).type = (int)CardType.Planet;
            cardList.ElementAt(24).type = (int)CardType.Planet;
            cardList.ElementAt(25).type = (int)CardType.Other;
            cardList.ElementAt(26).type = (int)CardType.Event;
            cardList.ElementAt(27).type = (int)CardType.Satelite_W;
            cardList.ElementAt(28).type = (int)CardType.OtherChance;
            cardList.ElementAt(29).type = (int)CardType.GCH;
            cardList.ElementAt(30).type = (int)CardType.Satelite_N;
            cardList.ElementAt(31).type = (int)CardType.Planet;
            cardList.ElementAt(32).type = (int)CardType.Planet;
            cardList.ElementAt(33).type = (int)CardType.Planet;
            cardList.ElementAt(34).type = (int)CardType.Satelite_W;
            cardList.ElementAt(35).type = (int)CardType.Satelite_T;
            cardList.ElementAt(36).type = (int)CardType.OtherChance;
            cardList.ElementAt(37).type = (int)CardType.OtherChance;
            cardList.ElementAt(38).type = (int)CardType.Planet;
            cardList.ElementAt(39).type = (int)CardType.Planet;
            cardList.ElementAt(40).type = (int)CardType.Planet;
            cardList.ElementAt(41).type = (int)CardType.Other;
            cardList.ElementAt(42).type = (int)CardType.Event;
            cardList.ElementAt(43).type = (int)CardType.Satelite_W;
            cardList.ElementAt(44).type = (int)CardType.GCH;
            cardList.ElementAt(45).type = (int)CardType.Planet;
            cardList.ElementAt(46).type = (int)CardType.Planet;
            cardList.ElementAt(47).type = (int)CardType.Planet;
            cardList.ElementAt(48).type = (int)CardType.Planet;
            cardList.ElementAt(49).type = (int)CardType.Satelite_T;
            cardList.ElementAt(50).type = (int)CardType.Satelite_W;
            cardList.ElementAt(51).type = (int)CardType.OtherChance;
            cardList.ElementAt(52).type = (int)CardType.OtherChance;
            cardList.ElementAt(53).type = (int)CardType.Event;
            cardList.ElementAt(54).type = (int)CardType.Planet;
            cardList.ElementAt(55).type = (int)CardType.Planet;
            cardList.ElementAt(56).type = (int)CardType.OtherChance;
            cardList.ElementAt(57).type = (int)CardType.Satelite_N;
            cardList.ElementAt(58).type = (int)CardType.OtherChance;
            cardList.ElementAt(59).type = (int)CardType.GCH;
            cardList.ElementAt(60).type = (int)CardType.OtherChance;
            cardList.ElementAt(61).type = (int)CardType.OtherChance;
            #endregion

        }
        #endregion

        #region Funkcja rysująca podglądy i zaznaczenie kart
        public void paintFieldAndBasicPreview(object sender, PaintEventArgs e)
        {
            
            e.Graphics.DrawImage(board, 0, 0);
            foreach (var item in cardList)
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(255, Color.Black)), item.rectangle);
            foreach (var item in cardList)
            {
                if (item.selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(200, Color.BlanchedAlmond)), cardList.ElementAt(currentlySelected).rectangleFill);
                    e.Graphics.DrawImage(cardList.ElementAt(currentlySelected).image, cardPreview);
                    if (cardList.ElementAt(currentlySelected).largeCover==2)
                        e.Graphics.DrawImage(cardTxtAndGfx.cardCoverList.ElementAt(currentlySelected), cardCover2);
                    else if (cardList.ElementAt(currentlySelected).largeCover == 1)
                        e.Graphics.DrawImage(cardTxtAndGfx.cardCoverList.ElementAt(currentlySelected), cardCover1);
                    else
                        e.Graphics.DrawImage(cardTxtAndGfx.cardCoverList.ElementAt(currentlySelected), cardCover3);
                    #region Narysowanie specyficznych oznaczeń na kartach w zależności od typu.

                    switch (cardList.ElementAt(currentlySelected).type)
                    {
                        case (int)CardType.Planet:
                            {
                                e.Graphics.DrawImage(planetLabel, 364, 642);
                                break;
                            }
                        case (int)CardType.Satelite_N:
                            {
                                e.Graphics.DrawImage(satellite_nLabel, 364, 642);
                                break;
                            }
                        case (int)CardType.Satelite_T:
                            {
                                e.Graphics.DrawImage(satellite_tLabel, 364, 642);
                                break;
                            }
                        case (int)CardType.Satelite_W:
                            {
                                e.Graphics.DrawImage(satellite_wLabel, 364, 642);
                                break;
                            }
                        default:
                            break;
                    }

                    #endregion

                    e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                    
                    #region wklejanie odpowiednich symboli i tekstów
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).titleleft, largeFont, blackBrush, new RectangleF(new Point(184, 181), new Size(303, 77)), stringFormatLeft);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).titlemiddle, largeFont, blackBrush, new RectangleF(new Point(161, 181), new Size(326, 57)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).cost, costFont, blackBrush, new RectangleF(new Point(376, 222), new Size(100, 39)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).cost_currency, costFont, blackBrush, new RectangleF(new Point(444, 222), new Size(50, 39)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).description0, mediumFont, blackBrush, new RectangleF(new Point(184, 509), new Size(180, 25)), stringFormatRight);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).description1, mediumFont, blackBrush, new RectangleF(new Point(184, 534), new Size(180, 25)), stringFormatRight);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).description2, mediumFont, blackBrush, new RectangleF(new Point(184, 559), new Size(180, 25)), stringFormatRight);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).description3, mediumFont, blackBrush, new RectangleF(new Point(184, 584), new Size(180, 25)), stringFormatRight);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).value0, mediumFont, blackBrush, new RectangleF(new Point(364, 509), new Size(60, 25)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).value1, mediumFont, blackBrush, new RectangleF(new Point(364, 534), new Size(60, 25)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).value2, mediumFont, blackBrush, new RectangleF(new Point(364, 559), new Size(60, 25)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).value3, mediumFont, blackBrush, new RectangleF(new Point(364, 584), new Size(60, 25)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).value0_currency, mediumFont, blackBrush, new RectangleF(new Point(424, 509), new Size(35, 25)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).value1_currency, mediumFont, blackBrush, new RectangleF(new Point(424, 534), new Size(35, 25)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).value2_currency, mediumFont, blackBrush, new RectangleF(new Point(424, 559), new Size(35, 25)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).value3_currency, mediumFont, blackBrush, new RectangleF(new Point(424, 584), new Size(35, 25)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).resource0, mediumFont, blackBrush, new RectangleF(new Point(184, 500), new Size(118, 25)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).resource1, mediumFont, blackBrush, new RectangleF(new Point(184, 550), new Size(118, 25)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).resource2, mediumFont, blackBrush, new RectangleF(new Point(184, 600), new Size(118, 25)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).price0, GCHpriceFont, blackBrush, new RectangleF(new Point(362, 500), new Size(90, 25)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).price1, GCHpriceFont, blackBrush, new RectangleF(new Point(362, 550), new Size(90, 25)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).price2, GCHpriceFont, blackBrush, new RectangleF(new Point(362, 600), new Size(90, 25)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).price0_currency, GCHpriceFont, blackBrush, new RectangleF(new Point(450, 500), new Size(35, 25)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).price1_currency, GCHpriceFont, blackBrush, new RectangleF(new Point(450, 550), new Size(35, 25)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).price2_currency, GCHpriceFont, blackBrush, new RectangleF(new Point(450, 600), new Size(35, 25)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).reputation, mediumFont, blackBrush, new RectangleF(new Point(206, 631), new Size(262, 22)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).replogo0, smallFont, blackBrush, new RectangleF(new Point(196, 650), new Size(94, 49)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).replogo1, smallFont, blackBrush, new RectangleF(new Point(290, 650), new Size(94, 49)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).replogo2, smallFont, blackBrush, new RectangleF(new Point(384, 650), new Size(94, 49)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).ownerName, smallFont, blackBrush, new RectangleF(new Point(184, 622), new Size(60, 20)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).level, smallFont, blackBrush, new RectangleF(new Point(244, 622), new Size(60, 20)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).canonLevel, smallFont, blackBrush, new RectangleF(new Point(304, 622), new Size(60, 20)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).chancetextit, mediumFontOtherIt, blackBrush, new RectangleF(new Point(161, 488), new Size(326, 90)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).chancetext, mediumFontOther, blackBrush, new RectangleF(new Point(161, 578), new Size(326, 64)), stringFormatCenter);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).dicetext, largeFont, blackBrush, new RectangleF(new Point(184, 642), new Size(282, 49)), stringFormatCenter);

                    e.Graphics.RotateTransform(-90f);
                    e.Graphics.DrawString(cardTxtAndGfx.cardTextList.ElementAt(currentlySelected).address, adresFont, blackBrush, new RectangleF(new Point(-702, 161), new Size(521, 24)), stringFormatCenter);
                    e.Graphics.RotateTransform(90f);
                    #endregion
                }
            }
            e.Dispose(); // <- zwolnienie zasobów systemowych zajmowanych przez PaintEventArgs, czytałem że w przypadku rysowania ogromnych ilości rzeczy i to często mogą pojawić się problemy z pamięcia itp, u nas nie będzie takiego problemu ale skoro to dobra praktyka to wrzuciłem.
        }
        #endregion

        #region Funkcja rysująca pionki graczy
        public void paintPlayers(object sender, PaintEventArgs e, List<Player> pl)
        {
            int z = 0;
            foreach (var item in pl)
            {
                e.Graphics.DrawImage(item.playerLogo, cardList.ElementAt(item.playerPosition).begin2.X + 1 + z, cardList.ElementAt(item.playerPosition).begin2.Y + 1 + z, 30, 30);
                z = z + 4;
            }
            e.Dispose(); // <- zwolnienie zasobów systemowych zajmowanych przez PaintEventArgs, czytałem że w przypadku rysowania ogromnych ilości rzeczy i to często mogą pojawić się problemy z pamięcia itp, u nas nie będzie takiego problemu ale skoro to dobra praktyka to wrzuciłem.
        }
        #endregion

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                smallFont.Dispose();
                mediumFont.Dispose();
                mediumFontOther.Dispose();
                mediumFontOtherIt.Dispose();
                GCHpriceFont.Dispose();
                adresFont.Dispose();
                largeFont.Dispose();
                costFont.Dispose();
                blackBrush.Dispose();
                stringFormatCenter.Dispose();
                stringFormatLeft.Dispose();
                stringFormatRight.Dispose();
                playerlogo_1Label.Dispose();
                playerlogo_2Label.Dispose();
                playerlogo_3Label.Dispose();
                playerlogo_4Label.Dispose();
                playerlogo_5Label.Dispose();
                playerlogo_6Label.Dispose();

            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region Deklaracja zmiennych
        public  List<Card>          cardList           = new List<Card>();
        public  CardTextAndGraphics cardTxtAndGfx      = new CardTextAndGraphics();
        private int                 width13            = 57; //szerokość pól węższych z grupy żółtej i niebieskiej
        private int                 width13l           = 82; //szerokość pól szerszych z grupy żółtej i niebieskiej
        private int                 height13           = 100; //wysokość pól z grupy żółtej i niebieskiej
        private int                 width24            = 100; //szerokość pól szerszych z grupy żółtej i niebieskiej//szerokość pól szerszych z grupy żółtej i niebieskiej
        private int                 height24           = 57;
        private int                 height24l          = 82;
        private int                 xyend              = 980;
        private int                 xybegin            = 0;
        private bool                last               = false;
        private int                 number             = 0;
        private int                 cardsInGroup       = 15;
        public  int                 buyableCardsCount  = 36; 
        private enum                Sector             { Yellow=1, Green=2, Blue=3, Red=4, Black=5 }
        public  enum                CardType           { Planet, Satelite_N, Satelite_T, Satelite_W, GCH, OtherChance, Other, Event }
        private Size                cardPreviewSize    = new Size(330, 525);
        private Size                cardCoverSize1     = new Size(301, 246);
        private Size                cardCoverSize2     = new Size(326, 246);
        private Point               cardPreviewBegin   = new Point(159, 179);
        public  Rectangle           cardPreview        { get; private set; }
        public  Rectangle           cardCover1         { get; private set; }
        public  Rectangle           cardCover2         { get; private set; }
        public  Rectangle           cardCover3         { get; private set; }
        public  int                 currentlySelected  { get; set; }
        private Font                smallFont          = new Font("Cambria", 8, System.Drawing.FontStyle.Regular);
        private Font                mediumFont         = new Font("Cambria", 10, System.Drawing.FontStyle.Regular);
        private Font                mediumFontOther    = new Font("Cambria", 11, System.Drawing.FontStyle.Regular);
        private Font                mediumFontOtherIt  = new Font("Cambria", 11, System.Drawing.FontStyle.Italic);
        private Font                GCHpriceFont       = new Font("Cambria", 12, System.Drawing.FontStyle.Regular);
        private Font                adresFont          = new Font("Cambria", 14, System.Drawing.FontStyle.Regular);
        private Font                largeFont          = new Font("Cambria", 18, System.Drawing.FontStyle.Regular);
        private Font                costFont           = new Font("Cambria", 20, System.Drawing.FontStyle.Regular);
        private SolidBrush          blackBrush         = new SolidBrush(Color.Black);
        private StringFormat        stringFormatCenter = new StringFormat();
        private StringFormat        stringFormatLeft   = new StringFormat();
        private StringFormat        stringFormatRight  = new StringFormat();
        #endregion
        
        #region Wgranie plików obrazów specjalnych labelek kart i planszy
        //Wgranie obrazu planszy:
        static Image board            = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.board.planszav3.png"));
        //Wgranie obrazów labelek planet i satelitów:
        static Image planetLabel      = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card3_misc.CIRC_PL.CIRC_PL.png"));
        static Image satellite_tLabel = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card3_misc.CIRC_SAT.CIRC_SAT_t.png"));
        static Image satellite_nLabel = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card3_misc.CIRC_SAT.CIRC_SAT_n.png"));
        static Image satellite_wLabel = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card3_misc.CIRC_SAT.CIRC_SAT_w.png"));
        //Wgranie obrazów labelek poziomu dział planety:
        static Image cannonlvl_1Label = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card3_misc.CLVL.CLVL_1-1.png"));
        static Image cannonlvl_2Label = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card3_misc.CLVL.CLVL_2-1.png"));
        static Image cannonlvl_3Label = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card3_misc.CLVL.CLVL_3-1.png"));
        static Image cannonlvl_4Label = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card3_misc.CLVL.CLVL_4-1.png"));
        static Image cannonlvl_5Label = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card3_misc.CLVL.CLVL_5-1.png"));
        //Wgranie obrazów labelek poziomu inwestycji planety:
        static Image planetlvl_1Label = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card3_misc.LVL.lvl1-1.png"));
        static Image planetlvl_2Label = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card3_misc.LVL.lvl2-1.png"));
        static Image planetlvl_3Label = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card3_misc.LVL.lvl3-1.png"));
        static Image planetlvl_4Label = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card3_misc.LVL.lvl4-1.png"));
        static Image planetlvl_5Label = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card3_misc.LVL.lvl5-1.png"));
        //Wgranie obrazów log graczy:
        public Image playerlogo_1Label = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card3_misc.PLOGO.PLOGO_1_R-1.png"));
        public Image playerlogo_2Label = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card3_misc.PLOGO.PLOGO_2_Y-1.png"));
        public Image playerlogo_3Label = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card3_misc.PLOGO.PLOGO_3_G-1.png"));
        public Image playerlogo_4Label = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card3_misc.PLOGO.PLOGO_4_B-1.png"));
        public Image playerlogo_5Label = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card3_misc.PLOGO.PLOGO_5_P-1.png"));
        public Image playerlogo_6Label = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card3_misc.PLOGO.PLOGO_6_BK-1.png"));
        #endregion
    }
}