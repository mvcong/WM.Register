using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WM.Register.Models
{
    public class RegisterDbContext : DbContext
    {
        public RegisterDbContext() : base("name = RegisterDbContext")
        {

        }
        //public virtual DbSet<srv_VNOGateWay_Merchant> mc_merchantss { get; set; }
    }
}