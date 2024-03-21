using ProductAPI.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.ApplicationCore.Contracts.IRepository
{
    public interface IReviewRepositoryAsync:IBaseRepositoryAsync<Review>
    {
        Task<IEnumerable<Review>> GetReviewsByProductAsync(int productId);
    }
}
