namespace API.InputModels
{
    public class QuoteInputModel
    {
        public CityInputModel City { get; set; }
        public List<OptionInputModel> Options { get; set; }
        public int SquareMeters { get; set; }
    }
}
