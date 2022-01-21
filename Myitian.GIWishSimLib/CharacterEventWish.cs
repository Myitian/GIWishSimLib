namespace Myitian.GIWishSimLib
{
    /// <summary>
    /// 角色活动祈愿
    /// </summary>
    public class CharacterEventWish : Wish
    {
        /// <summary>角色活动祈愿</summary>
        public CharacterEventWish() : this("角色活动祈愿", "角色活动祈愿_CharacterEventWish") { }
        /// <summary>角色活动祈愿</summary>
        /// <param name="wishName">祈愿名称</param>
        public CharacterEventWish(string wishName) : this(wishName, "角色活动祈愿_CharacterEventWish") { }
        /// <summary>角色活动祈愿</summary>
        /// <param name="wishName">祈愿名称</param>
        /// <param name="wishID">祈愿ID</param>
        public CharacterEventWish(string wishName, string wishID) : base(wishName, wishID)
        {
            WishType = WishTypes.CharacterEventWish;
            Pity = PityCalc.CharacterEventWishPity;
            Smoother = SmootherCalc.CharacterEventWishSmoothWeight;
        }

        /// <summary>角色活动祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        public CharacterEventWish(WishItems items) : this(items, "角色活动祈愿", "角色活动祈愿_CharacterEventWish") { }
        /// <summary>角色活动祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        /// <param name="wishName">祈愿名称</param>
        public CharacterEventWish(WishItems items, string wishName) : this(items, wishName, "角色活动祈愿_CharacterEventWish") { }
        /// <summary>角色活动祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        /// <param name="wishName">祈愿名称</param>
        /// <param name="wishID">祈愿ID</param>
        public CharacterEventWish(WishItems items, string wishName, string wishID) : base(items, wishName, wishID)
        {
            WishType = WishTypes.CharacterEventWish;
            Pity = PityCalc.CharacterEventWishPity;
            Smoother = SmootherCalc.CharacterEventWishSmoothWeight;
        }

        /// <summary>角色活动祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        /// <param name="counter">祈愿计数器</param>
        public CharacterEventWish(WishItems items, WishCounter counter) : this(items, counter, "角色活动祈愿", "角色活动祈愿_CharacterEventWish") { }
        /// <summary>角色活动祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        /// <param name="counter">祈愿计数器</param>
        /// <param name="wishName">祈愿名称</param>
        public CharacterEventWish(WishItems items, WishCounter counter, string wishName) : this(items, counter, wishName, "角色活动祈愿_CharacterEventWish") { }
        /// <summary>角色活动祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        /// <param name="counter">祈愿计数器</param>
        /// <param name="wishName">祈愿名称</param>
        /// <param name="wishID">祈愿ID</param>
        public CharacterEventWish(WishItems items, WishCounter counter, string wishName, string wishID) : base(items, counter, wishName, wishID)
        {
            WishType = WishTypes.CharacterEventWish;
            Pity = PityCalc.CharacterEventWishPity;
            Smoother = SmootherCalc.CharacterEventWishSmoothWeight;
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
                        Counter.C4StarCharacter = 1;
                        Counter.C4StarWeapon++;
                        Counter.C5StarCharacter++;
                        Counter.C5StarWeapon++;
                        return new WishItemInfo()
                        {
                            ItemType = ItemTypes.Character,
                            IsUP = true,
                            IsEP = false,
                            Name = Items.Item_4Star_UP_Character[Rng.ItemRNG(Items.Item_4Star_UP_Character.Length)]
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
                    Counter.C5StarCharacter = 1;
                    Counter.C5StarWeapon++;
                    if (Rng.UPRNG(.5, ref Counter.UP5Star))
                    {
                        return new WishItemInfo()
                        {
                            ItemType = ItemTypes.Character,
                            IsUP = true,
                            IsEP = false,
                            Name = Items.Item_5Star_UP_Character[Rng.ItemRNG(Items.Item_5Star_UP_Character.Length)]
                        };
                    }
                    else
                    {
                        return new WishItemInfo()
                        {
                            ItemType = ItemTypes.Character,
                            IsUP = false,
                            IsEP = false,
                            Name = Items.Item_5Star_Character[Rng.ItemRNG(Items.Item_5Star_Character.Length)]
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
