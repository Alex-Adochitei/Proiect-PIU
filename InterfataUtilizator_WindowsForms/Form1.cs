using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibrarieModele;
using NivelStocareDate;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Form1 : Form
    {
        private Label lblDenumire;
        private TextBox txtDenumire;
        private Label lblProducator;
        private TextBox txtProducator;
        private Label lblTip;
        private TextBox txtTip;
        private Label lblPret;
        private TextBox txtPret;
        private Label lblStoc;
        private TextBox txtStoc;
        private const int LATIME_CONTROL = 150;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 170;
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            this.ForeColor = Color.Black;
            this.BackColor = Color.Gray;
            this.Text = "INFORMATII MAGAZIN";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            //adaugare control de tip Label pentru 'Denumire';
            lblDenumire = new Label();
            lblDenumire.Width = LATIME_CONTROL;
            lblDenumire.Text = "Denumire:";
            lblDenumire.BackColor = Color.LightGray;
            this.Controls.Add(lblDenumire);

            //adaugare control de tip TextBox pentru 'Denumire';
            txtDenumire = new TextBox();
            txtDenumire.Width = LATIME_CONTROL;
            txtDenumire.Left = DIMENSIUNE_PAS_X;
            txtDenumire.BackColor = Color.LightGray;
            this.Controls.Add(txtDenumire);


            //adaugare control de tip Label pentru 'Producator';
            lblProducator= new Label();
            lblProducator.Width = LATIME_CONTROL;
            lblProducator.Text = "Producator:";
            lblProducator.Top = DIMENSIUNE_PAS_Y;
            lblProducator.BackColor = Color.LightGray;
            this.Controls.Add(lblProducator);

            //adaugare control de tip TextBox pentru 'Producator'
            txtProducator = new TextBox();
            txtProducator.Width = LATIME_CONTROL;
            txtProducator.Location = new Point(DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y);
            txtProducator.BackColor = Color.LightGray;
            this.Controls.Add(txtProducator);


            //adaugare control de tip Label pentru 'Tip';
            lblTip = new Label();
            lblTip.Width = LATIME_CONTROL;
            lblTip.Text = "Tip:";
            lblTip.Top = 2 * DIMENSIUNE_PAS_Y;
            lblTip.BackColor = Color.LightGray;
            this.Controls.Add(lblTip);

            //adaugare control de tip TextBox pentru 'Tip'
            txtTip = new TextBox();
            txtTip.Width = LATIME_CONTROL;
            txtTip.Location = new Point(DIMENSIUNE_PAS_X, 2 * DIMENSIUNE_PAS_Y);
            txtTip.BackColor = Color.LightGray;
            this.Controls.Add(txtTip);


            //adaugare control de tip Label pentru 'Pret';
            lblPret = new Label();
            lblPret.Width = LATIME_CONTROL;
            lblPret.Text = "Pret:";
            lblPret.Top = 3 * DIMENSIUNE_PAS_Y;
            lblPret.BackColor = Color.LightGray;
            this.Controls.Add(lblPret);

            //adaugare control de tip TextBox pentru 'Pret'
            txtPret = new TextBox();
            txtPret.Width = LATIME_CONTROL;
            txtPret.Location = new Point(DIMENSIUNE_PAS_X, 3 * DIMENSIUNE_PAS_Y);
            txtPret.BackColor = Color.LightGray;
            this.Controls.Add(txtPret);


            //adaugare control de tip Label pentru 'Stoc';
            lblStoc = new Label();
            lblStoc.Width = LATIME_CONTROL;
            lblStoc.Text = "Stoc:";
            lblStoc.Top = 4 * DIMENSIUNE_PAS_Y;
            lblStoc.BackColor = Color.LightGray;
            this.Controls.Add(lblStoc);

            //adaugare control de tip TextBox pentru 'Stoc'
            txtStoc = new TextBox();
            txtStoc.Width = LATIME_CONTROL;
            txtStoc.Location = new Point(DIMENSIUNE_PAS_X, 4 * DIMENSIUNE_PAS_Y);
            txtStoc.BackColor = Color.LightGray;
            this.Controls.Add(txtStoc);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Doriti sa salvati datele?", "Salvare date", MessageBoxButtons.YesNo);    
            if (result == DialogResult.Yes)
            {
                string denumire = txtDenumire.Text;
                string producator = txtProducator.Text;
                string tip = txtTip.Text;
                int pret = Convert.ToInt32(txtPret.Text);
                int stoc = Convert.ToInt32(txtStoc.Text);
                Aliment p = new Aliment(denumire, producator, tip, pret, stoc);
                AdministrareAlimente_FisierText adminAlimente = new AdministrareAlimente_FisierText("Alimente.txt");
                adminAlimente.AddAliment(p);
                MessageBox.Show("Datele au fost salvate!");
            }
            else
            {
                MessageBox.Show("Datele nu au fost salvate!");
            }
            this.Close();
        }
    }
}
