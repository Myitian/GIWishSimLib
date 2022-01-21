namespace Myitian.GIWishSimLib
{
    /// <summary>
    /// 常驻祈愿
    /// </summary>
    public class StandardWish : Wish
    {
        /// <summary>常驻祈愿</summary>
        public StandardWish() : this("常驻祈愿", "常驻祈愿_StandardWish") { }
        /// <summary>常驻祈愿</summary>
        /// <param name="wishName">祈愿名称</param>
        public StandardWish(string wishName) : this(wishName, "常驻祈愿_StandardWish") { }
        /// <summary>常驻祈愿</summary>
        /// <param name="wishName">祈愿名称</param>
        /// <param name="wishID">祈愿ID</param>
        public StandardWish(string wishName, string wishID) : base(wishName, wishID)
        {
            WishType = WishTypes.StandardWish;
            Pity = PityCalc.StandardWishPity;
            Smoother = SmootherCalc.StandardWishSmoothWeight;
        }

        /// <summary>常驻祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        public StandardWish(WishItems items) : this(items, "常驻祈愿", "常驻祈愿_StandardWish") { }
        /// <summary>常驻祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        /// <param name="wishName">祈愿名称</param>
        public StandardWish(WishItems items, string wishName) : this(items, wishName, "常驻祈愿_StandardWish") { }
        /// <summary>常驻祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        /// <param name="wishName">祈愿名称</param>
        /// <param name="wishID">祈愿ID</param>
        public StandardWish(WishItems items, string wishName, string wishID) : base(items, wishName, wishID)
        {
            WishType = WishTypes.StandardWish;
            Pity = PityCalc.StandardWishPity;
            Smoother = SmootherCalc.StandardWishSmoothWeight;
        }

        /// <summary>常驻祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        /// <param name="counter">祈愿计数器</param>
        public StandardWish(WishItems items, WishCounter counter) : this(items, counter, "常驻祈愿", "常驻祈愿_StandardWish") { }
        /// <summary>常驻祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        /// <param name="counter">祈愿计数器</param>
        /// <param name="wishName">祈愿名称</param>
        public StandardWish(WishItems items, WishCounter counter, string wishName) : this(items, counter, wishName, "常驻祈愿_StandardWish") { }
        /// <summary>常驻祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        /// <param name="counter">祈愿计数器</param>
        /// <param name="wishName">祈愿名称</param>
        /// <param name="wishID">祈愿ID</param>
        public StandardWish(WishItems items, WishCounter counter, string wishName, string wishID) : base(items, counter, wishName, wishID)
        {
            WishType = WishTypes.StandardWish;
            Pity = PityCalc.StandardWishPity;
            Smoother = SmootherCalc.StandardWishSmoothWeight;
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
                    Counter.C4StarCharacter++;
                    Counter.C4StarWeapon++;
                    Counter.C5StarCharacter++;
                    Counter.C5StarWeapon++;
                    return new WishItemInfo()
                    {
                        ItemType = ItemTypes.Weapon,
                        IsUP = false,
                        IsEP = false,
                        Name = Items.Item_3Star[Rng.ItemRNG(Items.Item_3Star.Length)]
                    };
                case 4:
                    int[] s4sw = Smoother(Counter.C4StarCharacter, Counter.C4StarWeapon, 4);
                    int s4swr = Rng.StarRNG(s4sw[0] + s4sw[1]);
                    if (s4swr <= s4sw[0]) //角色
                    {
                        Counter.C4StarCharacter = 1;
                        Counter.C4StarWeapon++;
                        Counter.C5StarCharacter++;
                        Counter.C5StarWeapon++;
                        return new WishItemInfo()
                        {
                            ItemType = ItemTypes.Character,
                            IsUP = false,
                            IsEP = false,
                            Name = Items.Item_4Star_Character[Rng.ItemRNG(Items.Item_4Star_Character.Length)]
                        };
                    }
                    else //武器
                    {
                        Counter.C4StarCharacter++;
                        Counter.C4StarWeapon = 1;
                        Counter.C5StarCharacter++;
                        Counter.C5StarWeapon++;
                        return new WishItemInfo()
                        {
                            ItemType = ItemTypes.Weapon,
                            IsUP = false,
                            IsEP = false,
                            Name = Items.Item_4Star_Weapon[Rng.ItemRNG(Items.Item_4Star_Weapon.Length)]
                        };
                    }
                case 5:
                    int[] s5sw = Smoother(Counter.C5StarCharacter, Counter.C5StarWeapon, 5);
                    int s5swr = Rng.StarRNG(s5sw[0] + s5sw[1]);
                    if (s5swr <= s5sw[0]) //角色
                    {
                        Counter.C4StarCharacter++;
                        Counter.C4StarWeapon++;
                        Counter.C5StarCharacter = 1;
                        Counter.C5StarWeapon++;
                        return new WishItemInfo()
                        {
                            ItemType = ItemTypes.Character,
                            IsUP = false,
                            IsEP = false,
                            Name = Items.Item_5Star_Character[Rng.ItemRNG(Items.Item_5Star_Character.Length)]
                        };
                    }
                    else //武器
                    {
                        Counter.C4StarCharacter++;
                        Counter.C4StarWeapon++;
                        Counter.C5StarCharacter++;
                        Counter.C5StarWeapon = 1;
                        return new WishItemInfo()
                        {
                            ItemType = ItemTypes.Weapon,
                            IsUP = false,
                            IsEP = false,
                            Name = Items.Item_5Star_Weapon[Rng.ItemRNG(Items.Item_5Star_Weapon.Length)]
                        };
                    }
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
