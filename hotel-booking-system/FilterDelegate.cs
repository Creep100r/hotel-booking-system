using System;
using System.Collections.Generic;
using System.Text;

namespace hotel_booking_system
{
    public delegate bool FilterDelegate<T>(T entity) where T : IEntity;
}
