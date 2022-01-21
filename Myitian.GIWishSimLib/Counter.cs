namespace Myitian.GIWishSimLib
{
    /// <summary>
    /// 祈愿计数器
    /// </summary>
    public class WishCounter
    {
        /// <summary>计数器</summary>
        public long Counter = 0;

        /// <summary>5星计数器</summary>
        public int C5Star = 1;
        /// <summary>5星角色计数器</summary>
        public int C5StarCharacter = 1;
        /// <summary>5星武器计数器</summary>
        public int C5StarWeapon = 1;
        /// <summary>4星计数器</summary>
        public int C4Star = 1;
        /// <summary>4星角色计数器</summary>
        public int C4StarCharacter = 1;
        /// <summary>4星武器计数器</summary>
        public int C4StarWeapon = 1;
        /// <summary>命定值</summary>
        public int FatePoint = 0;
        /// <summary>是否为5星UP</summary>
        public bool UP5Star = false;
        /// <summary>是否为4星UP</summary>
        public bool UP4Star = false;

        /// <summary>祈愿计数器</summary>
        public WishCounter() { }
        /// <summary>祈愿计数器</summary>
        /// <param name="wishCounter">源祈愿计数器</param>
        public WishCounter(WishCounter wishCounter)
        {
            Counter = wishCounter.Counter;

            C5Star = wishCounter.C5Star;
            C5StarCharacter = wishCounter.C5StarCharacter;
            C5StarWeapon = wishCounter.C5StarWeapon;
            C4Star = wishCounter.C4Star;
            C4StarCharacter = wishCounter.C4StarCharacter;
            C4StarWeapon = wishCounter.C4StarWeapon;

            FatePoint = wishCounter.FatePoint;

            UP5Star = wishCounter.UP5Star;
            UP4Star = wishCounter.UP4Star;
        }
        /// <summary>重置计数器</summary>
        /// <returns></returns>
        public bool Reset()
        {
            Counter = 1;

            C5Star = 1;
            C5StarCharacter = 1;
            C5StarWeapon = 1;
            C4Star = 1;
            C4StarCharacter = 1;
            C4StarWeapon = 1;

            FatePoint = 0;

            UP5Star = false;
            UP4Star = false;

            return true;
        }
    }
}
