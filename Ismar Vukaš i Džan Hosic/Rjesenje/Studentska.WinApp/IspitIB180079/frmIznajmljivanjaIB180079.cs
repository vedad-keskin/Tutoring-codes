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
        KnjigaServis knjigaServis = new KnjigaServis();
        StudentServis studentServis = new StudentServis();


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

            cmbKnjiga.DataSource = knjigaServis.GetAll(); // override .. 

            cmbKnjiga.DisplayMember = "Naziv";

            cmbStudent.DataSource = studentServis.GetAll();

        }

        private void UcitajPodatke()
        {


            var podaci = studentiKnjigeServis
                .GetAllIncluded()
                .ToList();


            if (podaci != null)
            {

                dgvPodaci.DataSource = null;
                dgvPodaci.DataSource = podaci;

            }



        }

        private void btnIznajmi_Click(object sender, EventArgs e)
        {

            var student = cmbStudent.SelectedItem as Student;
            var knjiga = cmbKnjiga.SelectedItem as KnjigeIB180079;


            if (studentiKnjigeServis.GetAll()
                .Exists(x => x.StudentId == student.Id &&
                x.KnjigaId == knjiga.Id &&
                x.Vracena == false))
            {

                MessageBox.Show($"Student {student} je već iznajmio knjigu {knjiga}!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (
                studentiKnjigeServis.GetAll()
                .Where(x => x.Vracena == false && x.KnjigaId == knjiga.Id).Count() >= knjiga.BrojPrimjeraka)
            {


                MessageBox.Show($"Knjiga {knjiga} nema dosuptnih kopija, a ukupno ih je bilo {knjiga.BrojPrimjeraka}!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                var novoIznajmljivanje = new StudentiKnjigeIB180079()
                {

                    //Id = 4,
                    StudentId = student.Id, // salju se u obliku ID 
                                            //Student = student, // FK nikad ne salju
                    KnjigaId = knjiga.Id,
                    DatumIznajmljivanja = DateTime.Now,
                    //DatumVracanja = null,
                    Vracena = false

                };

                studentiKnjigeServis.Add(novoIznajmljivanje);

                UcitajPodatke();

            }






        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {

            // 1. DIO
            // - THREAD
            // - VALIDACIJE
            // - AKO IMAMO COMBO BOX KOJI HOCEMO DA PRISTUPIMO MORAMO MU PRISTUPITI I IZVADITI GA PRIJE NEGO STO THREAD POKRENEMO

            var student = cmbStudent.SelectedItem as Student;

            await Task.Run(() => GenerisiIznajmljivanja(student));


        }

        private void GenerisiIznajmljivanja(Student? student)
        {

            // 2. DIO 
            // - POHRANE
            // - KALKULACIJE
            // - SLEEP THREADA (300ms)


            var sveKnjige = knjigaServis.GetAll();

            var info = "";

            var redniBroj = 1;


            for (int i = 0; i < sveKnjige.Count(); i++)
            {

                if (!studentiKnjigeServis.GetAll()
                    .Exists(x => x.StudentId == student.Id &&
                    x.KnjigaId == sveKnjige[i].Id ))
                {


                    Thread.Sleep(300);


                    var novoIznajmljivanje = new StudentiKnjigeIB180079()
                    {
                        StudentId = student.Id,
                        KnjigaId = sveKnjige[i].Id,
                        DatumIznajmljivanja = DateTime.Now,
                        Vracena = false,
                        //DatumVracanja = null

                    };

                    studentiKnjigeServis.Add(novoIznajmljivanje);

                    info += $"{redniBroj++}. {student} dodato zaduženje {sveKnjige[i]}{Environment.NewLine}";


                }




            }




            Action action = () =>
            {

                // 3. DIO
                // - MBOX
                // - ISPIS
                // - UCITAVANJE 

                MessageBox.Show($"Uspješno generisanje iznajmljivanja studenta {student}", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtInfo.Text = info;

                UcitajPodatke();

            };
            BeginInvoke(action);



        }

        private void frmIznajmljivanjaIB180079_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;

        }
    }

}
