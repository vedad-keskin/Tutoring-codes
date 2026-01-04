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

            // 1	1	1	08 - 10	Ponedeljak	Matematika :: Ponedeljak :: 08-10
            // 1	Matematika	6	1	0

            cbNastava.DataSource = db.NastavaIB180079
                .Include(x => x.Predmet)
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

            if (ValidirajUnos())
            {


                var nastava = cbNastava.SelectedItem as NastavaIB180079;
                var student = cbStudent.SelectedItem as Student;

                //   30 == 30
                if (prisustva.Count() == odabranaProstorija.Kapacitet)
                {
                    MessageBox.Show($"Kapacitet prostorije {odabranaProstorija} je popunjen", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (prisustva.Exists(x => x.StudentId == student.Id))
                {

                    MessageBox.Show($"Student {student} je već evidentiran na nastavi {nastava}", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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

        private bool ValidirajUnos()
        {
            return Validator.ProvjeriUnos(cbNastava, err, Kljucevi.RequiredField);
        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {

            // 1. dio 
            // --  postavljanje threada -> async i await
            // --  validacije
            // --  pristup combo boxu se mora raditi u prvom dijelu 

            if (ValidirajUnosMultithreadinga())
            {

                var student = cbStudent.SelectedItem as Student;

                await Task.Run(() => GenerisiPrisustva(student));

            }
        }

        private void GenerisiPrisustva(Student? student)
        {

            // 2. dio
            // -- kalkulacije
            // -- pohrane
            // -- sleep

            // STRING -> INT 

            var broj = int.Parse(txtBroj.Text);

            var nastave = db.NastavaIB180079
                .Where(x => x.ProstorijaId == odabranaProstorija.Id)
                .ToList();

            var info = "";

            for (int i = 0; i < nastave.Count(); i++)
            {
                for (int j = 0; j < broj; j++)
                {

                    var novoPrisustvo = new PrisustvoIB180079()
                    {

                        StudentId = student.Id,
                        NastavaId = nastave[i].Id,

                    };

                    db.PrisustvoIB180079.Add(novoPrisustvo);
                    db.SaveChanges();

                    info += $"{DateTime.Now.ToString("dd.MM HH:mm:ss")} -> {student} za {nastave[i]}{Environment.NewLine}";

                    Thread.Sleep(300);


                }
            }




            Action action = () =>
            {
                // 3. dio
                // -- mbox
                // -- ucitavanje
                // -- info

                MessageBox.Show($"Uspješno je generisano {broj * nastave.Count()} prisustava za studenta {student}","Informacija",MessageBoxButtons.OK,MessageBoxIcon.Information);

                UcitajPrisustva();

                txtInfo.Text = info;


            };
            BeginInvoke(action);




        }

        private bool ValidirajUnosMultithreadinga()
        {
            return Validator.ProvjeriUnos(txtBroj,err, Kljucevi.RequiredField);
        }
    }
}
