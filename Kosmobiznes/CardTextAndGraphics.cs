using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace Kosmobiznes
{
    /// <summary>
    /// Stores images and strings to be displayed on cards.
    /// </summary>
    class CardTextAndGraphics
    {
        #region Konstruktor klasy CardTextAndGraphics
        /// <summary>
        /// Constructor method for CardTextAndGraphics class
        /// </summary>
        public CardTextAndGraphics()
        {
            #region Lista szablonów kart
            cardTemplateList.Add(other_yellow);
            cardTemplateList.Add(planet_yellow);
            cardTemplateList.Add(planet_yellow);
            cardTemplateList.Add(satelite_military_yellow);
            cardTemplateList.Add(other_yellow);
            cardTemplateList.Add(planet_yellow);
            cardTemplateList.Add(planet_yellow);
            cardTemplateList.Add(satelite_telecom_yellow);
            cardTemplateList.Add(chance_yellow);
            cardTemplateList.Add(other_yellow);
            cardTemplateList.Add(chance_yellow);
            cardTemplateList.Add(planet_yellow);
            cardTemplateList.Add(planet_yellow);
            cardTemplateList.Add(satelite_science_yellow);
            cardTemplateList.Add(gch_yellow);
            
            cardTemplateList.Add(planet_green);
            cardTemplateList.Add(planet_green);
            cardTemplateList.Add(planet_green);
            cardTemplateList.Add(other_green);
            cardTemplateList.Add(satelite_telecom_green);
            cardTemplateList.Add(chance_green);
            cardTemplateList.Add(chance_green);
            cardTemplateList.Add(planet_green);
            cardTemplateList.Add(planet_green);
            cardTemplateList.Add(planet_green);
            cardTemplateList.Add(other_green);
            cardTemplateList.Add(chance_green);
            cardTemplateList.Add(satelite_military_green);
            cardTemplateList.Add(chance_green);
            cardTemplateList.Add(gch_green);

            cardTemplateList.Add(satelite_science_blue);
            cardTemplateList.Add(planet_blue);
            cardTemplateList.Add(planet_blue);
            cardTemplateList.Add(planet_blue);
            cardTemplateList.Add(satelite_military_blue);
            cardTemplateList.Add(satelite_telecom_blue);
            cardTemplateList.Add(other_blue);
            cardTemplateList.Add(chance_blue);
            cardTemplateList.Add(planet_blue);
            cardTemplateList.Add(planet_blue);
            cardTemplateList.Add(planet_blue);
            cardTemplateList.Add(other_blue);
            cardTemplateList.Add(chance_blue);
            cardTemplateList.Add(satelite_military_blue);
            cardTemplateList.Add(gch_blue);

            cardTemplateList.Add(planet_red);
            cardTemplateList.Add(planet_red);
            cardTemplateList.Add(planet_red);
            cardTemplateList.Add(planet_red);
            cardTemplateList.Add(satelite_telecom_red);
            cardTemplateList.Add(satelite_military_red);
            cardTemplateList.Add(chance_red);
            cardTemplateList.Add(chance_red);
            cardTemplateList.Add(chance_red);
            cardTemplateList.Add(planet_red);
            cardTemplateList.Add(planet_red);
            cardTemplateList.Add(chance_red);
            cardTemplateList.Add(satelite_science_red);
            cardTemplateList.Add(chance_red);
            cardTemplateList.Add(gch_red);

            cardTemplateList.Add(chance_black);
            cardTemplateList.Add(chance_black);
            #endregion

            #region Lista okładek kart
            cardCoverList.Add(cover1);
            cardCoverList.Add(cover2);
            cardCoverList.Add(cover3);
            cardCoverList.Add(cover4);
            cardCoverList.Add(cover5);
            cardCoverList.Add(cover6);
            cardCoverList.Add(cover7);
            cardCoverList.Add(cover8);
            cardCoverList.Add(cover9);
            cardCoverList.Add(cover10);
            cardCoverList.Add(cover11);
            cardCoverList.Add(cover12);
            cardCoverList.Add(cover13);
            cardCoverList.Add(cover14);
            cardCoverList.Add(cover15);
            cardCoverList.Add(cover16);
            cardCoverList.Add(cover17);
            cardCoverList.Add(cover18);
            cardCoverList.Add(cover19);
            cardCoverList.Add(cover20);
            cardCoverList.Add(cover21);
            cardCoverList.Add(cover22);
            cardCoverList.Add(cover23);
            cardCoverList.Add(cover24);
            cardCoverList.Add(cover25);
            cardCoverList.Add(cover26);
            cardCoverList.Add(cover27);
            cardCoverList.Add(cover28);
            cardCoverList.Add(cover29);
            cardCoverList.Add(cover30);
            cardCoverList.Add(cover31);
            cardCoverList.Add(cover32);
            cardCoverList.Add(cover33);
            cardCoverList.Add(cover34);
            cardCoverList.Add(cover35);
            cardCoverList.Add(cover36);
            cardCoverList.Add(cover37);
            cardCoverList.Add(cover38);
            cardCoverList.Add(cover39);
            cardCoverList.Add(cover40);
            cardCoverList.Add(cover41);
            cardCoverList.Add(cover42);
            cardCoverList.Add(cover43);
            cardCoverList.Add(cover44);
            cardCoverList.Add(cover45);
            cardCoverList.Add(cover46);
            cardCoverList.Add(cover47);
            cardCoverList.Add(cover48);
            cardCoverList.Add(cover49);
            cardCoverList.Add(cover50);
            cardCoverList.Add(cover51);
            cardCoverList.Add(cover52);
            cardCoverList.Add(cover53);
            cardCoverList.Add(cover54);
            cardCoverList.Add(cover55);
            cardCoverList.Add(cover56);
            cardCoverList.Add(cover57);
            cardCoverList.Add(cover58);
            cardCoverList.Add(cover59);
            cardCoverList.Add(cover60);
            cardCoverList.Add(cover61);
            cardCoverList.Add(cover62);
            #endregion

            LoadCardTextFromFile();
            
        }
        #endregion

        #region Lista tekstów kart
        /// <summary>
        /// Method for loading card texts from a .txt file into the application.
        /// </summary>
        public void LoadCardTextFromFile()
        {
            for (int i = 0; i < 62; i++)
            {
                cardTextList.Add(new CardText());
            }
            try
            {

                string cardtextstring = Properties.Resources.cardtext;
                line = cardtextstring.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
                

            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            int pomocnik = 0;
            for (int i = 0; i < 62; i++)
            {
                cardTextList.ElementAt(i).titleleft = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).titlemiddle = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).cost = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).cost_currency = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).address = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).description0 = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).description1 = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).description2 = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).description3 = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).value0 = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).value0_currency = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).value1 = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).value1_currency = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).value2 = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).value2_currency = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).value3 = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).value3_currency = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).resource0 = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).resource1 = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).resource2 = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).price0 = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).price0_currency = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).price1 = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).price1_currency = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).price2 = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).price2_currency = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).reputation = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).replogo0 = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).replogo1 = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).replogo2 = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).ownerName = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).level = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).canonLevel = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).chancetextit = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).chancetext = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
                cardTextList.ElementAt(i).dicetext = line.ElementAt(pomocnik).Replace("$", Environment.NewLine);
                pomocnik++;
            }
        }
        #endregion
        
        #region Deklaracja zmiennych
        public List<string>   line             = new List<string>();
        public List<Image>    cardTemplateList = new List<Image>();
        public List<CardText> cardTextList     = new List<CardText>();
        public List<Image>    cardCoverList    = new List<Image>();
        private static Size   imageSize        = new Size(330, 525);
        private static Size   imageCoverSize1  = new Size(301, 246);
        private static Size   imageCoverSize2  = new Size(326, 246);
        #endregion

        #region Wgranie plików obrazów - szablony kart
        static Image gch_yellow               = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_GCH_1-1.png"));
        static Image gch_green                = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_GCH_2-1.png"));
        static Image gch_blue                 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_GCH_3-1.png"));
        static Image gch_red                  = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_GCH_4-1.png"));
        static Image other_yellow             = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_other_1-1.png"));
        static Image other_green              = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_other_2-1.png"));
        static Image other_blue               = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_other_3-1.png"));
        static Image other_red                = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_other_4-1.png"));
        static Image chance_yellow            = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_other_los_1-1.png"));
        static Image chance_green             = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_other_los_2-1.png"));
        static Image chance_blue              = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_other_los_3-1.png"));
        static Image chance_red               = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_other_los_4-1.png"));
        static Image chance_black             = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_other_los_5-1.png"));
        static Image planet_yellow            = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_planet_1-1.png"));
        static Image planet_green             = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_planet_2-1.png"));
        static Image planet_blue              = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_planet_3-1.png"));
        static Image planet_red               = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_planet_4-1.png"));
        static Image satelite_military_yellow = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_sat_W_1-1.png"));
        static Image satelite_military_green  = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_sat_W_2-1.png"));
        static Image satelite_military_blue   = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_sat_W_3-1.png"));
        static Image satelite_military_red    = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_sat_W_4-1.png"));
        static Image satelite_science_yellow  = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_sat_N_1-1.png"));
        static Image satelite_science_blue    = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_sat_N_3-1.png"));
        static Image satelite_science_red     = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_sat_N_4-1.png"));
        static Image satelite_telecom_yellow  = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_sat_T_1-1.png"));
        static Image satelite_telecom_green   = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_sat_T_2-1.png"));
        static Image satelite_telecom_blue    = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_sat_T_3-1.png"));
        static Image satelite_telecom_red     = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card1_template.cardtemplate_sat_T_4-1.png"));
        #endregion

        #region Wgranie plików obrazów - grafiki kart planszy
        static Image cover1  = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_1C.png"));
        static Image cover2  = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_2C.png"));
        static Image cover3  = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_3C.png"));
        static Image cover4  = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_4C.png"));
        static Image cover5  = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_5C.png"));
        static Image cover6  = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_6C.png"));
        static Image cover7  = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_7C.png"));
        static Image cover8  = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_8C.png"));
        static Image cover9  = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_9C.png"));
        static Image cover10 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_10C.png"));
        static Image cover11 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_SZANSA.png"));
        static Image cover12 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_12C.png"));
        static Image cover13 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_13C.png"));
        static Image cover14 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_14C.png"));
        static Image cover15 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_15C.png"));
        static Image cover16 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_16C.png"));
        static Image cover17 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_17C.png"));
        static Image cover18 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_18C.png"));
        static Image cover19 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_19C.png"));
        static Image cover20 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_20C.png"));
        static Image cover21 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_21C.png"));
        static Image cover22 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_22C.png"));
        static Image cover23 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_23C.png"));
        static Image cover24 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_24C.png"));
        static Image cover25 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_25C.png"));
        static Image cover26 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_26C.png"));
        static Image cover27 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_SZANSA.png"));
        static Image cover28 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_28C.png"));
        static Image cover29 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_29C.png"));
        static Image cover30 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_30C.png"));
        static Image cover31 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_31C.png"));
        static Image cover32 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_32C.png"));
        static Image cover33 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_33C.png"));
        static Image cover34 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_34C.png"));
        static Image cover35 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_35C.png"));
        static Image cover36 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_36C.png"));
        static Image cover37 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_38C.png"));
        static Image cover38 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_37C.png"));
        static Image cover39 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_39C.png"));
        static Image cover40 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_40C.png"));
        static Image cover41 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_41C.png"));
        static Image cover42 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_42C.png"));
        static Image cover43 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_SZANSA.png"));
        static Image cover44 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_44C.png"));
        static Image cover45 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_45C.png"));
        static Image cover46 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_46C.png"));
        static Image cover47 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_47C.png"));
        static Image cover48 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_48C.png"));
        static Image cover49 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_49C.png"));
        static Image cover50 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_50C.png"));
        static Image cover51 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_51C.png"));
        static Image cover52 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_52C.png"));
        static Image cover53 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_53C.png"));
        static Image cover54 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_SZANSA.png"));
        static Image cover55 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_55C.png"));
        static Image cover56 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_56C.png"));
        static Image cover57 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_57C.png"));
        static Image cover58 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_58C.png"));
        static Image cover59 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_59C.png"));
        static Image cover60 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_60C.png"));
        static Image cover61 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_61C.png"));
        static Image cover62 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("Kosmobiznes.Resources.card2_graphics.card2_graphics_62C.png"));
        #endregion

        #region Wgranie plików obrazów - grafiki kart szns/eventów
        #endregion
    }
}