using System.Collections.Generic;
using Application.Domains;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Pages.Components.Footer
{
    [ViewComponent]
    public class Footer : ViewComponent
    {
        private readonly IPhoneService _phoneSer;
        private readonly IInfoService _infoSer;
        private readonly IAddressService _addressSer;
        private readonly ISocialService _socialSer;
        public Footer(
            IPhoneService phoneSer,
            IInfoService infoSer,
            IAddressService addressSer,
            ISocialService socialSer)
        {
            _phoneSer = phoneSer;
            _infoSer = infoSer;
            _addressSer = addressSer;
            _socialSer = socialSer;
        }
        public IViewComponentResult Invoke()
        {
            var lsSocial = new List<Social>() { new Social() { Id = 1, Name = "Facebook", Link = "fb.com/dangviettoan99" } };
            var data = new FooterModel()
            {
                InfoShop = _infoSer.GetItem(1),
                Phones = (List<Phone>)_phoneSer.GetListItems(),
                Addresses = (List<Address>)_addressSer.GetListItems(),
                Socials = lsSocial
            };
            return View(data);
        }

        public class FooterModel
        {
            public InfoShop InfoShop { get; set; }
            public List<Phone> Phones { get; set; }
            public List<Address> Addresses { get; set; }
            public List<Social> Socials { get; set; }
        }
    }
}