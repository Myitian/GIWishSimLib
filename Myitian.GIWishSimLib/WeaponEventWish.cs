namespace Myitian.GIWishSimLib
{
    /// <summary>
    /// 武器活动祈愿
    /// </summary>
    public class WeaponEventWish : Wish
    {
        /// <summary>武器活动祈愿</summary>
        public WeaponEventWish() : this("武器活动祈愿", "武器活动祈愿_WeaponEventWish") { }
        /// <summary>武器活动祈愿</summary>
        /// <param name="wishName">祈愿名称</param>
        public WeaponEventWish(string wishName) : this(wishName, "武器活动祈愿_WeaponEventWish") { }
        /// <summary>武器活动祈愿</summary>
        /// <param name="wishName">祈愿名称</param>
        /// <param name="wishID">祈愿ID</param>
        public WeaponEventWish(string wishName, string wishID) : base(wishName, wishID)
        {
            WishType = WishTypes.WeaponEventWish;
            Pity = PityCalc.WeaponEventWishPity;
            Smoother = SmootherCalc.WeaponEventWishSmoothWeight;
        }

        /// <summary>武器活动祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        public WeaponEventWish(WishItems items) : this(items, "武器活动祈愿", "武器活动祈愿_WeaponEventWish") { }
        /// <summary>武器活动祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        /// <param name="wishName">祈愿名称</param>
        public WeaponEventWish(WishItems items, string wishName) : this(items, wishName, "武器活动祈愿_WeaponEventWish") { }
        /// <summary>武器活动祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        /// <param name="wishName">祈愿名称</param>
        /// <param name="wishID">祈愿ID</param>
        public WeaponEventWish(WishItems items, string wishName, string wishID) : base(items, wishName, wishID)
        {
            WishType = WishTypes.WeaponEventWish;
            Pity = PityCalc.WeaponEventWishPity;
            Smoother = SmootherCalc.WeaponEventWishSmoothWeight;
        }

        /// <summary>武器活动祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        /// <param name="counter">祈愿计数器</param>
        public WeaponEventWish(WishItems items, WishCounter counter) : this(items, counter, "武器活动祈愿", "武器活动祈愿_WeaponEventWish") { }
        /// <summary>武器活动祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        /// <param name="counter">祈愿计数器</param>
        /// <param name="wishName">祈愿名称</param>
        public WeaponEventWish(WishItems items, WishCounter counter, string wishName) : this(items, counter, wishName, "武器活动祈愿_WeaponEventWish") { }
        /// <summary>武器活动祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        /// <param name="counter">祈愿计数器</param>
        /// <param name="wishName">祈愿名称</param>
        /// <param name="wishID">祈愿ID</param>
        public WeaponEventWish(WishItems items, WishCounter counter, string wishName, string wishID) : base(items, counter, wishName, wishID)
        {
            WishType = WishTypes.WeaponEventWish;
            Pity = PityCalc.WeaponEventWishPity;
            Smoother = SmootherCalc.WeaponEventWishSmoothWeight;
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
                    if (Rng.UPRNG(.5, ref Counter.UP4Star))
                    {
                        Counter.C4StarCharacter++;
                        Counter.C4StarWeapon = 1;
                        Counter.C5StarCharacter++;
                        Counter.C5StarWeapon++;
                        return new WishItemInfo()
                        {
                            ItemType = ItemTypes.Weapon,
                            IsUP = true,
                            IsEP = false,
                            Name = Items.Item_4Star_UP_Weapon[Rng.ItemRNG(Items.Item_4Star_UP_Weapon.Length)]
                        };
                    }
                    else
                    {
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
                    }
                case 5:
                    Counter.C4StarCharacter++;
                    Counter.C4StarWeapon++;
                    Counter.C5StarCharacter++;
                    Counter.C5StarWeapon = 1;
                    if (EpitomizedPath >= 0 && Counter.FatePoint == 2)
                    {
                        Counter.FatePoint = 0;
                        return new WishItemInfo()
                        {
                            ItemType = ItemTypes.Weapon,
                            IsUP = true,
                            IsEP = true,
                            Name = Items.Item_5Star_UP_Weapon[EpitomizedPath]
                        };
                    }
                    if (Rng.UPRNG(.75, ref Counter.UP5Star))
                    {
                        int i = Rng.ItemRNG(Items.Item_5Star_UP_Weapon.Length);
                        bool inep = EpitomizedPath >= 0;
                        bool isep = i == EpitomizedPath;
                        if (inep)
                        {
                            if (isep)
                            {
                                Counter.FatePoint = 0;
                            }
                            else
                            {
                                Counter.FatePoint++;
                            }
                        }
                        return new WishItemInfo()
                        {
                            ItemType = ItemTypes.Weapon,
                            IsUP = true,
                            IsEP = inep && isep,
                            Name = Items.Item_5Star_UP_Weapon[i]
                        };
                    }
                    else
                    {
                        if (EpitomizedPath >= 0)
                        {
                            Counter.FatePoint++;
                        }
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
