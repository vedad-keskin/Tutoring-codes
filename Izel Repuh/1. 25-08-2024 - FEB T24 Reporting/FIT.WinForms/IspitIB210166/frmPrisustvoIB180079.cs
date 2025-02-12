using FIT.Data;
using FIT.Data.IspitIB210166;
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

namespace FIT.WinForms.IspitIB210166
{
    public partial class frmPrisustvoIB180079 : Form
    {
        private ProstorijeIB210166 odabranaProstorija;
        DLWMSDbContext db = new DLWMSDbContext();
        List<PrisustvoIB210166> prisustva;

        public frmPrisustvoIB180079(ProstorijeIB210166 odabranaProstorija)
        {
            InitializeComponent();
            this.odabranaProstorija = odabranaProstorija;
        }

        private void frmPrisustvoIB180079_Load(object sender, EventArgs e)
        {
            dgvPrisustva.AutoGenerateColumns = false;


            lblNazivProstorije.Text = $"{odabranaProstorija.Naziv} - {odabranaProstorija.Oznaka}";

            cbStudent.DataSource = db.Studenti.ToList();

            cbNastava.DataSource = db.NastavaIB210166
                .Where(x => x.ProstorijeId == odabranaProstorija.Id)
                .ToList();

            cbNastava.DisplayMember = "Oznaka";

        }
        private void cbNastava_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajPrisustva();
        }

        private void UcitajPrisustva()
        {
            var nastava = cbNastava.SelectedItem as NastavaIB210166;

            // Id , StudentId, NastavaId

            // NastavaId, Dan, Vrijeme, ProstroijaId, 
            // PredmetId, Naziv, Semestar

            // ime prezime indeks 

            prisustva = db.PrisustvoIB210166
                .Include(x => x.Nastava).ThenInclude(x => x.Predmet)
                //.Include(x=> x.Nastava.Predmet)
                .Include(x => x.Student)
                .Where(x => x.NastavaId == nastava.Id)
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
            if (Validiraj())
            {
                var nastava = cbNastava.SelectedItem as NastavaIB210166;
                var student = cbStudent.SelectedItem as Student;


                if (prisustva.Exists(x => x.StudentId == student.Id))
                {
                    MessageBox.Show("Student je već evidentiran na ovoj nastavi", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (prisustva.Count() == odabranaProstorija.Kapacitet)
                    {
                        MessageBox.Show("Kapacitet prostorije je popunjen", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        var novoPrisustvo = new PrisustvoIB210166()
                        {
                            NastavaId = nastava.Id,
                            StudentId = student.Id
                        };

                        db.PrisustvoIB210166.Add(novoPrisustvo);
                        db.SaveChanges();

                    }
                }


                UcitajPrisustva();



            }
        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(cbNastava, err, Kljucevi.ReqiredValue) && Validator.ProvjeriUnos(cbStudent, err, Kljucevi.ReqiredValue);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // 1. DIO 
            // -- async
            // -- validacija
            // -- postavljanje threada
            // -- pokretanje threada
            // -- [sve sto je vezano za combo box]

            var nastava = cbNastava.SelectedItem as NastavaIB210166;
            var student = cbStudent.SelectedItem as Student;


            if (ValidirajMulitithreading())
            {
                Thread t1 = new Thread(() => GenerisiPrisustva(nastava, student));
                t1.Start();
            }

        }

        private void GenerisiPrisustva(NastavaIB210166 nastava, Student student)
        {
            // 2. DIO
            // -- kalkulacije
            // -- pohrane
            // -- sleep

            var broj = int.Parse(txtBroj.Text);
            var info = "";

            for (int i = 0; i < broj; i++)
            {
                Thread.Sleep(300);

                var novoPrisustvo = new PrisustvoIB210166()
                {
                    StudentId = student.Id,
                    NastavaId = nastava.Id
                };

                info += $"{DateTime.Now.ToString("dd.MM HH:mm:ss")} -> {student} za {nastava} {Environment.NewLine}";


                db.PrisustvoIB210166.Add(novoPrisustvo);
                db.SaveChanges();



            }


            Action action = () =>
            {
                // 3. DIO 
                // -- ispis
                // -- mbox
                // -- ucitavanje

                UcitajPrisustva();
                MessageBox.Show($"Generisali ste {broj} prisustava","Informacija",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtInfo.Text = info;


            };
            BeginInvoke(action);


        }

        private bool ValidirajMulitithreading()
        {
            return Validator.ProvjeriUnos(txtBroj, err, Kljucevi.ReqiredValue) && Validator.ProvjeriUnos(cbNastava, err, Kljucevi.ReqiredValue);
        }
    }
}
