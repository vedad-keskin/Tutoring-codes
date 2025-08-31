using DLWMS.Data;
using DLWMS.Data.IspitIB180079;
using DLWMS.Infrastructure;
using DLWMS.WinApp.Helpers;
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

namespace DLWMS.WinApp.IspitIB180079
{
    public partial class frmPrisustvoIB180079 : Form
    {
        DLWMSContext db = new DLWMSContext();
        private ProstorijeIB180079? odabranaProstorija;
        List<PrisustvoIB180079> prisustva;

        //public frmPrisustvoIB180079()
        //{
        //    InitializeComponent();
        //}

        public frmPrisustvoIB180079(ProstorijeIB180079? odabranaProstorija)
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
                .Where(x => x.NastavaId == odabranaNastava.Id)
                .ToList();

            if (prisustva != null)
            {

                dgvPrisustva.DataSource = null;
                dgvPrisustva.DataSource = prisustva;

            }

            lblBrojac.Text = $"{prisustva.Count()}/{odabranaProstorija.Kapacitet}";

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {
                var nastava = cbNastava.SelectedItem as NastavaIB180079;
                var student = cbStudent.SelectedItem as Student;

                if (prisustva.Count() == odabranaProstorija.Kapacitet)
                {
                    MessageBox.Show("Kapacitet prostorije je popunjen", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (prisustva.Exists(x => x.StudentId == student.Id))
                {
                    MessageBox.Show($"Student {student} je vec evidentiran na nastavi {nastava}", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    UcitajPrisustva();

                }


            }
        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(cbNastava, err, Kljucevi.RequiredField);
        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {
            // 1. dio
            // -- validacija 
            // -- thread --> async/await/task -- Thread
            // -- sve sto je vezano za combo box

            if (ValidirajMultithreading())
            {
                 var student = cbStudent.SelectedItem as Student;

                // starinski 
    
                //Thread thread = new Thread(() => GenrisiPrisustva());
                //thread.Start();

                // noviji/moderniji nacin
                await Task.Run(() => GenrisiPrisustva(student));

            }

        }

        private void GenrisiPrisustva(Student? student)
        {
            // 2. dio 
            // -- pohrane
            // -- kalkulacije
            // -- sleep (300 mils)


            var broj = int.Parse(txtBroj.Text);

            var sveNastaveProstorije = db.NastavaIB180079
                .Where(x => x.ProstorijaId == odabranaProstorija.Id)
                .ToList();

            var info = "";

            for (int i = 0; i < sveNastaveProstorije.Count(); i++)
            {

                for (int j = 0; j < broj; j++)
                {

                    var novoPrisustvo = new PrisustvoIB180079()
                    {

                        NastavaId = sveNastaveProstorije[i].Id,
                        StudentId = student.Id


                    };

                    info += $"{DateTime.Now.ToString("dd.MM HH:mm:ss")} -> {student} za {sveNastaveProstorije[i]} {Environment.NewLine}";

                    db.PrisustvoIB180079.Add(novoPrisustvo);
                    Thread.Sleep(300);

                }

            }
            db.SaveChanges();


            Action action = () =>
            {
                // 3. dio
                // -- mbox
                // -- ispis
                // -- ucitavanje

                UcitajPrisustva();

                MessageBox.Show($"Uspješno su generisana {broj} prisustava za studenta {student}","Informacija",MessageBoxButtons.OK,MessageBoxIcon.Information);

                txtInfo.Text = info;    


            };
            BeginInvoke(action);


        }

        private bool ValidirajMultithreading()
        {
            return Validator.ProvjeriUnos(txtBroj, err, Kljucevi.RequiredField);
        }
    }
}
