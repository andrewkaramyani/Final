namespace WebApplication3.ViewModel
{
    public class EmployeeFilters
    {
        public EmployeeFilters()
        {
            Department = -1;
            Section = -1;
            SubSection = -1;
            EmployeeName = "";
        }
        public int Department { get; set; }
        public int Section { get; set; }
        public int SubSection { get; set; }
        public string EmployeeName { get; set; }
    }
}