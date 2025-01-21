namespace TestApp.Api.Domain
{
    public class ResponsePercentageSales
    {
        public List<Company> Distributors { get; set; }
        public double Total { get; set; }

        public ResponsePercentageSales() 
        {
            Distributors = new List<Company>();
        }
    }

    public class Company
    {
        public string State { get; set; }
        public double Value { get; set; }
        public double Percentage { get; set; }
    }
}
