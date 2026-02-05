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
        StudentiKnjgeServis studentiKnjgeServis = new StudentiKnjgeServis();
        StudentServis studentServis = new StudentServis();
        KnjigeServis knjigeServis = new KnjigeServis();

        public frmIznajmljivanjaIB180079()
        {
            InitializeComponent();
        }

        private void frmIznajmljivanjaIB180079_Load(object sender, EventArgs e)
        {
            dgvStudentiKnjige.AutoGenerateColumns = false;

            UcitajStudentiKnjige();

            UcitajComboBox();

        }

        private void UcitajComboBox()
        {

            cbStudent.DataSource = studentServis.GetAll();

            cbKnjiga.DataSource = knjigeServis.GetAll();

            cbKnjiga.DisplayMember = "Naziv";

        }

        private void UcitajStudentiKnjige()
        {



            //var studentiKnjige = db.StudentiKnjigeIB180079.ToList();
            var studentiKnjige = studentiKnjgeServis
                .GetAllIncluded()

                .ToList();


            if (studentiKnjige != null)
            {

                dgvStudentiKnjige.DataSource = null;
                dgvStudentiKnjige.DataSource = studentiKnjige;

            }



        }

        private void btnIznajmi_Click(object sender, EventArgs e)
        {

            var student = cbStudent.SelectedItem as Student;

            var knjiga = cbKnjiga.SelectedItem as KnjigeIB180079;


            if (studentiKnjgeServis.GetAll()
                .Where(x => x.KnjigaId == knjiga.Id && x.Vracena == false)
                .ToList().Count() >= knjiga.BrojPrimjeraka)
            {
                MessageBox.Show($"Nije dostupna {knjiga} jer nema više primjeraka te knjige na stanju", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (studentiKnjgeServis.GetAll()
                .Exists(x => x.StudentId == student.Id
                && x.KnjigaId == knjiga.Id
                && x.Vracena == false
                ))
            {

                MessageBox.Show($"Student {student} je već iznajmio knjigu {knjiga} a prethodno je nije vratio", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {

                var novaStudentKnjiga = new StudentiKnjigeIB180079()
                {
                    StudentId = student.Id,
                    KnjigaId = knjiga.Id,
                    DatumIznajmljivanja = DateTime.Now,
                    Vracena = false

                };

                studentiKnjgeServis.Add(novaStudentKnjiga);

                UcitajStudentiKnjige();

            }



        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {
            // 1. dio
            // -- validacije
            // -- thread
            // -- ako imamo combo box koji se korisi u MT onda pohranu tog combo boxa moramo uraditi u prvom dijelu threada

            var student = cbStudent.SelectedItem as Student;

            await Task.Run(() => GenerisiIznajmljivanja(student));

        }

        private void GenerisiIznajmljivanja(Student? student)
        {
            // 2. dio
            // -- kalklulacije
            // -- pohrane
            // -- sleep


            var sveKnjige = knjigeServis.GetAll();

            var info = "";

            var redniBroj = 1;

            for (int i = 0; i < sveKnjige.Count(); i++)
            {
                //Thread.Sleep(3000);

                //var novaStudentKnjiga = new StudentiKnjigeIB180079()
                //{
                //    StudentId = student.Id,
                //    KnjigaId = sveKnjige[i].Id,
                //    DatumIznajmljivanja = DateTime.Now,
                //    Vracena = false

                //};

                //studentiKnjgeServis.Add(novaStudentKnjiga);

                if (!studentiKnjgeServis.GetAll()
                    .Exists(x => x.StudentId == student.Id &&
                    x.KnjigaId == sveKnjige[i].Id))
                {

                    Thread.Sleep(300);

                    var novaStudentKnjiga = new StudentiKnjigeIB180079()
                    {
                        StudentId = student.Id,
                        KnjigaId = sveKnjige[i].Id,
                        DatumIznajmljivanja = DateTime.Now,
                        Vracena = false

                    };

                    info += $"{redniBroj++}. {student} dodato {sveKnjige[i]}{Environment.NewLine}";


                    studentiKnjgeServis.Add(novaStudentKnjiga);


                }




            }



            Action action = () =>
            {
                // 3. dio
                // -- ucitavanja
                // -- ispisi
                // -- mbox

                UcitajStudentiKnjige();

                MessageBox.Show($"Uspješno su generisana iznajmljvanja", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtInfo.Text = info;

            };
            BeginInvoke(action);


        }

        private void frmIznajmljivanjaIB180079_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
