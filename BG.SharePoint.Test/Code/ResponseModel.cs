using System;

namespace BG.SharePoint.Test
{
    public class ResponseModel
    {
        public Guid SiteId { set; get; }
        public Guid WebId { set; get; }
        public string SiteUrl { set; get; }
        public string WebUrl { set; get; }
        public bool IsCreated { set; get; }
        public string Message { set; get; }
    }

    public class Color
    {
        public string Title { set; get; }
    }
}
