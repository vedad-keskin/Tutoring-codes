using DLWMS.Data.IspitIB180079;
using DLWMS.Infrastructure;
using DLWMS.WinApp.Helpers;
using DLWMS.WinApp.Izvjestaji;
using DocumentFormat.OpenXml.Office2016.Drawing.Command;
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
        List<StipendijeGodineIB180079> stipendijeGodine;
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
            stipendijeGodine = db.StipendijeGodineIB180079
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

            var odabranaStipendijaGodina = stipendijeGodine[e.RowIndex];
            //var odabranaStipendijaGodina2 = dgvStipendijeGodine.SelectedRows[0].DataBoundItem as StipendijeGodineIB180079

            odabranaStipendijaGodina.Aktivna = !odabranaStipendijaGodina.Aktivna;

            db.StipendijeGodineIB180079.Update(odabranaStipendijaGodina);
            db.SaveChanges();

            UcitajStipendijeGodine();



        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {

            if (Validiraj())
            {

                var godina = cbGodina.SelectedItem?.ToString() ?? "";

                var stipendija = cbStipendija.SelectedItem as StipendijeIB180079;

                var iznos = int.Parse(txtIznos.Text);

                if (stipendijeGodine.Exists(x => x.Godina == godina && x.StipendijaId == stipendija.Id))
                {
                    MessageBox.Show("Odabrana stipendija već postoji", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var novaStipendijaGodina = new StipendijeGodineIB180079()
                    {
                        StipendijaId = stipendija.Id,
                        Iznos = iznos,
                        Godina = godina,
                        Aktivna = true
                    };

                    db.StipendijeGodineIB180079.Add(novaStipendijaGodina);
                    db.SaveChanges();

                }


                UcitajStipendijeGodine();


            }

        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(txtIznos, err, Kljucevi.RequiredField);
        }

        private void btnPotvrda_Click(object sender, EventArgs e)
        {

            var odabranaStipendijaGodina = dgvStipendijeGodine.SelectedRows[0].DataBoundItem as StipendijeGodineIB180079;


            var frmIzvjestaj = new frmIzvjestaji(odabranaStipendijaGodina);

            frmIzvjestaj.Show();


        }
    }
}
