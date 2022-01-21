namespace Myitian.GIWishSimLib
{
    /// <summary>
    /// 新手祈愿
    /// </summary>
    public class NoviceWish : Wish
    {
        /// <summary>是否为第一个四星</summary>
        public bool IsFirst4Star { get; set; } = true;

        /// <summary>新手祈愿</summary>
        public NoviceWish() : this("新手祈愿", "新手祈愿_NoviceWish") { }
        /// <summary>新手祈愿</summary>
        /// <param name="wishName">祈愿名称</param>
        public NoviceWish(string wishName) : this(wishName, "新手祈愿_NoviceWish") { }
        /// <summary>新手祈愿</summary>
        /// <param name="wishName">祈愿名称</param>
        /// <param name="wishID">祈愿ID</param>
        public NoviceWish(string wishName, string wishID) : base(wishName, wishID)
        {
            WishType = WishTypes.NoviceWish;
            Pity = PityCalc.NoviceWishPity;
        }

        /// <summary>新手祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        public NoviceWish(WishItems items) : this(items, "新手祈愿", "新手祈愿_NoviceWish") { }
        /// <summary>新手祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        /// <param name="wishName">祈愿名称</param>
        public NoviceWish(WishItems items, string wishName) : this(items, wishName, "新手祈愿_NoviceWish") { }
        /// <summary>新手祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        /// <param name="wishName">祈愿名称</param>
        /// <param name="wishID">祈愿ID</param>
        public NoviceWish(WishItems items, string wishName, string wishID) : base(items, wishName, wishID)
        {
            WishType = WishTypes.NoviceWish;
            Pity = PityCalc.NoviceWishPity;
        }

        /// <summary>新手祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        /// <param name="counter">祈愿计数器</param>
        public NoviceWish(WishItems items, WishCounter counter) : this(items, counter, "新手祈愿", "新手祈愿_NoviceWish") { }
        /// <summary>新手祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        /// <param name="counter">祈愿计数器</param>
        /// <param name="wishName">祈愿名称</param>
        public NoviceWish(WishItems items, WishCounter counter, string wishName) : this(items, counter, wishName, "新手祈愿_NoviceWish") { }
        /// <summary>新手祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        /// <param name="counter">祈愿计数器</param>
        /// <param name="wishName">祈愿名称</param>
        /// <param name="wishID">祈愿ID</param>
        public NoviceWish(WishItems items, WishCounter counter, string wishName, string wishID) : base(items, counter, wishName, wishID)
        {
            WishType = WishTypes.NoviceWish;
            Pity = PityCalc.NoviceWishPity;
        }

        /// <summary>
        /// 重置祈愿及其计数器
        /// </summary>
        /// <returns></returns>
        public new bool Reset()
        {
            Counter.Reset();
            IsFirst4Star = true;
            EpitomizedPath = -1;
            return true;
        }
        /// <summary>
        /// 更新祈愿物品
        /// </summary>
        /// <returns></returns>
        public new bool Update(WishItems newItems)
        {
            if (ResetCounterWhenUpdated)
            {
                Counter.Reset();
                IsFirst4Star = true;
            }
            Items = newItems;
            return true;
        }
        /// <summary>
        /// 获取指定星级的物品
        /// </summary>
        /// <param name="starlevel">星级</param>
        /// <returns>一个 WishItemInfo ，包含了物品信息</returns>
        public override WishItemInfo GetItem(byte starlevel)
        {
            switch (starlevel)
            {
                case 3:
                    return new WishItemInfo()
                    {
                        ItemType = ItemTypes.Weapon,
                        IsUP = false,
                        IsEP = false,
                        Name = Items.Item_3Star[Rng.ItemRNG(Items.Item_3Star.Length)]
                    };
                case 4:
                    if (IsFirst4Star)
                    {
                        IsFirst4Star = false;
                        return new WishItemInfo()
                        {
                            ItemType = ItemTypes.Character,
                            IsUP = true,
                            IsEP = false,
                            Name = Items.Item_4Star_UP_Character[Rng.ItemRNG(Items.Item_4Star_UP_Character.Length)]
                        };
                    }
                    return new WishItemInfo()
                    {
                        ItemType = ItemTypes.Character,
                        IsUP = false,
                        IsEP = false,
                        Name = Items.Item_4Star_Character[Rng.ItemRNG(Items.Item_4Star_Character.Length)]
                    };
                case 5:
                    return new WishItemInfo()
                    {
                        ItemType = ItemTypes.Character,
                        IsUP = false,
                        IsEP = false,
                        Name = Items.Item_5Star_Character[Rng.ItemRNG(Items.Item_5Star_Character.Length)]
                    };
                default:
                    return new WishItemInfo()
                    {
                        ItemType = ItemTypes.Unknown,
                        IsUP = false,
                        IsEP = false,
                        Name = string.Empty
                    };
            }
        }
    }
}
