using DocumentFormat.OpenXml.Office2019.Excel.RichData2;
using Studentska.Data.Entiteti;
using Studentska.Data.IspitIB180079;
using Studentska.Servis.Servisi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Studentska.WinApp.IspitIB180079
{
    public partial class frmIznajmljivanjaIB180079 : Form
    {

        StudentiKnjigeServis studentiKnjigeServis = new StudentiKnjigeServis();
        StudentServis studentServis = new StudentServis();
        KnjigeServis knjigeServis = new KnjigeServis();

        public frmIznajmljivanjaIB180079()
        {
            InitializeComponent();
        }

        private void frmIznajmljivanjaIB180079_Load(object sender, EventArgs e)
        {
            dgvPodaci.AutoGenerateColumns = false;

            UcitajComboBox();

            UcitajPodatke();


        }

        private void UcitajComboBox()
        {

            cbStudent.DataSource = studentServis.GetAll();

            cbKnjiga.DataSource = knjigeServis.GetAll();

            cbKnjiga.DisplayMember = "Naziv";

        }

        private void UcitajPodatke()
        {




            var podaci = studentiKnjigeServis
                .GetAllIncluded() // _dbContext.StudentiKnjigeIB180079 ------ ToList();
                .ToList(); // ToList();



            dgvPodaci.DataSource = podaci;


        }

        private void btnIznajmi_Click(object sender, EventArgs e)
        {

            var student = cbStudent.SelectedItem as Student;

            var knjiga = cbKnjiga.SelectedItem as KnjigeIB180079;


            if (studentiKnjigeServis
                .GetAll()
                .Exists(x => x.StudentId == student.Id &&
                x.KnjigaId == knjiga.Id &&
                x.Vracena == false))
            {

                MessageBox.Show($"Student {student} je već prethodno iznajmio knjigu {knjiga} a prethodno je nije vratio", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (studentiKnjigeServis.GetAll().
                Where(x => x.KnjigaId == knjiga.Id && x.Vracena == false).Count() >= knjiga.BrojPrimjeraka)
            {

                MessageBox.Show($"Broj primjeraka {knjiga} je {knjiga.BrojPrimjeraka}, nemamo više primjeraka na stanju.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
            else
            {


                var novoIznajmljivanje = new StudentiKnjigeIB180079()
                {
                    //Id = 4,
                    StudentId = student.Id,
                    //Student = student,
                    KnjigaId = knjiga.Id,
                    DatumIznajmljivanja = DateTime.Now,
                    Vracena = false
                };

                studentiKnjigeServis.Add(novoIznajmljivanje);

                UcitajPodatke();

            }


        }

        private void frmIznajmljivanjaIB180079_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;

        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {
            // 1. DIO
            // -- thread
            // -- validacije
            // -- AKO IMAMO COMBO BOX I TREBAMO MU PRISTUPOITI MORAMO MU PRISTUPITIU U PRVOM DIJELU

            var student = cbStudent.SelectedItem as Student;


            await Task.Run(() => GenerisiIznajmljivanja(student));



        }

        private void GenerisiIznajmljivanja(Student? student)
        {

            // 2. DIO
            // -- kalkulacije
            // -- pohrane
            // -- sleep


            var sveKnjige = knjigeServis.GetAll();

            var info = "";

            var redniBroj = 1;

            for (int i = 0; i < sveKnjige.Count(); i++)
            {

                if (!studentiKnjigeServis.GetAll()
                    .Exists(x => x.StudentId == student.Id && 
                    x.KnjigaId == sveKnjige[i].Id))
                {

                    Thread.Sleep(300);

                    var novoIznajmljivanje = new StudentiKnjigeIB180079()
                    {
                        StudentId = student.Id,
                        KnjigaId = sveKnjige[i].Id,
                        DatumIznajmljivanja = DateTime.Now,
                        //DatumVracanja = null,
                        Vracena = false
                    };

                    info += $"{redniBroj++}. {student} dodato zaduzenje {sveKnjige[i]}{Environment.NewLine}";

                    studentiKnjigeServis.Add(novoIznajmljivanje);

                }

            }




            Action action = () =>
            {
                // 3. DIO 
                // -- mbox
                // -- ucitavanja
                // -- ispis

                MessageBox.Show($"Studentu {student} su generisana iznajmljivanja","Informacija", MessageBoxButtons.OK,MessageBoxIcon.Information);

                UcitajPodatke();

                txtInfo.Text = info;
                

            };
            BeginInvoke(action);

        }
    }
}
