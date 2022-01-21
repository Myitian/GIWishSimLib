using System;

namespace Myitian.GIWishSimLib
{
    /// <summary>
    /// 祈愿类型
    /// </summary>
    public enum WishTypes : byte
    {
        /// <summary>角色活动祈愿</summary>
        CharacterEventWish,
        /// <summary>角色活动祈愿2</summary>
        CharacterEventWish2,
        /// <summary>武器活动祈愿</summary>
        WeaponEventWish,
        /// <summary>常驻祈愿</summary>
        StandardWish,
        /// <summary>新手祈愿</summary>
        NoviceWish,

        /// <summary>未知</summary>
        Unknown = 255
    }
    /// <summary>
    /// 物品类型
    /// </summary>
    public enum ItemTypes : byte
    {
        /// <summary>角色</summary>
        Character,
        /// <summary>武器</summary>
        Weapon,

        /// <summary>未知</summary>
        Unknown = 255
    }
    /// <summary>
    /// 祈愿物品组
    /// </summary>
    public class WishItems
    {
        /// <summary>5星角色</summary>
        public string[] Item_5Star_Character = new string[0];
        /// <summary>5星UP角色</summary>
        public string[] Item_5Star_UP_Character = new string[0];
        /// <summary>4星角色</summary>
        public string[] Item_4Star_Character = new string[0];
        /// <summary>4星UP角色</summary>
        public string[] Item_4Star_UP_Character = new string[0];
        /// <summary>5星武器</summary>
        public string[] Item_5Star_Weapon = new string[0];
        /// <summary>5星UP武器</summary>
        public string[] Item_5Star_UP_Weapon = new string[0];
        /// <summary>4星武器</summary>
        public string[] Item_4Star_Weapon = new string[0];
        /// <summary>4星UP武器</summary>
        public string[] Item_4Star_UP_Weapon = new string[0];
        /// <summary>3星</summary>
        public string[] Item_3Star = new string[0];
    }
    /// <summary>
    /// 祈愿物品信息
    /// </summary>
    public struct WishItemInfo
    {
        /// <summary>名称名称</summary>
        public string Name;
        /// <summary>物品类型</summary>
        public ItemTypes ItemType;
        /// <summary>是否为UP</summary>
        public bool IsUP;
        /// <summary>是否为定轨</summary>
        public bool IsEP;
    }

    /// <summary>
    /// 祈愿基类
    /// </summary>
    public abstract class Wish
    {
        private int VALUE_EpitomizedPath = -1;
        /// <summary>祈愿ID，目前没有功能</summary>
        public string WishID { get; set; } = null;
        /// <summary>祈愿名称</summary>
        public string WishName { get; set; } = "";
        /// <summary>祈愿类型</summary>
        public WishTypes WishType { get; set; } = WishTypes.Unknown;
        /// <summary>祈愿保底机制</summary>
        public Func<int, int, int[]> Pity { get; set; }
        /// <summary>“平稳”机制</summary>
        public Func<int, int, byte, int[]> Smoother { get; set; }
        /// <summary>抽取数量上限</summary>
        public long Limit { get; set; } = long.MaxValue;

        /// <summary>祈愿物品组</summary>
        public WishItems Items { get; set; }
        /// <summary>祈愿计数器</summary>
        public WishCounter Counter { get; set; }
        /// <summary>定轨</summary>
        public int EpitomizedPath
        {
            get => VALUE_EpitomizedPath;
            set
            {
                VALUE_EpitomizedPath = value;
                Counter.FatePoint = 0;
            }
        }
        /// <summary>卡池更新是否重置计数器</summary>
        public bool ResetCounterWhenUpdated { get; set; } = false;

        /// <summary>祈愿</summary>
        /// <param name="wishName">祈愿名称</param>
        /// <param name="wishID">祈愿ID</param>
        public Wish(string wishName, string wishID)
        {
            if (wishName != null)
            {
                WishName = wishName;
            }
            WishID = wishID;
            Counter = new WishCounter();
            Items = new WishItems();
        }
        /// <summary>祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        /// <param name="wishName">祈愿名称</param>
        /// <param name="wishID">祈愿ID</param>
        public Wish(WishItems items, string wishName, string wishID)
        {
            if (wishName != null)
            {
                WishName = wishName;
            }
            WishID = wishID;
            Counter = new WishCounter();
            Items = items;
        }
        /// <summary>祈愿</summary>
        /// <param name="items">祈愿物品组</param>
        /// <param name="counter">祈愿计数器</param>
        /// <param name="wishName">祈愿名称</param>
        /// <param name="wishID">祈愿ID</param>
        public Wish(WishItems items, WishCounter counter, string wishName, string wishID)
        {
            if (wishName != null)
            {
                WishName = wishName;
            }
            WishID = wishID;
            Counter = counter;
            Items = items;
        }

        /// <summary>
        /// 获取指定星级的物品
        /// </summary>
        /// <param name="starlevel">星级</param>
        /// <returns>一个 WishItemInfo ，包含了物品信息</returns>
        public abstract WishItemInfo GetItem(byte starlevel);
        /// <summary>
        /// 重置祈愿及其计数器
        /// </summary>
        /// <returns></returns>
        public bool Reset()
        {
            Counter.Reset();
            EpitomizedPath = -1;
            return true;
        }
        /// <summary>
        /// 更新祈愿物品
        /// </summary>
        /// <returns></returns>
        public bool Update(WishItems newItems)
        {
            if (ResetCounterWhenUpdated)
            {
                Counter.Reset();
            }
            Items = newItems;
            return true;
        }
    }
}
