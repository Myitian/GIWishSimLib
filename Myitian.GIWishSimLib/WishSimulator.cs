namespace Myitian.GIWishSimLib
{
    /// <summary>
    /// 祈愿结果
    /// </summary>
    public class WishResult
    {
        /// <summary>计数器</summary>
        public long Counter;

        /// <summary>5星计数器</summary>
        public int C5Star;
        /// <summary>5星角色计数器</summary>
        public int C5StarCharacter;
        /// <summary>5星武器计数器</summary>
        public int C5StarWeapon;
        /// <summary>4星计数器</summary>
        public int C4Star;
        /// <summary>4星角色计数器</summary>
        public int C4StarCharacter;
        /// <summary>4星武器计数器</summary>
        public int C4StarWeapon;
        /// <summary>命定值</summary>
        public int FatePoint;

        /// <summary>是否为UP</summary>
        public bool IsUP;
        /// <summary>是否为定轨</summary>
        public bool IsEpitomizedPath;

        /// <summary>星级</summary>
        public int Star;
        /// <summary>名称</summary>
        public string Name;
        /// <summary>物品类型</summary>
        public ItemTypes ItemType;
        /// <summary>祈愿类型</summary>
        public WishTypes WishType;
    }
    /// <summary>
    /// 祈愿模拟器
    /// </summary>
    public static class WishSimulator
    {
        /// <summary>
        /// 获取一次祈愿
        /// </summary>
        /// <param name="wish">要抽取的祈愿</param>
        /// <returns></returns>
        public static WishResult GetWish(ref Wish wish)
        {
            if (wish.Counter.Counter >= wish.Limit || wish.Counter.Counter < 0)
            {
                return null;
            }
            WishResult wishResult = new WishResult()
            {
                Counter = wish.Counter.Counter,
                C5Star = wish.Counter.C5Star,
                C5StarCharacter = wish.Counter.C5StarCharacter,
                C5StarWeapon = wish.Counter.C5StarWeapon,
                C4Star = wish.Counter.C4Star,
                C4StarCharacter = wish.Counter.C4StarCharacter,
                C4StarWeapon = wish.Counter.C4StarWeapon,
                FatePoint = wish.Counter.FatePoint,
                WishType = wish.WishType
            };
            wish.Counter.Counter++;

            int[] weights = wish.Pity(wish.Counter.C4Star, wish.Counter.C5Star);
            int a = weights[0],
                b = a + weights[1],
                c = b + weights[2],
                rndnum = Rng.StarRNG(c);
            byte starlevel = 3;
            if (rndnum <= a)
            {
                starlevel = 5;
                wish.Counter.C5Star = 1;
                wish.Counter.C4Star++;
            }
            else if (rndnum <= b)
            {
                starlevel = 4;
                wish.Counter.C5Star++;
                wish.Counter.C4Star = 1;
            }
            else if (rndnum <= c)
            {
                wish.Counter.C5Star++;
                wish.Counter.C4Star++;
            }
            wishResult.Star = starlevel;

            WishItemInfo item = wish.GetItem(starlevel);
            wishResult.IsUP = item.IsUP;
            wishResult.IsEpitomizedPath = item.IsEP;
            wishResult.Name = item.Name;
            wishResult.ItemType = item.ItemType;

            return wishResult;
        }
    }
}
