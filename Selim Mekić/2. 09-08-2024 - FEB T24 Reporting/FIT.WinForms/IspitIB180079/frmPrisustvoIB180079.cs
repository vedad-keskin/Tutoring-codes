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

            cbNastava.DataSource = db.NastavaIB180079
                .Include(x => x.Predmet)
                .Include(x => x.Prostorija)
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
                .Include(x => x.Nastava)
                .Include(x => x.Student)
                .Where(x => x.NastavaId == odabranaNastava.Id)
                .ToList();

            if (prisustva != null)
            {

                dgvPrisustva.DataSource = null;
                dgvPrisustva.DataSource = prisustva;
            }

            lblBrojPrisustava.Text = $"{prisustva.Count()}/{odabranaProstorija.Kapacitet}";

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            var nastava = cbNastava.SelectedItem as NastavaIB180079;
            var student = cbStudent.SelectedItem as Student;


            if (prisustva.Exists(x => x.StudentId == student.Id))
            {
                MessageBox.Show("Student je vec dodan na nastavi", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (odabranaProstorija.Kapacitet == prisustva.Count())
                {
                    MessageBox.Show("Kapacitet prostorije je popunjen", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    var novoPrisustvo = new PrisustvoIB180079()
                    {

                        StudentId = student.Id,
                        NastavaId = nastava.Id

                    };

                    db.PrisustvoIB180079.Add(novoPrisustvo);
                    db.SaveChanges();

                }



            }


            UcitajPrisustva();

        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {
            // 1. dio
            // combo box se mora raditi ovdje 

            if (Validiraj())
            {
                var student = cbStudent.SelectedItem as Student;

                Thread t1 = new Thread(() => GenerisiPrisustva(student));
                t1.Start();

            }
           
        }

        private void GenerisiPrisustva(Student? student)
        {

            var broj = int.Parse(txtBroj.Text);

            var nastaveProstorije = db.NastavaIB180079
                .Where(x=> x.ProstorijaId == odabranaProstorija.Id)
                .ToList();
            var info = "";


            for (int i = 0; i < nastaveProstorije.Count(); i++)
            {
                for (int j = 0; j < broj; j++)
                {
                    Thread.Sleep(300);

                    var novoPrisustvo = new PrisustvoIB180079()
                    {
                        StudentId = student.Id,
                        NastavaId = nastaveProstorije[i].Id
                    };

                    info += $"{DateTime.Now.ToString("MM.dd HH:mm:ss")} -> {student} za {nastaveProstorije[i]} {Environment.NewLine}";

                    db.PrisustvoIB180079.Add(novoPrisustvo);
                    db.SaveChanges();

                }
            }


            Action action = () =>
            {
                UcitajPrisustva();
                MessageBox.Show($"Generisano je {broj} za svaku nastavu","Informacija",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
