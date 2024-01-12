using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Page_Nation
{

    
    public partial class Form1 : Form
    {
        private int totalBtns ;
        private int viewBtns ;
        private int nextCount = 1;
        private int curBtn=0;

        Button b = new Button();
        private Point sLoc = new Point(70, 3);
        private Point absLoc;
        List<Button> buttons = new List<Button>();

        private string[] locArray = new string[] { "C:/Users/Illamugundhan/Desktop/pictures/pic1.jpg", "C:/Users/Illamugundhan/Desktop/pictures/pic2.jpg", "C:/Users/Illamugundhan/Desktop/pictures/pic3.jpg", "C:/Users/Illamugundhan/Desktop/pictures/pic4.jpg" };

        private delegate void newDelegate(object obj,int n);
        private event newDelegate display;
        List<picture> pList = new List<picture>();

        public Form1()
        {
            InitializeComponent();
            EnterBtn.Click += OnClickEnterBtn;
            restartBtn.Click += OnClickRestart;
            nextBtn.Click += OnClickNextBtn;
            backBtn.Click += OnClickBackBtn;
            display += ShowName;


            
        }

        private void OnClickEnterBtn(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            nextCount = 1;
            curBtn = 0;

            //Button b = new Button();
            sLoc = new Point(70, 3);
            
            buttons = new List<Button>();

            if(textBox1.Text != "" && textBox2.Text!="" && (Convert.ToInt32(textBox1.Text)>= Convert.ToInt32(textBox2.Text)))
            {
                totalBtns = Convert.ToInt32(textBox1.Text);
                viewBtns = Convert.ToInt32(textBox2.Text);

                sLoc.X = (((panel1.Width - (((Convert.ToInt32(viewBtns+2)))) * 64))/2 ) -25;
                absLoc = sLoc;
                absLoc.X -= 64;

                for(int i=0;i<totalBtns;i++)
                {
                    picture p = new picture();
                    p.ID = i+1;
                    p.Location = locArray[i % 4];

                    pList.Add(p);
                }

            }
            else
            {
                MessageBox.Show("Enter valid inputs");
                return;
            }
            if(viewBtns>7)
            {
                MessageBox.Show("Enter view button lesser than 7");
                return;
            }

            b = new Button
            {
                Location = sLoc,
                Size = new Size(64, 50),
                Text = "..."
            };
            b.Click += OnClickBtn;
            panel1.Controls.Add(b);
            buttons.Add(b);
            sLoc.X += 70;
            b.Visible = false;
            for (int i=1;i<=viewBtns;i++)
            {
                b = new Button
                {
                    Location = sLoc,
                    Size = new Size(64, 50),

                    Text = i + ""
                };
                b.Click += OnClickBtn;
                panel1.Controls.Add(b);
                buttons.Add(b);
                sLoc.X += 70;

            }
            b = new Button
            {
                Location = sLoc,
                Size = new Size(64, 50),
                Text = "..."
            };
            b.Click += OnClickBtn;
            panel1.Controls.Add(b);
            buttons.Add(b);
            sLoc.X += 70;
            //buttons[0].Focus();



            //for (int i=totalBtns-viewBtns+1;i<=totalBtns;i++)
            //{
            //    b = new Button
            //    {
            //        Location = sLoc,
            //        Size = new Size(64, 50),

            //        Text = i + ""

            //    };
            //    b.Click += OnClickBtn;
            //    panel1.Controls.Add(b);
            //    buttons.Add(b);
            //    sLoc.X += 70;
            //}
        }

        private void OnClickRestart(object sender, EventArgs e)
        {
            this.Close();

            System.Diagnostics.Process.Start(Application.ExecutablePath);
        }

        
        int ctrB = 0;
        private void OnClickNextBtn(object sender , EventArgs e)
        {
            //curBtn++;
            //int startBtnIter = curBtn;
            //for(int ctr=0;ctr<viewBtns;ctr++)
            //{
            //    buttons[ctr + 1].Text = startBtnIter + "";
            //}
            if (ctrB == totalBtns)
            {
                return;
            }
            int a = nextCount;
            if (buttons[viewBtns].Text == totalBtns + "")
            {
                buttons[viewBtns].Focus();

                return;
            }
            //for(int i=0;i<viewBtns;i++)
            //{
            //    buttons[i].Text = (Convert.ToInt32((buttons[i]).Text) + 1 )+"";

            //}
            //nextCount++;

            if (buttons[nextCount - 1].Text == Convert.ToString(viewBtns))
            {
                buttons[0].Visible = true;
            }
            if (buttons[buttons.Count - 2].Text == (totalBtns - 1 + ""))
            {
                buttons[buttons.Count - 1].Visible = false;
            }
            if (ctrB >= totalBtns)
            {
                //ctr = totalBtns;
                buttons[buttons.Count - 2].Focus();
                //ShowName(null, buttons.Count-2);
                return;
            }
            if (nextCount == viewBtns + 1)
            {
                for (int i = 1; i <= viewBtns; i++)
                {

                    buttons[i].Text = (Convert.ToInt32((buttons[i]).Text) + 1) + "";
                }
                buttons[nextCount - 1].Focus();
                //ShowName(null, nextCount-1);
                //nextCount = 0;

            }
            else
            {
                buttons[nextCount].Focus();
                //ShowName(null, nextCount);
                nextCount++;
            }
            ctrB++;
            //if (ctrB >= totalBtns)
            //    nextCount--;

            picfocus();



        }
        bool isL = false;
        private void OnClickBackBtn(object sender, EventArgs e)
        {

            
            //if (nextCount < 1) nextCount++;
            if (ctrB<=1)
            {
                buttons[1].Focus();
                return;
            }

            if(nextCount==2)
            {
                for(int i=1;i<=viewBtns;i++)
                {
                    buttons[i].Text = (Convert.ToInt32((buttons[i]).Text) -1 ) + "";
                }
                buttons[1].Focus();
            }
            else
            {
                buttons[nextCount - 1].Focus();
                //ShowName(null, (isL) ? nextCount - 1 : nextCount - 2);
                nextCount--;
                //isL = false;
            }
            ctrB--;
            if (buttons[1].Text == (totalBtns - viewBtns + ""))
            {
                buttons[buttons.Count - 1].Visible = true;
            }
            if (buttons[1].Text == "1")
            {
                buttons[0].Visible = false;
            }

            picfocus();
        }

        private void OnClickBtn(object sender, EventArgs e)
        {
            if (int.TryParse((sender as Button).Text, out _))
            {

                display(sender, Convert.ToInt32((sender as Button).Text));
                //(sender as Button).Focus();
                curBtn = Convert.ToInt32((sender as Button).Text);
                for (int i = 0; i < buttons.Count; i++)
                {
                    if (buttons[i].Text == (sender as Button).Text)
                    {
                        nextCount = i + 1;
                    }
                }
                //nextCount = curBtn%viewBtns -1;
                //ctr = curBtn;
                ctrB = Convert.ToInt32((sender as Button).Text);
                isL = false;
                picfocus();


            }
            else
            {
                if((sender as Button)==buttons[buttons.Count-1])
                {
                    int val = totalBtns;
                    for(int i=buttons.Count-2;i>0;i--)
                    {
                        buttons[i].Text = val-- +"";
                        
                    }
                    buttons[buttons.Count - 1].Visible = false;
                    buttons[0].Visible = true;
                    nextCount = viewBtns;
                    ctrB = totalBtns-1;
                    isL = true;
                    buttons[nextCount].Focus();
                    picfocus();


                }
                else
                {
                    //int val = viewBtns;
                    for (int i = 1; i<=viewBtns; i++)
                    {
                        buttons[i].Text = i + "";

                    }
                    buttons[0].Visible = false;
                    buttons[buttons.Count - 1].Visible = true;
                    nextCount = 2;
                    ctrB = 1;
                    picfocus();
                }
            }
        }
        private void ShowName(object sender, int i)
        {
            //MessageBox.Show("Page"+i);

            //pictureBox1.Image = Image.FromFile(pList[i-1].Location);
            //pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void picfocus()
        {
            int id = 0;
            
            foreach (Button btn in buttons)
            {
                if (btn.Focused)
                {
                    if (int.TryParse(btn.Text, out id)) ;
                    break;
                }
            }
            if (id > 0)
            {
                
                if (pictureBox1.Image!=null)
                {
                    Image i = pictureBox1.Image;
                    i.Dispose();
                }
                pictureBox1.Image = Image.FromFile(pList[id - 1].Location);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
    }
}
