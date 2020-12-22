using CentralService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newHQ.Models
{
    public class MenuListModel
    {
        public List<NotificationIcon> NotificationIcons { get; set; }

        public List<MessageModel> Messages { get; set; }
    }

    public class NotificationIcon
    {
        public NotificationIcon()
        {
            GroupNo = 1;
        }

        public string Name { get; set; }

        public string ImgName { get; set; }

        public int Number { get; set; }

        public RecordsNumberModel Details { get; set; }

        public ActionLink Action { get; set; }

        public int GroupNo { get; set; }
    }

    public class ActionLink
    {
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public object RouteValues { get; set; }
    }
}
