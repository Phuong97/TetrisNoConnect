using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public class Play
    {
        
        Board board = new Board();
        Info info = new Info();
        
        //1. Khoi tao
        public void Init(Panel p)
        {
            board.DrawBoard(p);
           
        }

        //2. Khoi tao Block

        public Block CreatBlock()
        {
            Block block = new Block();
            block = block.ShapeBlock();
            return block;
        }

        //Delete block

        public void DeleteBlock(Block block)
        {
            for (int i = 0; i < block.Row1; i++)
            {
                for (int j = 0; j < block.Column1; j++)
                {
                    if (block.Arr[i, j] == 1)
                    {
                        if ((block.JBoard + j) % 2 == 0)
                        {
                            board.Map1[i + block.IBoard, j + block.JBoard].BackColor = Color.Silver;
                        }
                        else
                        {
                            board.Map1[i + block.IBoard, j + block.JBoard].BackColor = Color.LightGray;
                        }
                    }

                }
            }
        }
        // Update index for board 
        public void DrawBlockInMap(Block block)
        {
            int[,] arr = block.Arr;
            int Iboard = block.IBoard;
            int Jboard = block.JBoard;
            int rowBlock = block.Row1;
            int columnBlock = block.Column1;
            for (int i = 0; i < rowBlock; i++)
            {
                for (int j = 0; j < columnBlock; j++)
                {
                    if (arr[i, j] == 1)
                        board.MapPlayGame1[i + Iboard, j + Jboard] = 1;
                }
            }
        }
        //Get Color
        public Color[,] getColor()
        {
            Color[,] ColorBoard = new Color[board.Row1, board.Column1];
            for (int i = board.Row1-1; i >= 4; i--)
            {
                for (int j = 0; j < board.Column1; j++)
                {
                    ColorBoard[i, j] = board.Map1[i-1 , j].BackColor;
                }
            }
            return ColorBoard;
        }
        //Draw
        public void Draw()
        {
            Color[,] ColorBoard = getColor();
            for (int i = 0; i < board.Row1; i++)
            {
                for (int j = 0; j < board.Column1; j++)
                {
                    if (board.MapPlayGame1[i, j] == 1)
                    {
                        board.Map1[i, j].BackColor = ColorBoard[i,j];
                    }
                    else
                    {
                        if (j % 2 == 0)
                            board.Map1[i, j].BackColor = Color.Silver;
                        else
                            board.Map1[i, j].BackColor = Color.LightGray;
                    }
                }
            }
        }

        //DrawBlock
        public void DrawBlock(Block block)
        {
            board.DrawBlock(block);
        }

        public void DrawBlockNext(Panel p,Block block)
        {
            board.DrawBlockNext(p,block);
        }

        // 3.Rotate
        public bool ConditionRotate(Block b)
        {
           
            for (int i = 0; i < b.Row1; i++)
            {
                for (int j = 0; j < b.Column1; j++)
                {
                    if (b.ConditionBoard(b.IBoard + i, b.JBoard + j) == false || board.MapPlayGame1[b.IBoard + i, b.JBoard + j] == 1 || b.JBoard + b.Row1 > 10 || b.IBoard + b.Row1 > 21)
                        return false;
                }
            }
            return true;
        }
        public Block Rotate(ref Block block)
        {
            if (ConditionRotate(block))
                return block.Rotate(ref block);
            else
                return block;
        }

        // Condiontion
        public bool ConditionLeft(Block block)
        {
            for (int i = 0; i < block.Row1; i++)
            {
                for (int j = 0; j < block.Column1; j++)
                {
                    if (block.Arr[i, j] == 1)
                    {
                        if (block.ConditionLeft(block.IBoard + i, block.JBoard + j) == false || block.JBoard - 1 < 0 || block.IBoard <= 3 || board.MapPlayGame1[block.IBoard + i, block.JBoard + j - 1] == 1)
                            return false;
                    }
                }
            }
            return true;
        }

        public bool ConditionRight(Block block)
        {
            for (int i = 0; i < block.Row1; i++)
            {
                for (int j = 0; j < block.Column1; j++)
                {
                    if (block.Arr[i, j] == 1)
                    {
                        if (block.ConditionRight(block.IBoard + i, block.JBoard + j) == false || board.MapPlayGame1[block.IBoard + i, block.JBoard + j + 1] == 1 || block.IBoard <= 3)
                            return false;
                    }
                }
            }
            return true;
        }

        public bool ConditionDown(Block block)
        {
            for (int i = 0; i < block.Row1; i++)
            {
                for (int j = 0; j < block.Column1; j++)
                {
                    if (block.Arr[i, j] == 1)
                    {
                        if (block.ConditionDown(block.IBoard + i, block.JBoard + j) == false || board.MapPlayGame1[block.IBoard + i + 1, block.JBoard + j] == 1)
                            return false;
                    }
                }
            }
            return true;
        }
        //Move
        public Block MoveLeft(ref Block block)
        {
            if (ConditionLeft(block))
                return block.Left(ref block);
            else
                return block;
        }

        public Block MoveRight(ref Block block)
        {
            if (ConditionRight(block))
                return block.Right(ref block);
            else
                return block;
        }

        public Block MoveDown(ref Block block)
        {
            if (ConditionDown(block))
                return block.Down(ref block);
            else
                return block;
        }

        //Info
        public void setInfo(Info info, int t)
        {
            info.Speed = t;
        }

        //WIN LOSEEEEE

        
        public void UpdateMap(int row)
        {
            for (int i = row; i > 0; i--)
            {
                for (int j = 0; j < 10; j++)
                {
                    board.MapPlayGame1[i, j] = board.MapPlayGame1[i - 1, j];
                }
            }

        }
        public int Check(Block block, Info info)
        {
            int i = block.Row1 - 1;
            int count, j, score;
            do
            {
                count = 0;
                for (j = 0; j < board.Column1; j++)
                {
                    if (board.MapPlayGame1[block.IBoard + i, j] == 1)
                    {
                        count++;
                    }

                }
                if (count == 10)
                {
                    score = 100;
                    info.UpLevel(info, score);
                    UpdateMap(block.IBoard + i);
                    Draw();
                }
                else
                    i--;
            } while (i >= 0);
            return 1;
        }

    }
}
