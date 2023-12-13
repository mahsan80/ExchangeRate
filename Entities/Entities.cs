using Newtonsoft.Json;

namespace ExchangeRate.Entities
{
    internal class Partners
    {
        public string? Country { get; set; }
        public string? CountryCode { get; set; }
        public string? CurrencyCode { get; set; }
        public decimal FlatRate { get; set; }

        internal static List<Partners> GetListofPartners()
        {
               List<Partners> partners = new List<Partners>() 
               {
                   new Partners { Country = "Mexico",CountryCode="MEX" ,CurrencyCode = "MXN", FlatRate =  0.024m },
                   new Partners { Country = "India",CountryCode="IND" ,CurrencyCode = "INR", FlatRate = 3.213m },
                   new Partners { Country = "Philippines",CountryCode="PHL" ,CurrencyCode = "PHP", FlatRate = 2.437m },
                   new Partners { Country = "Guatemala",CountryCode="GTM" ,CurrencyCode = "GTQ", FlatRate =  0.056m }

                };

            return partners;
        }

    }

    internal class PartnerRates
    {
        [JsonProperty("Currency")]
        public string? Currency { get; set; }
        public string? PaymentMethod { get; set; }
        public string? DeliveryMethod { get; set; }
        public decimal Rate { get; set; }
        public DateTime AcquiredDate { get; set; }
    }

