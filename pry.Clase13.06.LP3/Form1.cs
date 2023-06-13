using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pry.Clase13._06.LP3
{
    
    public partial class Form1 : Form
    {
        //Crea una variable para no renegar con ancho y alto en el for 
        const int ALTO = 40;
        const int ANCHO = 80;

        //Crea el objeto del grafico
        Graphics gra;
        //Crea el objeto de la clase
        clsCocheras Co;
        //Crea el objeto de la tabla 
        DataTable tco;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Crea fuente para ponerle nro a las cocheras 
            Font fuente = new Font("Verdana", 8, FontStyle.Bold);
            int x = 0;
            int y = 0;
            //Lo usa para darle el nro a cada cochera
            int nc = 0;

            //Crea la repetitiva para llenar èl picturbox con los circulos
            for (y = 0; y <= pictureBox1.Height - ALTO; y = y + ALTO)
            {
                for (x = 0; x <= pictureBox1.Width - ANCHO; x = x + ANCHO)
                {
                    nc++;
                    //Crea una variable de tipo registro y busca la cochera registrada en la BD 
                    DataRow fCo = tco.Rows.Find(nc);
                    //Si no la encuentra la pinta de verde
                    if (fCo == null)
                    {
                        gra.FillEllipse(Brushes.Green, x, y, ANCHO, ALTO);
                    }
                    else
                    //Si la encuentra la pinta de rojo 
                    {
                        gra.FillEllipse(Brushes.Red, x, y, ANCHO, ALTO);
                    }
                    
                    //Darle el nro a cada cochera
                    gra.DrawString(nc.ToString(), fuente, Brushes.Black, x +10, y + 10);
                }
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gra = pictureBox1.CreateGraphics();

            Co = new clsCocheras();
            tco = Co.GetCocheras();

        }
    }
}
