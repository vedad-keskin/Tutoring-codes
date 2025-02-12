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

            // Id
            // StudentId
            // NastavaId
            // Dan
            // Vrijeme
            // Oznaka
            // ProstorijaId
            // PredmetId
            // Naziv
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
            if (Validiraj())
            {
                var nastava = cbNastava.SelectedItem as NastavaIB180079;
                var student = cbStudent.SelectedItem as Student;

                if (prisustva.Exists(x => x.StudentId == student.Id))
                {
                    MessageBox.Show("Student je već evidentiran na ovoj nastavi", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //           10      ==  10
                    if (prisustva.Count() == odabranaProstorija.Kapacitet)
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
        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(cbNastava, err, Kljucevi.ReqiredValue) && Validator.ProvjeriUnos(cbStudent, err, Kljucevi.ReqiredValue);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // async 
            // validacija
            // pokretanje i pravljenje threada
            // sve sto je vezano za combo box

            var student = cbStudent.SelectedItem as Student;
            if (ValidirajMultithreading())
            {
                Thread t1 = new Thread(() => GenerisiPrisustva(student));
                t1.Start();
            }


        }

        private void GenerisiPrisustva(Student? student)
        {
            // pohrane
            // kalkulacije
            // sleep

            var broj = int.Parse(txtBroj.Text);
            var info = "";

            var sveNastaveOveProstorije = db.NastavaIB180079
                .Include(x=> x.Predmet)
                .Where(x => x.ProstorijaId == odabranaProstorija.Id)
                .ToList();

            for (int i = 0; i < broj; i++)
            {
                for (int j = 0; j < sveNastaveOveProstorije.Count(); j++)
                {
                    Thread.Sleep(300);

                    var novoPrisustvo = new PrisustvoIB180079()
                    {
                        StudentId = student.Id,
                        NastavaId = sveNastaveOveProstorije[j].Id,
                    };

                    db.PrisustvoIB180079.Add(novoPrisustvo);
                    db.SaveChanges();

                    info += $"{DateTime.Now.ToString("dd.MM HH:mm:ss")} -> {student} za {sveNastaveOveProstorije[j]} {Environment.NewLine}";



                }
            }


            Action action = () =>
            {
                // ispis
                // mbox
                // ucitavanje

                MessageBox.Show($"Uspješno ste generisali {broj} zapisa za svaku nastavu", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UcitajPrisustva();
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
