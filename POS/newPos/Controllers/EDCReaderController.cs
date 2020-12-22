using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AxSerial;
using System.IO;
namespace newPos.Controllers
{
    public class EDCReaderController : Controller
    {
        ComPort _objComPort ;
        // GET: EDCReader
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SentToEDCCreditCard(string PortNo,string TextPost)
        {
            try
            {
             
                var _seccess = false;
                var _message = "";

                _objComPort = new ComPort();
                _objComPort.Clear();
                _objComPort.Device = PortNo;
                _objComPort.BaudRate = 9600;
                _objComPort.ComTimeout = 10000;
                _objComPort.HardwareFlowControl = -1;
            //    _objComPort.SoftwareFlowControl = _objComPort.asFLOWCONTROL_DISABLE;
                _objComPort.Open();

                var _receive = "";
                TextPost = TextPost.Replace(" ", "");

                if (_objComPort.IsOpened)
                {
                    //int j = 0;

                    for (int i = 0; i < TextPost.Length - 1; i++)
                    {

                      int chr = Convert.ToInt32(TextPost.Substring(i, 2));
                     _objComPort.WriteByte(chr);

                    }
                 //  _objComPort.WriteBytes(TextPost);
                  //  _objComPort.UpdateCom();
                 //   _objComPort
                    var recivetmp  = 0;
                    bool check = true;
                    var exit_loop = 0;

                    while (_objComPort.LastError == 0 || _objComPort.LastError == 30115)
                    {
                        recivetmp = _objComPort.ReadByte();

                        _receive += recivetmp + ",";

                        if (_receive.Length >= 2000)
                        {
                            _objComPort.Close();
                            break;
                        }

                        if (check)
                        {
                            check = false;

                                if (_receive.Substring(0, 1) != "6")
                            {
                                _objComPort.Close();
                                break;
                            }
                        }

                        if (recivetmp == 0)
                        {
                            exit_loop = exit_loop + 1;
                        }
                        else
                        {
                            exit_loop = 0;
                        }

                        if (exit_loop == 40)
                        {
                         
                            break;
                        }
                    }

                    if (_receive.Substring(0, 1) == "6")
                    {
                        var txt1 = "";
    
                        txt1 = _receive;
                      
                        var b = 0;
                        for (int a = 0; a < txt1.Length; a++)
                        {
                            if (txt1.Substring(a, 1) == "2")
                            {
                                b = a;
                                break;
                            }
                        }

                        _seccess = true;
                       
                    }
                    else
                    {
                        _message =  "ไม่สามารถติดต่อธนาคารได้ในขณะนี้ กรุณาตรวจสอบ";
                        _seccess = false;
                    }

                }
                else
                {
                 
                    _message =  "ไม่สามารถติดต่อเครื่อง EDC ได้ กรุณาตรวจสอบ";
                    _seccess = false;
                }


                _objComPort.Close();
                return Json(new { seccess = _seccess, message = _message, receiveText = _receive }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _objComPort.Close();
                return Json(new { seccess = false, message = "ไม่สามารถติดต่อเครื่อง EDC ได้ กรุณาตรวจสอบ" },JsonRequestBehavior.AllowGet);
            }
          



           
        }
        
    }
}