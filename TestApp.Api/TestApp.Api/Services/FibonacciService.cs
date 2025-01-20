using TestApp.Api.Domain;

namespace TestApp.Api.Services
{
    public class FibonacciService
    {
        public async Task<List<ResponseFibonacciDomain>> CalculateFibonacciAsync(FibonacciParams fibonacciParams)
        {
            try
            {
                ResponseFibonacciDomain fibonacci = new ResponseFibonacciDomain();
                List<ResponseFibonacciDomain> response = new List<ResponseFibonacciDomain>();
                int limit = 0;
                int previous = 0;
                int current = 1;

                fibonacci.TranslateDescription = "Número não pertence à lista";

                // Verificar se temos o valor passado
                if (fibonacciParams.Number == null)
                {
                    fibonacci.ErrorStatus = "Não há número informado, por favor adicionar um número válido";
                    fibonacci.TranslateDescription = "Número inválido";
                }

                // Verificar se houve um número válido
                if (fibonacciParams.Number != null)
                {
                    if(int.TryParse(fibonacciParams.Number.ToString(), out _))
                    {
                        fibonacciParams.Number = fibonacciParams.Number;
                    }
                    else
                    {
                        // Caso seja inválido, vamos usar o zero como ponto de partida
                        fibonacciParams.Number = 0;
                    }

                    if (fibonacciParams.Number == 0)
                        limit = 10;
                    else
                    {
                        limit = fibonacciParams.Number;
                    }

                    // Calcular a sequência até o número escolhido
                    for (int i = 0; i < limit; i++)
                    {
                        fibonacci.Numbers.Add(previous);

                        if (previous > fibonacciParams.Number)
                            break;

                        if (previous == fibonacciParams.Number)
                        {
                            fibonacci.BelongsToList = true;
                            fibonacci.TranslateDescription = "Número pertence à lista";
                        }

                        int next = previous + current;
                        previous = current;
                        current = next;
                    }
                }

                response.Add(fibonacci);
                return response;
            }
            catch (Exception exception)
            {
                throw;
            }
        }
    }
}
