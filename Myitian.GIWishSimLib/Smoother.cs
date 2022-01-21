namespace Myitian.GIWishSimLib
{
    /// <summary>
    /// 平稳机制
    /// </summary>
    public static class SmootherCalc
    {
        /// <summary>
        /// 权重限制器
        /// </summary>
        /// <param name="input">输入 int[3]</param>
        /// <param name="limit">限制</param>
        /// <returns>int[3]，超出限制的被截断</returns>
        public static int[] WeightLimiter(in int[] input, int limit = 10000)
        {
            int a = input[0];
            int b = input[1];
            if (a > b)
            {
                if (a > limit)
                {
                    return new int[] { limit, 0 };
                }
                int c = a + b;
                if (c > limit)
                {
                    return new int[] { a, c - limit };
                }
            }
            else
            {
                if (b > limit)
                {
                    return new int[] { 0, limit };
                }
                int c = a + b;
                if (c > limit)
                {
                    return new int[] { c - limit, b };
                }
            }
            return input;
        }

        /// <summary>
        /// 角色活动祈愿平稳机制
        /// </summary>
        /// <param name="characterCounter">角色计数器</param>
        /// <param name="weaponCounter">武器计数器</param>
        /// <param name="star">物品星级</param>
        /// <returns>int[2]，第一项为角色概率，第二项为武器概率</returns>
        public static int[] CharacterEventWishSmoothWeight(int characterCounter, int weaponCounter, byte star = 4)
        {
            return StandardWishSmoothWeight(characterCounter, weaponCounter, star);
        }
        /// <summary>
        /// 角色活动祈愿2平稳机制
        /// </summary>
        /// <param name="characterCounter">角色计数器</param>
        /// <param name="weaponCounter">武器计数器</param>
        /// <param name="star">物品星级</param>
        /// <returns>int[2]，第一项为角色概率，第二项为武器概率</returns>
        public static int[] CharacterEventWish2SmoothWeight(int characterCounter, int weaponCounter, byte star = 4)
        {
            return StandardWishSmoothWeight(characterCounter, weaponCounter, star);
        }
        /// <summary>
        /// 常驻祈愿平稳机制
        /// </summary>
        /// <param name="characterCounter">角色计数器</param>
        /// <param name="weaponCounter">武器计数器</param>
        /// <param name="star">物品星级</param>
        /// <returns>int[2]，第一项为角色概率，第二项为武器概率</returns>
        public static int[] StandardWishSmoothWeight(int characterCounter, int weaponCounter, byte star)
        {
            int[] r = new int[2];
            switch (star)
            {
                case 4:
                    r[0] = 255;
                    if (characterCounter >= 18)
                        r[0] += 2550 * (characterCounter - 17);
                    r[1] = 255;
                    if (weaponCounter >= 18)
                        r[1] += 2550 * (weaponCounter - 17);
                    break;
                case 5:
                    r[0] = 30;
                    if (characterCounter >= 148)
                        r[0] += 300 * (characterCounter - 147);
                    r[1] = 30;
                    if (weaponCounter >= 148)
                        r[1] += 300 * (weaponCounter - 147);
                    break;
            }
            return WeightLimiter(r);
        }
        /// <summary>
        /// 武器活动祈愿平稳机制
        /// </summary>
        /// <param name="characterCounter">角色计数器</param>
        /// <param name="weaponCounter">武器计数器</param>
        /// <param name="star">没有作用，仅为了匹配接口</param>
        /// <returns>int[2]，第一项为角色概率，第二项为武器概率</returns>
        public static int[] WeaponEventWishSmoothWeight(int characterCounter, int weaponCounter, byte star = 4)
        {
            int[] r = new int[2];
            r[0] = 300;
            if (characterCounter >= 16)
                r[0] += 3000 * (characterCounter - 15);
            r[1] = 300;
            if (weaponCounter >= 16)
                r[1] += 3000 * (weaponCounter - 15);
            return WeightLimiter(r);
        }
    }
}