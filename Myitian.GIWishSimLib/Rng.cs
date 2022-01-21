using System;

namespace Myitian.GIWishSimLib
{
    /// <summary>
    /// 随机数生成器
    /// </summary>
    public static class Rng
    {
        /// <summary>
        /// 星级随机生成器
        /// </summary>
        /// <param name="max">最大指</param>
        /// <param name="seed">种子</param>
        /// <returns></returns>
        public static int StarRNG(int max, object seed = null)
        {
            if (seed is null) seed = Guid.NewGuid();
            return new Random(seed.GetHashCode()).Next(1, max + 1);
        }
        /// <summary>
        /// 物品索引随机生成器
        /// </summary>
        /// <param name="max"></param>
        /// <param name="seed">种子</param>
        /// <returns></returns>
        public static int ItemRNG(int max, object seed = null)
        {
            if (seed is null) seed = Guid.NewGuid();
            return new Random(seed.GetHashCode()).Next(0, max);
        }
        /// <summary>
        /// UP随机生成器
        /// </summary>
        /// <param name="percentage">概率</param>
        /// <param name="isUP">是否UP</param>
        /// <param name="seed">种子</param>
        /// <returns></returns>
        public static bool UPRNG(double percentage, ref bool isUP, object seed = null)
        {
            if (seed is null) seed = Guid.NewGuid();
            if (isUP || new Random(seed.GetHashCode()).NextDouble() < percentage)
            {
                isUP = false;
                return true;
            }
            else
            {
                isUP = true;
                return false;
            }
        }
    }
}
