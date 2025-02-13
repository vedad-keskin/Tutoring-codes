using FIT.Infrastructure;
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
    public partial class frmProstorijeIB180079 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        public frmProstorijeIB180079()
        {
            InitializeComponent();
        }

        private void frmProstorijeIB180079_Load(object sender, EventArgs e)
        {
            dgvProstorije.AutoGenerateColumns = false;
            // ALT + ENTER
            UcitajProstorije();
        }

        private void UcitajProstorije()
        {

            // prostorije[0] = AMF1  -> Broj   -> 2  --> Id = 1
            // prostorije[1] = UC1   -> Broj   -> 1  --> Id = 2
            // prostorije[2] = AKS   -> Broj   -> 1  --> Id = 3

            var prostorije = db.ProstorijeIB180079.ToList();

            //                < 3  ----> 0 1 2 
            for (int i = 0; i < prostorije.Count(); i++)
            {

                // 

                prostorije[i].Broj = db.NastavaIB180079
                    //                   3 ==                   3
                    .Where( x => x.ProstorijaId == prostorije[i].Id )
                    .Count();
            }


            dgvProstorije.DataSource = prostorije;


        }
    }
}
