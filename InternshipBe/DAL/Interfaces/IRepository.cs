﻿using Microsoft.EntityFrameworkCore.Storage;
using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task CreateAsync(TEntity item);

        Task SaveChangesAsync();

        Point GetLocation(double officeLatitude, double officeLongitude, double latittude = 0, double longitude = 0);

        Task<IDbContextTransaction> BeginTrancation();

        Task<IEnumerable<TEntity>> GetSpecifiedAmountAsync(IQueryable<TEntity> entities, int skip, int take);

        SortTypes GetSortType(string sortBy);
    }
}
