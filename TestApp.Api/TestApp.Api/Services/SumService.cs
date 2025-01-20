using TestApp.Api.Domain;

namespace TestApp.Api.Services
{
    public class SumService
    {
        public async Task<List<ResponseDomain>> SumUpAsync()
        {
            try
            {
                ResponseDomain sumUp = new ResponseDomain();
                List<ResponseDomain> response = new List<ResponseDomain>();

                int index = 13;
                int sum = 0;

                for (int k = 0; k < index; k++) 
                { 
                    sum = sum + k;
                }

                // Sum será igual a 78               
                if (sum > 0)
                {
                    sumUp.Result = sum;
                    response.Add(sumUp);
                }

                return response;
            }
            catch (Exception exception)
            {
                throw;
            }
        }
    }
}
