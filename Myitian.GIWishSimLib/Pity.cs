namespace Myitian.GIWishSimLib
{
    /// <summary>
    /// 保底计算
    /// </summary>
    public static class PityCalc
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
            if (a > limit)
            {
                return new int[] { limit, 0, 0 };
            }
            int b = a + input[1];
            if (b > limit)
            {
                return new int[] { input[0], b - limit, 0 };
            }
            int c = b + input[2];
            if (c > limit)
            {
                return new int[] { input[0], input[1], c - limit };
            }
            return input;
        }

        /// <summary>
        /// 角色活动祈愿保底计算
        /// </summary>
        /// <param name="counter_4star">4星计数器</param>
        /// <param name="counter_5star">5星计数器</param>
        /// <returns>int[3]，第一项为 5星概率*10000 ，第二项为 4星概率*10000 ，第三项为 3星概率*10000</returns>
        public static int[] CharacterEventWishPity(int counter_4star, int counter_5star)

        {
            return StandardWishPity(counter_4star, counter_5star);
        }
        /// <summary>
        /// 角色活动祈愿2保底计算
        /// </summary>
        /// <param name="counter_4star">4星计数器</param>
        /// <param name="counter_5star">5星计数器</param>
        /// <returns>int[3]，第一项为 5星概率*10000 ，第二项为 4星概率*10000 ，第三项为 3星概率*10000</returns>
        public static int[] CharacterEventWish2Pity(int counter_4star, int counter_5star)
        {
            return StandardWishPity(counter_4star, counter_5star);
        }
        /// <summary>
        /// 新手祈愿保底计算
        /// </summary>
        /// <param name="counter_4star">4星计数器</param>
        /// <param name="counter_5star">5星计数器</param>
        /// <returns>int[3]，第一项为 5星概率*10000 ，第二项为 4星概率*10000 ，第三项为 3星概率*10000</returns>
        public static int[] NoviceWishPity(int counter_4star, int counter_5star)
        {
            return StandardWishPity(counter_4star, counter_5star);
        }
        /// <summary>
        /// 常驻祈愿保底计算
        /// </summary>
        /// <param name="counter_4star">4星计数器</param>
        /// <param name="counter_5star">5星计数器</param>
        /// <returns>int[3]，第一项为 5星概率*10000 ，第二项为 4星概率*10000 ，第三项为 3星概率*10000</returns>
        public static int[] StandardWishPity(int counter_4star, int counter_5star)
        {
            int[] result = new int[] { 60, 510, 9430 };
            // 5星
            if (counter_5star >= 74)
            {
                result[0] += 600 * (counter_5star - 73);
            }
            // 4星
            if (counter_4star >= 9)
            {
                result[1] += 5100 * (counter_4star - 8);
            }
            return WeightLimiter(result);
        }
        /// <summary>
        /// 武器活动祈愿保底计算
        /// </summary>
        /// <param name="counter_4star">4星计数器</param>
        /// <param name="counter_5star">5星计数器</param>
        /// <returns>int[3]，第一项为 5星概率*10000 ，第二项为 4星概率*10000 ，第三项为 3星概率*10000</returns>
        public static int[] WeaponEventWishPity(int counter_4star, int counter_5star)
        {
            int[] result = new int[] { 70, 600, 9330 };
            // 5星
            if (counter_5star >= 74)
            {
                result[0] = 7770 + 350 * (counter_5star - 73);
            }
            else if (counter_5star >= 63)
            {
                result[0] += 700 * (counter_5star - 62);
            }
            // 4星
            if (counter_4star >= 8)
            {
                result[1] += 6000 + 3000 * (counter_4star - 8);
            }
            return WeightLimiter(result);
        }
    }
}
