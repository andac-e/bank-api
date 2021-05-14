using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebBankAPI.Models.Context;
using WebBankAPI.Models.Entities;

namespace WebBankAPI.Models.Init
{
    public class MyInit:CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            CardInfo ci = new CardInfo();
            ci.CardUserName = "Andaç Erdoğmuş";
            ci.CardNumber = "1111 1111 1111 1111";
            ci.CardExpiryYear = 2022;
            ci.CardExpiryMonth = 12;
            ci.SecurityNumber = "999";
            ci.Limit = 40000;
            ci.Balance = 40000;

            context.Cards.Add(ci);
            context.SaveChanges();
        }
    }
}