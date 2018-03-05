using System;
using System.Drawing;

namespace Tetris
{
    public class Block
    {
        ///Attribute
        private int Row, Column;
        int iBoard, jBoard;
        private int[,] arr;
        private Color color;

        ///Property
        public Color Color { get => color; set => color = value; }
        public int[,] Arr { get => arr; set => arr = value; }
        public int Row1 { get => Row; set => Row = value; }
        public int Column1 { get => Column; set => Column = value; }
        public int IBoard { get => iBoard; set => iBoard = value; }
        public int JBoard { get => jBoard; set => jBoard = value; }

        ///Set Color Block

        public Color setColor()
        {
            Random rd = new Random();
            switch (rd.Next(1, 6))
            {
                case 1:
                    return Color.Blue;
                case 2:
                    return Color.Green;
                case 3:
                    return Color.Orange;
                case 4:
                    return Color.Red;
                case 5:
                    return Color.HotPink;
                default:
                    return Color.Gray;
            }
        }

        //Create
        public Block ShapeBlock()
        {
            Random rd = new Random();
            Block block = new Block();
            switch (rd.Next(1, 8))
            {
                case 1:
                    block.Row = 1;
                    block.Column = 4;
                    block.IBoard = 3;
                    block.JBoard = 4;
                    block.Arr = new int[,] {
                        {1,1,1,1}
                    };
                    block.color = setColor();
                    return block;
                case 2:
                    block.Row = 2;
                    block.Column = 2;
                    block.IBoard = 3;
                    block.JBoard = 4;
                    block.Arr = new int[,] {
                        {1,1},
                        {1,1}
                    };
                    block.color = setColor();
                    return block;
                case 3:
                    block.Row = 2;
                    block.Column = 3;
                    block.IBoard = 3;
                    block.JBoard = 4;
                    block.Arr = new int[,] {
                        {1,1,1},
                        {0,0,1}

                    };
                    block.color = setColor();
                    return block;
                case 4:
                    block.Row = 2;
                    block.Column = 3;
                    block.IBoard = 3;
                    block.JBoard = 4;
                    block.Arr = new int[,] {
                         {1,1,1},
                         {1,0,0}

                    };
                    block.color = setColor();
                    return block;
                case 5:
                    block.Row = 3;
                    block.Column = 2;
                    block.IBoard = 3;
                    block.JBoard = 4;
                    block.Arr = new int[,] {
                         {1,0},
                         {1,1},
                         {0,1}
                    };
                    block.color = setColor();
                    return block;
                case 6:
                    block.Row = 2;
                    block.Column = 3;
                    block.IBoard = 3;
                    block.JBoard = 4;
                    block.Arr = new int[,] {
                         {1,1,0},
                         {0,1,1}
                    };
                    block.color = setColor();
                    return block;
                case 7:
                    block.Row = 2;
                    block.Column = 3;
                    block.IBoard = 3;
                    block.JBoard = 4;
                    block.Arr = new int[,] {
                        {1,1,1},
                        {0,1,0}
                    };
                    block.color = setColor();
                    return block;
                default:
                    return null;

            }
        }
        // Rotate

        public Block Rotate(ref Block b)
        {
            int tmpRow = b.Column1;
            int tmpColumn = b.Row1;
            int[,] tmpArr = new int[tmpRow, tmpColumn];
            for (int i = b.Row1 - 1; i >= 0; i--)
            {
                for (int j = b.Column1 - 1; j >= 0; j--)
                {
                    tmpArr[j, b.Row1 - i - 1] = b.Arr[i, j];
                }
            }
            b.Arr = new int[tmpRow, tmpColumn];
            b.Column1 = tmpColumn;
            b.Row1 = tmpRow;
            b.Arr = tmpArr;
            return b;
        }

        //Condition

        public bool ConditionBoard(int r, int c)
        {
            if (c >= 0 && c < 10 && r >= 0 && r < 22)
                return true;
            else
                return false;
        }
        public bool ConditionLeft(int r, int c)
        {
            if (ConditionBoard(r, c) == true && c > 0)
                return true;
            else
                return false;
        }

        public bool ConditionRight(int r, int c)
        {
            if (ConditionBoard(r, c) == true && c < 10 - 1)
                return true;
            else
                return false;
        }
        public bool ConditionDown(int r, int c)
        {
            if (ConditionBoard(r, c) == true && r < 22 - 1)
                return true;
            else
                return false;
        }
        // Move

        public Block Left(ref Block b)
        {
            b.JBoard--;
            return b;
        }

        public Block Right(ref Block b)
        {
            b.JBoard++;
            return b;
        }

        public Block Down(ref Block b)
        {
            b.IBoard++;
            return b;
        }
    }
}
