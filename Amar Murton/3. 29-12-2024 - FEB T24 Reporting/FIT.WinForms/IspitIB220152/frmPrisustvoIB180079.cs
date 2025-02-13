using FIT.Data;
using FIT.Data.IspitIB220152;
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

namespace FIT.WinForms.IspitIB220152
{
    public partial class frmPrisustvoIB180079 : Form
    {
        private ProstorijeIB220152 odabranaProstorija;
        DLWMSDbContext db = new DLWMSDbContext();
        List<PrisustvoIB220152> prisustva;


        public frmPrisustvoIB180079(ProstorijeIB220152 odabranaProstorija)
        {
            InitializeComponent();
            this.odabranaProstorija = odabranaProstorija;
        }

        private void frmPrisustvoIB180079_Load(object sender, EventArgs e)
        {
            dgvPrisustva.AutoGenerateColumns = false;

            lblNazivProstorije.Text = $"{odabranaProstorija.Naziv} - {odabranaProstorija.Oznaka}";


            cbNastava.DataSource = db.NastavaIB220152
                .Where(x => x.ProstorijeId == odabranaProstorija.Id)
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

            var odabranaNastava = cbNastava.SelectedItem as NastavaIB220152;


            // Id
            // NastavaId
            // StudentId

            // + include Nastava

            // ProstorijaId
            // Vrijeme
            // Dan
            // PredmetId

            // + include Student

            // Ime, Prezime, Indeks, Datum... 

            // + include Predmet --> Naziv, Semestar, PredmetId

            prisustva = db.PrisustvoIB220152
                .Include(x => x.Nastava.Predmet)
                //.Include(x=> x.Nastava).ThenInclude(x=> x.Predmet)
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
            if (Validiraj())
            {

                var student = cbStudent.SelectedItem as Student;

                var nastava = cbNastava.SelectedItem as NastavaIB220152;

                if (prisustva.Exists(x => x.StudentId == student.Id))
                {
                    MessageBox.Show($"Student {student.Ime} {student.Prezime} je već dodan na nastavi", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                // 30 == 30 
                else if (odabranaProstorija.Kapacitet == prisustva.Count())
                {
                    MessageBox.Show("Kapacitet prostorije je popunjen", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    var novoPrisustvo = new PrisustvoIB220152()
                    {
                        StudentId = student.Id,
                        NastavaId = nastava.Id
                    };

                    db.PrisustvoIB220152.Add(novoPrisustvo);
                    db.SaveChanges();

                }




                UcitajPrisustva();



            }
        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(cbNastava, err, Kljucevi.ReqiredValue);
        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {
            // 1. dio
            // -- validacija
            // -- async 
            // -- pokretanje i kreiranje threada
            // -- pohrana ako je ona vezana za combo box iz baze 

            if (ValidirajMultithreading())
            {

                var student = cbStudent.SelectedItem as Student;
                var nastava = cbNastava.SelectedItem as NastavaIB220152;

                Thread t1 = new Thread(() => GenerisiPrisustva(student, nastava)  );
                t1.Start();


            }


        }

        private void GenerisiPrisustva(Student? student, NastavaIB220152? nastava)
        {
            // 2. dio
            // pohrane, kaluk, sleep

            var broj = int.Parse(txtBroj.Text);
            var info = "";




            for (int i = 0; i < broj; i++)
            {
                Thread.Sleep(300);

                var novoPrisustvo = new PrisustvoIB220152()
                {
                    StudentId = student.Id,
                    NastavaId = nastava.Id


                };

                db.PrisustvoIB220152.Add(novoPrisustvo);
                db.SaveChanges();


            }

            // 3. dio
            // -- ispise, mbox, ucitavanje

            Action action = () =>
            {

                MessageBox.Show($"Generisano je {broj} zapisa","Informacija",MessageBoxButtons.OK,MessageBoxIcon.Information);
                UcitajPrisustva();
            };
            BeginInvoke(action);




        }

        private bool ValidirajMultithreading()
        {
            return Validator.ProvjeriUnos(txtBroj, err, Kljucevi.ReqiredValue);
        }
    }
}
