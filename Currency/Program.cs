namespace Currency
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var service = new CurrencyRatesService();


            // Завдання 1
            Console.WriteLine("Введіть код валюти: ");
            string currencyCode = Console.ReadLine();
            service.GetRatesForLastThreeDays(currencyCode);

            // Завдання 2
            string filePath = "currencyRates.xml";
            service.SaveRatesToXml(filePath);
        }
    }
}
