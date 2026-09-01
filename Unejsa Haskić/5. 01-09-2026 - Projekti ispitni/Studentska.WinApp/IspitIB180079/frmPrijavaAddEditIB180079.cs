using Studentska.Data.Entiteti;
using Studentska.Data.IspitIB180079;
using Studentska.Servis.Servisi;
using Studentska.WinApp.Helpers;
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
    public partial class frmPrijavaAddEditIB180079 : Form
    {
        StudentServis studentServis = new StudentServis();
        ProjektiServis projektiServis = new ProjektiServis();
        StudentiProjektiServis studentiProjektiServis = new StudentiProjektiServis();
        public frmPrijavaAddEditIB180079()
        {
            InitializeComponent();
        }

        private void frmPrijavaAddEditIB180079_Load(object sender, EventArgs e)
        {
            UcitajInfo();
        }

        private void UcitajInfo()
        {
            cmbStatus.SelectedIndex = 0;

            cmbStatus.Enabled = false;

            cmbStudent.DataSource = studentServis.GetAll();

            cmbProjekat.DataSource = projektiServis
                .GetAll()
                .Where(x => x.Aktivan)
                .ToList();

        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (ValidirajUnos())
            {

                var student = cmbStudent.SelectedItem as Student;
                var projekat = cmbProjekat.SelectedItem as ProjektiIB180079;

                var status = cmbStatus.SelectedItem as string;

                var datumPrijave = dtpDatumPrijave.Value;


                if (datumPrijave > projekat.RokZavrsetka)
                {


                    MessageBox.Show("Prijava je veća od roka završetka projekta", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (studentiProjektiServis.GetAll().Exists(x => x.StudentId == student.Id && x.ProjekatId == projekat.Id && x.Arhivirana == false))
                {

                    MessageBox.Show("Student već ima aktivnu prijavu na projekta", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (studentiProjektiServis.GetAll().Exists(x => x.StudentId == student.Id && x.Status == "PRIHVACENA"))
                {

                    MessageBox.Show("Student već ima prihvaćen projekat", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
                else if (studentiProjektiServis.GetAll().Where(x => x.ProjekatId == projekat.Id && x.Status == "PRIHVACENA").Count() >= projekat.MaxBrojStudenata)
                {
                    MessageBox.Show("Student ne moze biti poslati prijavu jer je popunjen maksimalan broj prihavecnih prijava. Pokusajte kasnije, nakon što odredjeni studenti zavrse projekat", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {

                    var novaPrijava = new StudentiProjektiIB180079()
                    {

                        StudentId = student.Id,
                        ProjekatId = projekat.Id,
                        Status = status,
                        DatumPrijave = datumPrijave,
                        DatumPromjene = DateTime.Now,
                        Arhivirana = false,

                    };

                    studentiProjektiServis.Add(novaPrijava);

                    DialogResult = DialogResult.OK;

                }




            }

        }

        private bool ValidirajUnos()
        {
            return Validator.ValidanUnos(cmbProjekat, err, "Obavezan unos") && Validator.ValidanUnos(cmbStudent, err, "Obavezan unos");
        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {
            // 1. dio
            // - validacije 
            // - kreiranje threada
            // - combo box ako ga ima i koristi se u mt mora se izvaditi u prvom dijelu 

            var odabraniStudent = cmbStudent.SelectedItem as Student;

            await Task.Run(() => GenerisiPrijave(odabraniStudent));



        }

        private void GenerisiPrijave(Student? odabraniStudent)
        {

            // 2. dio
            // -- pohrane
            // -- kalkulacije
            // -- sleep

            var aktivniProjekti = projektiServis
                .GetAll()
                .Where(x => x.Aktivan && x.RokZavrsetka > DateTime.Now)
                .ToList();


            var info = "";

            for (int i = 0; i < aktivniProjekti.Count(); i++)
            {

                if (!studentiProjektiServis.GetAll().Exists( x=> x.StudentId == odabraniStudent.Id && x.ProjekatId == aktivniProjekti[i].Id && x.Arhivirana == false) )
                {

                    Thread.Sleep(300);

                    var novaPrijava = new StudentiProjektiIB180079()
                    {

                        StudentId = odabraniStudent.Id,
                        ProjekatId = aktivniProjekti[i].Id,
                        DatumPrijave = DateTime.Now,
                        DatumPromjene = DateTime.Now,
                        Status = "PODNESENA",
                        Arhivirana = false


                    };

                    info += $"Dodata prijava na projekat '{aktivniProjekti[i]}' - studentu {odabraniStudent}{Environment.NewLine}";


                    studentiProjektiServis.Add(novaPrijava);

                }




            }




            Action action = () =>
            {
                // 3. dio 
                // -- mbox
                // -- ispis
                // -- ucitavanja

                if (info == "")
                {
                    MessageBox.Show($"Student nije u mogućnosti generisati prijave po traženim pravilima", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Uspješno su generisane prijave", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtInfo.Text = info;
                }




            };
            BeginInvoke(action);





        }

        private void frmPrijavaAddEditIB180079_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
