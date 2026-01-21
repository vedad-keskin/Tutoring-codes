using DLWMS.Data.IspitIB180079;
using DLWMS.Infrastructure;
using DLWMS.WinApp.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinApp.IspitIB180079
{
    public partial class frmStipendijeIB180079 : Form
    {
        DLWMSContext db = new DLWMSContext();
        public frmStipendijeIB180079()
        {
            InitializeComponent();
        }

        private void frmStipendijeIB180079_Load(object sender, EventArgs e)
        {

            dgvStipendijeGodine.AutoGenerateColumns = false;

            UcitajComboBox();

            UcitajStipendijeGodine();
        }

        private void UcitajComboBox()
        {
            cbGodina.SelectedIndex = 0;

            cbStipendija.DataSource = db.StipendijeIB180079.ToList();
        }

        private void UcitajStipendijeGodine()
        {

            var stipendijeGodine = db.StipendijeGodineIB180079
                .Include(x => x.Stipendija)
                .ToList();


            if (stipendijeGodine != null)
            {

                dgvStipendijeGodine.DataSource = null;
                dgvStipendijeGodine.DataSource = stipendijeGodine;

            }

        }

        private void dgvStipendijeGodine_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            var odabranaStipendijaGodina = dgvStipendijeGodine.SelectedRows[0].DataBoundItem as StipendijeGodineIB180079;

            //if(odabranaStipendijaGodina.Aktivna == true)
            //{
            //    odabranaStipendijaGodina.Aktivna = false;
            //}
            //else
            //{
            //    odabranaStipendijaGodina.Aktivna = true;
            //}

            //odabranaStipendijaGodina.Aktivna = odabranaStipendijaGodina.Aktivna ? false : true; 

            odabranaStipendijaGodina.Aktivna = !odabranaStipendijaGodina.Aktivna;


            db.StipendijeGodineIB180079.Update(odabranaStipendijaGodina);

            db.SaveChanges();

            UcitajStipendijeGodine();

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {

            if (ValidirajUnos())
            {

                var godina = cbGodina.SelectedItem.ToString(); // "2025" , "2026" .. 

                var stipendija = cbStipendija.SelectedItem as StipendijeIB180079;

                // STRING -> INT
                var iznos = int.Parse(txtIznos.Text); // "200" --> 200


                if (db.StipendijeGodineIB180079.ToList().Exists(x => x.Godina == godina
                && x.StipendijaId == stipendija.Id))
                {

                    MessageBox.Show($"Već postoji stipendija {stipendija} na godini {godina}", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    var novaStipendijaGodina = new StipendijeGodineIB180079()
                    {
                        //Id = 7, // pucanje programa
                        //Stipendija = stipendija, // pucanje programa

                        StipendijaId = stipendija.Id,
                        Godina = godina,
                        Aktivna = true,
                        Iznos = iznos

                    };

                    db.StipendijeGodineIB180079.Add(novaStipendijaGodina);

                    db.SaveChanges();

                    txtIznos.Clear();

                    UcitajStipendijeGodine();

                }





            }

        }

        private bool ValidirajUnos()
        {

            return Helpers.Validator.ProvjeriUnos(txtIznos, err, "Ovo polje je obavezno");

        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {

            // 1. dio
            // -- validacija (ako je potrebna)
            // -- postavljanje threada ( async await Task )
            // -- ako imamo combo box koji je vezan za generisanje moramo ga izvaditi u prvom dijelu i proslijediti u drugi dio


            await Task.Run(() => GenerisiStipendije());


        }

        private void GenerisiStipendije()
        {

            // 2. dio
            // -- pohrane
            // -- kalkulacije
            // -- sleep ( uspavljivanje threada )


            var odabranaStipendijaGodina = dgvStipendijeGodine.SelectedRows[0].DataBoundItem as StipendijeGodineIB180079;

            var sviStudenti = db.Studenti.ToList();


            var info = "";

            var redniBroj = 1;


            //for (int i = 0; i < sviStudenti.Count(); i++)
            //{

            //    var novaStudentStipendija = new StudentiStipendijeIB180079()
            //    {
            //        StudentId = sviStudenti[i].Id,
            //        StipendijaGodinaId = odabranaStipendijaGodina.Id

            //    };

            //    db.StudentiStipendijeIB180079.Add(novaStudentStipendija);
            //    db.SaveChanges();

            //}



            for (int i = 0; i < sviStudenti.Count(); i++)
            {

                if (!db.StudentiStipendijeIB180079.ToList().Exists(x =>
                x.StudentId == sviStudenti[i].Id
                && x.StipendijaGodinaId == odabranaStipendijaGodina.Id))
                {

                    Thread.Sleep(300);

                    var novaStudentStipendija = new StudentiStipendijeIB180079()
                    {
                        StudentId = sviStudenti[i].Id,
                        StipendijaGodinaId = odabranaStipendijaGodina.Id
                    };

                    db.StudentiStipendijeIB180079.Add(novaStudentStipendija);
                    db.SaveChanges();


                    info += $"{redniBroj}. {odabranaStipendijaGodina} stipendija u iznosu od {odabranaStipendijaGodina.Iznos} dodata {sviStudenti[i]}{Environment.NewLine}";

                    redniBroj++;

                }


            }





            Action action = () =>
            {

                // 3. dio
                // -- mbox (obavjestavanje korisnika)
                // -- ispisi
                // -- ucitavanje (refresh)

                MessageBox.Show($"Uspješno su generisane stipendije", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtInfo.Text = info;


            };
            BeginInvoke(action);




        }

        private void frmStipendijeIB180079_FormClosed(object sender, FormClosedEventArgs e)
        {

             DialogResult = DialogResult.OK;

        }
    }
}
