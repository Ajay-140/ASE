using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASEProject
{
    public partial class Form1 : Form
    {

        //canvaslock
        private readonly object canvasLock = new object();
        public Form1()
        {
            InitializeComponent();

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            //initialise rich text box to use as drawing section
            richTextBox1.Paint += RichTextBox1_Paint;
            richTextBox1.MouseDown += RichTextBox1_MouseDown;
            richTextBox1.MouseMove += RichTextBox1_MouseMove;
            richTextBox1.MouseUp += RichTextBox1_MouseUp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = ("No double clicking!");
            if (pictureBox1.Image == null)
            {
                pictureBox1.Location = new Point(10, 10);
            }
            //shapes creating on right panel
            using (var graphics = Graphics.FromImage(pictureBox1.Image))
            {

                graphics.Clear(Color.White);

                if ("circle".Equals(textBox1.Text))
                {
                    graphics.FillEllipse(Brushes.Aquamarine, 10, 10, 100, 100);
                }
                else if ("square".Equals(textBox1.Text))
                {
                    graphics.FillRectangle(Brushes.CornflowerBlue, 10, 10, 100, 100);
                }
                //triangle creation values, points need moving to position where needed
                else if ("triangle".Equals(textBox1.Text))
                {
                    Point[] trianglePoints = new Point[]
                    {
                           new Point(10, 110), // Vertex 1
                           new Point(60, 10),  // Vertex 2
                           new Point(110, 110) // Vertex 3
                    };

                    graphics.FillPolygon(Brushes.Teal, trianglePoints);
                }


                pictureBox1.Refresh();
            }
        }




        private bool isDrawing = false;
        private Point previousPoint;
        private Pen drawingPen = new Pen(Color.Black, 2);


        //rich text box with help for flickering and pen leak
        private void RichTextBox1_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            }
            richTextBox1.Refresh();

        }

        private void RichTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            previousPoint = e.Location;
        }

        private void RichTextBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                using (Graphics g = richTextBox1.CreateGraphics())
                using (Pen tempPen = new Pen(drawingPen.Color, drawingPen.Width))
                {
                    g.DrawLine(drawingPen, previousPoint, e.Location);
                    previousPoint = e.Location;
                }
            }
        }

        private void RichTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        private void buttonChooseColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                drawingPen.Color = colorDialog1.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Show the ColorDialog when the button is clicked
            DialogResult result = colorDialog1.ShowDialog();

            // Checks that the user clicked OK in the Color Dialog
            if (result == DialogResult.OK)
            {
                // get the chosen color from the Color Dialog
                Color selectedColor = colorDialog1.Color;

                // use selected color like change pen colour or button colour
                button3.BackColor = selectedColor;
                drawingPen.Color = selectedColor;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            double area = 140 * 140 * math.PI;
            math.isEven(20);


            //threading
            // Initialize and start the threads
            Thread thread1 = new Thread(ProgramThread1);
            Thread thread2 = new Thread(ProgramThread2);

            thread1.Start();
            thread2.Start();

        }

        private void ProgramThread1()
        {
            while (true)
            {
                // Logic for Thread 1
                string outputText = "Thread 1 - Chocolate World";

                // Update the shared canvas
                UpdateCanvas(outputText);

                Thread.Sleep(10); // Simulate some processing time
            }
        }

        private void ProgramThread2()
        {
            while (true)
            {
                // Logic for Thread 2
                string outputText = "Thread 2 - Processing more chocolate intake";

                // Update the shared canvas
                UpdateCanvas(outputText);

                Thread.Sleep(10); // Simulate some processing time
            }
        }

        private void UpdateCanvas(string text)
        {
            lock (canvasLock)//Canvaslock
            {
                // Thread-safe access to the canvas
                BeginInvoke((Action)(() =>
                {
                    // Update the canvas or output window
                    richTextBox1.AppendText(text + Environment.NewLine);
                }));
            }
        }

        
       
    }
}

