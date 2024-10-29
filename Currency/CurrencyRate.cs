using System;
using System.ComponentModel.DataAnnotations;

public class CurrencyRate
{
    [Key]
    public int Id { get; set; }
    public string CurrencyName { get; set; }
    public string CurrencyCode { get; set; }
    public double RateToUAH { get; set; }
    public DateTime Date { get; set; }
}
