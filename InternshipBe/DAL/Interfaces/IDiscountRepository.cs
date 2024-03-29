﻿using DAL.Entities;
using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDiscountRepository : IRepository<Discount>
    {
        IQueryable<Discount> SearchDiscounts(string searchQuery, int[] tagIDs, Point location, int radius, bool isUser);

        Task<SavedDiscount> GetSavedDiscountAsync(int id, int userId);

        Task<SavedDiscount> CreateSavedDiscountAsync(Discount discount, User user);

        IQueryable<Discount> GetClosestDiscounts(Point location, int radius, bool isUser);

        Task<Assessment> GetUserAssessmentAsync(int id, int userId);

        Task<Assessment> CreateAssessmentAsync(Discount discount, User user, int assessmnetValue);

        Task<IEnumerable<PointOfSale>> GetPointOfSalesAsync(int id);

        IQueryable<Discount> SearchStatisticDiscountsAsync(string searchQuery);

        IQueryable<Discount> SortDiscounts(IQueryable<Discount> discounts, SortTypes sortBy, Point location);

        Task<double?> GetDiscountRatingAsync(int id);

        Task<ICollection<string>> GetDiscountTagsAsync(int id);

        Task<bool> IsSavedDiscountAsync(int id, int userId);

        Task<bool> IsOrderedDiscountAsync(int id, int userId);

        Task<(string, int)> GetAddressAndDistanceToClosestPointOfSaleAsync(int id, Point location);

        IOrderedQueryable<Discount> SortBy(IQueryable<Discount> discounts, SortTypes sortBy);

        IOrderedQueryable<Discount> ThenSortBy(IOrderedQueryable<Discount> discounts, SortTypes sortBy);

        Task<int> GetDiscountTicketCountAsync(int id);

        Task<int> GetTotalNumberOfDiscountsAsync(IQueryable<Discount> discounts);

        Task<IEnumerable<string>> SearchHintsAsync(string subSearchQuery, int take);

        Task UpdateDiscountActivityStatusAsync(int id, bool activityStatus);
    }
}
