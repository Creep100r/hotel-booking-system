using System;
using System.Collections.Generic;
using System.Text;

namespace hotel_booking_system
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> data, int currentPage, int skip)
        {
            return data.Skip(currentPage * skip).Take(skip);
        }
    }
}
