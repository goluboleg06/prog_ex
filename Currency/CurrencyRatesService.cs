using System;
using System.Linq;
using System.Xml.Linq;

public class CurrencyRatesService
{
    public void GetRatesForLastThreeDays(string currencyCode)
    {
        using (var context = new CurrencyContext())
        {
            var threeDaysAgo = DateTime.Now.AddDays(-3);
            var rates = context.CurrencyRates
                                .Where(r => r.CurrencyCode == currencyCode && r.Date >= threeDaysAgo)
                                .OrderBy(r => r.Date)
                                .ToList();

            foreach (var rate in rates)
            {
                Console.WriteLine($"Назва валюти: {rate.CurrencyName}, Код валюти: {rate.CurrencyCode}, Курс до гривні: {rate.RateToUAH}, Дата: {rate.Date}");
            }
        }
    }
    public void SaveRatesToXml(string filePath)
    {
        using (var context = new CurrencyContext())
        {
            var currencyRates = context.CurrencyRates.ToList();

            XElement root = new XElement("CurrencyRates",
                from rate in currencyRates
                select new XElement("Currency",
                    new XElement("CurrencyName", rate.CurrencyName),
                    new XElement("CurrencyCode", rate.CurrencyCode),
                    new XElement("RateToUAH", rate.RateToUAH),
                    new XElement("Date", rate.Date)
                )
            );

            root.Save(filePath);
            Console.WriteLine($"Дані збережено у файл: {filePath}");
        }
    }
}
