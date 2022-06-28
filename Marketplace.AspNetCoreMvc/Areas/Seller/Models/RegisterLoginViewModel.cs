using Marketplace.Model.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.AspNetCoreMvc.Areas.Seller.Models
{
    public class RegisterLoginViewModel
    {
        public SellerRegisterDto RegisterModel { get; set; }
        public LoginDto LoginModel { get; set; }
    }
}
