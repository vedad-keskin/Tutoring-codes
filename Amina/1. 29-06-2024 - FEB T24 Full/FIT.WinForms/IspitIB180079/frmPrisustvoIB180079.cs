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
        List<PrisustvaIB180079> prisustva;


        public frmPrisustvoIB180079(ProstorijeIB180079 odabranaProstorija)
        {
            InitializeComponent();
            this.odabranaProstorija = odabranaProstorija;
        }

        private void frmPrisustvoIB180079_Load(object sender, EventArgs e)
        {
            dgvPrisustva.AutoGenerateColumns = false;

            lblNazivProstorije.Text = $"{odabranaProstorija.Naziv} {odabranaProstorija.Oznaka}";


            cbNastava.DataSource = db.NastavaIB180079
                .Include(x => x.Predmet)
                .Where(x => x.ProstorijaId == odabranaProstorija.Id)
                .ToList();


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
                .Include(x => x.Nastava).ThenInclude(x => x.Predmet)
                .Include(x => x.Student)
                .Where(x => x.NastavaId == odabranaNastava.Id && x.Nastava.ProstorijaId == odabranaProstorija.Id).ToList();

            if (prisustva != null)
            {

                dgvPrisustva.DataSource = null;
                dgvPrisustva.DataSource = prisustva;
            }

            lblKapacitet.Text = $"{prisustva.Count()}/{odabranaProstorija.Kapacitet}";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nastava = cbNastava.SelectedItem as NastavaIB180079;
            var student = cbStudent.SelectedItem as Student;

            //    30              ==         30
            if (prisustva.Count() == odabranaProstorija.Kapacitet)
            {

                MessageBox.Show("Prostorija je popunjena", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (prisustva.Exists(x => x.StudentId == student.Id))
            {

                MessageBox.Show("Student je vec dodan na toj nastavi", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {



                var novoPrisustvo = new PrisustvaIB180079
                {
                    NastavaId = nastava.Id,
                    StudentId = student.Id


                };

                db.PrisustvoIB180079.Add(novoPrisustvo);
                db.SaveChanges();

                UcitajPrisustva();
            }



        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {
                // 1. dio
                // -- postavljanje threada
                // -- pokretanje threada
                // -- sve sto je vezano za combobox
                // -- validacije

                var student = cbStudent.SelectedItem as Student;
                var nastava = cbNastava.SelectedItem as NastavaIB180079;


                Thread thread = new Thread(() => GenerisiPrisustva(student,nastava));
                thread.Start();

            }
        }

        private void GenerisiPrisustva(Student student, NastavaIB180079 nastava)
        {
            // 2. dio
            // -- kalkulacije
            // -- pohrane osim ako je u pitanju combobox jer to onda mora biti iznad
            // -- ako thread treba da se uspava

            Thread.Sleep(300);

            var broj = int.Parse(txtBroj.Text); 
            string info = "";

            //      5 > 30 
            if (broj > (odabranaProstorija.Kapacitet - prisustva.Count()))
            {
                MessageBox.Show("Generisanje ce prekoraciti kapacitet prostorije","Upozorenje",MessageBoxButtons.OK,MessageBoxIcon.Warning);

            }
            else
            {
                for (int i = 0; i < broj; i++)
                {
                    var novoPrisustvo = new PrisustvaIB180079()
                    {
                        StudentId = student.Id,
                        NastavaId = nastava.Id

                    };

                    db.PrisustvoIB180079.Add(novoPrisustvo);
                    db.SaveChanges();

                    info += $"{DateTime.Now.ToString("dd.MM HH:mm:ss")} -> {student} za {nastava} {Environment.NewLine}";


                }

            }




            Action action = () =>
            {
                // 3. dio
                // -- ispisi
                // -- ucitavanja
                // -- mbox

                UcitajPrisustva();
                MessageBox.Show($"Generisano je {broj} zapisa","Informacija",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtInfo.Text = info;


            };
            BeginInvoke(action);




        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(txtBroj, err, Kljucevi.ReqiredValue);
        }
    }
}
