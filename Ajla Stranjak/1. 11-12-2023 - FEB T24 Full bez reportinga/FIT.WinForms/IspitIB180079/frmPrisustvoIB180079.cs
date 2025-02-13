using FIT.Data;
using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
using FIT.WinForms.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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

            cbNastava.DataSource = db.NastavaIB180079.Include(x => x.Predmet).Where(x => x.ProstorijaId == odabranaProstorija.Id).ToList();

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


            prisustva = db.PrisustvoIB180079.Where(x => x.NastavaId == odabranaNastava.Id).ToList();


            if (prisustva != null)
            {


                dgvPrisustva.DataSource = null;
                dgvPrisustva.DataSource = prisustva;
            }

            lblPrebrojavanje.Text = $"{prisustva.Count()}/{odabranaProstorija.Kapacitet}";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nastava = cbNastava.SelectedItem as NastavaIB180079;
            var student = cbStudent.SelectedItem as Student;


            if (prisustva.Exists(x => x.StudentId == student.Id))
            {
                MessageBox.Show("Student je vec dodan na nastavi");
            }
            //                5   ==               5
            else if (prisustva.Count() == odabranaProstorija.Kapacitet)
            {

                MessageBox.Show("Kapacitet prostorije je popunjen");
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

        private void button2_Click(object sender, EventArgs e)
        {
            // 1. dio
            // -- sve sto je vazno za combobox
            // -- postavljanje threada
            // -- pokretanje threada
            // -- validacija

            if (Validiraj())
            {
                var student = cbStudent.SelectedItem as Student;
                var nastava = cbNastava.SelectedItem as NastavaIB180079;

                Thread thread = new Thread(() => GenerisiPrisustva(student, nastava));
                thread.Start();


            }




        }

        private void GenerisiPrisustva(Student? student, NastavaIB180079? nastava)
        {
            // 2. dio
            // -- kalukacije
            // -- uspavljivanje threada
            // -- pohrane

            var broj = int.Parse(txtBroj.Text);
            string info = "";

            for (int i = 0; i < broj; i++)
            {

                var novoPrisustvo = new PrisustvoIB180079()
                {
                    NastavaId = nastava.Id,
                    StudentId = student.Id
                };

                db.PrisustvoIB180079.Add(novoPrisustvo);
                db.SaveChanges();

                info += $"{DateTime.Now.ToString("dd.MM HH:mm:ss")} -> {student} za {nastava} {Environment.NewLine}" ;

            }

            Action action = () =>
            {

                // 3. dio
                // -- ispsi
                // -- ucitanja
                // -- mbox

                UcitajPrisustva();
                txtInfo.Text = info;
                MessageBox.Show($"Genrisano je {broj} zapisa");


            };
            BeginInvoke(action);



        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(txtBroj, err, Kljucevi.ReqiredValue);
        }
    }
}
