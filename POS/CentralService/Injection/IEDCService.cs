using CentralService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Injection
{
    public interface IEDCService
    {
        object PortReady(string comport);
    }
}
