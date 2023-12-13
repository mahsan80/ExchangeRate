using ExchangeRate.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Transactions;
//using System.Web.Http;

namespace ExchangeRate.Controllers
{
   
    [ApiController]
    [Route("api")]
    
    public class ExchangeRatesController : ControllerBase
    {
       

        private readonly ILogger<ExchangeRatesController> _logger;

        public ExchangeRatesController(ILogger<ExchangeRatesController> logger)
        {
            _logger = logger;
        }

         /// <summary>
         /// Take input 3 letter country code (non case sensitive) and return exchange rates based on Delivery/payment types
         /// Currenlty no exeption handling as we are assuming no issue on josn file / json converter
         /// </summary>
         /// <param name="country"></param>
         /// <returns></returns>
        //[HttpGet("exchange-rates/{country}")]

        [HttpGet("exchange-rates")]
        public IActionResult GetExchangeRates(string country)
        {
            if(string.IsNullOrEmpty(country) || country.Trim().Length != 3 || !char.IsLetter(country[0]) || !char.IsLetter(country[1])|| !char.IsLetter(country[2]))
            {
                return BadRequest("Please Provide the valid Country Code.");
            }
            List<PartnerRatesResponse> resp = new List<PartnerRatesResponse>();
            //matching passed country code with stored partners
            Partners? p = Partners.GetListofPartners().Where(X => X.CountryCode == country.Trim().ToUpper()).FirstOrDefault<Partners>();
            if (p != null)
            {
                RootObject? ratesList = new RootObject();
                //instead of file we are populating from static variable and loading into List using json converter
                ratesList = JsonConvert.DeserializeObject<RootObject>(JsonFile.jsonString);
                if (ratesList != null)
                {
                    //getting max Acuqired date wise rates based on payment method and delivery method folter by passed country code
                   var query = (from t in ratesList.PartnerRates
                                 where t.Currency == p.CurrencyCode
                                 group t by new { t.PaymentMethod, t.DeliveryMethod, t.Currency } into grp
                                 select new
                                 {
                                     grp.Key.PaymentMethod,
                                     grp.Key.DeliveryMethod,
                                     MaxAcqDate = grp.Max(t => t.AcquiredDate)
                                 }).ToList();

                   
                    foreach(var v in query)
                    {
                        //fetching rate based on query result set unique rate per payment method abd delivery method
                        PartnerRates? item = ratesList.PartnerRates.Where(x=>x.AcquiredDate == v.MaxAcqDate && x.DeliveryMethod == v.DeliveryMethod && x.PaymentMethod == v.PaymentMethod).FirstOrDefault(); 

                        if(item != null)
                        {
                            //adding to response List object
                            resp.Add(new PartnerRatesResponse() { CountryCode = p.CountryCode, CurrencyCode = p.CurrencyCode, DeliveryMethod = item.DeliveryMethod, PangeaRate = Math.Round(item.Rate + p.FlatRate,2), PaymentMethod = item.PaymentMethod });

                        }

                    }
                    ratesList = null;
                    query = null;
                    p = null;
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

           //returning Json
            return Ok(resp);

        }
    }
}
