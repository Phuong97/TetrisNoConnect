using System;
using System.Windows.Forms;
using System.Threading;
namespace Tetris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Play player = new Play();
        Block currentBlock;
        Block nextBlock;
        Info info = new Info();
        Block nextnextBlock;

        private void Form1_Load(object sender, EventArgs e)
        {
            player.Init(panel1);
            PlayGame(); 
        }

        public void PlayGame()
        {
            currentBlock = player.CreatBlock();
            nextBlock = player.CreatBlock();
            player.DrawBlock(currentBlock);
            player.DrawBlockNext(panel2,nextBlock);
            player.setInfo(info,timer1.Interval);
            DrawInfo();   
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Block block;
            player.DeleteBlock(currentBlock);
            switch (e.KeyCode)
            {
                case Keys.S:
                    block = player.MoveLeft(ref currentBlock);
                    player.DrawBlock(block);
                    break;
                case Keys.F:
                    block = player.MoveRight(ref currentBlock);
                    player.DrawBlock(block);
                    break;
                case Keys.C:

                    block = player.MoveDown(ref currentBlock);
                    player.DrawBlock(block);
                    break;
                case Keys.A:
                    block = player.Rotate(ref currentBlock);
                    player.DrawBlock(block);
                    break;
                default:
                    break;
            }
        }
        
       
        public void DrawInfo()
        {
            label1.Text = info.Score.ToString();
            label2.Text = info.Speed.ToString();
            label3.Text = info.Level.ToString();
        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
            player.DeleteBlock(currentBlock);
            player.DrawBlock(player.MoveDown(ref currentBlock));
            if (player.ConditionDown(currentBlock) == false)
            {
                nextnextBlock = player.CreatBlock();
                //nextBlock = player.CreatBlock();
                player.DrawBlockNext(panel2,nextnextBlock);
                player.DrawBlockInMap(currentBlock);
                int kq = player.Check(currentBlock,info);
                DrawInfo();
                player.DrawBlock(currentBlock);
                currentBlock = nextBlock;
                nextBlock = nextnextBlock;
                //player.Draw();
                timer1.Interval = info.Speed;
            }

        }
    }
}
