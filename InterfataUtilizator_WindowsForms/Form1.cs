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
using System.Configuration;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Form1 : Form
    {
        AdministrareAlimente_FisierText adminAliments;
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
        private Label[] lblsDenumire;
        private Label[] lblsProducator;
        private Label[] lblsPret;
        private const int LATIME_CONTROL = 150;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 170;
        public Form1()
        {
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            adminAliments = new AdministrareAlimente_FisierText(caleCompletaFisier);
            InitializeComponent();
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            this.ForeColor = Color.Black;
            this.BackColor = Color.Gray;
            this.Text = "INFORMAȚII MAGAZIN";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            lblProducator = new Label();
            lblProducator.Width = LATIME_CONTROL;
            lblProducator.Text = "Producător:";
            lblProducator.Left = 2 * DIMENSIUNE_PAS_X;
            lblProducator.ForeColor = Color.Black;
            lblProducator.BackColor = Color.LightGray;
            this.Controls.Add(lblProducator);
            lblDenumire = new Label();
            lblDenumire.Width = LATIME_CONTROL;
            lblDenumire.Text = "Denumire:";
            lblDenumire.Left = DIMENSIUNE_PAS_X;
            lblDenumire.ForeColor = Color.Black;
            lblDenumire.BackColor = Color.LightGray;
            this.Controls.Add(lblDenumire);
            lblPret = new Label();
            lblPret.Width = LATIME_CONTROL;
            lblPret.Text = "Preț:";
            lblPret.Left = 3 * DIMENSIUNE_PAS_X;
            lblPret.ForeColor = Color.Black;
            lblPret.BackColor = Color.LightGray;
            this.Controls.Add(lblPret);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SalvareAlimente();
            AfisareAlimente();
        }
        private void AfisareAlimente()
        {
            Aliment[] alimente = adminAliments.GetAlimente(out int nrAlimente);

            lblsDenumire = new Label[nrAlimente];
            lblsProducator = new Label[nrAlimente];
            lblsPret = new Label[nrAlimente];

            int i = 0;
            foreach (Aliment aliment in alimente)
            {
                //adaugare control de tip Label pentru numele studentilor;
                lblsDenumire[i] = new Label();
                lblsDenumire[i].Width = LATIME_CONTROL;
                lblsDenumire[i].Text = aliment.Denumire;
                lblsDenumire[i].Left = DIMENSIUNE_PAS_X;
                lblsDenumire[i].BackColor = Color.LightGray;
                lblsDenumire[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsDenumire[i]);

                //adaugare control de tip Label pentru prenumele studentilor
                lblsProducator[i] = new Label();
                lblsProducator[i].Width = LATIME_CONTROL;
                lblsProducator[i].Text = aliment.Producator;
                lblsProducator[i].Left = 2 * DIMENSIUNE_PAS_X;
                lblsProducator[i].BackColor = Color.LightGray;
                lblsProducator[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsProducator[i]);

                //adaugare control de tip Label pentru notele studentilor
                lblsPret[i] = new Label();
                lblsPret[i].Width = LATIME_CONTROL;
                lblsPret[i].Text = string.Join(" ", aliment.Pret);
                lblsPret[i].Left = 3 * DIMENSIUNE_PAS_X;
                lblsPret[i].BackColor = Color.LightGray;
                lblsPret[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsPret[i]);
                i++;
            }
        }
        private void SalvareAlimente()
        {
            //adaugare control de tip Label pentru 'Denumire';
            lblDenumire = new Label();
            lblDenumire.Width = LATIME_CONTROL;
            lblDenumire.Text = "Denumire:";
            lblDenumire.Left = DIMENSIUNE_PAS_X;
            lblDenumire.Top = 4 * DIMENSIUNE_PAS_Y;
            lblDenumire.BackColor = Color.LightGray;
            this.Controls.Add(lblDenumire);

            //adaugare control de tip TextBox pentru 'Denumire';
            txtDenumire = new TextBox();
            txtDenumire.Width = LATIME_CONTROL;
            txtDenumire.Location = new Point(2 * DIMENSIUNE_PAS_X, 4 * DIMENSIUNE_PAS_Y);
            txtDenumire.BackColor = Color.LightGray;
            this.Controls.Add(txtDenumire);


            //adaugare control de tip Label pentru 'Producator';
            lblProducator = new Label();
            lblProducator.Width = LATIME_CONTROL;
            lblProducator.Text = "Producător:";
            lblProducator.Left = DIMENSIUNE_PAS_X;
            lblProducator.Top = 5 * DIMENSIUNE_PAS_Y;
            lblProducator.BackColor = Color.LightGray;
            this.Controls.Add(lblProducator);

            //adaugare control de tip TextBox pentru 'Producator'
            txtProducator = new TextBox();
            txtProducator.Width = LATIME_CONTROL;
            txtProducator.Location = new Point(2 * DIMENSIUNE_PAS_X, 5 * DIMENSIUNE_PAS_Y);
            txtProducator.BackColor = Color.LightGray;
            this.Controls.Add(txtProducator);


            //adaugare control de tip Label pentru 'Tip';
            lblTip = new Label();
            lblTip.Width = LATIME_CONTROL;
            lblTip.Text = "Tip:";
            lblTip.Left = DIMENSIUNE_PAS_X;
            lblTip.Top = 6 * DIMENSIUNE_PAS_Y;
            lblTip.BackColor = Color.LightGray;
            this.Controls.Add(lblTip);

            //adaugare control de tip TextBox pentru 'Tip'
            txtTip = new TextBox();
            txtTip.Width = LATIME_CONTROL;
            txtTip.Location = new Point(2 * DIMENSIUNE_PAS_X, 6 * DIMENSIUNE_PAS_Y);
            txtTip.BackColor = Color.LightGray;
            this.Controls.Add(txtTip);


            //adaugare control de tip Label pentru 'Pret';
            lblPret = new Label();
            lblPret.Width = LATIME_CONTROL;
            lblPret.Text = "Preț:";
            lblPret.Left = DIMENSIUNE_PAS_X;
            lblPret.Top = 7 * DIMENSIUNE_PAS_Y;
            lblPret.BackColor = Color.LightGray;
            this.Controls.Add(lblPret);

            //adaugare control de tip TextBox pentru 'Pret'
            txtPret = new TextBox();
            txtPret.Width = LATIME_CONTROL;
            txtPret.Location = new Point(2 * DIMENSIUNE_PAS_X, 7 * DIMENSIUNE_PAS_Y);
            txtPret.BackColor = Color.LightGray;
            this.Controls.Add(txtPret);


            //adaugare control de tip Label pentru 'Stoc';
            lblStoc = new Label();
            lblStoc.Width = LATIME_CONTROL;
            lblStoc.Text = "Stoc:";
            lblStoc.Left = DIMENSIUNE_PAS_X;
            lblStoc.Top = 8 * DIMENSIUNE_PAS_Y;
            lblStoc.BackColor = Color.LightGray;
            this.Controls.Add(lblStoc);

            //adaugare control de tip TextBox pentru 'Stoc'
            txtStoc = new TextBox();
            txtStoc.Width = LATIME_CONTROL;
            txtStoc.Location = new Point(2 * DIMENSIUNE_PAS_X, 8 * DIMENSIUNE_PAS_Y);
            txtStoc.BackColor = Color.LightGray;
            this.Controls.Add(txtStoc);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Doriți să salvați datele?", "Salvare date", MessageBoxButtons.YesNo);    
            if (result == DialogResult.Yes)
            {
                string denumire = txtDenumire.Text;
                string producator = txtProducator.Text;
                string tip = txtTip.Text;
                int pret = Convert.ToInt32(txtPret.Text);
                int stoc = Convert.ToInt32(txtStoc.Text);
                Aliment aliment = new Aliment(denumire, producator, tip, pret, stoc);
                adminAliments.AddAliment(aliment);
                MessageBox.Show("Datele au fost salvate!");
            }
            else
            {
                MessageBox.Show("Datele nu au fost salvate!");
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
