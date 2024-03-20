using ApplicationCore.Contracts.IRepository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CustomerRepositoryAsync : BaseRepositoryAsync<Customer>, ICustomerRepositoryAsync
    {
        public CustomerRepositoryAsync(CustomerDBContext tb) : base(tb)
        {
        }
    }
}
