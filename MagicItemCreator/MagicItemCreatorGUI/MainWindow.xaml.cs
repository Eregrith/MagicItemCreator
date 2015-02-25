using MagicItemCreator.CustomTypes;
using MagicItemCreator.Enums;
using MagicItemCreator.Creators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MagicItemCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Si on tombe sur une arme, on veut une melee

            ItemQuality quality;
            Random r = new Random();
            int i = r.Next(1, 3);
            switch (i)
            {
                case 1:
                    MagicItemCreation.ChosenRange = Range.Melee;
                    break;
                case 2:
                    MagicItemCreation.ChosenRange = Range.Ranged;
                    break;
                default:
                    quality = ItemQuality.Medium;
                    break;
            }
            i = r.Next(1, 4);
            switch (i)
            {
                case 1:
                    quality = ItemQuality.Minor;
                    break;
                case 2:
                    quality = ItemQuality.Medium;
                    break;
                case 3:
                    quality = ItemQuality.Major;
                    break;
                default:
                    quality = ItemQuality.Medium;
                    break;
            }

            MagicItem item = WeaponCreation.Create(quality);

            itemDisplay.Text += item.ToString() + Environment.NewLine;
        }
    }
}
