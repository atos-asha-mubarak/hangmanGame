using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace HangMan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private System.Media.SoundPlayer mediaSoundPlayer = new System.Media.SoundPlayer();
        string w = "";
        List<Label> labels = new List<Label>();
        int missed = -1;
        string name = "dude";
        int choice = -1;
        int score = 0;

       

        enum bparts
        {
            Head, shirt, RightArm, LeftArm, RightLeg, LeftLeg,
        }

        

        void DrawBodyParts(bparts bp)
        {
           

            if (bp == bparts.Head)
                pictureBox1.Image = Image.FromFile("hung2.png");
            
            else if (bp == bparts.shirt)
                pictureBox1.Image = Image.FromFile("shirt.png");
            

            else if (bp == bparts.RightArm)
                pictureBox1.Image = Image.FromFile("rightarm.png");
            

            else if (bp == bparts.LeftArm)
                pictureBox1.Image = Image.FromFile("leftarm.png");
            

            else if (bp == bparts.RightLeg)
                pictureBox1.Image = Image.FromFile("rightleg.png");

            else if (bp == bparts.LeftLeg)
                pictureBox1.Image = Image.FromFile("leftleg.png");

            
        }


        void makelabels()
        {
            name = textBox1.Text;
            w = getRandomWords().ToLower();
            w.Replace(" ", "");


            char[] ch = w.ToCharArray();
            int space = 569 / ch.Length - 1;

            for (int i = 0; i < ch.Length - 1; i++)
            {

                labels.Add(new Label());
                labels[i].Location = new Point((i * space) + 10, 109);
                labels[i].Parent = gb2;
                labels[i].Text = "__";
                labels[i].BringToFront();
                labels[i].CreateControl();

            }

            label1.Text = "Length: " + (ch.Length - 1).ToString();

        }

        void Drawstick()
        {
            //Graphics hp = panel1.CreateGraphics();
            //Pen p = new Pen(Color.Black, 10);
            //hp.DrawLine(p, new Point(170, 337), new Point(170, 8));
            //hp.DrawLine(p, new Point(175, 8), new Point(105, 8));
            //hp.DrawLine(p, new Point(100, 0), new Point(100, 50));

            // a tryout only :P
        }


        string getRandomWords()
        {

            // Default is "Motivating Words" 0: Adjectives/ 1:Sports / 2:Animals / 
            // 3:countries /4:Motivating words/5:Action Words


            //If program didn't work you have to remove all commented lines , and read from WEB


            // WebClient wc = new WebClient();
            

            // string list = wc.DownloadString("http://dictionary-thesaurus.com/wordlists/MotivatingWords%28101%29.txt");

            string list="";

            if (choice == 0)
                // list = wc.DownloadString("http://dictionary-thesaurus.com/wordlists/Adjectives%2850%29.txt");

               
                list = System.IO.File.ReadAllText("adjectives.txt");


            else if (choice == 1)
                // list = wc.DownloadString("http://dictionary-thesaurus.com/wordlists/Sportsgames%28133%29.txt");

                list = System.IO.File.ReadAllText("sports.txt");

            else if (choice == 2)
                // list = wc.DownloadString("http://dictionary-thesaurus.com/wordlists/Animals%2865%29.txt");

                list = System.IO.File.ReadAllText("Animals.txt");


            else if (choice == 3)
                // list = wc.DownloadString("http://dictionary-thesaurus.com/wordlists/Countries%2893%29.txt");

                list = System.IO.File.ReadAllText("countries.txt");


            else if (choice == 4)
               // list = wc.DownloadString("http://dictionary-thesaurus.com/wordlists/MotivatingWords%28101%29.txt");

                list = System.IO.File.ReadAllText("motivating.txt");


            else if (choice == 5)
                // list = wc.DownloadString("http://dictionary-thesaurus.com/wordlists/ActionWords%28114%29.txt");

                list = System.IO.File.ReadAllText("actions.txt");


            string[] words = list.Split('\n');
            Random rand = new Random();
            return words[rand.Next(0, words.Length - 1)];
        }


        private void Form1_Shown(object sender, EventArgs e)
        {
            Drawstick();
            makelabels();
        }

        private void Letter_Click(object sender, EventArgs e)
        {


            try
            {
                char letter = textBox1.Text.ToLower().ToCharArray()[0];
                
                
                if (!char.IsLetter(letter))
                {
                    errorProvider1.BlinkRate = 100;
                    errorProvider1.SetError(textBox1, "Only a letter Dude!");
                }

                textBox1.Text = "";

                if (w.Contains(letter))
                {

                    string location = @"Backs.wav";
                    mediaSoundPlayer.SoundLocation = location;
                    mediaSoundPlayer.Play();

                    char[] LS = w.ToLower().ToCharArray();
                    for (int i = 0; i < LS.Length; i++)
                    {
                        if (LS[i] == letter)
                        {
                            labels[i].Text = letter.ToString();
                            answer.Image = Image.FromFile("okay.jpg");
                        }

                    }

                    foreach (Label l in labels)
                        if (l.Text == "__") return;
                    MessageBox.Show("You've Guessed it " + name + "\n\n You saved this innocent man", "Mabrook");
                    newgame();
                    score++;
                    label3.Text = "Score: " + score.ToString();



                }
                else
                {

                    string location = @"steak.wav";
                    mediaSoundPlayer.SoundLocation = location;
                    mediaSoundPlayer.Play();


                    answer.Image = Image.FromFile("wrong.GIF");
                    label2.Text += " " + letter.ToString() + " |";
                    missed++;
                    DrawBodyParts((bparts)missed);
                    if (missed == 5)
                    {
                        MessageBox.Show("You're so lucky " + name + ", you're not our Hangman! \n\n You've Lost :)\n\n Word Was: " + w);
                        newgame();
                    }

                }

                textBox1.Text = "";
            
        }

        catch(Exception X)
            {
        MessageBox.Show("Please enter a letter");
            }
    }

        void newgame()
        {
            getRandomWords();
            Drawstick();
            makelabels();
            label2.Text = "m i s s e d : ";
            textBox1.Text = "";
            missed = -1;
            pictureBox1.Image = Image.FromFile("hung1.png");
            
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            string location = @"Shot.wav";
            mediaSoundPlayer.SoundLocation = location;
            mediaSoundPlayer.Play();

            Form2 welcome = new Form2();
            welcome.ShowDialog();
            welcome.Dispose();

            
            choice = welcome.returnSelect();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("HangMan Version 1.0\n\nDeveloped & Designed by Jude Al-Safadi\n\nPlease visit my Website or Tweet a hello :D \n In Case you need any help \n http://Judesaf.com");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
