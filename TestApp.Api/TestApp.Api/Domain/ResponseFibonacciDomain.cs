namespace TestApp.Api.Domain
{
    public class ResponseFibonacciDomain
    {
        public List<int> Numbers { get; set; }
        public int Number { get; set; }
        public bool BelongsToList { get; set; }
        public string TranslateDescription { get; set; }
        public string? ErrorStatus { get; set; }

        public ResponseFibonacciDomain() 
        { 
            Numbers = new List<int>();
        }
    }
}
