using FIT.Data;
using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
using FIT.WinForms.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIT.WinForms.IspitIB180079
{
    public partial class frmPrisustvoIB180079 : Form
    {
        private ProstorijeIB180079 odabranaProstorija;
        DLWMSDbContext db = new DLWMSDbContext();
        List<PrisustvoIB180079> prisustva;

        public frmPrisustvoIB180079(ProstorijeIB180079 odabranaProstorija)
        {
            InitializeComponent();
            this.odabranaProstorija = odabranaProstorija;
        }

        private void frmPrisustvoIB180079_Load(object sender, EventArgs e)
        {
            dgvPrisustva.AutoGenerateColumns = false;
            lblNazivProstorije.Text = $"{odabranaProstorija.Naziv} - {odabranaProstorija.Oznaka}";

            cbNastava.DataSource = db.NastavaIB180079
                .Where(x => x.ProstorijaId == odabranaProstorija.Id)
                .ToList();

            cbNastava.DisplayMember = "Oznaka";

            cbStudent.DataSource = db.Studenti.ToList();


        }

        private void cbNastava_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajPrisustva();
        }

        private void UcitajPrisustva()
        {
            var odabranaNastava = cbNastava.SelectedItem as NastavaIB180079;


            // NastavaId
            // StudentId
            // ProstroijaId
            // PredmetId
            // Vrijeme
            // Dan
            // Naziv
            // Semestar
            // Vedad Keskin IB21321 

            prisustva = db.PrisustvoIB180079
                .Include(x => x.Nastava).ThenInclude(x => x.Predmet)
                .Include(x => x.Student)
                .Where(x => x.NastavaId == odabranaNastava.Id)
                .ToList();

            if (prisustva != null)
            {

                dgvPrisustva.DataSource = null;
                dgvPrisustva.DataSource = prisustva;

            }

            lblPrebrojavanje.Text = $"{prisustva.Count()}/{odabranaProstorija.Kapacitet}";

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {

            var student = cbStudent.SelectedItem as Student;
            var nastava = cbNastava.SelectedItem as NastavaIB180079;

            if (prisustva.Exists(x => x.StudentId == student.Id))
            {
                MessageBox.Show("Student je vec evideniran na nastavi", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //                         5    ==    5 
                if (odabranaProstorija.Kapacitet == prisustva.Count())
                {
                    MessageBox.Show("Kapacitet prostorije je popunjen", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var novoPrisustvo = new PrisustvoIB180079()
                    {
                        NastavaId = nastava.Id,
                        StudentId = student.Id
                    };


                    db.PrisustvoIB180079.Add(novoPrisustvo);
                    db.SaveChanges();

                }



            }




            UcitajPrisustva();


        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {
            // 1. DIO
            // -- async 
            // -- validacija
            // -- poziv threada
            // -- pokretanje threada
            // -- [sve sto je vezano za combobox]

            var student = cbStudent.SelectedItem as Student;


            if (Validiraj())
            {

                Thread thread = new Thread(() => GenerisiPrisustva(student));
                thread.Start();
            }

        }

        private void GenerisiPrisustva(Student? student)
        {
            // 2. DIO
            // -- pohrane osim pohrane iz combo boxa
            // -- kalkulacije
            // -- sleep

            var broj = int.Parse(txtBroj.Text);
            var info = "";

            var SveNastaveOdabraneProstorije = db.NastavaIB180079.Where(x => x.ProstorijaId == odabranaProstorija.Id).ToList();


            for (int i = 0; i < SveNastaveOdabraneProstorije.Count(); i++)
            {

                for (int j = 0; j < broj; j++)
                {

                    Thread.Sleep(300);

                    var novoPrisustvo = new PrisustvoIB180079()
                    {
                        StudentId = student.Id,
                        NastavaId = SveNastaveOdabraneProstorije[i].Id
                    };

                    info += $"{DateTime.Now.ToString("MM.dd HH:mm:ss")} -> {student} za {SveNastaveOdabraneProstorije[i]} {Environment.NewLine}";

                    db.PrisustvoIB180079.Add(novoPrisustvo);
                    db.SaveChanges();

                }

            }



            Action action = () =>
            {
                // 3. DIO
                // -- Ucitavanja
                // -- ispisi
                // -- mbox

                UcitajPrisustva();
                txtInfo.Text = info;
                MessageBox.Show($"Generisana su prisustva","Informacija",MessageBoxButtons.OK,MessageBoxIcon.Information);
                


            };
            BeginInvoke(action);





        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(txtBroj, err, Kljucevi.ReqiredValue);
        }
    }
}
