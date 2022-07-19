using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalesWebsite.CustomerSite.Services;
using SalesWebsite.Shared.Constants;
using SalesWebsite.Shared.CreateRequest;

namespace SalesWebsite.CustomerSite.Pages.Customer
{
    public class RegisterModel : PageModel
    {

        private readonly ICustomerService _customeService;

        public string Error { get; set; }

        public RegisterModel(ICustomerService customeService)
        {
            _customeService = customeService;
        }

        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            var customerRegister = new CustomerCreateRequest()
            {
                UserName = Request.Form["userName"],
                FullName = Request.Form["fullName"],
                Password = Request.Form["password"],
                ConfirmPassword = Request.Form["confirmPassword"]
            };

            var isSucess = await _customeService.RegisterAsync(customerRegister);
            if(isSucess == true)
            {
                Response.Redirect(PagesConstants.LOGIN);
            } else
            {
                Error = "Tài khoản đã tồn tại";
            }

        }
    }
}
