using CentralService.Injection;
using CentralService.Models;
using CentralService.Services;
using PosData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.Utilities;
using static PosService.PosServiceUnityExtension;
using Microsoft.PointOfService;

namespace PosService.Services
{
    public class CashDrawerService : ICashDrawerService
    {
        private Entities _db;
        private Mapper _mapper;
        CashDrawer _cashdw;
        PosPrinter m_Printer;

        public PosExplorer Explorer { get; set; }

        public CashDrawerService(Entities conn, Mapper mapper)
        {
            _db = conn;
            _mapper = mapper;
        }

        private void GetDevice()
        {
            Explorer = new PosExplorer();
            try
            {
                //DeviceCollection receiptPrinterDevices = posExplorer.GetDevices(DeviceType.PosPrinter);

                DeviceInfo pos_di = Explorer.GetDevice(DeviceType.PosPrinter, "PosPrinter");
                if (pos_di != null)
                    m_Printer = (PosPrinter)Explorer.CreateInstance(pos_di);

                DeviceInfo Cashdw_di = Explorer.GetDevice(DeviceType.CashDrawer, "CashDrawer");
                if (Cashdw_di != null)
                    _cashdw = (CashDrawer)Explorer.CreateInstance(Cashdw_di);
            }
            catch (Exception e)
            {
                // ignored
            }
        }
        private void DisconnectFromPrinter(PosPrinter printer)
        {
            printer.Release();
            printer.Close();
        }

        private void ConnectToPrinter(PosPrinter printer)
        {
            printer.Open();
            printer.Claim(10000);
            printer.DeviceEnabled = true;
        }

        public void OpenCashDrawer()
        {
            var useCashdw = _db.SB_System.FirstOrDefault();

            if (useCashdw?.cashdw == "1")
            {
                GetDevice();

                try
                {
                    _cashdw.Open();
                    _cashdw.Claim(1000);
                    _cashdw.DeviceEnabled = true;

                    //m_Printer.PrintImmediate(PrinterStation.Receipt, "\x1B|\x70|\x00|\x19|\xFB");

                    // pulse the cash drawer pin  pulseLength-> 1 = 100ms, 2 = 200ms, pin-> 0 = pin2, 1 = pin5
                    //m_printer.PrintNormal(PrinterStation.Receipt, System.Text.ASCIIEncoding.ASCII.GetString(New Byte() {27, 112, 48, 55, 121}))

                    //m_Printer.PrintNormal(PrinterStation.Receipt, System.Text.ASCIIEncoding.ASCII.GetString(new Byte[] { 27, 112, 0, 25, 250 }));
                    //m_Printer.OpenDrawer();

                    _cashdw.OpenDrawer();
                }
                catch (Exception e)
                {
                    LogManager.WriteLog(e.ToString());
                }
                finally
                {
                    if (_cashdw != null)
                    {
                        //m_Printer.CutPaper(100);
                        _cashdw.DeviceEnabled = false;
                        _cashdw.Release();
                        _cashdw.Close();
                    }
                }
            }
        }

    }

}


