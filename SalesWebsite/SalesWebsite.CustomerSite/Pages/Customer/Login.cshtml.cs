using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalesWebsite.CustomerSite.Services;
using SalesWebsite.Shared.Constants;
using SalesWebsite.Shared.Dto.Customer;

namespace SalesWebsite.CustomerSite.Pages
{
    public class CustomerModel : PageModel
    {

        private readonly ICustomerService _customerService;

        public CustomerModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public string Error { get; set; }
        public void OnGet()
        {
            if(Request.Cookies["token"] != null)
            {
                Response.Cookies.Delete("token");
                Response.Cookies.Delete("userName");
                Response.Cookies.Delete("fullName");
            }
        }
        public async Task OnPostAsync()
        {
            var customer = new CustomerLoginRequest()
            {
                UserName = Request.Form["userName"],
                Password = Request.Form["password"]
            };

            var customerResponse =  await _customerService.LoginAsync(customer);

            if(customerResponse != null)
            {
                var cookieOption = new CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(1),
                };
                Response.Cookies.Append("token", customerResponse.Token, cookieOption);
                Response.Cookies.Append("userName", customerResponse.UserName, cookieOption);
                Response.Cookies.Append("fullName", customerResponse.FullName, cookieOption);
                //Response.Cookies.Append("role", customerResponse.IsAdmin.ToString, cookieOption);

                Response.Redirect(PagesConstants.PRODUCT);
            } else
            {
                Error = "Sai tên tài khoản hoặc mật khẩu";
            }
           

        }
    }
}
