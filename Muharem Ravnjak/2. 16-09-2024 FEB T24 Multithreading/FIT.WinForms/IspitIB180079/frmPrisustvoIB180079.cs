using FIT.Data;
using FIT.Data.IspitiB180079;
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

            cbNastava.DataSource = db.NastavaIB180079
                .Include(x=> x.Predmet)
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

            var nastava = cbNastava.SelectedItem as NastavaIB180079;

            // Id
            // NastavaId
            // Nastava -> Id ProstorijaId Vrijeme Dan Oznaka
            // StudentId
            // Student -> Id Ime Prezime Indeks DatumRodjena
            // Predmet -> Naziv Seemstar Id

            prisustva = db.PrisustvoIB180079
                .Include(x => x.Nastava).ThenInclude(x => x.Predmet)
                //.Include(x=> x.Nastava.Predmet)
                .Include(x => x.Student)
                .Where(x => x.NastavaId == nastava.Id)
                .ToList();

            if (prisustva != null)
            {

                dgvPrisustva.DataSource = null;
                dgvPrisustva.DataSource = prisustva;
            }

            lblPrebrojavanje.Text = $"{prisustva.Count()}/{odabranaProstorija.Kapacitet}";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {
                var student = cbStudent.SelectedItem as Student;
                var nastava = cbNastava.SelectedItem as NastavaIB180079;


                if (prisustva.Exists(x => x.StudentId == student.Id))
                {

                    MessageBox.Show("Student je već dodan na toj nastavi", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    //                 5  ==  5
                    if (prisustva.Count() == odabranaProstorija.Kapacitet)
                    {
                        MessageBox.Show("Kapacitet prostorije je popunjen", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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




                }



                UcitajPrisustva();

            }
        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(cbNastava, err, Kljucevi.ReqiredValue);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // 1. DIO 
            // -- async 
            // -- validacija
            // -- postavaljanje i pokretanje threada
            // -- sve sto je vezano za combo box


            var student = cbStudent.SelectedItem as Student;
            var nastava = cbNastava.SelectedItem as NastavaIB180079;
            

            if (ValidrajMultithreading())
            {

                Thread t1 = new Thread(() => GenerisiPrisustva(student, nastava));
                t1.Start();
            }


        }

        private void GenerisiPrisustva(Student? student, NastavaIB180079? nastava)
        {
            // 2. DIO 
            // -- pohrane
            // -- kalkulacije 
            // -- sleep

            var info = "";

            var broj = int.Parse(txtBroj.Text);

            for (int i = 0; i < broj; i++)
            {
                Thread.Sleep(300);

                var novoPrisustvo = new PrisustvoIB180079()
                {
                    NastavaId = nastava.Id,
                    StudentId = student.Id
                };

                info += $"{DateTime.Now.ToString("MM.dd HH:mm:ss")} -> {student} za {nastava} {Environment.NewLine}";

                db.PrisustvoIB180079.Add(novoPrisustvo);
                db.SaveChanges();


            }


            Action action = () =>
            {
                // 3. DIO
                // -- ispis
                // -- ucitavanja
                // -- mbox  

                UcitajPrisustva();
                MessageBox.Show($"Generisali ste {broj} zapisa","Informacija",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
