using CentralService.Models;
using System.Collections.Generic;

namespace newPos.Models
{
    public class MenuListModel
    {
        public List<NotificationIcon> NotificationIcons { get; set; }

        public List<MessageModel> Messages { get; set; }

        public RegisterBlueCardModel BlueCardModel { get; set; }

        public MenuListModel()
        {
            NotificationIcons = new List<NotificationIcon>();
            Messages = new List<MessageModel>();
            BlueCardModel = new RegisterBlueCardModel();
        }

        public string EndOldBatch { get; set; }
        public string OpenBatch { get; set; }

        public string CloseBatchToday { get; set; }
        public Gen_WifiModel WifiModel { get; set; }
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
