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
        List<StipendijeGodineIB180079> stipendijeGodine;
        public frmStipendijeIB180079()
        {
            InitializeComponent();
        }

        private void frmStipendijeIB180079_Load(object sender, EventArgs e)
        {
            dgvStipendijeGodine.AutoGenerateColumns = false;

            UcitajStipendijeGodine();
            UcitajComboBox();
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

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {
                var stipendija = cbStipendija.SelectedItem as StipendijeIB180079 ?? new StipendijeIB180079();
                var godina = cbGodina?.SelectedItem?.ToString() ?? "";
                var iznos = int.Parse(txtIznos.Text);

                if (stipendijeGodine.Exists(x => x.Godina == godina && x.StipendijaId == stipendija.Id))
                {
                    MessageBox.Show("Stipendija već postoji", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {

                    var novaStipendijaGodina = new StipendijeGodineIB180079()
                    {
                        StipendijaId = stipendija.Id,
                        Godina = godina,
                        Iznos = iznos,
                        Aktivan = true
                    };

                    db.StipendijeGodineIB180079.Add(novaStipendijaGodina);
                    db.SaveChanges();

                    UcitajStipendijeGodine();
                }

            }
        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(cbStipendija, err, Kljucevi.RequiredField);
        }

        private void frmStipendijeIB180079_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void dgvStipendijeGodine_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            var odabranaStipendijaGodina = stipendijeGodine[e.RowIndex];
            //var odabranaStipendijaGodina2 = dgvStipendijeGodine.SelectedRows[0].DataBoundItem as StipendijeGodineIB180079;

            odabranaStipendijaGodina.Aktivan = !odabranaStipendijaGodina.Aktivan;

            db.StipendijeGodineIB180079.Update(odabranaStipendijaGodina);
            db.SaveChanges();

            UcitajStipendijeGodine();


        }
    }
}
