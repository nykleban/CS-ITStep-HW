using ShopMVC.ViewModels;

namespace ShopMVC.Services
{
    public static class CartService
    {
        private static string Key = "v2cv1uc312uc12c3chb1v2";

        public static void SetItems(ISession session, IEnumerable<SessionCartItemVM> items)
        {
            session.Set(Key, items);
        }

        public static List<SessionCartItemVM> GetItems(ISession session)
        {
            return session.Get<List<SessionCartItemVM>>(Key) ?? new List<SessionCartItemVM>();
        }

        public static int GetDistinctCount(ISession session)
        {
            return GetItems(session).Count;
        }

        public static int GetTotalQuantity(ISession session)
        {
            return GetItems(session).Sum(i => i.Count);
        }

        public static void AddToCart(ISession session, int productId)
        {
            var items = GetItems(session);
            var item = items.FirstOrDefault(i => i.ProductId == productId);

            if (item == null)
                items.Add(new SessionCartItemVM { ProductId = productId, Count = 1 });
            else
                item.Count++;

            SetItems(session, items);
        }

        public static void Increase(ISession session, int productId)
        {
            var items = GetItems(session);
            var item = items.FirstOrDefault(i => i.ProductId == productId);

            if (item != null) item.Count++;

            SetItems(session, items);
        }

        public static void Decrease(ISession session, int productId)
        {
            var items = GetItems(session);
            var item = items.FirstOrDefault(i => i.ProductId == productId);

            if (item != null)
            {
                item.Count--;
                if (item.Count < 1)
                    items = items.Where(i => i.ProductId != productId).ToList();
            }

            SetItems(session, items);
        }

        public static void RemoveFromCart(ISession session, int productId)
        {
            var items = GetItems(session).Where(i => i.ProductId != productId).ToList();
            SetItems(session, items);
        }

        public static bool IsInCart(ISession session, int productId)
        {
            return GetItems(session).Any(i => i.ProductId == productId);
        }

        public static void Clear(ISession session)
        {
            SetItems(session, new List<SessionCartItemVM>());
        }
    }
}
