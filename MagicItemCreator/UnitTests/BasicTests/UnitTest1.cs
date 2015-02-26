using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicItemCreator.Creators;
using MagicItemCreator.CustomTypes;
using MagicItemCreator.Enums;
using FluentAssertions;

namespace UnitTests.BasicTests
{
    [TestClass]
    public class BasicTests
    {
        /// <summary>
        /// Teste si la qualité de l'objet demandée est bien celle que l'on a dans l'objet qui revient
        /// </summary>
        [TestMethod]
        public void ItemQualityIsKept()
        {
            ItemQuality quality;
            Random r = new Random();

            for (int t = 0; t < 10000; t++)
            {
                int i = r.Next(1, 4);
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

                MagicItem item = MagicItemCreation.Create(quality);

                item.Quality.Should().Be(quality);
            }
        }
    }
}
