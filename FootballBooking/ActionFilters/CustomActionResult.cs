using Microsoft.AspNetCore.Mvc;

namespace FootballBooking.ActionFilters
{
    public class CustomActionResult : IActionResult
    {
        //public Task ExecuteResultAsync(ActionContext context)
        //{
        //   var  context.
        //}
        public Task ExecuteResultAsync(ActionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
