using ExchangeRate.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Net;

namespace ExchangeRate.Controllers
{
   
    [ApiController]
    [Route("api/exchange-rates")]

    public class ExchangeRatesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        private readonly ILogger<ExchangeRatesController> _logger;

        public ExchangeRatesController(ILogger<ExchangeRatesController> logger)
        {
            _logger = logger;
        }

        
        //[HttpGet(Name = "exchange-rates")]
        //public List<PartnerRatesResponse> GetRates(string? country)
        //{
        //  List<PartnerRatesResponse> resp = new List<PartnerRatesResponse>();
        //    Partners? p = Partners.GetListofPartners().Where(X => X.CountryCode == country).FirstOrDefault<Partners>();
        //    if (p != null)
        //    {
        //        RootObject? ratesList = new RootObject();
        //        ratesList = JsonConvert.DeserializeObject<RootObject>(JsonFile.jsonString);
        //        if (ratesList != null)
        //        {
        //            List<PartnerRates> prList = ratesList.PartnerRates.Where(x => x.Currency == p.CurrencyCode).ToList();
        //            foreach (PartnerRates r2 in prList)
        //            {
        //                resp.Add(new PartnerRatesResponse() { CountryCode = p.CountryCode,CurrencyCode = p.CurrencyCode,DeliveryMethod = r2.DeliveryMethod,PangeaRate = r2.Rate+p.FlatRate,PaymentMethod=r2.PaymentMethod });

        //            }
        //        }
        //    }

        //   // return null;
        //    return resp;

        //}


        [HttpGet(Name = "exchange-rates")]
        public IActionResult GetExchangeRates(string? country)
        {
            List<PartnerRatesResponse> resp = new List<PartnerRatesResponse>();
            Partners? p = Partners.GetListofPartners().Where(X => X.CountryCode == country).FirstOrDefault<Partners>();
            if (p != null)
            {
                RootObject? ratesList = new RootObject();
                ratesList = JsonConvert.DeserializeObject<RootObject>(JsonFile.jsonString);
                if (ratesList != null)
                {
                    List<PartnerRates> prList = ratesList.PartnerRates.Where(x => x.Currency == p.CurrencyCode).ToList();
                    foreach (PartnerRates r2 in prList)
                    {
                        resp.Add(new PartnerRatesResponse() { CountryCode = p.CountryCode, CurrencyCode = p.CurrencyCode, DeliveryMethod = r2.DeliveryMethod, PangeaRate = r2.Rate + p.FlatRate, PaymentMethod = r2.PaymentMethod });

                    }
                }
                else
                {
                    return NotFound("The exchange rate is not configured for the provided country.");
                }
            }
            else
            {
                return NotFound("The Provided Country is not configured in the system.");             
            }

           
            return Ok(resp);

        }
    }
}
