using AxSerial;
using CentralService.Injection;
using CentralService.Models;
using PosData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace PosService.Services
{
    public class EDCService : IEDCService
    {
        private Entities _db;
        public ComPort objComport;
        public EDCService(Entities conn)
        {
            _db = conn;
        }

        public object PortReady(string comport)
        {
            object ob = null;
            try
            {
                objComport = new ComPort();
                objComport.Device = comport;
                objComport.BaudRate = 9600;
                objComport.ComTimeout = 1000;
                objComport.HardwareFlowControl = objComport.asFLOWCONTROL_DEFAULT;
                objComport.Open();
                ob = new
                {
                    objComport.IsOpened
                };
            }
            catch (Exception x)
            {

            }
            finally
            {
                objComport.Close();
            }
            return ob;
        }
    }
}
