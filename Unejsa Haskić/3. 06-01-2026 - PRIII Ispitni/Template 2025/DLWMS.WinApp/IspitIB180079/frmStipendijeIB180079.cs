using DLWMS.Data.IspitIB180079;
using DLWMS.Infrastructure;
using DLWMS.WinApp.Helpers;
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

            //if(e.ColumnIndex == 4)
            //{

            var odabranaStipednijaGodina = dgvStipendijeGodine.SelectedRows[0].DataBoundItem as StipendijeGodineIB180079;


            //if(odabranaStipednijaGodina.Aktivna == true)
            //{

            //    odabranaStipednijaGodina.Aktivna = false;

            //}
            //else
            //{

            //    odabranaStipednijaGodina.Aktivna = true;

            //}

            //odabranaStipednijaGodina.Aktivna = odabranaStipednijaGodina.Aktivna ? false : true;


            odabranaStipednijaGodina.Aktivna = !odabranaStipednijaGodina.Aktivna;

            db.StipendijeGodineIB180079.Update(odabranaStipednijaGodina);
            db.SaveChanges();

            UcitajStipendijeGodine();

            //}



        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {

            if (ValidirajUnos())
            {

                var godina = cbGodina.SelectedItem.ToString();

                var stipendija = cbStipendija.SelectedItem as StipendijeIB180079;

                var iznos = int.Parse(txtIznos.Text);


                if (db.StipendijeGodineIB180079.ToList().Exists(x =>
                x.Godina == godina
                && x.StipendijaId == stipendija.Id))
                {

                    MessageBox.Show($"Već postoji {stipendija} na godini {godina}", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {

                    var novaStipendijaGodina = new StipendijeGodineIB180079()
                    {
                        //Stipendija = stipendija,
                        //Id = 1,
                        StipendijaId = stipendija.Id,
                        Godina = godina,
                        Iznos = iznos,
                        Aktivna = true
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
            return Validator.ProvjeriUnos(txtIznos, err, "Ovo polje je obavezno") &&
                Validator.ProvjeriUnos(cbStipendija, err, "Ovo polje je obavezno") &&
                Validator.ProvjeriUnos(cbGodina, err, "Ovo polje je obavezno");
        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {
            // 1. dio
            // -- postavljanje threada .. async/await 
            // -- validacije
            // -- ako imamo combo box vezan za multitrheading moramo uzeti vrijednosti iz tog cb u prvom dijelu

            var odabranaStipendija = cbStipendija.SelectedItem as StipendijeIB180079;


            await Task.Run(() => GenerisiStipendije(odabranaStipendija));


        }

        //                            ? IZA VRSTE VAR. ZNACI NULLABLE
        private void GenerisiStipendije(StipendijeIB180079? odabranaStipendija)
        {
            // 2. dio
            // -- sve pohrane (osim cb pohrana)
            // -- kalkulacije
            // -- sleep

            // KADA RADIMO CASTANJE

            // 1. KADA VADIMO NESTO IZ COMBO BOXA (IZ BAZE)
            // 2. KADA VADIMO NESTO IZ DGV 

            MessageBox.Show($"{odabranaStipendija?.Naziv ?? "N/A"}");

            var odabranaStipendijaGodina = dgvStipendijeGodine.SelectedRows[0].DataBoundItem as StipendijeGodineIB180079;

            var sviStudenti = db.Studenti.ToList();

            var info = "";

            var redniBroj = 1;

            for (int i = 0; i < sviStudenti.Count(); i++)
            {


                if (!db.StudentiStipendijeIB180079.ToList().Exists(x => 
                x.StudentId == sviStudenti[i].Id &&
                x.StipendijaGodinaId == odabranaStipendijaGodina.Id
                ))
                {

                    Thread.Sleep(300);

                    var novaStudentStipendija = new StudentiStipendijeIB180079()
                    {

                        StudentId = sviStudenti[i].Id,
                        StipendijaGodinaId = odabranaStipendijaGodina.Id

                    };

                    info += $"{redniBroj}. {odabranaStipendijaGodina} stipendija u iznosu od {odabranaStipendijaGodina.Iznos} dodata {sviStudenti[i]}{Environment.NewLine}";

                    redniBroj++;

                    db.StudentiStipendijeIB180079.Add(novaStudentStipendija);
                    db.SaveChanges();


                }



            }






            //for (int i = 0; i < sviStudenti.Count(); i++)
            //{
            //    Thread.Sleep(300);

            //    var novaStudentStipendija = new StudentiStipendijeIB180079()
            //    {

            //        StudentId = sviStudenti[i].Id,
            //        StipendijaGodinaId = odabranaStipendijaGodina.Id

            //    };

            //    db.StudentiStipendijeIB180079.Add(novaStudentStipendija);
            //    db.SaveChanges();

            //}



            Action action = () =>
            {

                // 3. dio
                // -- mbox
                // -- ispisi
                // -- ucitavanja

                MessageBox.Show("Uspješno ste generisali stipendije", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
