using ABCretail2.Models;
using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ABCretail2.Controllers
{
    public class UsersController : Controller
    {
        private readonly TableClient _tableClient;

        // Constructor to inject the TableClient for accessing Azure Table Storage
        public UsersController(TableServiceClient tableServiceClient)
        {
            _tableClient = tableServiceClient.GetTableClient("UsersTable");  // Use your table name
        }

        // Index action to retrieve and display the list of users
        public async Task<IActionResult> Index()
        {
            // Query all users from the Azure Table Storage
            var users = _tableClient.Query<UserModel>().ToList();

            // Pass the list of users to the view
            return View(users);
        }
    }
}
