using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slots
{
    public class Card
    {
        Color cardColor;
        Graphics cardCanvas;

        public Color CardColor { get; set; }

        public Card(Random rGen, Graphics cardCanvas)
        {
            this.cardCanvas = cardCanvas;
            int randomNum = rGen.Next(4);

            switch (randomNum)
            {
                case 0:
                    cardColor = Color.Blue;
                    break;
                case 1:
                    cardColor = Color.Red;
                    break;
                case 2:
                    cardColor = Color.Orange;
                    break;
                case 3:
                    cardColor = Color.Green;
                    break;
            }
            CardColor = cardColor;
        }

        public void DrawCard(Point cardLocation)
        {
            Pen outlinePen = new Pen(Color.Black);
            SolidBrush cardBrush = new SolidBrush(cardColor);

            int cardSize = 50;
            
            cardCanvas.DrawRectangle(outlinePen, cardLocation.X, cardLocation.Y, cardSize, cardSize);
            cardCanvas.FillRectangle(cardBrush, cardLocation.X, cardLocation.Y, cardSize, cardSize);
        }
    }
}
