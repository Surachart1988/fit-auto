using CentralService.Models;
using System.Collections.Generic;

namespace CentralService.Injection
{
    public interface IDashboardService
    {
        List<NameValueModel> GetNotificationsNumber();
        Gen_WifiModel GetWifiDetail();
        void SaveHashWifi(string hashstr, out string wifihash, out string _time1);
    }
}
