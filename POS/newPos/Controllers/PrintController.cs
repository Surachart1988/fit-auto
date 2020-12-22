using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using newPos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PosData.Models;
namespace newPos.Controllers
{
    public class PrintController : Controller
    {
        // GET: Print
        Entities _db = new Entities();


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Printtest()
        {

          

            return View();
        }
       
        public ActionResult PrintReport11()
        {
            var rpt = new ReportClass();
            try
            {
                #region num1
                string reportname = "";
                if (Request.QueryString["reportname"] != null)
                {
                    reportname = Request.QueryString["reportname"];
                }
                else if (Request.Form["reportname"] != null)
                {
                    reportname = Request.Form["reportname"];
                }
                string progroup_code = "";
                if (Request.QueryString["progroup_code"] != null)
                {
                    progroup_code = Request.QueryString["progroup_code"];
                }
                else if (Request.Form["progroup_code"] != null)
                {
                    progroup_code = Request.Form["progroup_code"];
                }
                string pro_brand_code = "";
                if (Request.QueryString["pro_brand_code"] != null)
                {
                    pro_brand_code = Request.QueryString["pro_brand_code"];
                }
                else if (Request.Form["pro_brand_code"] != null)
                {
                    pro_brand_code = Request.Form["pro_brand_code"];
                }
                string pro_model_code = "";
                if (Request.QueryString["pro_model_code"] != null)
                {
                    pro_model_code = Request.QueryString["pro_model_code"];
                }
                else if (Request.Form["pro_model_code"] != null)
                {
                    pro_model_code = Request.Form["pro_model_code"];
                }
                string thaibaht = Request.QueryString["thaibaht"];
                string thaibaht1 = Request.QueryString["thaibaht"];
                string doc_no = Request.QueryString["doc_no"];
                //string branch_no = Convert.ToString(Request.QueryString["branch_no"]);
                string branch_no = Request.QueryString["branch_no"];
                string fdate = Request.QueryString["fdate"];
                string tdate = Request.QueryString["tdate"];
                string sdate = Request.QueryString["sdate"];
                string edate = Request.QueryString["edate"];
                //string ven_code = Request.QueryString["ven_code"];
                //ReportDocument rpt = new ReportDocument();
                //rpt.Dispose(); //Here rd is Report Document which is Initialized before
                //rpt.Clone();
                //rpt.Close();
                //crvReport.Dispose();
                //lblRptName.Text = Server.MapPath(reportname);


                rpt.FileName = (Server.MapPath("~/report/" + reportname));
                rpt.Load();
                //rpt.Close();
                //rpt.Dispose();
                //Response.Write(Server.MapPath(reportname));
                //Response.End();
                //===================================================================================
                if (reportname == "stk_sumstock.rpt")
                {
                    // //Response.Write("<a href href='../car_checklist.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    ////Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    //rpt.SetParameterValue("thaibaht", thaibaht);
                }
                if (reportname == "sumstock_view.rpt")
                {
                    // //Response.Write("<a href href='../car_checklist.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    ////Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    //rpt.SetParameterValue("thaibaht", thaibaht);
                }
                //===================================================================================
                if (reportname == "car_checklist.rpt")
                {
                    // //Response.Write("<a href href='../car_checklist.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    ////Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    //rpt.SetParameterValue("thaibaht", thaibaht);
                }
                //=====================================จัดสินค้า==============================================
                if (reportname == "job_shipping.rpt")
                {
                    //string pro_code = Request.QueryString["pro_code"];
                    ////Response.Write("<a href href='../startjob_rt.asp' align='CENTER target='_self''> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    // //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    //rpt.SetParameterValue("pro_code", pro_code);
                }
                //=====================================ใบตรวจสภาพ==============================================
                if (reportname == "car_inspection.rpt")
                {
                    //string pro_code = Request.QueryString["pro_code"];
                    ////Response.Write("<a href href='../startjob_rt.asp' align='CENTER target='_self''> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    // //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    //rpt.SetParameterValue("pro_code", pro_code);
                }

                //=====================================ใบสั่งงาน==============================================
                if (reportname == "job_nocar.rpt")
                {
                    ////Response.Write("<a href href='../startjob_rt.asp' align='CENTER target='_self''> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    // //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "job.rpt")
                {
                    ////Response.Write("<a href href='../startjob_rt.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    ////Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }

                //=====================================ใบชำระค่าใช้จ่าย ================================================
                else if (reportname == "bpi.rpt")
                {
                    //Response.Write("<a href href='../pay_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //===================================== PPA ================================================
                else if (reportname == "PPA.rpt")
                {
                    string prn_pay_type = Request.QueryString["prn_pay_type"];
                    //Response.Write("<a href href='../deb_pay_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                    //rpt.SetParameterValue("prn_pay_type", prn_pay_type);
                }
                //===================================== BAP ================================================
                else if (reportname == "Bap.rpt")
                {
                    //Response.Write("<a href href='../deb_pay_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht1", thaibaht1);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //===================================== PO ================================================
                else if (reportname == "po.rpt")
                {
                    //Response.Write("<a href href='../pc_pr_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //===================================== ใบเบิกวัสดุ ================================================
                else if (reportname == "aca.rpt")
                {
                    //Response.Write("<a href href='../asc_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("branch_no", branch_no);
                }

                //===================================== PTA ================================================
                else if (reportname == "PTA.rpt")
                {
                    //Response.Write("<a href href='../deb_return_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //===================================== PCC  ================================================		
                else if (reportname == "PCC.rpt")
                {
                    //Response.Write("<a href href='../deb_depay_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //===================================== ใบลดหนี้เจ้าหนี้ (ตามใบรับเข้า) ================================================		
                else if (reportname == "PCP.rpt")
                {
                    //Response.Write("<a href href='../deb_depayinv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //===================================== ใบเพิ่มหนี้เจ้าหนี้ ================================================		
                else if (reportname == "PDC.rpt")
                {
                    //Response.Write("<a href href='../deb_inpay_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //===================================== ใบเพิ่มหนี้เจ้าหนี้(ตามใบรับเข้า)  ================================================	
                else if (reportname == "PDP.rpt")
                {
                    //Response.Write("<a href href='../deb_inpayinv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //=====================================ใบลดหนี้/รับคือสินค้า==============================================
                else if (reportname == "rcn_nocar.rpt")
                {
                    // Response.Write ("<a href='../ws_disc_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //=====================================ใบลดหนี้/รับคือสินค้า==============================================
                else if (reportname == "rcn.rpt")
                {
                    // Response.Write ("<a href='../rt_disc_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    // Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);

                }
                //=====================================ใบเสนอราคา==============================================
                else if (reportname == "quo.rpt")
                {
                    string prn_createname = Request.QueryString["prn_createname"];
                    //Response.Write ("<a href='../rt_pr_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("prn_createname", prn_createname);
                }
                else if (reportname == "quo2.rpt")
                {
                    string prn_createname = Request.QueryString["prn_createname"];
                    //Response.Write ("<a href='../rt_pr_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("prn_createname", prn_createname);
                }
                //=====================================ใบรับมัดจำ==============================================
                else if (reportname == "rda.rpt")
                {
                    string prn_pay_type = Request.QueryString["prn_pay_type"];
                    //Response.Write ("<a href='../rt_dp_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("prn_pay_type", prn_pay_type);
                }
                //=====================================ใบประเมินความพึงพอใจ==============================================
                else if (reportname == "rpt_vote.rpt")
                {
                    //Response.Write ("<a href='../rt_vote_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                }
                //=====================================ใบรายงานติดตามผลการให้บริการ==============================================
                else if (reportname == "call_track.rpt")
                {
                    //Response.Write ("<a href='../call_track_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //=====================================ใบรับชำระลูกหนี้==============================================
                else if (reportname == "RPA.rpt")
                {
                    string prn_pay_type = Request.QueryString["prn_pay_type"];
                    //Response.Write ("<a href='../rt_pay_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    //rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("prn_pay_type", prn_pay_type);
                }
                //=====================================ใบคืนชำระลูกหนี้==============================================
                else if (reportname == "RTA.rpt")
                {
                    //Response.Write ("<a href='../rt_return_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //=====================================ใบลดหนี้ลูกหนี้==============================================
                else if (reportname == "rcc.rpt")
                {
                    //Response.Write ("<a href='../rtpay_depay_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //=====================================ใบลดหนี้ลูกหนี้(ตามใบเสร็จ)==============================================
                else if (reportname == "RCP.rpt")
                {
                    //Response.Write ("<a href='../rtpay_depayinv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //=====================================ใบเพิ่มหนี้ลูกหนี้==============================================
                else if (reportname == "RDC.rpt")
                {
                    //Response.Write ("<a href='../rtpay_inpay_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    // Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //=====================================ใบเพิ่มหนี้ลูกหนี้(ตามใบเสร็จ)==============================================
                else if (reportname == "RDP.rpt")
                {
                    //Response.Write ("<a href='../rtpay_inpayinv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    // Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    //rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //=====================================ใบวางบิล==============================================
                else if (reportname == "Bill.rpt")
                {
                    //Response.Write ("<a href='../rt_bill_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    // Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //=====================================ใบวางบิล2==============================================
                else if (reportname == "Bill_docno2.rpt")
                {
                    //Response.Write ("<a href='../rt_bill_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    // Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //=====================================ใบส่งสินค้าชั่วคราว==============================================
                else if (reportname == "tmp_nocar.rpt")
                {
                    string prn_car_reg = Request.QueryString["prn_car_reg"];
                    string prn_vat = Request.QueryString["prn_vat"];
                    string prn_pay_type = Request.QueryString["prn_pay_type"];
                    string prn_date = Request.QueryString["prn_date"];
                    ////Response.Write( "<a href='../rt_tmp_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    ////Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("prn_car_reg", prn_car_reg);
                    rpt.SetParameterValue("prn_vat", prn_vat);
                    rpt.SetParameterValue("prn_pay_type", prn_pay_type);
                    rpt.SetParameterValue("prn_date", prn_date);
                }
                else if (reportname == "tmp.rpt")
                {
                    string prn_car_reg = Request.QueryString["prn_car_reg"];
                    string prn_vat = Request.QueryString["prn_vat"];
                    string prn_pay_type = Request.QueryString["prn_pay_type"];
                    string prn_date = Request.QueryString["prn_date"];
                    ////Response.Write( "<a href='../rt_tmp_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    ////Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("prn_car_reg", prn_car_reg);
                    rpt.SetParameterValue("prn_vat", prn_vat);
                    rpt.SetParameterValue("prn_pay_type", prn_pay_type);
                    rpt.SetParameterValue("prn_date", prn_date);
                }
                else if (reportname == "tmp_3copy.rpt")
                {
                    string prn_car_reg = Request.QueryString["prn_car_reg"];
                    string prn_vat = Request.QueryString["prn_vat"];
                    string prn_pay_type = Request.QueryString["prn_pay_type"];
                    string prn_date = Request.QueryString["prn_date"];
                    ////Response.Write( "<a href='../rt_tmp_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    ////Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("prn_car_reg", prn_car_reg);
                    rpt.SetParameterValue("prn_vat", prn_vat);
                    rpt.SetParameterValue("prn_pay_type", prn_pay_type);
                    rpt.SetParameterValue("prn_date", prn_date);
                }
                else if (reportname == "tmp_3copy2.rpt")
                {
                    string prn_prodetail = Request.QueryString["prn_prodetail"];
                    string prn_car_reg = Request.QueryString["prn_car_reg"];
                    string prn_procode = Request.QueryString["prn_procode"];
                    string prn_pay_type = Request.QueryString["prn_pay_type"];
                    string prn_date = Request.QueryString["prn_date"];
                    string dealercode = Request.QueryString["dealercode"];

                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("prn_prodetail", prn_prodetail);
                    rpt.SetParameterValue("prn_procode", prn_procode);
                    rpt.SetParameterValue("prn_car_reg", prn_car_reg);
                    rpt.SetParameterValue("prn_pay_type", prn_pay_type);
                    rpt.SetParameterValue("prn_date", prn_date);
                    rpt.SetParameterValue("Copy1", "1");
                    rpt.SetParameterValue("Copy2", "2");
                    rpt.SetParameterValue("Copy3", "3");
                    rpt.SetParameterValue("dealercode", dealercode);


                }
                else if (reportname == "tmp_ha4.rpt")
                {
                    //Response.Write( "<a href='../rt_tmp_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "tmp_cos_ha4.rpt")
                {
                    //Response.Write( "<a href='../rt_tmp_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "tmp_cos_a4.rpt")
                {
                    //Response.Write( "<a href='../rt_tmp_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "tmp_vat.rpt")
                {
                    //Response.Write( "<a href='../rt_tmp_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "tmp_cos_nocar_a4.rpt")
                {
                    //Response.Write( "<a href='../rt_tmp_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "tmp_cos_nocar_ha4.rpt")
                {
                    //Response.Write( "<a href='../rt_tmp_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "tmp_MBA_ws2.rpt")
                {
                    //Response.Write( "<a href='../rt_tmp_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "tmp_MBA2.rpt")
                {
                    //Response.Write( "<a href='../rt_tmp_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "tmp_tyreplus_ws.rpt")
                {
                    //Response.Write( "<a href='../rt_tmp_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "tmp_tyreplus1.rpt")
                {
                    //Response.Write( "<a href='../rt_tmp_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "tmp_MBA_ws.rpt")
                {
                    //Response.Write( "<a href='../rt_tmp_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "tmp_MBA1.rpt")
                {
                    //Response.Write( "<a href='../rt_tmp_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }


                else if (reportname == "rpt_trn.rpt")
                {
                    //Response.Write( "<a href='../rt_tmp_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }

                //=====================================ใบเสร็จรับเงิน/ใบกำกับภาษี==============================================
                else if (reportname == "inv_tyreplus_ws.rpt")
                {
                    //Response.Write( "<a href='../rt_inv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "inv_tyreplus1.rpt")
                {
                    //Response.Write( "<a href='../rt_inv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "inv.rpt")
                {
                    string prn_prodetail = Request.QueryString["prn_prodetail"];
                    //string prn_procode = Request.QueryString["prn_procode"];
                    string prn_pay_type = Request.QueryString["prn_pay_type"];
                    //Response.Write( "<a href='../ws_inv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("prn_pay_type", prn_pay_type);
                    rpt.SetParameterValue("prn_prodetail", prn_prodetail);
                    rpt.SetParameterValue("prn_procode", "");
                    //rpt.SetParameterValue("prn_prodetail", prn_prodetail);
                }
                else if (reportname == "Ino.rpt")
                {
                    string prn_prodetail = Request.QueryString["prn_prodetail"];
                    string prn_car_reg = Request.QueryString["prn_car_reg"];
                    string prn_procode = Request.QueryString["prn_procode"];
                    string prn_pay_type = Request.QueryString["prn_pay_type"];
                    string prn_date = Request.QueryString["prn_date"];
                    //Response.Write( "<a href='../rt_inv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("Copy", "");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("prn_prodetail", prn_prodetail);
                    rpt.SetParameterValue("prn_procode", prn_procode);
                    rpt.SetParameterValue("prn_car_reg", prn_car_reg);
                    rpt.SetParameterValue("prn_pay_type", prn_pay_type);
                    rpt.SetParameterValue("prn_date", prn_date);
                    //rpt.SetParameterValue("rec_memo", "aaaa");
                }
                else if (reportname == "ino_3copy.rpt")
                {
                    string prn_prodetail = Request.QueryString["prn_prodetail"];
                    string prn_car_reg = Request.QueryString["prn_car_reg"];
                    string prn_procode = Request.QueryString["prn_procode"];
                    string prn_pay_type = Request.QueryString["prn_pay_type"];
                    string prn_date = Request.QueryString["prn_date"];
                    string dealercode = Request.QueryString["dealercode"];

                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("prn_prodetail", prn_prodetail);
                    rpt.SetParameterValue("prn_procode", prn_procode);
                    rpt.SetParameterValue("prn_car_reg", prn_car_reg);
                    rpt.SetParameterValue("prn_pay_type", prn_pay_type);
                    rpt.SetParameterValue("prn_date", prn_date);
                    rpt.SetParameterValue("Copy1", "1");
                    rpt.SetParameterValue("Copy2", "2");
                    rpt.SetParameterValue("Copy3", "3");
                    rpt.SetParameterValue("dealercode", dealercode);

                }
                else if (reportname == "ino_ha4.rpt")
                {
                    //Response.Write( "<a href='../rt_inv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "ino_cos_ha4.rpt")
                {
                    string prn_prodetail = Request.QueryString["prn_prodetail"];
                    string prn_car_reg = Request.QueryString["prn_car_reg"];
                    string prn_procode = Request.QueryString["prn_procode"];
                    //Response.Write( "<a href='../rt_inv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("prn_prodetail", prn_prodetail);
                    rpt.SetParameterValue("prn_procode", prn_procode);
                    rpt.SetParameterValue("prn_car_reg", prn_car_reg);
                }
                else if (reportname == "ino_cos_a4.rpt")
                {
                    string prn_prodetail = Request.QueryString["prn_prodetail"];
                    string prn_car_reg = Request.QueryString["prn_car_reg"];
                    string prn_procode = Request.QueryString["prn_procode"];
                    //Response.Write( "<a href='../rt_inv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("prn_prodetail", prn_prodetail);
                    rpt.SetParameterValue("prn_procode", prn_procode);
                    rpt.SetParameterValue("prn_car_reg", prn_car_reg);
                }
                else if (reportname == "Ino_nocar.rpt")
                {
                    string prn_prodetail = Request.QueryString["prn_prodetail"];
                    string prn_car_reg = Request.QueryString["prn_car_reg"];
                    string prn_procode = Request.QueryString["prn_procode"];
                    string prn_pay_type = Request.QueryString["prn_pay_type"];
                    string prn_date = Request.QueryString["prn_date"];
                    //Response.Write( "<a href='../rt_inv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("prn_prodetail", prn_prodetail);
                    rpt.SetParameterValue("prn_procode", prn_procode);
                    rpt.SetParameterValue("prn_car_reg", prn_car_reg);
                    rpt.SetParameterValue("prn_pay_type", prn_pay_type);
                    rpt.SetParameterValue("prn_date", prn_date);
                }
                else if (reportname == "ino_cos_nocar_a4.rpt")
                {
                    string prn_prodetail = Request.QueryString["prn_prodetail"];
                    string prn_car_reg = Request.QueryString["prn_car_reg"];
                    string prn_procode = Request.QueryString["prn_procode"];
                    //Response.Write( "<a href='../rt_inv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("prn_prodetail", prn_prodetail);
                    rpt.SetParameterValue("prn_procode", prn_procode);
                    rpt.SetParameterValue("prn_car_reg", prn_car_reg);
                }
                else if (reportname == "Ino_cos_nocar_ha4.rpt")
                {
                    //Response.Write( "<a href='../rt_inv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "ino_nocar_rename_a4.rpt")
                {
                    string prn_prodetail = Request.QueryString["prn_prodetail"];
                    string prn_car_reg = Request.QueryString["prn_car_reg"];
                    string prn_procode = Request.QueryString["prn_procode"];
                    string prn_pay_type = Request.QueryString["prn_pay_type"];
                    string prn_date = Request.QueryString["prn_date"];
                    //Response.Write( "<a href='../rt_inv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("prn_prodetail", prn_prodetail);
                    rpt.SetParameterValue("prn_procode", prn_procode);
                    rpt.SetParameterValue("prn_car_reg", prn_car_reg);
                    rpt.SetParameterValue("prn_pay_type", prn_pay_type);
                    rpt.SetParameterValue("prn_date", prn_date);
                }
                else if (reportname == "inv_MBA_ws2.rpt")
                {
                    //Response.Write( "<a href='../rt_inv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "inv_MBA2.rpt")
                {
                    //Response.Write( "<a href='../rt_inv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "inv_MBA_ws.rpt")
                {
                    //Response.Write( "<a href='../rt_inv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "inv_MBA1.rpt")
                {
                    //Response.Write( "<a href='../rt_inv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }



                else if (reportname == "inv_tyreplus_ws_rename.rpt")
                {
                    //Response.Write( "<a href='../rt_inv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "inv_tyreplus1_rename.rpt")
                {
                    //Response.Write( "<a href='../rt_inv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "inv_MBA_ws_rename.rpt")
                {
                    //Response.Write( "<a href='../rt_inv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "inv_MBA1_rename.rpt")
                {
                    //Response.Write( "<a href='../rt_inv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "inv_MBA_ws2_rename.rpt")
                {
                    //Response.Write( "<a href='../rt_inv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "inv_MBA2_rename.rpt")
                {
                    //Response.Write( "<a href='../rt_inv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "inv_rename.rpt")
                {

                    string prn_pay_type = Request.QueryString["prn_pay_type"];
                    //Response.Write( "<a href='../rt_inv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("prn_pay_type", prn_pay_type);
                }
                else if (reportname == "Ino_rename.rpt")
                {
                    string prn_prodetail = Request.QueryString["prn_prodetail"];
                    string prn_car_reg = Request.QueryString["prn_car_reg"];
                    string prn_procode = Request.QueryString["prn_procode"];
                    string prn_pay_type = Request.QueryString["prn_pay_type"];
                    string prn_date = Request.QueryString["prn_date"];
                    //Response.Write( "<a href='../rt_inv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("prn_prodetail", prn_prodetail);
                    rpt.SetParameterValue("prn_procode", prn_procode);
                    rpt.SetParameterValue("prn_car_reg", prn_car_reg);
                    rpt.SetParameterValue("prn_pay_type", prn_pay_type);
                    rpt.SetParameterValue("prn_date", prn_date);
                }

                //======================================ใบรับสินค้า============================================================
                else if (reportname == "ini.rpt")
                {
                    //Response.Write("<a href href='../stk_incre_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //======================================ใบส่งคืนสินค้า============================================================
                else if (reportname == "stk_return.rpt")
                {
                    //Response.Write("<a href href='../stk_return_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //======================================ใบโอนสินค้า============================================================
                else if (reportname == "move.rpt")
                {
                    //Response.Write("<a href href='../stk_move_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //======================================ใบปรับปรุงสินค้า============================================================
                else if (reportname == "update.rpt")
                {
                    //Response.Write("<a href href='../stk_update_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //======================================ใบเคลมสินค้า============================================================
                else if (reportname == "claim.rpt")
                {
                    //Response.Write("<a href href='../stk_claim_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //======================================ใบเช็คสต็อก============================================================
                else if (reportname == "check_stock.rpt")
                {
                    //Response.Write("<a href href='../stk_checkstock_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                }
                else if (reportname == "checkstock2_before.rpt")
                {
                    //Response.Write("<a href href='../stk_checkstock_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                }
                else if (reportname == "checkstock2_after.rpt")
                {
                    //Response.Write("<a href href='../stk_checkstock_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                }
                //=====================================-ขายส่ง ใบสั่งขาย ======================================================	
                else if (reportname == "ws.rpt")
                {
                    //Response.Write("<a href href='../ws_sale_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //=====================================ขายส่ง ใบส่งสินค้าชั่วคราว================================================	
                else if (reportname == "tmp_ws.rpt")
                {
                    string prn_pay_type = Request.QueryString["prn_pay_type"];
                    //Response.Write("<a href href='../ws_tmp_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("prn_pay_type", prn_pay_type);
                }
                //=====================================ใบรับชำระลูกหนี้==============================================
                else if (reportname == "RPA.rpt")
                {
                    string prn_date = Request.QueryString["prn_date"];
                    //Response.Write("<a href href='../rt_pay_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("prn_date", prn_date);

                }
                //=====================================สิ้นสุดใบรับชำระลูกหนี้==============================================

                else if (reportname == "RTA.rpt")
                {
                    //Response.Write("<a href href='../rt_return_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }

                //=====================================ใบลดหนี้ลูกหนี้==============================================
                else if (reportname == "rcc.rpt")
                {
                    //Response.Write("<a href href='../rtpay_depay_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }

                //=====================================ใบลดหนี้ลูกหนี้(ตามใบเสร็จ)==============================================
                else if (reportname == "RCP.rpt")
                {
                    //Response.Write("<a href href='../rtpay_depayinv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }

                //=====================================ใบเพิ่มหนี้ลูกหนี้==============================================
                else if (reportname == "RDC.rpt")
                {
                    //Response.Write("<a href href='../rtpay_inpay_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }

                //=====================================ใบเพิ่มหนี้ลูกหนี้(ตามใบเสร็จ)==============================================
                else if (reportname == "RDP.rpt")
                {
                    //Response.Write("<a href href='../rtpay_inpayinv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    //rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //=====================================ใบวางบิล==============================================
                else if (reportname == "Bill.rpt")
                {
                    //Response.Write("<a href href='../rt_bill_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }

                //=====================================ใบวางบิล2==============================================
                else if (reportname == "Bill_docno2.rpt")
                {
                    //Response.Write("<a href href='../rt_bill_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //=====================================รายงานสินค้าคงเหลือเลือกวัน==============================================
                else if (reportname == "rpt_pro_stock.rpt")
                {
                    //Response.Write("<a href href='../rpt_pro_stock.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");


                    string show_average_cost = Request.QueryString["show_average_cost"];
                    string show_pro_price = Request.QueryString["show_pro_price"];
                    string show_stock = Request.QueryString["show_stock"];
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    rpt.SetParameterValue("fdate", start_date_used);
                    rpt.SetParameterValue("show_average_cost", show_average_cost);
                    rpt.SetParameterValue("show_pro_price", show_pro_price);
                    rpt.SetParameterValue("show_stock", show_stock);
                }
                else if (reportname == "rpt_pro_stock_location.rpt")
                {
                    //Response.Write("<a href href='../rpt_pro_stock.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");


                    string show_average_cost = Request.QueryString["show_average_cost"];
                    string show_pro_price = Request.QueryString["show_pro_price"];
                    string show_stock = Request.QueryString["show_stock"];
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    rpt.SetParameterValue("fdate", start_date_used);
                    rpt.SetParameterValue("show_average_cost", show_average_cost);
                    rpt.SetParameterValue("show_pro_price", show_pro_price);
                    rpt.SetParameterValue("show_stock", show_stock);
                }
                else if (reportname == "rpt_pro_stock_advance.rpt")
                {
                    //Response.Write("<a href href='../rpt_pro_stock.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");


                    string show_average_cost = Request.QueryString["show_average_cost"];
                    string show_pro_price = Request.QueryString["show_pro_price"];
                    string show_stock = Request.QueryString["show_stock"];
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    rpt.SetParameterValue("fdate", start_date_used);
                    rpt.SetParameterValue("show_average_cost", show_average_cost);
                    rpt.SetParameterValue("show_pro_price", show_pro_price);
                    rpt.SetParameterValue("show_stock", show_stock);
                }

                //=======================================รายงานราคาสินค้า================================================
                else if (reportname == "rpt_Product_price.rpt")
                {
                    /*string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }*/
                    string pro_code = Request.QueryString["pro_code"];
                    string pro_size_name = Request.QueryString["pro_size_name"];

                    //Response.Write("<a href href='../rpt_Product.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    /*rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);*/
                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_name", pro_size_name);
                }
                //=====================================รายงานสินค้าคงเหลือ(ตามขนาด)==============================================
                else if (reportname == "rpt_pro_stock_size.rpt")
                {
                    //Response.Write("<a href href='../rpt_pro_stock_size.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    string start_date = Request.QueryString["start_date"];
                    String[] DateCom = start_date.Split('/');
                    string start_date_used = DateCom[0] + DateCom[1] + DateCom[2];
                    rpt.SetParameterValue("start_date", start_date_used);
                }
                //=====================================รายงานสินค้าไม่เคลื่อนไหว==============================================
                else if (reportname == "rpt_nosale.rpt")
                {
                    //Response.Write("<a href href='../rpt_NoSale.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    string start_date = Request.QueryString["start_date"];
                    String[] DateCom1 = start_date.Split('/');
                    string start_date_used = "";
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    String[] DateCom2 = end_date.Split('/');
                    string end_date_used = "";
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    rpt.SetParameterValue("fdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                }
                else if (reportname == "rpt_nosale_sale.rpt")
                {
                    //Response.Write("<a href href='../rpt_NoSale.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    string start_date = Request.QueryString["start_date"];
                    String[] DateCom1 = start_date.Split('/');
                    string start_date_used = "";
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    String[] DateCom2 = end_date.Split('/');
                    string end_date_used = "";
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    rpt.SetParameterValue("fdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                }
                //=====================================รายงานจุดสั่งซื้อ/จุดต่ำสุด ของสินค้า==============================================
                else if (reportname == "rpt_min_stock.rpt")
                {
                    //Response.Write("<a href href='../rpt_min_stock.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    //string pro_brand_code = Request.QueryString["pro_brand_code"];
                    ////string progroup_code = Request.QueryString["progroup_code"];
                    //string pro_model_code = Request.QueryString["pro_model_code"];
                    string pro_size_code = Request.QueryString["pro_size_code"];
                    string pro_stock = Request.QueryString["pro_stock"];
                    string pro_code = Request.QueryString["pro_code"];
                    string min_stock = Request.QueryString["min_stock"];

                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_code);
                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("min_stock", min_stock);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //=====================================รายงานการรับสินค้าตามผู้จำหน่าย==============================================
                else if (reportname == "rpt_Receive_vendor.rpt")
                {

                    //Response.Write("<a href href='../rpt_Receive_vendor.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    string start_date = Request.QueryString["start_date"];
                    String[] DateCom1 = start_date.Split('/');
                    string start_date_used = "";
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    String[] DateCom2 = end_date.Split('/');
                    string end_date_used = "";
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string ven_Code = Request.QueryString["Ven_Code"];
                    string pro_size_code = Request.QueryString["pro_size_code"];
                    string date_type = Request.QueryString["date_type"];

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("ldate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_code);
                    rpt.SetParameterValue("date_type", date_type);
                    rpt.SetParameterValue("ven_Code", ven_Code);
                    //rpt.SetParameterValue("branch_no", branch_no);
                }
                //==================== Job Document Report =======================
                else if (reportname == "rpt_job.rpt")
                {

                    //Response.Write("<a href href='../rpt_job.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string pro_size_name = Request.QueryString["pro_size_name"];
                    string doc_status = Request.QueryString["doc_status"];
                    string job_status = Request.QueryString["job_status"];
                    string car_insuarance = Request.QueryString["car_insuarance"];
                    //string doc_cancel = "";
                    //string doc_close = "";
                    //string user_add = Request.QueryString["user_add"];

                    //if (job_status == "")
                    //{
                    //    doc_cancel = "";
                    //    doc_close = "";
                    //}
                    //else if (job_status == "0")
                    //{
                    //    doc_cancel = "False";
                    //    doc_close = "False";
                    //}
                    //else if (job_status == "1")
                    //{
                    //    doc_cancel = "False";
                    //    doc_close = "True";
                    //}
                    //else if (job_status == "2")
                    //{
                    //    doc_cancel = "True";
                    //    doc_close = "False";
                    //}

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_name);
                    //rpt.SetParameterValue("doc_cancel", doc_cancel);
                    //rpt.SetParameterValue("doc_close", doc_close);
                    rpt.SetParameterValue("doc_status", doc_status);
                    rpt.SetParameterValue("job_status", job_status);
                    rpt.SetParameterValue("car_insuarance", car_insuarance);
                    //rpt.SetParameterValue("user_add", user_add);
                    rpt.SetParameterValue("branch_no", "004");

                }
                //==================== รายงานใบสั่งงานรวมรายการ =======================
                else if (reportname == "rpt_job_product.rpt")
                {

                    //Response.Write("<a href href='../rpt_job.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string pro_size_name = Request.QueryString["pro_size_name"];
                    string doc_status = Request.QueryString["doc_status"];
                    string job_status = Request.QueryString["job_status"];
                    //string doc_cancel = "";
                    //string doc_close = "";
                    //string user_add = Request.QueryString["user_add"];

                    //if (job_status == "")
                    //{
                    //    doc_cancel = "";
                    //    doc_close = "";
                    //}
                    //else if (job_status == "0")
                    //{
                    //    doc_cancel = "False";
                    //    doc_close = "False";
                    //}
                    //else if (job_status == "1")
                    //{
                    //    doc_cancel = "False";
                    //    doc_close = "True";
                    //}
                    //else if (job_status == "2")
                    //{
                    //    doc_cancel = "True";
                    //    doc_close = "False";
                    //}

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_name);
                    rpt.SetParameterValue("doc_status", doc_status);
                    rpt.SetParameterValue("job_status", job_status);
                    //rpt.SetParameterValue("doc_cancel", doc_cancel);
                    //rpt.SetParameterValue("doc_close", doc_close);
                    rpt.SetParameterValue("branch_no", "004");
                }
                else if (reportname == "rpt_job_drill_down.rpt")
                {

                    //Response.Write("<a href href='../rpt_job.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string pro_size_name = Request.QueryString["pro_size_name"];
                    string doc_status = Request.QueryString["doc_status"];
                    string job_status = Request.QueryString["job_status"];
                    string car_insuarance = Request.QueryString["car_insuarance"];
                    //string doc_cancel = "";
                    //string doc_close = "";
                    //string user_add = Request.QueryString["user_add"];

                    //if (job_status == "")
                    //{
                    //    doc_cancel = "";
                    //    doc_close = "";
                    //}
                    //else if (job_status == "0")
                    //{
                    //    doc_cancel = "False";
                    //    doc_close = "False";
                    //}
                    //else if (job_status == "1")
                    //{
                    //    doc_cancel = "False";
                    //    doc_close = "True";
                    //}
                    //else if (job_status == "2")
                    //{
                    //    doc_cancel = "True";
                    //    doc_close = "False";
                    //}

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_name);
                    //rpt.SetParameterValue("doc_cancel", doc_cancel);
                    //rpt.SetParameterValue("doc_close", doc_close);
                    rpt.SetParameterValue("doc_status", doc_status);
                    rpt.SetParameterValue("job_status", job_status);
                    rpt.SetParameterValue("car_insuarance", car_insuarance);
                    //rpt.SetParameterValue("user_add", user_add);
                    rpt.SetParameterValue("branch_no", "004");

                }
                //==================== Job Document Report =======================
                else if (reportname == "rpt_job_abnormal_profit.rpt")
                {

                    //Response.Write("<a href href='../rpt_job.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string pro_size_name = Request.QueryString["pro_size_name"];
                    string price_type = Request.QueryString["price_type"];
                    string doc_cancel = "";
                    string doc_close = "";
                    string profit_type = Request.QueryString["profit_type"];
                    string percent = Request.QueryString["percent"];
                    string job_status = Request.QueryString["job_status"];
                    //string user_add = Request.QueryString["user_add"];

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_name);
                    rpt.SetParameterValue("doc_cancel", doc_cancel);
                    rpt.SetParameterValue("doc_close", doc_close);
                    rpt.SetParameterValue("price_type", price_type);
                    rpt.SetParameterValue("profit_type", profit_type);
                    rpt.SetParameterValue("percent", percent);
                    rpt.SetParameterValue("job_status", job_status);
                    //rpt.SetParameterValue("user_add", user_add);
                    rpt.SetParameterValue("branch_no", "004");

                }
                else if (reportname == "rpt_ar_abnormal_profit.rpt")
                {

                    //Response.Write("<a href href='../rpt_job.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string pro_size_name = Request.QueryString["pro_size_name"];
                    string doc_cancel = "";
                    string doc_close = "";
                    string profit_type = Request.QueryString["profit_type"];
                    string price_type = Request.QueryString["price_type"];
                    string percent = Request.QueryString["percent"];
                    string cus_code = Request.QueryString["cus_code"];
                    string pro_code = Request.QueryString["pro_code"];
                    string sale_type = Request.QueryString["sale_type"];
                    //string user_add = Request.QueryString["user_add"];

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_name);
                    rpt.SetParameterValue("profit_type", profit_type);
                    rpt.SetParameterValue("price_type", price_type);
                    rpt.SetParameterValue("percent", percent);
                    rpt.SetParameterValue("cus_code", cus_code);
                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("sale_type", sale_type);
                    rpt.SetParameterValue("branch_no", "004");

                }
                else if (reportname == "rpt_ar_abnormal_profit_advance.rpt")
                {

                    //Response.Write("<a href href='../rpt_job.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string pro_size_code = Request.QueryString["pro_size_code"];
                    string doc_cancel = "";
                    string doc_close = "";
                    string profit_type = Request.QueryString["profit_type"];
                    string price_type = Request.QueryString["price_type"];
                    string percent = Request.QueryString["percent"];
                    string keyword = Request.QueryString["keyword"];
                    string sale_type = Request.QueryString["sale_type"];
                    //string user_add = Request.QueryString["user_add"];

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_code);
                    rpt.SetParameterValue("profit_type", profit_type);
                    rpt.SetParameterValue("price_type", price_type);
                    rpt.SetParameterValue("percent", percent);
                    rpt.SetParameterValue("keyword", keyword);
                    rpt.SetParameterValue("sale_type", sale_type);
                    rpt.SetParameterValue("branch_no", "004");

                }

                else if (reportname == "rpt_pr_abnormal_profit.rpt")
                {

                    //Response.Write("<a href href='../rpt_job.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string profit_type = Request.QueryString["profit_type"];
                    string percent = Request.QueryString["percent"];
                    //string user_add = Request.QueryString["user_add"];

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("profit_type", profit_type);
                    rpt.SetParameterValue("percent", percent);
                    //rpt.SetParameterValue("user_add", user_add);
                    rpt.SetParameterValue("branch_no", "004");

                }

                //============================================== รายงานใบสั่งขาย ===============================================================
                else if (reportname == "rpt_ws.rpt")
                {
                    //Response.Write("<a href href='../rpt_ws.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string pro_size_name = "";
                    if (Request.Form["pro_size_name"] != null)
                    {
                        pro_size_name = Request.QueryString["pro_size_name"];
                    }
                    string doc_close = "";
                    string doc_cancel = "";
                    string job_status = Request.QueryString["job_status"];

                    if (job_status == "")
                    {
                        doc_cancel = "";
                        doc_close = "";
                    }
                    else if (job_status == "0")
                    {
                        doc_cancel = "False";
                        doc_close = "False";
                    }
                    else if (job_status == "1")
                    {
                        doc_cancel = "False";
                        doc_close = "True";
                    }
                    else if (job_status == "2")
                    {
                        doc_cancel = "True";
                        doc_close = "False";
                    }
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_name);
                    rpt.SetParameterValue("doc_cancel", doc_cancel);
                    rpt.SetParameterValue("doc_close", doc_close);
                    //rpt.SetParameterValue("user_ad", Get_UserAuthor(13));
                    rpt.SetParameterValue("branch_no", "004");
                }
                //============================================== รายงานใบสั่งขายรวมรายการ ===============================================================
                else if (reportname == "rpt_ws_product.rpt")
                {
                    //Response.Write("<a href href='../rpt_ws.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string pro_size_name = "";
                    if (Request.Form["pro_size_name"] != null)
                    {
                        pro_size_name = Request.QueryString["pro_size_name"];
                    }
                    string doc_close = "";
                    string doc_cancel = "";
                    string job_status = Request.QueryString["job_status"];

                    if (job_status == "")
                    {
                        doc_cancel = "";
                        doc_close = "";
                    }
                    else if (job_status == "0")
                    {
                        doc_cancel = "False";
                        doc_close = "False";
                    }
                    else if (job_status == "1")
                    {
                        doc_cancel = "False";
                        doc_close = "True";
                    }
                    else if (job_status == "2")
                    {
                        doc_cancel = "True";
                        doc_close = "False";
                    }
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_name);
                    rpt.SetParameterValue("doc_cancel", doc_cancel);
                    rpt.SetParameterValue("doc_close", doc_close);
                    rpt.SetParameterValue("branch_no", "004");
                }

                else if (reportname == "rpt_pr.rpt")
                {
                    //Response.Write("<a href href='../rpt_pr.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    string Cust_code = Request.QueryString["Cust_code"];
                    string doc_code = Request.QueryString["doc_code"];
                    string pro_code = Request.QueryString["pro_code"];

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("Cust_code", Cust_code);
                    rpt.SetParameterValue("doc_code", doc_code);
                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("branch_no", "004");
                }
                else if (reportname == "rpt_pre_receive.rpt")
                {
                    //Response.Write("<a href href='../rpt_Pre_Receive.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    /*	foreach (string str in Request.Form)
                    {
                        Response.Write(str + " = " + Request.Form[str] + "<br />");
                    }*/
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string Cust_code = Request.QueryString["cust_code"];
                    string Cust_Type_code = Request.QueryString["cust_type_code"];
                    string doc_status = Request.QueryString["doc_status"];
                    string Cust_Pay_code = "";

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("Cust_code", Cust_code);
                    rpt.SetParameterValue("Cust_Type_code", Cust_Type_code);
                    rpt.SetParameterValue("Cust_pay_code", Cust_Pay_code);
                    rpt.SetParameterValue("doc_status", doc_status);
                    //rpt.SetParameterValue("branch_no",branch_no);
                }
                else if (reportname == "rpt_sum_day.rpt")
                {
                    //Response.Write("<a href href='../rpt_sum_day.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    string cus_code = Request.QueryString["cus_code"];
                    string cus_type = Request.QueryString["cus_type"];
                    string money_pay = Request.QueryString["money_pay"];

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("cus_code", cus_code);
                    rpt.SetParameterValue("cus_type", cus_type);
                    rpt.SetParameterValue("money_pay", money_pay);
                }
                else if (reportname == "rpt_sum_receive.rpt")
                {
                    //Response.Write("<a href href='../rpt_sum_receive.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    string cus_code = Request.QueryString["cus_code"];
                    string cus_type = Request.QueryString["cus_type"];

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("cus_code", cus_code);
                    rpt.SetParameterValue("cus_type", cus_type);
                }
                else if (reportname == "rpt_sum_receive_credit.rpt")
                {
                    //Response.Write("<a href href='../rpt_sum_receive_credit.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                }
                else if (reportname == "rpt_sale.rpt")
                {
                    //Response.Write("<a href href='../rpt_sale.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    string pro_size_code = Request.QueryString["pro_size_code"];
                    string pro_code = Request.QueryString["pro_code"];
                    string cus_code = Request.QueryString["cus_code"];
                    string sale_type = Request.QueryString["sale_type"];
                    string doc_type = Request.QueryString["doc_type"];
                    string report_type = Request.QueryString["report_type"];

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_code);
                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("cus_code", cus_code);
                    rpt.SetParameterValue("sale_type", sale_type);
                    rpt.SetParameterValue("doc_type", doc_type);
                    rpt.SetParameterValue("report_type", report_type);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "rpt_sale_product.rpt")
                {
                    //Response.Write("<a href href='../rpt_sale.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    string pro_size_code = Request.QueryString["pro_size_code"];
                    string pro_code = Request.QueryString["pro_code"];
                    string cus_code = Request.QueryString["cus_code"];
                    string sale_type = Request.QueryString["sale_type"];
                    string doc_type = Request.QueryString["doc_type"];
                    string report_type = Request.QueryString["report_type"];

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_code);
                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("cus_code", cus_code);
                    rpt.SetParameterValue("sale_type", sale_type);
                    rpt.SetParameterValue("doc_type", doc_type);
                    rpt.SetParameterValue("report_type", report_type);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                else if (reportname == "rpt_sale_model.rpt")
                {
                    //Response.Write("<a href href='../rpt_sale_model.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                }
                else if (reportname == "rpt_sale_brand.rpt")
                {
                    //Response.Write("<a href href='../rpt_sale_brand.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                }
                //===================================== Product Movement Report ==============================================
                else if (reportname == "rpt_pro_movement.rpt")
                {

                    //Response.Write("<a href href='../rpt_pro_movement.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string pro_size_code = Request.QueryString["pro_size_code"];
                    string pro_stock = Request.QueryString["pro_stock"];
                    string pro_code = Request.QueryString["pro_code"];
                    string pro_type = Request.QueryString["pro_type"];

                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_code);
                    rpt.SetParameterValue("pro_stock", pro_stock);
                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("pro_type", pro_type);

                }
                else if (reportname == "rpt_pro_movement_list.rpt")
                {

                    //Response.Write("<a href href='../rpt_pro_movement.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string pro_size_code = Request.QueryString["pro_size_code"];
                    string pro_stock = Request.QueryString["pro_stock"];
                    string pro_code = Request.QueryString["pro_code"];
                    string pro_type = Request.QueryString["pro_type"];

                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_code);
                    rpt.SetParameterValue("pro_stock", pro_stock);
                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("pro_type", pro_type);

                }
                else if (reportname == "rpt_pro_movement_no_ict.rpt")
                {

                    //Response.Write("<a href href='../rpt_pro_movement_no_ict.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    string pro_size_code = Request.QueryString["pro_size_code"];
                    string pro_code = Request.QueryString["pro_code"];
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_code);
                    rpt.SetParameterValue("pro_code", pro_code);
                }
                else if (reportname == "rpt_pro_movement_no_ict_list.rpt")
                {

                    //Response.Write("<a href href='../rpt_pro_movement_no_ict.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    string pro_size_code = Request.QueryString["pro_size_code"];
                    string pro_code = Request.QueryString["pro_code"];
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_code);
                    rpt.SetParameterValue("pro_code", pro_code);
                }

                else if (reportname == "rpt_pobuy.rpt")
                {
                    //Response.Write("<a href href='../rpt_PObuy.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string pro_size_code = Request.QueryString["pro_size_code"];
                    string pro_code = Request.QueryString["pro_code"];
                    string po_status = Request.QueryString["po_status"];
                    string doc_close = "";
                    string doc_cancel = "";
                    string doc_cancel_qty = "";
                    string doc_close_cancel_qty = "";

                    if (po_status == "")
                    {
                    }
                    else if (po_status == "1")
                    {
                        doc_close = "1";
                    }
                    else if (po_status == "2")
                    {
                        doc_cancel = "1";
                    }
                    else if (po_status == "0")
                    {
                        doc_cancel = "0";
                        doc_close = "0";
                        doc_cancel_qty = "0";
                    }
                    else if (po_status == "3")
                    {
                        doc_cancel_qty = "1";
                    }
                    else if (po_status == "4")
                    {
                        doc_cancel_qty = "1";
                        doc_close_cancel_qty = "1";
                    }
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_code);
                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("doc_cancel", doc_cancel);
                    rpt.SetParameterValue("doc_cancel_qty", doc_cancel_qty);
                    rpt.SetParameterValue("doc_close", doc_close);
                    rpt.SetParameterValue("doc_close_cancel_qty", doc_close_cancel_qty);
                    rpt.SetParameterValue("po_status", po_status);
                }
                else if (reportname == "rpt_pobuy_product.rpt")
                {
                    //Response.Write("<a href href='../rpt_pobuy.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string pro_size_code = Request.QueryString["pro_size_code"];
                    string pro_code = Request.QueryString["pro_code"];
                    string po_status = Request.QueryString["po_status"];
                    string doc_close = "";
                    string doc_cancel = "";
                    string doc_cancel_qty = "";
                    string doc_close_cancel_qty = "";

                    if (po_status == "")
                    {
                    }
                    else if (po_status == "1")
                    {
                        doc_close = "1";
                    }
                    else if (po_status == "2")
                    {
                        doc_cancel = "1";
                    }
                    else if (po_status == "0")
                    {
                        doc_cancel = "0";
                        doc_close = "0";
                        doc_cancel_qty = "0";
                    }
                    else if (po_status == "3")
                    {
                        doc_cancel_qty = "1";
                    }
                    else if (po_status == "4")
                    {
                        doc_cancel_qty = "1";
                        doc_close_cancel_qty = "1";
                    }
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_code);
                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("doc_cancel", doc_cancel);
                    rpt.SetParameterValue("doc_close", doc_close);
                    rpt.SetParameterValue("po_status", po_status);
                    rpt.SetParameterValue("doc_cancel_qty", doc_cancel_qty);
                    rpt.SetParameterValue("doc_close_cancel_qty", doc_close_cancel_qty);
                }
                else if (reportname == "rpt_buy.rpt")
                {
                    //Response.Write("<a href href='../rpt_buy.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string pro_code = Request.QueryString["pro_code"];
                    string ven_code = Request.QueryString["ven_code"];

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("ven_code", ven_code);
                }
                else if (reportname == "rpt_product_keep.rpt")
                {
                    //Response.Write("<a href href='../rpt_Product_keep.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string pro_size_code = Request.QueryString["pro_size_code"];
                    string pro_code = Request.QueryString["pro_code"];

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_code);
                    rpt.SetParameterValue("pro_code", pro_code);
                }
                //=====================================รายงานใบรับเข้าสินค้า==============================================
                else if (reportname == "rpt_apreceive.rpt")
                {
                    //Response.Write("<a href href='../rpt_apreceive.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string pro_code = Request.QueryString["pro_code"];
                    string pro_size = Request.QueryString["pro_size_code"];
                    string po_status = Request.QueryString["po_status"];
                    string ven_code = Request.QueryString["Ven_Code"];
                    string date_type = Request.QueryString["date_type"];
                    string doc_name = Request.QueryString["doc_name"];
                    string doc_close = "";
                    string doc_cancel = "";

                    if (po_status == "")
                    {
                        doc_cancel = "";
                        doc_close = "";
                    }
                    else if (po_status == "1")
                    {
                        doc_cancel = "0";
                        doc_close = "1";
                    }
                    else if (po_status == "2")
                    {
                        doc_cancel = "1";
                        doc_close = "0";
                    }
                    else if (po_status == "0")
                    {
                        doc_cancel = "0";
                        doc_close = "0";
                    }

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size", pro_size);
                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("doc_close", doc_close);
                    rpt.SetParameterValue("doc_cancel", doc_cancel);
                    rpt.SetParameterValue("ven_code", ven_code);
                    rpt.SetParameterValue("date_type", date_type);
                    rpt.SetParameterValue("doc_name", doc_name);

                }
                //==================================================================================================================================================
                else if (reportname == "rpt_apreceive_product.rpt")
                {
                    //Response.Write("<a href href='../rpt_apreceive.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string pro_code = Request.QueryString["pro_code"];
                    string pro_size = Request.QueryString["pro_size_code"];
                    string po_status = Request.QueryString["po_status"];
                    string ven_code = Request.QueryString["Ven_Code"];
                    string date_type = Request.QueryString["date_type"];
                    string doc_name = Request.QueryString["doc_name"];
                    string doc_close = "";
                    string doc_cancel = "";

                    if (po_status == "")
                    {
                        doc_cancel = "";
                        doc_close = "";
                    }
                    else if (po_status == "1")
                    {
                        doc_cancel = "0";
                        doc_close = "1";
                    }
                    else if (po_status == "2")
                    {
                        doc_cancel = "1";
                        doc_close = "0";
                    }
                    else if (po_status == "0")
                    {
                        doc_cancel = "0";
                        doc_close = "0";
                    }

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size", pro_size);
                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("doc_close", doc_close);
                    rpt.SetParameterValue("doc_cancel", doc_cancel);
                    rpt.SetParameterValue("ven_code", ven_code);
                    rpt.SetParameterValue("date_type", date_type);
                    rpt.SetParameterValue("doc_name", doc_name);
                }
                //=====================================รายงานเพิ่มหนี้เจ้าหนี้============================================
                else if (reportname == "rpt_ap_add.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string ven_code = Request.QueryString["ven_code"];

                    //Response.Write("<a href href='../rpt_ap_add.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("ven_code", ven_code);
                }
                //============================= รายงานเพิ่มหนี้เจ้าหนี้ตามใบรับเข้า=============================
                else if (reportname == "rpt_ap_add2.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string Pro_Code = Request.QueryString["Pro_Code"];
                    string Progroup_Code = Request.QueryString["Progroup_Code"];
                    string Pro_Brand_Code = Request.QueryString["Pro_Brand_Code"];
                    string Pro_Model_Code = Request.QueryString["Pro_Model_Code"];
                    string Pro_Size_Code = Request.QueryString["Pro_Size_Code"];
                    string ven_code = Request.QueryString["ven_code"];

                    //Response.Write("<a href href='../rpt_ap_add2.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("Pro_Code", Pro_Code);
                    rpt.SetParameterValue("Progroup_Code", Progroup_Code);
                    rpt.SetParameterValue("Pro_Brand_Code", Pro_Brand_Code);
                    rpt.SetParameterValue("Pro_Model_Code", Pro_Model_Code);
                    rpt.SetParameterValue("Pro_Size_Code", Pro_Size_Code);
                    rpt.SetParameterValue("ven_code", ven_code);
                }
                //============================= รายงานลดหนี้เจ้าหนี้=============================
                else if (reportname == "rpt_ap_down.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string ven_code = Request.QueryString["ven_code"];

                    //Response.Write("<a href href='../rpt_AP_down.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("ven_code", ven_code);
                }
                //============================= รายงานลดหนี้หนี้เจ้าหนี้ตามใบรับเข้า=============================
                else if (reportname == "rpt_ap_down2.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string Pro_Code = Request.QueryString["Pro_Code"];
                    string Progroup_Code = Request.QueryString["Progroup_Code"];
                    string Pro_Brand_Code = Request.QueryString["Pro_Brand_Code"];
                    string Pro_Model_Code = Request.QueryString["Pro_Model_Code"];
                    string Pro_Size_Code = Request.QueryString["Pro_Size_Code"];
                    string ven_code = Request.QueryString["ven_code"];

                    //Response.Write("<a href href='../rpt_AP_down2.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("Pro_Code", Pro_Code);
                    rpt.SetParameterValue("Progroup_Code", Progroup_Code);
                    rpt.SetParameterValue("Pro_Brand_Code", Pro_Brand_Code);
                    rpt.SetParameterValue("Pro_Model_Code", Pro_Model_Code);
                    rpt.SetParameterValue("Pro_Size_Code", Pro_Size_Code);
                    rpt.SetParameterValue("ven_code", ven_code);
                }
                //============================= รายงานเจ้าหนี้ค้างชำระ=============================
                else if (reportname == "rpt_ap_keep.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    string start_date_used = Request.QueryString["start_date_used"];
                    string end_date_used = Request.QueryString["end_date_used"];
                    string Ven_Code = Request.QueryString["Ven_Code"];

                    //Response.Write("<a href href='../rpt_ap_keep.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("Ven_Code", Ven_Code);

                }
                //============================= รายงานการจ่ายชำระเจ้าหนี้=============================
                else if (reportname == "rpt_AP_Pay.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    string Vendor_Code = Request.QueryString["Vendor_Code"];
                    string date_type = Request.QueryString["date_type"];

                    //Response.Write("<a href href='../rpt_AP_Pay.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("Vendor_Code", Vendor_Code);
                    rpt.SetParameterValue("date_type", date_type);
                }
                //============================= รายงานสรุปการจ่ายชำระประจำวัน=============================
                else if (reportname == "rpt_sum_ap_pay.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    string Vendor_Code = Request.QueryString["ven_code"];

                    //Response.Write("<a href href='../rpt_sum_ap_pay.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("cus_code", Vendor_Code);
                }
                else if (reportname == "rpt_tax_po.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    string ven_code = Request.QueryString["ven_code"];
                    string rpt_type = Request.QueryString["rpt_type"];
                    string vat_rate = Request.QueryString["vat_rate"];
                    string date_type = Request.QueryString["date_type"];
                    string flag_novat = Request.QueryString["flag_novat"];

                    //Response.Write("<a href href='../rpt_tax_po.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("ven_code", ven_code);
                    rpt.SetParameterValue("rpt_type", rpt_type);
                    rpt.SetParameterValue("vat_rate", vat_rate);
                    rpt.SetParameterValue("date_type", date_type);
                    rpt.SetParameterValue("flag_novat", flag_novat);
                }
                //============================= รายงานอายุเจ้าหนี้=============================
                else if (reportname == "rptApageing.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    string ven_code = Request.QueryString["ven_code"];

                    //Response.Write("<a href href='../rpt_credit_vendor.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("ldate", end_date);
                    rpt.SetParameterValue("ven_code", ven_code);


                }
                //=====================================รายงานการจ่ายเช็ค==============================================
                else if (reportname == "rpt_Pay_Cheque.rpt")
                {
                    //Response.Write("<a href href='../rpt_Pay_Cheque.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string Trans_Type = Request.QueryString["Trans_Type"];
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("type_code", Trans_Type);
                }
                //=====================================รายงานการรับเช็ค==============================================
                else if (reportname == "rpt_Receive_Cheque.rpt")
                {
                    //Response.Write("<a href href='../rpt_Receive_Cheque.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string Type_Code = Request.QueryString["Type_Code"];
                    string bank_code = Request.QueryString["bank_code"];
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("Type_Code", Type_Code);
                    rpt.SetParameterValue("bank_code", bank_code);
                }
                //=====================================รายงานความเคลื่อนไหวบัญชี==============================================
                else if (reportname == "rpt_Account.rpt")
                {
                    //Response.Write("<a href href='../rpt_Account.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string Account_ID = Request.QueryString["Account_ID"];

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                }
                //=====================================รายงานสรุปการรับจ่ายเงินประจำวัน==============================================
                else if (reportname == "rpt_Day.rpt")
                {
                    //Response.Write("<a href href='../rpt_Account.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                }
                //=====================================รายงานการวางบิล/รับชำระลูกหนี้==============================================
                else if (reportname == "rpt_check_ar.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string Cus_Code = Request.QueryString["Cus_Code"];
                    string date_type = Request.QueryString["date_type"];
                    string doc_status = Request.QueryString["doc_status"];

                    //Response.Write("<a href href='../rpt_check_ar.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("cus_code", Cus_Code);
                    rpt.SetParameterValue("date_type", date_type);
                    rpt.SetParameterValue("doc_status", doc_status);
                }

                //=====================================รายงานเพิ่มหนี้ลูกหนี้==============================================

                else if (reportname == "rpt_AR_add.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string Cus_Code = Request.QueryString["Cus_Code"];

                    //Response.Write("<a href href='../rpt_AR_add.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("cus_code", Cus_Code);
                }

                //=====================================รายงานเพิ่มหนี้ลูกหนี้ตามใบเสร็จ==============================================
                else if (reportname == "rpt_AR_add2.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string pro_code = Request.QueryString["pro_code"];
                    string pro_size_code = Request.QueryString["pro_size_code"];

                    //Response.Write("<a href href='../rpt_AR_add2.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_code);
                }
                //=====================================รายงานลดหนี้ลูกหนี้==============================================
                else if (reportname == "rpt_AR_down.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string Cus_Code = Request.QueryString["Cus_Code"];
                    //Response.Write("<a href href='../rpt_AR_down.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("Cus_Code", Cus_Code);
                }
                //=====================================รายงานลดหนี้ลูกหนี้ตามใบเสร็จ==============================================
                else if (reportname == "rpt_AR_down2.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string pro_code = Request.QueryString["pro_code"];
                    string pro_size_code = Request.QueryString["pro_size_code"];
                    //Response.Write("<a href href='../rpt_AR_down2.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_code);
                }
                //=====================================รายงานลูกหนี้ค้างชำระ==============================================
                else if (reportname == "rpt_AR_keep.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string Cus_Type = Request.QueryString["Cus_Type"];
                    string Cus_Code = Request.QueryString["Cus_Code"];
                    string date_select = Request.QueryString["date_select"];
                    //Response.Write ("<a href='../rpt_AR_Keep.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    // Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("Cus_Type", Cus_Type);
                    rpt.SetParameterValue("Cus_Code", Cus_Code);
                    rpt.SetParameterValue("date_select", date_select);
                }
                //=====================================รายงานการรับชำระลูกหนี้==============================================
                else if (reportname == "rpt_AR_Receive.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string Cus_Code = Request.QueryString["Cus_Code"];
                    //Response.Write ("<a href='../rpt_AR_Receive.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    // Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("Cus_Code", Cus_Code);
                }
                //=====================================รายงานสถานะการรับเงิน==============================================
                else if (reportname == "Rpt_Confirm_Receive.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string Cus_Code = Request.QueryString["Cus_Code"];
                    string confirm_status = Request.QueryString["confirm_status"];
                    //Response.Write ("<a href='../Rpt_Confirm_Receive.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    // Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("Cus_Code", Cus_Code);
                    rpt.SetParameterValue("confirm_status", confirm_status);

                }
                //=====================================รายงานภาษีขาย==============================================
                else if (reportname == "rpt_tax_sale.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    string Cus_Code = Request.QueryString["Cus_Code"];
                    //Response.Write ("<a href='../rpt_tax_sale.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("Cus_Code", Cus_Code);
                }
                //=====================================รายงานอายุลูกหนี้==============================================
                else if (reportname == "rptArageing.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    string Cus_Code = Request.QueryString["Cus_Code"];
                    //Response.Write ("<a href='../rpt_credit_customer.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    // Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("pStartDate", start_date);
                    rpt.SetParameterValue("pEndDate", end_date);
                    rpt.SetParameterValue("Cus_Code", Cus_Code);
                }
                else if (reportname == "rptArageing_detail.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    string Cus_Code = Request.QueryString["Cus_Code"];
                    //Response.Write ("<a href='../rpt_credit_customer.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    // Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("pStartDate", start_date);
                    rpt.SetParameterValue("pEndDate", end_date);
                    rpt.SetParameterValue("Cus_Code", Cus_Code);
                }
                else if (reportname == "rpt_buy_group.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    string ven_code = Request.QueryString["ven_code"];

                    //Response.Write("<a href href='../rpt_buy_group.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("progroup_code", progroup_code);

                }
                //===================================== Analysis Report Profit ==============================================
                else if (reportname == "rpt_profit.rpt")
                {

                    //Response.Write("<a href href='../report_back.asp?url_back=rpt_profit.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../report_back.asp?url_back=posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    string start_date = Request["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string pro_size_name = Request["pro_size_name"];
                    string pro_code = Request["pro_code"];
                    string vat_product = Request["vat_product"];
                    string bill_novat_status = Request["bill_novat_status"];

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_name", pro_size_name);
                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("vat_product", vat_product);
                    rpt.SetParameterValue("bill_novat_status", bill_novat_status);
                }
                else if (reportname == "rpt_profit_qty.rpt")
                {

                    //Response.Write("<a href href='../report_back.asp?url_back=rpt_profit.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../report_back.asp?url_back=posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    string start_date = Request["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string pro_size_name = Request["pro_size_name"];
                    string pro_code = Request["pro_code"];
                    string vat_product = Request["vat_product"];

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_name", pro_size_name);
                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("vat_product", vat_product);
                }
                //=====================================รายงานยอดกขายตามประเภทสินค้า==============================================
                else if (reportname == "rpt_sale_group.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];

                    //Response.Write ("<a href='../rpt_sale_group.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("progroup_code", progroup_code);

                }
                //=====================================รายงานยอดกขายตามยี่ห้อสินค้า==============================================
                else if (reportname == "rpt_brand.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    string sale_type = Request.QueryString["sale_type"];

                    //Response.Write ("<a href='../rpt_brand.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("sale_type", sale_type);

                }
                //=====================================รายงานยอดกขายตามงรุ่นสินค้า==============================================
                else if (reportname == "rpt_model.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    string sale_type = Request.QueryString["sale_type"];

                    //Response.Write ("<a href='../rpt_model.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("sale_type", sale_type);

                }
                //=====================================รายงานยอดขายตามขนาดสินค้า==============================================
                else if (reportname == "rpt_size.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    string pro_size_code = Request.QueryString["pro_size_code"];

                    //Response.Write ("<a href='../rpt_size.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_code);

                }
                //=====================================รายงานยอดขายตามประเภทลูกค้า==============================================
                else if (reportname == "rpt_sale_custgroup.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    string cus_type = Request.QueryString["cus_type"];

                    //Response.Write ("<a href='../rpt_sale_custgroup.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("cus_type", cus_type);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                }
                //=====================================รายงานวิเคราะห์ขายตามลูกค้า==============================================
                else if (reportname == "rpt_sale_cust.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string cus_type = Request.QueryString["cus_type"];
                    string Cus_Code = Request.QueryString["Cus_Code"];
                    string pro_size_name = Request.QueryString["pro_size_name"];

                    //Response.Write ("<a href='../rpt_sale_cust.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("Cus_Code", Cus_Code);
                    rpt.SetParameterValue("cus_type", cus_type);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_name", pro_size_name);
                }
                //=====================================รายงานส่งเสริมการขาย==============================================
                else if (reportname == "rpt_promotion.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string Cus_Code = Request.QueryString["Cus_Code"];
                    string doc_code = Request.QueryString["doc_code"];

                    //Response.Write ("<a href='../rpt_promotion.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("Cus_Code", Cus_Code);
                    rpt.SetParameterValue("doc_code", doc_code);
                }
                //============================= รายงานวิเคราะห์ซื้อตามยี่ห้อสินค้า =============================
                else if (reportname == "rpt_buy_brand.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }


                    //Response.Write("<a href href='../rpt_buy_brand.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                }
                //=============================รายงานวิเคราะห์ซื้อตามรุ่นสินค้า=============================
                else if (reportname == "rpt_buy_model.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    //Response.Write("<a href href='../rpt_buy_model.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                }
                //=============================รายงานวิเคราะห์การซื้อตามขนาดสินค้า=============================
                else if (reportname == "rpt_buy_size.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string pro_size_code = Request.QueryString["pro_size_code"];

                    //Response.Write("<a href href='../rpt_buy_size.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_code);
                }
                //=============================รายงานวิเคราะห์ซื้อตามผู้จำหน่าย=============================
                else if (reportname == "rpt_vendor.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    string ven_code = Request.QueryString["ven_code"];

                    //Response.Write("<a href href='../rpt_vendor.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("ven_code", ven_code);

                }
                //=============================รายงานประวัติการใช้บริการลูกค้า=============================
                else if (reportname == "rpt_Profile_Service.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    string ven_code = Request.QueryString["ven_code"];
                    string Cus_Code = Request.QueryString["Cus_Code"];
                    string Pro_Code = Request.QueryString["Pro_Code"];
                    string pro_size_name = Request.QueryString["pro_size_name"];

                    //Response.Write("<a href href='../rpt_profile_service.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("Cus_Code", Cus_Code);
                    rpt.SetParameterValue("Pro_Code", Pro_Code);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_name", pro_size_name);
                }

                //==========================================รายงานบริการครั้งต่อไป============================================
                else if (reportname == "rpt_next_serv.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    string Sub_NextServ_Code = Request.QueryString["Sub_NextServ_Code"];
                    //string Cus_Code = Request.QueryString["Cus_Code"];
                    //string Pro_Code = Request.QueryString["Pro_Code"];
                    //string pro_size_name = Request.QueryString["pro_size_name"];

                    //Response.Write("<a href href='../rpt_next_serv.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("Sub_NextServ_Code", Sub_NextServ_Code);
                    /*rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_name", pro_size_name);*/
                }
                //===================================== รายงานค่า Commission ==============================================
                else if (reportname == "rpt_commission.rpt")
                {
                    //string doc_no_comm = Request.QueryString["doc_no"];
                    string user_id = Request.QueryString["user_id"];

                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("user_id", user_id);
                }
                else if (reportname == "rpt_commission_all.rpt")
                {
                    //string doc_no_comm = Request.QueryString["doc_no"];

                    rpt.SetParameterValue("doc_no", doc_no);
                }
                else if (reportname == "rpt_commission_view.rpt")
                {
                    //string doc_no_comm = Request.QueryString["doc_no"];

                    rpt.SetParameterValue("doc_no", doc_no);
                }
                else if (reportname == "rpt_commission_variable.rpt")
                {
                    //string doc_no_comm = Request.QueryString["doc_no"];
                    string type_emp_id = Request.QueryString["type_emp_id"];

                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("type_emp_id", type_emp_id);
                }
                //========================================รายงานลูกค้าขาดการติดต่อ=================================================
                else if (reportname == "rpt_Nocontact.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string Cus_Code = Request.QueryString["Cus_Code"];


                    //Response.Write("<a href href='../rpt_NoContact.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("Cus_Code", Cus_Code);
                }
                //========================================รายงานลูกค้าขาดการติดต่อพร้อมข้อมูล=================================================
                else if (reportname == "rpt_nocontact_detail.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string Cus_Code = Request.QueryString["Cus_Code"];


                    //Response.Write("<a href href='../rpt_NoContact.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("Cus_Code", Cus_Code);
                }

                //=============================รายงานวิเคราะห์ความพึงพอใจลูกค้า=============================
                else if (reportname == "rpt_comment.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    string Cus_Code = Request.QueryString["Cus_Code"];

                    //Response.Write("<a href href='../rpt_comment.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("Cus_Code", Cus_Code);
                }
                //=============================รายงานติดตาม3วันหลังให้บริการ=============================
                else if (reportname == "rpt_calltrack.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string Cus_Code = Request.QueryString["Cus_Code"];
                    string callstatus = Request.QueryString["call_status"];
                    string callpoint = Request.QueryString["call_point"];
                    string day_limit = Request.QueryString["day_limit"];


                    //Response.Write("<a href href='../rpt_calltrack.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("Cus_Code", Cus_Code);
                    rpt.SetParameterValue("callstatus", callstatus);
                    rpt.SetParameterValue("callpoint", callpoint);
                    rpt.SetParameterValue("day_limit", day_limit);
                }
                //=============================รายงานการปฏิบัติงานของพนักงาน=============================
                else if (reportname == "rpt_semp_job.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string semp_no = Request.QueryString["io_by"];

                    //Response.Write("<a href href='../rpt_calltrack.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("ldate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("semp_no", semp_no);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                }
                //=============================รายงานการปฏิบัติงานของพนักงาน=============================
                else if (reportname == "rpt_semp_ws.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string semp_no = Request.QueryString["io_by"];

                    //Response.Write("<a href href='../rpt_calltrack.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("ldate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("semp_no", semp_no);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                }
                //=============================รายงานการรับ/จ่ายชำระประจำวัน=============================
                else if (reportname == "rpt_sum_mix.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string Cus_Code = Request.QueryString["Cus_Code"];

                    //Response.Write("<a href href='../rpt_sum_mix.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("Cus_Code", Cus_Code);
                }
                //=============================รายงานทะเบียนรถยนต์=============================
                else if (reportname == "rpt_Car.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string Car_Type_Code = Request.QueryString["Car_Type_Code"];
                    string Car_Code = Request.QueryString["Car_Code"];
                    string Car_Model_Code = Request.QueryString["Car_Model_Code"];
                    string Car_Province_Code = Request.QueryString["Car_Province_Code"];

                    //Response.Write("<a href href='../rpt_Car.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("Car_Type_Code", Car_Type_Code);
                    rpt.SetParameterValue("Car_Code", Car_Code);
                    rpt.SetParameterValue("Car_Model_Code", Car_Model_Code);
                    rpt.SetParameterValue("Car_Province_Code", Car_Province_Code);
                }

                //=============================รายงานทะเบียนลูกค้า=============================
                else if (reportname == "rpt_Cust.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string Cus_Type = Request.QueryString["Cus_Type"];
                    string Cus_Code = Request.QueryString["Cus_Code"];

                    //Response.Write("<a href href='../rpt_Cust.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("Cus_Type", Cus_Type);
                    rpt.SetParameterValue("Cus_Code", Cus_Code);
                }
                //=============================รายงานทะเบียนสินค้า=============================
                else if (reportname == "rpt_Product.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string pro_code = Request.QueryString["pro_code"];
                    string pro_size_name = Request.QueryString["pro_size_name"];

                    //Response.Write("<a href href='../rpt_Product.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_name", pro_size_name);
                }

                //=============================รายงานทะเบียนสินค้าใหม่=============================
                else if (reportname == "rpt_New_Product.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string Ven_Code = Request.QueryString["Ven_Code"];

                    //Response.Write("<a href href='../rpt_New_Product.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("Ven_Code", Ven_Code);
                }
                //=============================บาร์โค้ด=============================
                else if (reportname == "bar_code.rpt")
                {
                    //Response.Write("<a href href='../stk_incre_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    string record = Request.QueryString["record"];
                    rpt.SetParameterValue("record", record);
                }
                else if (reportname == "bar_code_02.rpt")
                {
                    //Response.Write("<a href href='../stk_incre_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    string record = Request.QueryString["record"];
                    rpt.SetParameterValue("record", record);
                }
                else if (reportname == "bar_code_03.rpt")
                {
                    //Response.Write("<a href href='../stk_incre_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    string record = Request.QueryString["record"];
                    rpt.SetParameterValue("record", record);
                }
                else if (reportname == "barcode_ini.rpt")
                {
                    //Response.Write("<a href='../report_back.asp?url_back=stk_incre_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href='../report_back.asp?url_back=posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                }
                else if (reportname == "barcode_listing.rpt")
                {
                    //Response.Write("<a href='../report_back.asp?url_back=stk_incre_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href='../report_back.asp?url_back=posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("doc_no", doc_no);
                    //   rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, Session["reportname"].ToString());
                    // Response.End();
                }
                else if (reportname == "prn_cust0_name_add_carreg.rpt")
                {
                    string prn_type1 = Request.QueryString["prn_type1"];
                    rpt.SetParameterValue("prn_type1", prn_type1);
                }
                else if (reportname == "rpt_next_serv_cust.rpt")
                {
                    string prosub_code = Request.QueryString["prosub_code"];
                    rpt.SetParameterValue("prosub_code", prosub_code);
                    rpt.SetParameterValue("fdate", fdate);
                    rpt.SetParameterValue("tdate", tdate);
                    rpt.SetParameterValue("sdate", sdate);
                    rpt.SetParameterValue("edate", edate);
                }
                else if (reportname == "prn_cust2_name_add_carreg.rpt")
                {
                    string prn_type1 = Request.QueryString["prn_type1"];
                    rpt.SetParameterValue("prn_type1", prn_type1);
                }
                else if (reportname == "rpt_nexservice_treatment.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    string ven_code = Request.QueryString["ven_code"];
                    string Cus_Code = Request.QueryString["Cus_Code"];
                    string Pro_Code = Request.QueryString["Pro_Code"];
                    string pro_size_name = Request.QueryString["pro_size_name"];

                    //Response.Write("<a href href='../rpt_next_serv.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_name", pro_size_name);
                }
                //=======================================รายงานการรับชำระตามพนักงาน================================================
                else if (reportname == "rpt_receive_by_emp.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string io_by = Request.QueryString["io_by"];
                    string user_id = Request.QueryString["user_id"];
                    string sale_type = Request.QueryString["sale_type"];

                    //Response.Write("<a href href='../rpt_Product.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("io_by", io_by);
                    rpt.SetParameterValue("user_id", user_id);
                    rpt.SetParameterValue("sale_type", sale_type);
                }
                // รายงานสรุปการขายรับจ่ายชำระ
                else if (reportname == "rpt_sum_sale_receive.rpt")
                {
                    //Response.Write("<a href href='../rpt_sum_day.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    string cus_code = Request.QueryString["cus_code"];
                    string cus_type = Request.QueryString["cus_type"];

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("cus_code", cus_code);
                    rpt.SetParameterValue("cus_type", cus_type);
                }
                //=======================================รายงาน DOT================================================
                else if (reportname == "rpt_dot.rpt")
                {
                    string Pro_Size_Code = Request.QueryString["Pro_Size_Code"];
                    string pro_code = Request.QueryString["pro_code"];
                    string start_dot = Request.QueryString["start_dot"];
                    string end_dot = Request.QueryString["end_dot"];

                    //Response.Write("<a href href='../rpt_Product.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("Pro_Size_Code", Pro_Size_Code);
                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("start_dot", start_dot);
                    rpt.SetParameterValue("end_dot", end_dot);
                }
                //=======================================รายงาน Vat Balance ================================================
                //        else if (reportname == "rpt_vat_balance.rpt")
                //        {

                //            string pro_code = Request.QueryString["pro_code"];
                //            string pro_size_name = Request.QueryString["pro_size_name"];


                //            rpt.SetParameterValue("pro_code", pro_code);
                //            rpt.SetParameterValue("progroup_code", progroup_code);
                //            rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                //            rpt.SetParameterValue("pro_model_code", pro_model_code);
                //            rpt.SetParameterValue("pro_size_name", pro_size_name);
                //        }
                else if (reportname == "rpt_vat_balance.rpt")
                {

                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    string pro_code = Request.QueryString["search_pro_code"];
                    string pro_size_name = Request.QueryString["pro_size_name"];
                    string show_vat_zero = Request.QueryString["show_vat_zero"];



                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_name", pro_size_name);
                    rpt.SetParameterValue("show_vat_zero", show_vat_zero);
                }
                //=======================================รายงานงบกำไรขาดทุนเบ็ดเสร็จ==============================================
                else if (reportname == "rpt_financial.rpt")
                {
                    //Response.Write("<a href href='../rpt_sum_receive_credit.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string bill_novat_status = Request.QueryString["bill_novat_status"];

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("bill_novat_status", bill_novat_status);
                }
                //============================รายงานสรุปขายตามพนักงาน(ขายปลีก)=============================
                else if (reportname == "rpt_semp_sale.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string semp_no = Request.QueryString["io_by"];

                    //Response.Write("<a href href='../rpt_calltrack.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("ldate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("semp_no", semp_no);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                }
                //============================รายงานสรุปขายตามพนักงาน(ขายส่ง)=============================
                else if (reportname == "rpt_semp_sale_ws.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string semp_no = Request.QueryString["io_by"];

                    //Response.Write("<a href href='../rpt_calltrack.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("ldate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("semp_no", semp_no);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                }
                //============================พิมพ์หมายเลข S/N============================
                else if (reportname == "sn_prn.rpt")
                {
                    string pro_code = Request.QueryString["pro_code"];

                    //Response.Write("<a href href='../rpt_calltrack.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("pro_code", pro_code);
                }
                //============================================================================================
                //============================= รายงานวิเคราะห์ซื้อตามยี่ห้อสินค้าขั้นสูง =============================
                else if (reportname == "rpt_buy_brand_advance.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string keyword = Request.QueryString["keyword"];

                    //Response.Write("<a href href='../rpt_buy_brand.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("keyword", keyword);
                }
                //=============================รายงานวิเคราะห์ซื้อตามรุ่นสินค้าขั้นสูง===============================
                else if (reportname == "rpt_buy_model_advance.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string keyword = Request.QueryString["keyword"];

                    //Response.Write("<a href href='../rpt_buy_brand.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("keyword", keyword);
                }
                //=============================รายงานวิเคราะห์การซื้อตามขนาดสินค้า(ขั้นสูง)=============================
                else if (reportname == "rpt_buy_size_advance.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string keyword = Request.QueryString["keyword"];
                    string pro_size_code = Request.QueryString["pro_size_code"];

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_code);
                    rpt.SetParameterValue("keyword", keyword);

                }

                //=============================การขาย(ขั้นสูง)==============================
                else if (reportname == "rpt_sale_advance.rpt")
                {
                    //Response.Write("<a href href='../rpt_sale.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    string pro_size_code = Request.QueryString["pro_size_code"];
                    string pro_code = Request.QueryString["pro_code"];
                    string cus_code = Request.QueryString["cus_code"];
                    string sale_type = Request.QueryString["sale_type"];
                    string doc_type = Request.QueryString["doc_type"];
                    string report_type = Request.QueryString["report_type"];
                    string keyword = Request.QueryString["keyword"];

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("keyword", keyword);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_code);
                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("cus_code", cus_code);
                    rpt.SetParameterValue("sale_type", sale_type);
                    rpt.SetParameterValue("doc_type", doc_type);
                    rpt.SetParameterValue("report_type", report_type);
                    rpt.SetParameterValue("branch_no", branch_no);
                }
                //=============================การวิเคราะห์ขายตามยี่ห้อ(ขั้นสูง)==============================
                else if (reportname == "rpt_brand_advance.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    string keyword = Request.QueryString["keyword"];
                    string sale_type = Request.QueryString["sale_type"];


                    //Response.Write ("<a href='../rpt_brand.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");


                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("keyword", keyword);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("sale_type", sale_type);

                }
                //=====================================รายงานยอดกขายตามงรุ่นสินค้า(ขั้นสูง)==============================================
                else if (reportname == "rpt_model_advance.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    string keyword = Request.QueryString["keyword"];
                    string sale_type = Request.QueryString["sale_type"];

                    //Response.Write ("<a href='../rpt_model.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("keyword", keyword);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("sale_type", sale_type);

                }
                //=====================================รายงานยอดขายตามขนาดสินค้า(ขั้นสูง)==============================================
                else if (reportname == "rpt_size_advance.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    string pro_size_code = Request.QueryString["pro_size_code"];
                    string keyword = Request.QueryString["keyword"];

                    //Response.Write ("<a href='../rpt_size.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("keyword", keyword);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_code", pro_size_code);

                }
                //===================================== รายงานวิเคราะห์กำไรขาดทุน(ขั้นสูง) ==============================================
                else if (reportname == "rpt_profit_advance.rpt")
                {

                    //Response.Write("<a href href='../report_back.asp?url_back=rpt_profit.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../report_back.asp?url_back=posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    string start_date = Request["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string pro_size_name = Request["pro_size_name"];
                    string pro_code = Request["pro_code"];
                    string vat_product = Request["vat_product"];
                    string keyword = Request["keyword"];
                    string bill_novat_status = Request["bill_novat_status"];


                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("keyword", keyword);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_name", pro_size_name);
                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("vat_product", vat_product);
                    rpt.SetParameterValue("bill_novat_status", bill_novat_status);
                }
                //=======================================รายงานความเคลื่อนไหว Vat Balance ================================================
                else if (reportname == "rpt_vat_balance_movement.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    string pro_code = Request.QueryString["search_pro_code"];
                    string pro_size_name = Request.QueryString["pro_size_name"];
                    //string show_vat_zero = Request.QueryString["show_vat_zero"];
                    string show_vat = Request.QueryString["show_vat"];
                    //string show_all = Request.QueryString["show_all"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_name", pro_size_name);
                    //rpt.SetParameterValue("show_vat_zero", show_vat_zero);
                    rpt.SetParameterValue("show_vat", show_vat);
                    //rpt.SetParameterValue("show_all", show_all);
                }
                else if (reportname == "rpt_vat_balance_movement_not_zero.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    string pro_code = Request.QueryString["search_pro_code"];
                    string pro_size_name = Request.QueryString["pro_size_name"];
                    //string show_vat_zero = Request.QueryString["show_vat_zero"];
                    string show_vat = Request.QueryString["show_vat"];
                    //string show_all = Request.QueryString["show_all"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_name", pro_size_name);
                    //rpt.SetParameterValue("show_vat_zero", show_vat_zero);
                    rpt.SetParameterValue("show_vat", show_vat);
                    //rpt.SetParameterValue("show_all", show_all);
                }
                //=====================================รายงานรายวันรับ==============================================
                else if (reportname == "rpt_receive_day.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    string Cus_Code = Request.QueryString["Cus_Code"];
                    //Response.Write ("<a href='../rpt_tax_sale.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write ("<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("Cus_Code", Cus_Code);
                }
                //============================================================================================
                //=============================รายงานวิเคราะห์การติดตามผล=============================
                else if (reportname == "rpt_satisfaction_anlysis.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    //Response.Write("<a href href='../rpt_comment.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                }
                //=====================================รูปแบบเช็คธนาคารยูโอบี==============================================
                else if (reportname == "rpt_chq_uob.rpt")
                {
                    string doc_no_run = Request.QueryString["doc_no_run"];
                    string bank_code = Request.QueryString["bank_code"];

                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("doc_no_run", doc_no_run);
                    rpt.SetParameterValue("bank_code", bank_code);
                }
                //=====================================รูปแบบเช็คธนาคารกรุงเทพ==============================================
                else if (reportname == "rpt_chq_bbl.rpt")
                {
                    string doc_no_run = Request.QueryString["doc_no_run"];
                    string bank_code = Request.QueryString["bank_code"];

                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("doc_no_run", doc_no_run);
                    rpt.SetParameterValue("bank_code", bank_code);
                }
                //=====================================รูปแบบเช็คธนาคารไทยพาณิชย์==============================================
                else if (reportname == "rpt_chq_scb.rpt")
                {
                    string doc_no_run = Request.QueryString["doc_no_run"];
                    string bank_code = Request.QueryString["bank_code"];

                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("doc_no_run", doc_no_run);
                    rpt.SetParameterValue("bank_code", bank_code);
                }
                //=====================================รายงานสรุปรายการภาษีเงินได้ถูกหัก ณ ที่จ่าย==============================================
                else if (reportname == "rpt_vat3.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                }
                //=====================================รายงานการตรวจสอบจำนวนสินค้าก่อนรับเข้า==============================================
                else if (reportname == "rpt_check_before_ini.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string pro_code = Request.QueryString["pro_code"];
                    string pro_size_name = Request.QueryString["pro_size_name"];

                    //Response.Write("<a href href='../rpt_Product.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("pro_code", pro_code);
                    rpt.SetParameterValue("progroup_code", progroup_code);
                    rpt.SetParameterValue("pro_brand_code", pro_brand_code);
                    rpt.SetParameterValue("pro_model_code", pro_model_code);
                    rpt.SetParameterValue("pro_size_name", pro_size_name);
                }
                //=====================================รายงานใบส่งคืนสินค้า==============================================
                else if (reportname == "rpt_pcn.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string start_date_used = "";
                    string[] DateCom1 = start_date.Split('/');
                    if (DateCom1.Length == 3)
                    {
                        start_date_used = DateCom1[2] + DateCom1[1] + DateCom1[0];
                    }
                    string end_date = Request.QueryString["end_date"];
                    string end_date_used = "";
                    String[] DateCom2 = end_date.Split('/');
                    if (DateCom2.Length == 3)
                    {
                        end_date_used = DateCom2[2] + DateCom2[1] + DateCom2[0];
                    }
                    string ven_code = Request.QueryString["ven_code"];

                    //Response.Write("<a href href='../rpt_ap_add.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write("<a href href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                    rpt.SetParameterValue("sdate", start_date_used);
                    rpt.SetParameterValue("edate", end_date_used);
                    rpt.SetParameterValue("ven_code", ven_code);
                }
                //=====================================ใบหักภาษี ณ ที่จ่าย==============================================
                else if (reportname == "rpt_wth.rpt")
                {
                    rpt.SetParameterValue("doc_no", doc_no);
                }
                //=====================================ใบปะหน้า ภ.ง.ด.1==============================================
                else if (reportname == "rpt_PND1.rpt")
                {
                    string smonth = Request.QueryString["smonth"];
                    string syear = Request.QueryString["syear"];

                    rpt.SetParameterValue("smonth", smonth);
                    rpt.SetParameterValue("syear", syear);
                }
                //=====================================ใบแนบ ภ.ง.ด.1==============================================
                else if (reportname == "rpt_PND1at.rpt")
                {
                    string smonth = Request.QueryString["smonth"];
                    string syear = Request.QueryString["syear"];

                    rpt.SetParameterValue("smonth", smonth);
                    rpt.SetParameterValue("syear", syear);
                }
                //=====================================ใบปะหน้า ภ.ง.ด.2==============================================
                else if (reportname == "rpt_PND2.rpt")
                {
                    string smonth = Request.QueryString["smonth"];
                    string syear = Request.QueryString["syear"];

                    rpt.SetParameterValue("smonth", smonth);
                    rpt.SetParameterValue("syear", syear);
                }
                //=====================================ใบแนบ ภ.ง.ด.2==============================================
                else if (reportname == "rpt_PND2at.rpt")
                {
                    string smonth = Request.QueryString["smonth"];
                    string syear = Request.QueryString["syear"];

                    rpt.SetParameterValue("smonth", smonth);
                    rpt.SetParameterValue("syear", syear);
                }
                //=====================================ใบปะหน้า ภ.ง.ด.3==============================================
                else if (reportname == "rpt_PND3.rpt")
                {
                    string smonth = Request.QueryString["smonth"];
                    string syear = Request.QueryString["syear"];

                    rpt.SetParameterValue("smonth", smonth);
                    rpt.SetParameterValue("syear", syear);
                }
                //=====================================ใบแนบ ภ.ง.ด.3==============================================
                else if (reportname == "rpt_PND3at.rpt")
                {
                    string smonth = Request.QueryString["smonth"];
                    string syear = Request.QueryString["syear"];

                    rpt.SetParameterValue("smonth", smonth);
                    rpt.SetParameterValue("syear", syear);
                }
                //=====================================ใบปะหน้า ภ.ง.ด.53==============================================
                else if (reportname == "rpt_PND53.rpt")
                {
                    string smonth = Request.QueryString["smonth"];
                    string syear = Request.QueryString["syear"];

                    rpt.SetParameterValue("smonth", smonth);
                    rpt.SetParameterValue("syear", syear);
                }
                //=====================================ใบแนบ ภ.ง.ด.53==============================================
                else if (reportname == "rpt_PND53at.rpt")
                {
                    string smonth = Request.QueryString["smonth"];
                    string syear = Request.QueryString["syear"];

                    rpt.SetParameterValue("smonth", smonth);
                    rpt.SetParameterValue("syear", syear);
                }
                //=====================================ใบปะหน้า ภ.ง.ด.54==============================================
                else if (reportname == "rpt_PND54.rpt")
                {
                    string smonth = Request.QueryString["smonth"];
                    string syear = Request.QueryString["syear"];

                    rpt.SetParameterValue("smonth", smonth);
                    rpt.SetParameterValue("syear", syear);
                }
                //=====================================ใบแนบ ภ.ง.ด.54==============================================
                else if (reportname == "rpt_PND54at.rpt")
                {
                    string smonth = Request.QueryString["smonth"];
                    string syear = Request.QueryString["syear"];

                    rpt.SetParameterValue("smonth", smonth);
                    rpt.SetParameterValue("syear", syear);
                }
                //=====================================ใบปะหน้า ภ.ง.ด.1ก==============================================
                else if (reportname == "rpt_PND1A.rpt")
                {
                    string syear = Request.QueryString["syear"];

                    rpt.SetParameterValue("syear", syear);
                }
                //=====================================ใบแนบ ภ.ง.ด.1ก==============================================
                else if (reportname == "rpt_PND1Aat.rpt")
                {
                    string syear = Request.QueryString["syear"];

                    rpt.SetParameterValue("syear", syear);
                }
                //=====================================ใบปะหน้า ภ.ง.ด.2ก==============================================
                else if (reportname == "rpt_PND2A.rpt")
                {
                    string syear = Request.QueryString["syear"];

                    rpt.SetParameterValue("syear", syear);
                }
                //=====================================ใบแนบ ภ.ง.ด.2ก==============================================
                else if (reportname == "rpt_PND2Aat.rpt")
                {
                    string syear = Request.QueryString["syear"];

                    rpt.SetParameterValue("syear", syear);
                }
                //=====================================ใบปะหน้า ภ.ง.ด.3ก==============================================
                else if (reportname == "rpt_PND3A.rpt")
                {
                    string syear = Request.QueryString["syear"];

                    rpt.SetParameterValue("syear", syear);
                }
                //=====================================ใบแนบ ภ.ง.ด.3ก==============================================
                else if (reportname == "rpt_PND3Aat.rpt")
                {
                    string syear = Request.QueryString["syear"];

                    rpt.SetParameterValue("syear", syear);
                }
                else if (reportname == "abb.rpt")
                {
                    string prn_prodetail = Request.QueryString["prn_prodetail"];
                    string prn_car_reg = Request.QueryString["prn_car_reg"];
                    string prn_procode = Request.QueryString["prn_procode"];
                    string prn_pay_type = Request.QueryString["prn_pay_type"];
                    //Response.Write( "<a href='../rt_inv_list.asp' align='CENTER'> <img src='btn_newsale.gif' width='65' height='20' border='0'> </a>");
                    //Response.Write( "<a href='../posmain.asp' align='CENTER'> <img src='btn_backmenu.gif' width='65' height='20' border='0'></a>");

                    try
                    {
                        var rptToPrinter = new ReportClass(); ;
                        rptToPrinter.Load(Server.MapPath(reportname));
                        rptToPrinter.SetParameterValue("doc_no", doc_no);
                        rptToPrinter.SetParameterValue("thaibaht", thaibaht);
                        rptToPrinter.SetParameterValue("branch_no", branch_no);
                        rptToPrinter.SetParameterValue("prn_prodetail", prn_prodetail);
                        rptToPrinter.SetParameterValue("prn_procode", prn_procode);
                        rptToPrinter.SetParameterValue("prn_car_reg", prn_car_reg);
                        rptToPrinter.SetParameterValue("prn_pay_type", prn_pay_type);
                        rptToPrinter.PrintOptions.PrinterName = "EPSON TM-T88IV Receipt";
                        // rptToPrinter.PrintToPrinter(1, false, 0, 0);
                        rptToPrinter.PrintToPrinter(1, false, 0, 0);
                        rptToPrinter.Close();
                        rptToPrinter.Dispose();

                    }
                    catch (Exception ex)
                    {

                    }
                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("prn_prodetail", prn_prodetail);
                    rpt.SetParameterValue("prn_procode", prn_procode);
                    rpt.SetParameterValue("prn_car_reg", prn_car_reg);
                    rpt.SetParameterValue("prn_pay_type", prn_pay_type);
                }
                else if (reportname == "gen_wifi.rpt")
                {

                    string hash_wifi = Request.QueryString["hash_wifi"];
                    string datenow = Request.QueryString["print_time"];
                    var rptToPrinter = new ReportDocument(); ;
                    rptToPrinter.Load(Server.MapPath(reportname));
                    rptToPrinter.SetParameterValue("hash_wifi", hash_wifi);
                    rptToPrinter.SetParameterValue("datenow", datenow);
                    rptToPrinter.PrintOptions.PrinterName = "EPSON TM-T88IV Receipt";
                    rptToPrinter.PrintToPrinter(1, false, 0, 0);
                    rptToPrinter.Close();
                    rptToPrinter.Dispose();



                    rpt.SetParameterValue("hash_wifi", hash_wifi);
                    rpt.SetParameterValue("datenow", datenow);
                }
                else if (reportname == "rpt_dayend.rpt")
                {
                    string start_date = Request.QueryString["start_date"];
                    string end_date = Request.QueryString["end_date"];
                    rpt.SetParameterValue("fdate", start_date);
                    rpt.SetParameterValue("tdate", end_date);
                }
                else if (reportname == "day_end_once.rpt")
                {
                    string total = Request.QueryString["total"];

                    rpt.SetParameterValue("doc_no", doc_no);
                    rpt.SetParameterValue("thaibaht", thaibaht);
                    rpt.SetParameterValue("branch_no", branch_no);
                    rpt.SetParameterValue("total", total);
                }
#endregion
                //   Session["reportname"] = reportname.Replace(".rpt", "") + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
          

                var stream = rpt.ExportToStream(ExportFormatType.PortableDocFormat);

                return File(stream, "application/pdf");

            }


            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                rpt.Close();
                rpt.Dispose();
            }
        }


        public ActionResult PrintReport(ReportModels model)
        {
            
             var rpt = new ReportClass();
         
            try
            {
                var printer_slip_default = _db.SB_System.FirstOrDefault()?.printer_slip_default;
                var _reportName = "redeem.rpt";
                rpt.FileName = (Server.MapPath("~/report/" + "redeem.rpt"));
                rpt.Load();
                if (_reportName == "redeem.rpt") {

                    rpt.SetParameterValue("doc_no", model?.doc_no??"");
                  //  rpt.SetParameterValue("thaibaht", model?.thaibaht??"");
                   // rpt.SetParameterValue("branch_no", model?.branch_no??"");
                   // rpt.SetParameterValue("prn_prodetail", model?.prn_prodetail??"");
                   // rpt.SetParameterValue("prn_procode", model?.prn_procode??"");
                  //  rpt.SetParameterValue("prn_car_reg", model?.prn_car_reg??"");
                  //  rpt.SetParameterValue("prn_pay_type", model?.prn_pay_type??"");
                   rpt.PrintOptions.PrinterName = printer_slip_default;

                    rpt.PrintToPrinter(1, false, 0, 0);

                   // rpt.Close();
                  //  rpt.Dispose();
                }

                //   var stream = rpt.ExportToStream(ExportFormatType.PortableDocFormat);
                //  return File(stream, "application/pdf");
                return Json(new {success=true ,message="" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                rpt.Close();
                rpt.Dispose();
            }
        }
    }


}