    public class PartnerRatesResponse
    {
        [JsonProperty("CurrencyCode")]
        public string? CurrencyCode { get; set; }
        [JsonProperty("CountryCode")]
        public string? CountryCode { get; set; }
        [JsonProperty("PangeaRate")]
        public decimal PangeaRate { get; set; }
        [JsonProperty("PaymentMethod")]
        public string? PaymentMethod { get; set; }
        [JsonProperty("DeliveryMethod")]
        public string? DeliveryMethod { get; set; }
    }
    internal class JsonFile
    {
        public static string jsonString = "{\"PartnerRates\": [\r\n{\r\n\"Currency\": \"MXN\",\r\n\"PaymentMethod\": \"debit\",\r\n\"DeliveryMethod\": \"cash\",\r\n\"Rate\": 16.78,\r\n\"AcquiredDate\": \"2023-07-24T05:00:00.000Z\"\r\n},\r\n{\r\n\"Currency\": \"MXN\",\r\n\"PaymentMethod\": \"debit\",\r\n\"DeliveryMethod\": \"deposit\",\r\n\"Rate\": 16.83,\r\n\"AcquiredDate\": \"2023-07-24T05:00:00.000Z\"\r\n},\r\n{\r\n\"Currency\": \"MXN\",\r\n\"PaymentMethod\": \"debit\",\r\n\"DeliveryMethod\": \"debit\",\r\n\"Rate\": 16.78,\r\n\"AcquiredDate\": \"2023-07-24T05:00:00.000Z\"\r\n},\r\n{\r\n\"Currency\": \"MXN\",\r\n\"PaymentMethod\": \"debit\",\r\n\"DeliveryMethod\": \"cash\",\r\n\"Rate\": 16.65,\r\n\"AcquiredDate\": \"2023-07-26T05:00:00.000Z\"\r\n},\r\n{\r\n\"Currency\": \"MXN\",\r\n\"PaymentMethod\": \"bankaccount\",\r\n\"DeliveryMethod\": \"debit\",\r\n\"Rate\": 16.81,\r\n\"AcquiredDate\": \"2023-07-24T05:00:00.000Z\"\r\n},\r\n{\r\n\"Currency\": \"MXN\",\r\n\"PaymentMethod\": \"bankaccount\",\r\n\"DeliveryMethod\": \"deposit\",\r\n\"Rate\": 16.89,\r\n\"AcquiredDate\": \"2023-07-24T05:00:00.000Z\"\r\n},\r\n{\r\n\"Currency\": \"MXN\",\r\n\"PaymentMethod\": \"cash\",\r\n\"DeliveryMethod\": \"deposit\",\r\n\"Rate\": 16.79,\r\n\"AcquiredDate\": \"2023-07-24T05:00:00.000Z\"\r\n},\r\n{\r\n\"Currency\": \"MXN\",\r\n\"PaymentMethod\": \"bankaccount\",\r\n\"DeliveryMethod\": \"deposit\",\r\n\"Rate\": 16.89,\r\n\"AcquiredDate\": \"2023-07-24T05:00:00.000Z\"\r\n},\r\n{\r\n\"Currency\": \"PHP\",\r\n\"PaymentMethod\": \"debit\",\r\n\"DeliveryMethod\": \"cash\",\r\n\"Rate\": 57.14,\r\n\"AcquiredDate\": \"2023-07-24T05:00:00.000Z\"\r\n},\r\n{\r\n\"Currency\": \"PHP\",\r\n\"PaymentMethod\": \"debit\",\r\n\"DeliveryMethod\": \"deposit\",\r\n\"Rate\": 56.74,\r\n\"AcquiredDate\": \"2023-07-24T05:00:00.000Z\"\r\n},\r\n{\r\n\"Currency\": \"PHP\",\r\n\"PaymentMethod\": \"debit\",\r\n\"DeliveryMethod\": \"debit\",\r\n\"Rate\": 56.12,\r\n\"AcquiredDate\": \"2023-07-24T05:00:00.000Z\"\r\n},\r\n{\r\n\"Currency\": \"PHP\",\r\n\"PaymentMethod\": \"debit\",\r\n\"DeliveryMethod\": \"cash\",\r\n\"Rate\": 57.3,\r\n\"AcquiredDate\": \"2023-07-26T05:00:00.000Z\"\r\n},\r\n{\r\n\"Currency\": \"PHP\",\r\n\"PaymentMethod\": \"bankaccount\",\r\n\"DeliveryMethod\": \"debit\",\r\n\"Rate\": 57.33,\r\n\"AcquiredDate\": \"2023-07-26T05:00:00.000Z\"\r\n},\r\n{\r\n\"Currency\": \"PHP\",\r\n\"PaymentMethod\": \"bankaccount\",\r\n\"DeliveryMethod\": \"deposit\",\r\n\"Rate\": 57.79,\r\n\"AcquiredDate\": \"2023-07-26T05:00:00.000Z\"\r\n},\r\n{\r\n\"Currency\": \"PHP\",\r\n\"PaymentMethod\": \"bankaccount\",\r\n\"DeliveryMethod\": \"cash\",\r\n\"Rate\": 57.63,\r\n\"AcquiredDate\": \"2023-07-24T05:00:00.000Z\"\r\n},\r\n{\r\n\"Currency\": \"PHP\",\r\n\"PaymentMethod\": \"cash\",\r\n\"DeliveryMethod\": \"cash\",\r\n\"Rate\": 57.22,\r\n\"AcquiredDate\": \"2023-07-26T05:00:00.000Z\"\r\n},\r\n{\r\n\"Currency\": \"GTQ\",\r\n\"PaymentMethod\": \"debit\",\r\n\"DeliveryMethod\": \"deposit\",\r\n\"Rate\": 8.26,\r\n\"AcquiredDate\": \"2023-07-24T05:00:00.000Z\"\r\n},\r\n{\r\n\"Currency\": \"GTQ\",\r\n\"PaymentMethod\": \"debit\",\r\n\"DeliveryMethod\": \"debit\",\r\n\"Rate\": 8.08,\r\n\"AcquiredDate\": \"2023-07-24T05:00:00.000Z\"\r\n},\r\n{\r\n\"Currency\": \"GTQ\",\r\n\"PaymentMethod\": \"debit\",\r\n\"DeliveryMethod\": \"cash\",\r\n\"Rate\": 8.14,\r\n\"AcquiredDate\": \"2023-07-24T05:00:00.000Z\"\r\n},\r\n{\r\n\"Currency\": \"INR\",\r\n\"PaymentMethod\": \"debit\",\r\n\"DeliveryMethod\": \"cash\",\r\n\"Rate\": 81.72,\r\n\"AcquiredDate\": \"2023-07-26T05:00:00.000Z\"\r\n},\r\n{\r\n\"Currency\": \"INR\",\r\n\"PaymentMethod\": \"bankaccount\",\r\n\"DeliveryMethod\": \"debit\",\r\n\"Rate\": 81.85,\r\n\"AcquiredDate\": \"2023-07-24T05:00:00.000Z\"\r\n},\r\n{\r\n\"Currency\": \"INR\",\r\n\"PaymentMethod\": \"bankaccount\",\r\n\"DeliveryMethod\": \"deposit\",\r\n\"Rate\": 81.83,\r\n\"AcquiredDate\": \"2023-07-26T05:00:00.000Z\"\r\n},\r\n{\r\n\"Currency\": \"INR\",\r\n\"PaymentMethod\": \"debit\",\r\n\"DeliveryMethod\": \"cash\",\r\n\"Rate\": 81.63,\r\n\"AcquiredDate\": \"2023-07-24T05:00:00.000Z\"\r\n}\r\n]\r\n}";

    }

    internal class RootObject
    {
        public List<PartnerRates>? PartnerRates { get; set; }
    }

}
