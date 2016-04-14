using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slots
{
    public class CardGenerator
    {
        Random rGen;
        Graphics cardBoard;
        List<Card> cardList;
        public int Credit{ get; set; }
        public CardGenerator(Graphics cardBoard)
        {
            this.cardBoard = cardBoard;
            rGen = new Random();
            Credit = 100;
        }

        public void GenerateCards()
        {
            cardList = new List<Card>();

            for (int i = 0; i < 9; i++)
            {
                cardList.Add(new Card(rGen, cardBoard));
            }
        }

        public void DrawAllCards()
        {
            Point cardPoint = new Point(0, 0);
            foreach (Card c in cardList)
            {
                int xLoc = cardList.IndexOf(c);
                int yLoc = 0;
                if (xLoc > 2 && xLoc <= 5) 
                {
                    xLoc -= 3;
                    yLoc += 1;
                }
                else if (xLoc > 5)
                {
                    xLoc -= 6;
                    yLoc += 2;
                }

                yLoc = yLoc * 50 + 10;
                xLoc = xLoc * 50 + 10;

                cardPoint.X = xLoc;
                cardPoint.Y = yLoc;
                c.DrawCard(cardPoint);
            }
        }

        public void CheckCards(Label label, int multiplier)
        {
            bool win = false;
            label.Text = "";
            label.ForeColor = Color.Green;
            if (cardList[0].CardColor.Name.Equals(cardList[1].CardColor.Name) && cardList[0].CardColor.Name.Equals(cardList[2].CardColor.Name))
            {
                win = true;
                highlightCards(0);
            }
            else if (cardList[3].CardColor.Name.Equals(cardList[4].CardColor.Name) && cardList[3].CardColor.Name.Equals(cardList[5].CardColor.Name))
            {
                win = true;
                highlightCards(1);
            }
            else if (cardList[6].CardColor.Name.Equals(cardList[7].CardColor.Name) && cardList[6].CardColor.Name.Equals(cardList[8].CardColor.Name))
            {
                win = true;
                highlightCards(2);
            }
            else
            {
                win = false;
            }

            if (win)
            {
                label.Text = "Win";
                Credit += multiplier;
            }
            else
            {
                label.ForeColor = Color.Red;
                label.Text = "Lose";
                Credit -= multiplier;
            }
            
        }

        private void highlightCards(int row)
        {
            Pen highlightPen = new Pen(Color.Yellow, 5);

            int yLoc;
            int xLoc;

            if (row == 0)
                yLoc = 0;
            else if (row == 1)
                yLoc = 1;
            else
                yLoc = 2;

            yLoc = yLoc * 50 + 10;
            xLoc = 10;
            // width > height
            cardBoard.DrawRectangle(highlightPen, xLoc, yLoc, 150, 50);
        }
    }
}
