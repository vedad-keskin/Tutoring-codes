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

            UcitajComboBox();

        }

        private void UcitajComboBox()
        {
            cbStudent.DataSource = db.Studenti.ToList();

            cbNastava.DataSource = db.NastavaIB180079
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
                //.Include(x=> x.Nastava).ThenInclude(x=> x.Predmet)
                .Include(x => x.Nastava.Predmet)
                .Include(x => x.Student)
                .Where(x => x.NastavaId == odabranaNastava.Id)
                .ToList();

            // Id NastavaId StudentId

            // Id Dan Vrijeme PredmetId ProstorijaId Oznaka

            // Id Naziv Semestar 


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

                var nastava = cbNastava.SelectedItem as NastavaIB180079;
                var student = cbStudent.SelectedItem as Student;


                //            5  ==       5
                if (prisustva.Count() == odabranaProstorija.Kapacitet)
                {
                    MessageBox.Show($"Kapacitet prostorije je popunjen", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (prisustva.Exists(x => x.StudentId == student.Id))
                {
                    MessageBox.Show($"Student {student} već je dodan na odabranoj nastavi", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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



                UcitajPrisustva();


            }
        }

        private bool Validraj()
        {
            return Validator.ProvjeriUnos(cbNastava, err, Kljucevi.ReqiredValue);
        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {
            // 1. dio 
            // -- validacija, thread/ async await
            // -- kada imamo comobo box moramo ga raditi u prvom dijelu 
            


            if (ValidirajMultithreading())
            {
                var student = cbStudent.SelectedItem as Student;
                var nastava = cbNastava.SelectedItem as NastavaIB180079;

                await Task.Run(() => GenerisiGradove(student, nastava));

                //Thread thread = new Thread(() => GenerisiGradove());
                //thread.Start();

            }

        }


        private void GenerisiGradove(Student? student, NastavaIB180079? nastava)
        {
            var broj = int.Parse(txtBroj.Text);

            var info = "";


            for (int i = 0; i < broj; i++)
            {
                Thread.Sleep(300);

                var novoPrisustvo = new PrisustvoIB180079()
                {

                    StudentId = student.Id,
                    NastavaId = nastava.Id

                };

                info += $"{DateTime.Now.ToString("dd.MM HH:mm:ss")} -> {student} za {nastava}{Environment.NewLine}";

                db.PrisustvoIB180079.Add(novoPrisustvo);
                db.SaveChanges();

            }


            Action action = () =>
            {
                MessageBox.Show($"Generisano je {broj} prisustava", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
