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

            cmbProjekat.DataSource = projektiServis.GetAll()
                .Where(x => x.Aktivan == true)
                .ToList();

            cmbStudent.DataSource = studentServis.GetAll();

            cmbStatus.SelectedIndex = 0;

            cmbStatus.Enabled = false;


        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {

            if (ValidirajUnos())
            {

                var student = cmbStudent.SelectedItem as Student;

                var projekat = cmbProjekat.SelectedItem as ProjektiIB180079;

                var datumPrijave = dtpDatumPrijave.Value;

                var status = cmbStatus.SelectedItem as string;

                //       6.6       5.5
                if (datumPrijave > projekat.RokZavrsetka)
                {

                    MessageBox.Show($"Datum prijave ne može biti veći od roka završetka projekta","Upozorenje",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                }else if (studentiProjektiServis.GetAll()
                    .Exists(x => x.StudentId == student.Id && 
                    x.ProjekatId == projekat.Id &&
                    x.Arhivirano == false ))
                {

                    MessageBox.Show($"Student {student} se ne može prijaviti na projekat {projekat} zato što ne može imati dvije aktivne prijave na isti projekat", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (studentiProjektiServis.GetAll().Exists(x => 
                x.StudentId == student.Id && x.Status == "PRIHVACENA"))
                {

                    MessageBox.Show($"Student {student} se ne može prijaviti na projekat {projekat} zato što već ima prihvaćen projekat", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                //else if (studentiProjektiServis.GetAll()
                //    .Where(x => x.ProjekatId == projekat.Id && x.Status != "ZAVRSENA")
                //    .Count() >= projekat.MaxBrojStudenata)
                //{


                //    MessageBox.Show($"Projekat {projekat} ne može primiti više studenata", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //}
                else
                {

                    var novaPrijava = new StudentiProjektiIB180079()
                    {

                        StudentId = student.Id,
                        ProjekatId = projekat.Id,
                        DatumPrijave = datumPrijave,
                        Status = status,
                        Arhivirano = false

                    };


                    studentiProjektiServis.Add(novaPrijava);

                    DialogResult = DialogResult.OK;

                }







            }

        }

        private bool ValidirajUnos()
        {
            return Validator.ValidanUnos(cmbProjekat, err, "Obavezan unos")
                && Validator.ValidanUnos(cmbStudent, err, "Obavezan unos");
        }
    }
}
