namespace TestApp.Api.Domain
{
    public class ResponseInvoiceSales
    {
        public double MinInvoiceSales { get; set; }
        public double MaxInvoiceSales { get; set; }
        public double Average { get; set; }
        public int DaysAboveMonthlyAverage { get; set; }
    }

    public class MonthSales
    {
        public int Month { get; set; }
        public string MonthName { get; set; }
        public List<DayInvoiceSales> InvoiceSales { get; set; }

        public MonthSales() 
        { 
            this.InvoiceSales = new List<DayInvoiceSales>();
        }
    }

    public class DayInvoiceSales
    {
        public string Day { get; set; }
        public string Number { get; set; }
        public double Value { get; set; }
    }
}
