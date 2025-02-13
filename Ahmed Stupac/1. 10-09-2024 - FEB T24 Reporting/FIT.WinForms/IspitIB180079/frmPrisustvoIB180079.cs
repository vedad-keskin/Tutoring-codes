using FIT.Data;
using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
using FIT.WinForms.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            cbStudent.DataSource = db.Studenti.ToList();

            cbNastava.DataSource = db.NastavaIB180079
                .Where(x => x.ProstorijaId == odabranaProstorija.Id)
                .ToList();

            cbNastava.DisplayMember = "Oznaka";


        }

        private void cbNastava_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajPrisutva();
        }

        private void UcitajPrisutva()
        {

            var odabranaNastava = cbNastava.SelectedItem as NastavaIB180079;

            // Id
            // NastavaId
            // StudentId
            // Id
            // Vrijeme
            // Dan
            // Oznaka
            // Id
            // Ime
            // Prezime
            // Indeks
            // Naziv
            // Id
            // Semestar

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

        private void button1_Click(object sender, EventArgs e)
        {
            var nastava = cbNastava.SelectedItem as NastavaIB180079;
            var student = cbStudent.SelectedItem as Student;


            if (prisustva.Exists(x => x.StudentId == student.Id))
            {
                MessageBox.Show("Student je vec dodan");
            }
            else
            {
                if (odabranaProstorija.Kapacitet == prisustva.Count())
                {
                    MessageBox.Show("Kapacitet prostorije je popunjen");

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

            UcitajPrisutva();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // 1. DIO
            // -- async 
            // -- validacija
            // -- postavljanje i pokretanje threada
            // -- ako imas combo box ucitaj ga ovdje 

            var student = cbStudent.SelectedItem as Student;
            var nastava = cbNastava.SelectedItem as NastavaIB180079;

            if (Validiraj())
            {
                Thread t1 = new Thread(() => GenerisiPrisustva(student,nastava));
                t1.Start();
            }


        }

        private void GenerisiPrisustva(Student? student, NastavaIB180079? nastava)
        {
            // 2. DIO 
            // -- pohrane
            // -- kalkulacije
            // -- sleep

            var broj = int.Parse(txtBroj.Text);
            var info = "";


            for (int i = 0; i < broj; i++)
            {
                Thread.Sleep(300);


                var novoPrisustvo = new PrisustvoIB180079()
                {
                    NastavaId = nastava.Id,
                    StudentId = student.Id
                };
                db.PrisustvoIB180079.Add(novoPrisustvo);  
                db.SaveChanges();

                info += $"{DateTime.Now.ToString("dd.MM HH:mm:ss")} -> {student} za {nastava} {Environment.NewLine}";

            }





            Action action = () =>
            {
                // 3. DIO
                // -- ispis
                // -- ucitavanja
                // -- mbox

                UcitajPrisutva();
                MessageBox.Show($"Generisali ste {broj} zapisa");
                txtInfo.Text = info;

            };
            BeginInvoke(action);


        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(txtBroj, err, Kljucevi.ReqiredValue);
        }
    }
}
