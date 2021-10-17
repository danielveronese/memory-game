using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryMatchingGame
{
    public partial class MemoryGame : Form
    {
        //Inizializza le variabili 
        Random location = new Random(); //Cambia posizione in modo casuale
        List<Point> points= new List<Point>(); // Per memorizzare la posizione delle immagini
        PictureBox FlippedImage1;
        PictureBox FlippedImage2;
        int FlippedCount = 0;
        int LevelUp = 30;
        int TimeLevel = 60;
        int Score = 0;
       
       

        
        public MemoryGame()
        {
            InitializeComponent();
         

        }

        private void MemoryGame_Load(object sender, EventArgs e)
        {
            label1.Text = "3"; //Etichetta Mostra il tempo prima che le carte vengano girate in modalità Coperta
            foreach (PictureBox picture in GamePanel.Controls)
            {

                picture.Enabled = false;
                points.Add(picture.Location);
            }
            foreach (PictureBox picture in GamePanel.Controls)
            {  //Randomizzazione delle immagini
                int next = location.Next(points.Count);
                Point p = points[next];
                picture.Location = p;
                points.Remove(p);
                
            }

            ScoreTimer.Start();
            CountdownTimer.Start();
            img1.Image = Properties.Resources.img1;
            dupimg1.Image = Properties.Resources.img1;
            img2.Image = Properties.Resources.img2;
            dupimg2.Image = Properties.Resources.img2;
            img3.Image = Properties.Resources.img3;
            dupimg3.Image = Properties.Resources.img3;
            img4.Image = Properties.Resources.img4;
            dupimg4.Image = Properties.Resources.img4;
            img5.Image = Properties.Resources.img5;
            dupimg5.Image = Properties.Resources.img5;
            img6.Image = Properties.Resources.img6;
            dupimg6.Image = Properties.Resources.img6;
            img7.Image = Properties.Resources.img7;
            dupimg7.Image = Properties.Resources.img7;
            img8.Image = Properties.Resources.img8;
            dupimg8.Image = Properties.Resources.img8;
            img9.Image = Properties.Resources.img9;
            dupimg9.Image = Properties.Resources.img9;
            img10.Image = Properties.Resources.img10;
            dupimg10.Image = Properties.Resources.img10;
            
        }
       
        private void resetButton_Click(object sender, EventArgs e)
        {   //Reimposta tutti i valori
            resetButton.BackColor = Color.Transparent;
            resetButton.Text = "Play Again";
            ScoreCounter.Text = "0";
            timeLeft.Text = "60";
            levelValue.Text = "1";
            //Riavvio del gioco
            MemoryGame_Load(sender, e);
        }

        private void ScoreTimer_Tick(object sender, EventArgs e)
        {
            ScoreTimer.Stop();
            foreach (PictureBox picture in GamePanel.Controls)
            {   //Riportare tutte le carte in modalità coperta
                picture.Enabled = true;
                picture.Cursor = Cursors.Hand;
                picture.Image = Properties.Resources.cover;
            }
            
        }


        private void CountdownTimer_Tick(object sender, EventArgs e)
        {   //Conto alla rovescia per la visualizzazione delle immagini all'inizio del gioco
            int timer = Convert.ToInt32(label1.Text);
            timer -= 1;
            label1.Text = Convert.ToString(timer);
            if(timer==0)
            {
                CountdownTimer.Stop();
                TimeRemaining.Start();
            }
        }
        private void TimeRemaining_Tick(object sender, EventArgs e)
        {   //Timer per mostrare quanto tempo è rimasto per completare il livello
            int timer = Convert.ToInt32(timeLeft.Text);
            timer -= 1;
            timeLeft.Text = Convert.ToString(timer);
            if (timer == 0)
            {
                TimeRemaining.Stop();
                MessageBox.Show("You Scored "+ScoreCounter.Text+" at level : "+levelValue.Text);
                ScoreCounter.Text = "0";
                resetButton.BackColor = Color.Red;
                resetButton.Text = "Play Again?";
            }
        }

        

        private void changeLevel()
        {
            //Aumenta il livello del gioco aumentando il punteggio richiesto e diminuendo il limite di tempo
            Score += Convert.ToInt32(ScoreCounter.Text);
            MessageBox.Show("Next Level!");
            if(Convert.ToInt32(ScoreCounter.Text) >= LevelUp)
            {
                ScoreCounter.Text = "0";
                TimeLevel -= 5;
                timeLeft.Text = Convert.ToString(TimeLevel);
                levelValue.Text = Convert.ToString(Convert.ToInt32(levelValue.Text) + 1);
                LevelUp += 5;
                if(TimeLevel <=15)
                {
                    MessageBox.Show("Thanks for Playing! You've completed the game");
                    Application.Exit();
                }
                MemoryGame_Load(this, null);
            }
            else
            {
                MessageBox.Show("Game Over! You didn't score enough to go to the next level. Total Score -> "+Score);
                resetButton.BackColor = Color.Red;
                resetButton.Text = "Play Again?";
            }
        }
        //Clic su eventi per tutti i Picturebox
        #region Cards
        private void img1_Click(object sender, EventArgs e)
        {
            img1.Image = Properties.Resources.img1;
            checkImages(img1, dupimg1);
        }

        private void img2_Click(object sender, EventArgs e)
        {
            img2.Image = Properties.Resources.img2;
            checkImages(img2, dupimg2);
        }

        private void img3_Click(object sender, EventArgs e)
        {
            img3.Image = Properties.Resources.img3;
            checkImages(img3, dupimg3);
        }

        private void img4_Click(object sender, EventArgs e)
        {
            img4.Image = Properties.Resources.img4;
            checkImages(img4, dupimg4);
        }

        private void img5_Click(object sender, EventArgs e)
        {
            img5.Image = Properties.Resources.img5;
            checkImages(img5, dupimg5);
        }

        private void img6_Click(object sender, EventArgs e)
        {
            img6.Image = Properties.Resources.img6;
            checkImages(img6, dupimg6);
        }

        private void img7_Click(object sender, EventArgs e)
        {
            img7.Image = Properties.Resources.img7;
            checkImages(img7, dupimg7);
        }

        private void img8_Click(object sender, EventArgs e)
        {
            img8.Image = Properties.Resources.img8;
            checkImages(img8, dupimg8);
        }

        private void img9_Click(object sender, EventArgs e)
        {
            img9.Image = Properties.Resources.img9;
            checkImages(img9, dupimg9);
        }

        private void img10_Click(object sender, EventArgs e)
        {
            img10.Image = Properties.Resources.img10;
            checkImages(img10, dupimg10);
        }


        private void dupimg1_Click(object sender, EventArgs e)
        {
            dupimg1.Image = Properties.Resources.img1;
            checkImages(dupimg1, img1);
        }


        private void dupimg2_Click(object sender, EventArgs e)
        {
            dupimg2.Image = Properties.Resources.img2;
            checkImages(dupimg2, img2);
        }

        private void dupimg3_Click(object sender, EventArgs e)
        {
            dupimg3.Image = Properties.Resources.img3;
            checkImages(dupimg3, img3);
        }

        private void dupimg4_Click(object sender, EventArgs e)
        {
            dupimg4.Image = Properties.Resources.img4;
            checkImages(dupimg4, img4);
        }

        private void dupimg5_Click(object sender, EventArgs e)
        {
            dupimg5.Image = Properties.Resources.img5;
            checkImages(dupimg5, img5);
        }

        private void dupimg6_Click(object sender, EventArgs e)
        {
            dupimg6.Image = Properties.Resources.img6;
            checkImages(dupimg6, img6);
        }

        private void dupimg7_Click(object sender, EventArgs e)
        {
            dupimg7.Image = Properties.Resources.img7;
            checkImages(dupimg7, img7);
        }

        private void dupimg8_Click(object sender, EventArgs e)
        {
            dupimg8.Image = Properties.Resources.img8;
            checkImages(dupimg8, img8);
        }

        private void dupimg9_Click(object sender, EventArgs e)
        {
            dupimg9.Image = Properties.Resources.img9;
            checkImages(dupimg9, img9);
        }

        private void dupimg10_Click(object sender, EventArgs e)
        {
            dupimg10.Image = Properties.Resources.img10;
            checkImages(dupimg10, img10);
        }
        #endregion

        private void FlipTime_Tick(object sender, EventArgs e)
        {
            //Timer per capovolgere le immagini sull'immagine di copertina
            FlipTime.Stop();
            FlippedImage1.Image = Properties.Resources.cover;
            FlippedImage2.Image = Properties.Resources.cover;
            FlippedImage1 = null;
            FlippedImage2 = null;

        }
        private void checkImages(PictureBox pic1, PictureBox pic2)
        {
            //Controlla se le immagini sono le stesse in entrambi i PictureBox

            if (FlippedImage1 == null)
            {
                FlippedImage1 = pic1;
            }
            else if (FlippedImage1 != null && FlippedImage2 == null)
            {
                if(FlippedImage1 != pic1)
                    FlippedImage2 = pic1;
            }
            if (FlippedImage1 != null && FlippedImage2 != null)
            {
                if (FlippedImage1.Tag == FlippedImage2.Tag)
                {
                    FlippedImage1 = null;   //Riassegnazione a null per il prossimo set di valori
                    FlippedImage2 = null;   //Come sopra
                    pic2.Enabled = false;   //Per evitare di fare clic sull'immagine
                    pic1.Enabled = false;   //Come sopra
                    ++FlippedCount;         //Per controllare se il gioco è finito controllando se tutte le immagini sono state capovolte
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10); //Aumento del punteggio se c'è una corrispondenza corretta
                }
                else
                {
                    FlipTime.Start();
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5); //Decremento punteggio se c'è una corrispondenza sbagliata
                }
            
            }
           
            if (FlippedCount == 10)
            {   //se tutte le immagini vengono capovolte, ripristina il valore di conteggio e chiama changeLevel() per controllare e passare al livello successivo
                FlippedCount = 0;
                changeLevel();
            }





        }

        private void MemoryGame_Load_1(object sender, EventArgs e)
        {

        }
    }
}
