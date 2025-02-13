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

            UcitajComboBox();

        }

        private void UcitajComboBox()
        {
            cbStudent.DataSource = db.Studenti.ToList();

            cbNastava.DataSource = db.NastavaIB180079
                .Include(x => x.Predmet)
                .Where(x => x.ProstorijaId == odabranaProstorija.Id)
                .ToList();

            cbNastava.DisplayMember = "Oznaka";
        }

        private void cbNastava_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajPrisustva();
        }

        private void UcitajPrisustva()
        {

            var odabranaNastava = cbNastava.SelectedItem as NastavaIB180079;

            prisustva = db.PrisustvoIB180079
                //.Include(x=> x.Nastava).ThenInclude(x=> x.Predmet)
                .Include(x => x.Nastava.Predmet)
                .Include(x => x.Student)
                .Where(x => x.NastavaId == odabranaNastava.Id)
                .ToList();

            // Id NastavaId StudentId

            // Id PredmetId ProstorijaId Vrijeme Dan Oznaka

            // Id Naziv Semestar

            // Id Ime Prezime Indeks Datu....


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
                var nastava = cbNastava.SelectedItem as NastavaIB180079;

                //                 5 == 5
                if (prisustva.Count() == odabranaProstorija.Kapacitet)
                {
                    MessageBox.Show($"Nastava je popunjena", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (prisustva.Exists(x => x.StudentId == student.Id))
                {
                    MessageBox.Show($"Student {student.Ime} {student.Prezime} je već evidentiran na stavi.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    var novoPrisustvo = new PrisustvoIB180079()
                    {

                        StudentId = student.Id,
                        NastavaId = nastava.Id
                    };

                    db.PrisustvoIB180079.Add(novoPrisustvo);
                    db.SaveChanges();

                }



                UcitajPrisustva();


            }
        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(cbNastava, err, Kljucevi.ReqiredValue);
        }

        private void btnGenerisi_Click(object sender, EventArgs e)
        {
            // 1. dio
            // -- validacija
            // -- pokretanje i kreiranje threada
            // -- sve sto je vezano za combo box 

            if (ValidirajMultithreading())
            {
                var student = cbStudent.SelectedItem as Student;
                var nastava = cbNastava.SelectedItem as NastavaIB180079;

                Thread t1 = new Thread(() => GenerisiPrisustva(student, nastava));
                t1.Start(); 

            }


        }

        private void GenerisiPrisustva(Student student, NastavaIB180079 nastava)
        {
            // 2. dio
            // -- pohrane, kalk, sleep


            var broj = int.Parse(txtBroj.Text);
            var info = "";

            for (int i = 0; i < broj; i++)
            {
                Thread.Sleep(300);

                var novoPrisustvo = new PrisustvoIB180079()
                {
                    StudentId = student.Id,
                    NastavaId = nastava.Id
                };

                db.PrisustvoIB180079.Add(novoPrisustvo);
                db.SaveChanges();

                info += $"{DateTime.Now.ToString("dd.MM HH:mm:ss")} -> {student} za {nastava} {Environment.NewLine}";

            }


            Action action = () =>
            {
                // 3. dio
                // -- ispisi, mbox, ucitavanje

                UcitajPrisustva();
                MessageBox.Show($"Uspješno je generisano {broj} prisustava","Informacija",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtInfo.Text = info;    

            };
            BeginInvoke(action);

        }

        private bool ValidirajMultithreading()
        {
            return Validator.ProvjeriUnos(txtBroj, err, Kljucevi.ReqiredValue);
        }
    }
}
