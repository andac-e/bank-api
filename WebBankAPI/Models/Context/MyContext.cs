using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebBankAPI.Models.Entities;
using WebBankAPI.Models.Init;

namespace WebBankAPI.Models.Context
{
    public class MyContext:DbContext
    {
        public MyContext():base("MyConnection")
        {
            Database.SetInitializer(new MyInit());
        }

        public DbSet<CardInfo> Cards { get; set; }

    }
}