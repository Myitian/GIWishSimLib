using System;

namespace Myitian.GIWishSimLib
{
    /// <summary>
    /// �����������
    /// </summary>
    public static class Rng
    {
        /// <summary>
        /// �Ǽ����������
        /// </summary>
        /// <param name="max">���ָ</param>
        /// <param name="seed">����</param>
        /// <returns></returns>
        public static int StarRNG(int max, object seed = null)
        {
            if (seed is null) seed = Guid.NewGuid();
            return new Random(seed.GetHashCode()).Next(1, max + 1);
        }
        /// <summary>
        /// ��Ʒ�������������
        /// </summary>
        /// <param name="max"></param>
        /// <param name="seed">����</param>
        /// <returns></returns>
        public static int ItemRNG(int max, object seed = null)
        {
            if (seed is null) seed = Guid.NewGuid();
            return new Random(seed.GetHashCode()).Next(0, max);
        }
        /// <summary>
        /// UP���������
        /// </summary>
        /// <param name="percentage">����</param>
        /// <param name="isUP">�Ƿ�UP</param>
        /// <param name="seed">����</param>
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
