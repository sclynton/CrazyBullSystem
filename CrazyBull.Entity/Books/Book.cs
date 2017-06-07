using CrazyBull.Core.Books;
using System;

namespace CrazyBull.Core
{
    public class Book : BaseEntity
    {
        /// <summary>
        /// 封面图片地址
        /// </summary>
        public string CoverImage { get; set; }
        public string BookName { get; set; }
        /// <summary>
        /// 是否完结
        /// </summary>
        public bool IsOver { get; set; }
        /// <summary>
        /// 是否首页推荐
        /// </summary>
        public bool IsIndex { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        /// <summary>
        /// 频道 0：男频 1：女频
        /// </summary>
        public ChannelType ChannelType { get; set; }
        /// <summary>
        /// 最后一次更书时间
        /// </summary>
        public DateTime? UpdatedTime { get; set; }
        /// <summary>
        /// 小说简介
        /// </summary>
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
