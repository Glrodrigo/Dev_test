using TestApp.Api.Domain;

namespace TestApp.Api.Services
{
    public class PercentageSalesService
    {
        public async Task<List<ResponsePercentageSales>> PercentageSalesAsync()
        {
            try
            {
                ResponsePercentageSales sales = new ResponsePercentageSales();
                List<ResponsePercentageSales> response = new List<ResponsePercentageSales>();

                sales = this.GenerateCompany(sales);
                sales.Total = Math.Round(this.CalculateTotal(sales), 2);
                sales = this.CalculatePercentage(sales);

                response.Add(sales);

                return response;
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        private double CalculateTotal(ResponsePercentageSales sales)
        {
            double total = 0.00;

            foreach (var distribuitor in sales.Distributors)
            {
                total = total + distribuitor.Value;
            }

            return total;
        }

        private ResponsePercentageSales CalculatePercentage(ResponsePercentageSales sales)
        {
            // Calcula a porcentagem
            foreach (var distribuitor in sales.Distributors)
            {
                distribuitor.Percentage = Math.Round((distribuitor.Value / sales.Total) * 100, 1);
            }
            
            return sales;
        }

        public ResponsePercentageSales GenerateCompany(ResponsePercentageSales sales)
        {
            sales.Distributors.Add(new Company { State = "SP", Value = 67836.43 });
            sales.Distributors.Add(new Company { State = "RJ", Value = 36678.66 });
            sales.Distributors.Add(new Company { State = "MG", Value = 29229.88 });
            sales.Distributors.Add(new Company { State = "ES", Value = 27165.48 });
            sales.Distributors.Add(new Company { State = "OUTROS", Value = 19849.53 });

            return sales;
        }
    }
}
