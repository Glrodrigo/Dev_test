using TestApp.Api.Domain;

namespace TestApp.Api.Services
{
    public class ReverseService
    {
        public async Task<List<ResponseReverseDomain>> ReverseWordAsync(ReverseParams reverseParams)
        {
            try
            {
                ResponseReverseDomain reverse = new ResponseReverseDomain();
                List<ResponseReverseDomain> response = new List<ResponseReverseDomain>();
                string reverseWord = "";

                // Caso seja passado algum número, a palavra escolhida será default
                if (int.TryParse(reverseParams.Word, out _))
                {
                    reverseParams.Word = "Default";
                }

                // Pegar o tamanho da palavra e iniciar a atribuição do último elemento
                if (reverseParams.Word.Length > 0)
                {
                    for (int i = reverseParams.Word.Length - 1; i >= 0; i--)
                    {
                        reverseWord = reverseWord + reverseParams.Word[i];
                    }

                    reverse.ReverseWord = reverseWord;
                }

                reverse.Word = reverseParams.Word;
                response.Add(reverse);

                return response;
            }
            catch (Exception exception)
            {
                throw;
            }
        }
    }
}
