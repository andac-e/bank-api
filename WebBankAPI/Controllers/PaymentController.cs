using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebBankAPI.DesignPatterns.SingletonPattern;
using WebBankAPI.DTOClasses;
using WebBankAPI.Models.Context;
using WebBankAPI.Models.Entities;

namespace WebBankAPI.Controllers
{
    public class PaymentController : ApiController
    {
        MyContext _db;
        public PaymentController()
        {
            _db = DBTool.DBInstance;
        }

        //Test Action
        //[HttpGet]
        //public List<PaymentDTO> GetAll()
        //{
        //    return _db.Cards.Select(x => new PaymentDTO
        //    {
        //        CardUserName = x.CardUserName
        //    }).ToList();
        //}

        [HttpPost]
        public IHttpActionResult ReceivePayment(PaymentDTO item)
        {
            CardInfo ci = _db.Cards.FirstOrDefault(x =>
            x.CardNumber == item.CardNumber &&
            x.SecurityNumber == item.SecurityNumber &&
            x.CardUserName == item.CardUserName &&
            x.CardExpiryMonth == item.CardExpiryMonth &&
            x.CardExpiryYear == item.CardExpiryYear);

            if (ci != null)
            {
                if (ci.CardExpiryYear < DateTime.Now.Year) return BadRequest("Expired Card");

                else if (ci.CardExpiryYear == DateTime.Now.Year)
                {
                    if (ci.CardExpiryMonth < DateTime.Now.Month) return BadRequest("Expired Card");

                    if (ci.Balance >= item.ShoppingPrice) return Ok();
                    else return BadRequest("Balance Exceeded");

                }

                if (ci.Balance >= item.ShoppingPrice) return Ok();
                else return BadRequest("Balance Exceeded");

            }
            else
            {
                return BadRequest("Card Not Found");
            }

        }

    }
}
