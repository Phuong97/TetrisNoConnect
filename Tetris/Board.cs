using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public class Board
    {
        //Attribute
        private int Row;
        private int Column;
        private Label[,] Map;
        private int[,] MapPlayGame;

        //Property
        public Label[,] Map1 { get => Map; set => Map = value; }
        public int Column1 { get => Column; set => Column = value; }
        public int Row1 { get => Row; set => Row = value; }
        public int[,] MapPlayGame1 { get => MapPlayGame; set => MapPlayGame = value; }


        //Constructor
        public Board()
        {
            Row1 = 22;
            Column1 = 10;
            Map1 = new Label[Row1, Column1];
            MapPlayGame1 = new int[Row1, Column1];
        }

        public void DrawBlock(Block block)
        {
            for (int i = 0; i < block.Row1; i++)
            {
                for (int j = 0; j < block.Column1; j++)
                {
                    if (block.Arr[i, j] == 1)
                    {
                        Map1[i + block.IBoard, j + block.JBoard].BackColor = block.Color;
                    }
                }
            }
        }
        public void DrawBoard(Panel p)
        {
            Board board = new Board();
            Point point = p.Location;
            int x = point.X;
            int y = point.Y - 30;

            for (int i = 0; i < board.Row1; i++)
            {
                //if (i > 3)
                //{
                y += 30;
                x = p.Location.X;
                //}
                for (int j = 0; j < board.Column1; j++)
                {
                    //if (i > 3)
                    //{
                    point = new Point(x, y);
                    Map1[i, j] = new Label();
                    Map1[i, j].Text = i.ToString() + j.ToString();
                    Map1[i, j].Location = point;
                    Map1[i, j].Width = Map1[i, j].Height = 30;
                    if (j % 2 == 0)
                    {
                        Map1[i, j].BackColor = Color.Silver;
                    }
                    else
                    {
                        Map1[i, j].BackColor = Color.LightGray;
                    }

                    Map1[i, j].BorderStyle = BorderStyle.FixedSingle;
                    p.Controls.Add(Map1[i, j]);
                    x += 30;
                    //}

                }
            }
        }

    }
}
