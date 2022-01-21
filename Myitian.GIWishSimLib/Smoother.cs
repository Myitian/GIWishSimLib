namespace Myitian.GIWishSimLib
{
    /// <summary>
    /// ƽ�Ȼ���
    /// </summary>
    public static class SmootherCalc
    {
        /// <summary>
        /// ��ɫ���Ըƽ�Ȼ���
        /// </summary>
        /// <param name="characterCounter">��ɫ������</param>
        /// <param name="weaponCounter">����������</param>
        /// <param name="star">��Ʒ�Ǽ�</param>
        /// <returns>int[2]����һ��Ϊ��ɫ���ʣ��ڶ���Ϊ��������</returns>
        public static int[] CharacterEventWishSmoothWeight(int characterCounter, int weaponCounter, byte star = 4)
        {
            return StandardWishSmoothWeight(characterCounter, weaponCounter, star);
        }
        /// <summary>
        /// ��ɫ���Ը2ƽ�Ȼ���
        /// </summary>
        /// <param name="characterCounter">��ɫ������</param>
        /// <param name="weaponCounter">����������</param>
        /// <param name="star">��Ʒ�Ǽ�</param>
        /// <returns>int[2]����һ��Ϊ��ɫ���ʣ��ڶ���Ϊ��������</returns>
        public static int[] CharacterEventWish2SmoothWeight(int characterCounter, int weaponCounter, byte star = 4)
        {
            return StandardWishSmoothWeight(characterCounter, weaponCounter, star);
        }
        /// <summary>
        /// ��פ��Ըƽ�Ȼ���
        /// </summary>
        /// <param name="characterCounter">��ɫ������</param>
        /// <param name="weaponCounter">����������</param>
        /// <param name="star">��Ʒ�Ǽ�</param>
        /// <returns>int[2]����һ��Ϊ��ɫ���ʣ��ڶ���Ϊ��������</returns>
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
            return r;
        }
        /// <summary>
        /// �������Ըƽ�Ȼ���
        /// </summary>
        /// <param name="characterCounter">��ɫ������</param>
        /// <param name="weaponCounter">����������</param>
        /// <param name="star">û�����ã���Ϊ��ƥ��ӿ�</param>
        /// <returns>int[2]����һ��Ϊ��ɫ���ʣ��ڶ���Ϊ��������</returns>
        public static int[] WeaponEventWishSmoothWeight(int characterCounter, int weaponCounter, byte star = 4)
        {
            int[] r = new int[2];
            r[0] = 300;
            if (characterCounter >= 16)
                r[0] += 3000 * (characterCounter - 15);
            r[1] = 300;
            if (weaponCounter >= 16)
                r[1] += 3000 * (weaponCounter - 15);
            return r;
        }
    }
}