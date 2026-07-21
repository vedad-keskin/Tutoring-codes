//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Studentska.WinApp.Helpers
{
    public class Validator 
    {
        public static bool ValidanUnos(Control control, ErrorProvider err, string poruka)
        {
            bool validan = true;
            if (control is ComboBox cmb && cmb.SelectedIndex < 0)
                validan = false;
            else if (control is PictureBox pb && pb.Image == null )
                validan = false;
            else if (control is TextBox txt && string.IsNullOrWhiteSpace(txt.Text))
                validan = false;

            if (!validan)
            {
                err.SetError(control, poruka);
                return false;
            }            
            err.Clear();
            return true;
        }
    }

}
