namespace Studentska.WinApp.Helpers
{
    public static class Ekstenzije
    {
        public static void UcitajPodatke<T>(this ComboBox cmb, List<T> dataSource,
            string valueMember = "Id", string displayMember = "Naziv")
        {
            cmb.DataSource = dataSource;
            cmb.DisplayMember = displayMember;
            cmb.ValueMember = valueMember;
        }
    }
}
