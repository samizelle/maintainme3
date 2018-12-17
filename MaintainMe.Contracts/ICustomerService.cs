using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintainMe.Models;

namespace MaintainMe.Contracts
{
    public interface ICustomerService
    {
        bool CreateCustomer(CustomerCreate model);
        IEnumerable<CustomerListItem> GetCustomers();
        CustomerDetail GetCustomerById(int customerId);
        bool UpdateCustomer(CustomerEdit model);
        bool DeleteCustomer(int customerId);

    }
}
