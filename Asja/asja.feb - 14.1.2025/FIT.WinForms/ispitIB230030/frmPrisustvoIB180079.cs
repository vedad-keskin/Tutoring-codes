using FIT.Data;
using FIT.Data.ispitIB230030;
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

namespace FIT.WinForms.ispitIB230030
{
    public partial class frmPrisustvoIB180079 : Form
    {
        private ProstorijeIB230030 odabranaProstorija;
        DLWMSDbContext db = new DLWMSDbContext();
        List<PrisustvoIB230030> prisustva;

        public frmPrisustvoIB180079(ProstorijeIB230030 odabranaProstorija)
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

            cbNastava.DataSource = db.NastavaIB230030
                .Where(x => x.ProstorijaID == odabranaProstorija.Id)
                .ToList();

            cbNastava.DisplayMember = "Oznaka";

        }

        private void cbNastava_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajPrisustva();
        }

        private void UcitajPrisustva()
        {

            var odabranaNastava = cbNastava.SelectedItem as NastavaIB230030;

            prisustva = db.PrisustvoIB230030
                .Include(x => x.Nastava.Predmet)
                .Include(x => x.Student)
                .Where(x => x.NastavaID == odabranaNastava.Id)
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
            if (Validraj())
            {

                var nastava = cbNastava.SelectedItem as NastavaIB230030;
                var student = cbStudent.SelectedItem as Student;

                //   5               ==   5
                if (prisustva.Count() == odabranaProstorija.Kapacitet)
                {
                    MessageBox.Show($"Kapacitet prostorije je popunjen", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (prisustva.Exists(x => x.StudentID == student.Id))
                {
                    MessageBox.Show($"Student {student} je već evidentiran na odabranoj nastavi", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    var novoPrisustvo = new PrisustvoIB230030()
                    {
                        NastavaID = nastava.Id,
                        StudentID = student.Id
                    };

                    db.PrisustvoIB230030.Add(novoPrisustvo);
                    db.SaveChanges();


                }




                UcitajPrisustva();


            }
        }

        private bool Validraj()
        {
            return Validator.ProvjeriUnos(cbNastava, err, Kljucevi.ReqiredValue);
        }

        private void btnGenerisi_Click(object sender, EventArgs e)
        {
            // 1. dio
            // -- validacija
            // -- postavljanje threada
            // -- pokretanje threada
            // -- sve sto je vezano za combo box

            if (ValidrajMultithreading())
            {
                var student = cbStudent.SelectedItem as Student;
                var nastava = cbNastava.SelectedItem as NastavaIB230030;

                Thread t1 = new Thread(() => GenerisiPrisustva(student, nastava));
                t1.Start();

            }


        }

        private void GenerisiPrisustva(Student? student, NastavaIB230030? nastava)
        {
            // 2. dio
            // -- kalkulacije
            // -- pohrane
            // -- sleep 


            var broj = int.Parse(txtBroj.Text);

            var info = "";


            for (int i = 0; i < broj; i++)
            {
                Thread.Sleep(300);

                var novoPrisustvo = new PrisustvoIB230030()
                {
                    StudentID = student.Id,
                    NastavaID = nastava.Id
                };

                db.PrisustvoIB230030.Add(novoPrisustvo);
                db.SaveChanges();

                info += $"{DateTime.Now.ToString("dd.MM HH:mm:ss")} -> {student} za {nastava.NastavaInfo}{Environment.NewLine}";


            }



            Action action = () =>
            {
                // 3. dio
                // -- mbox
                // -- ispisi
                // -- ucitavanje

                MessageBox.Show($"Uspješno je generisano {broj} prisustava", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UcitajPrisustva();

                txtInfo.Text = info;


            };
            BeginInvoke(action);



        }

        private bool ValidrajMultithreading()
        {
            return Validator.ProvjeriUnos(txtBroj, err, Kljucevi.ReqiredValue);
        }
    }
}
