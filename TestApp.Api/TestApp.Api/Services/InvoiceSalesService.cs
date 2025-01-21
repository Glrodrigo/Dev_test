using TestApp.Api.Domain;

namespace TestApp.Api.Services
{
    public class InvoiceSalesService
    {
        public async Task<List<ResponseInvoiceSales>> AverageSalesAsync()
        {
            try
            {
                ResponseInvoiceSales sales = new ResponseInvoiceSales();
                List<ResponseInvoiceSales> response = new List<ResponseInvoiceSales>();
                double maxInvoiceSales = 0.00;
                double average = 0.00;

                MonthSales monthSales = this.GenerateSales();
                double minInvoiceSales = monthSales.InvoiceSales[1].Value;
                average = this.CalculateAverage(monthSales);

                // Verificar a média de valores de vendas mensais
                foreach (var sale in monthSales.InvoiceSales)
                {
                    if (sale.Day == "Saturday" || sale.Day == "Sunday")
                        continue;

                    if (sale.Value == 0.00)
                        continue;

                    // Verificar se valor é o mínimo
                    if (sale.Value < minInvoiceSales)
                        minInvoiceSales = sale.Value;

                    // Verificar se valor é o máximo
                    if (sale.Value > maxInvoiceSales)
                        maxInvoiceSales = sale.Value;

                    // Verificar se valor é maior que a média
                    if (sale.Value > average)
                        sales.DaysAboveMonthlyAverage = sales.DaysAboveMonthlyAverage + 1;
                }

                sales.MinInvoiceSales = minInvoiceSales;
                sales.MaxInvoiceSales = maxInvoiceSales;
                sales.Average = Math.Round(average, 2);
                response.Add(sales);

                return response;
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        private double CalculateAverage(MonthSales monthSales)
        {
            double total = 0.00;

            foreach (var sale in monthSales.InvoiceSales)
            {
                total = total + sale.Value;
            }

            if (total > 0.00)
                total = total / 31;

            return total;
        }

        private MonthSales GenerateSales()
        {
            MonthSales monthSales = new MonthSales();
            monthSales.Month = 1;
            monthSales.MonthName = "January";
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Monday", Number = "1", Value = 0.00 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Tuesday", Number = "2", Value = 1000532.50 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Wednesday", Number = "3", Value = 1635728.43 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Thursday", Number = "4", Value = 1294576.22 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Friday", Number = "5", Value = 1874563.11 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Saturday", Number = "6", Value = 0.00 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Sunday", Number = "7", Value = 0.00 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Monday", Number = "8", Value = 1986345.23 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Tuesday", Number = "9", Value = 500000.53 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Wednesday", Number = "10", Value = 1356729.76 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Thursday", Number = "11", Value = 542389.65 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Friday", Number = "12", Value = 1678293.44 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Saturday", Number = "13", Value = 0.00 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Sunday", Number = "14", Value = 0.00 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Monday", Number = "15", Value = 1235678.89 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Tuesday", Number = "16", Value = 700389.65 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Wednesday", Number = "17", Value = 1557893.23 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Thursday", Number = "18", Value = 1123456.45 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Friday", Number = "19", Value = 1678234.22 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Saturday", Number = "20", Value = 0.00 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Sunday", Number = "21", Value = 0.00 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Monday", Number = "22", Value = 1978456.34 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Tuesday", Number = "23", Value = 700150.00 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Wednesday", Number = "24", Value = 1567342.88 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Thursday", Number = "25", Value = 1345672.44 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Friday", Number = "26", Value = 1548923.78 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Saturday", Number = "27", Value = 0.00 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Sunday", Number = "28", Value = 0.00 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Monday", Number = "29", Value = 0.00 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Tuesday", Number = "30", Value = 620532.50 });
            monthSales.InvoiceSales.Add(new DayInvoiceSales() { Day = "Wednesday", Number = "31", Value = 1321728.43 });

            return monthSales;
        }
    }
}
