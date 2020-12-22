using System.Web.Optimization;

namespace newHQ
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/login/css").Include(
                      "~/Content/login.css"));
            bundles.Add(new ScriptBundle("~/bundles/login/js").Include(
                      "~/Scripts/login.js"));
            bundles.Add(new ScriptBundle("~/bundles/sendclient").Include(
                  "~/Scripts/transpiled/sendclient/index.js"));
            #region Global

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/admin-lte/js").Include(
                        "~/admin-lte/js/adminlte.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/moment.min.js",
                        "~/node_modules/utf-8/utf-8.js",
                        "~/Scripts/autoNumeric/autoNumeric.js",
                        "~/Scripts/transpiled/tools.js",
                        "~/node_modules/sweetalert/dist/sweetalert.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables-script").Include(
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/dataTables.bootstrap4.js",
                        "~/Scripts/DataTables/dataTables.buttons.js",
                        "~/Scripts/DataTables/buttons.bootstrap4.js",
                        "~/Scripts/DataTables/buttons.html5.js",
                        "~/Scripts/DataTables/dataTables.fixedHeader.min.js",
                        "~/Scripts/DataTables/dataTables.responsive.min.js",
                        "~/Scripts/DataTables/responsive.bootstrap4.min.js"));

            bundles.Add(new StyleBundle("~/Content/datatables-style").Include(
                        "~/Content/Datatables/css/dataTables.bootstrap4.min.css",
                        "~/Content/Datatables/css/buttons.bootstrap4.min.css",
                        "~/Content/Datatables/css/fixedHeader.bootstrap.min.css",
                        "~/Content/Datatables/css/responsive.bootstrap4.min.css"));

            bundles.Add(new StyleBundle("~/bundles/admin/form").Include(
                        "~/node_modules/cleave.js/dist/cleave.min.js",
                        "~/node_modules/cleave.js/dist/addons/cleave-phone.th.js",
                        "~/Scripts/transpiled/base-form.js"
                        ));
            #endregion

            #region Layout

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.12.4.js",
                        "~/Scripts/jquery.redirect.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.min.css",
                        "~/Content/font-awesome.min.css",
                        "~/admin-lte/css/AdminLTE.min.css",
                        "~/admin-lte/css/skins/skin-blue.min.css",
                        "~/Content/site.css"));

            #endregion

            #region Layout Admin

            bundles.Add(new ScriptBundle("~/bundles/admin/jquery").Include(
                        "~/Scripts/jquery-3.3.1.js",
                        "~/Scripts/jquery.redirect.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin/bootstrap").Include(
                        "~/Scripts/admin/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin/js").Include(
                        "~/Scripts/select2-4.0.6/js/select2.min.js",
                        "~/node_modules/cleave.js/dist/cleave.min.js",
                        "~/Scripts/bootstrap-datepicker-1.9.0/bootstrap-datepicker.js",
                        "~/Scripts/datetimepicker/bootstrap-datetimepicker.js",
                        "~/Scripts/bootstrap-validator/validator.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/admin/css").Include(
                        //"~/Content/bootstrap.min.css",
                        "~/Content/font-awesome.min.css",
                        "~/admin-lte/css/AdminLTE.min.css",
                        "~/admin-lte/css/skins/skin-blue.min.css",
                        "~/Content/site.css",
                        "~/Content/vendors/bootstrap.min.css",
                        "~/Content/sb-admin.css",
                        "~/Content/vendors/bootstrap-datepicker-1.9.0/bootstrap-datepicker.css",
                        "~/Content/vendors/datetimepicker/bootstrap-datetimepicker.css",
                        "~/Content/bootstrap-radio.css",
                        "~/Content/vendors/select2-4.0.6/css/select2.css",
                        "~/Content/vendors/select2-bootstrap/select2-bootstrap.css",
                        "~/Content/cos.css",
                        "~/Content/custom_cos.css"
                        ));
            #endregion           

            #region home
            bundles.Add(new ScriptBundle("~/bundles/dashboard").Include(
                    "~/Scripts/transpiled/index-form.js",
                    "~/Scripts/transpiled/dashboard/index.js",
                    "~/Scripts/transpiled/dashboard/message-modal.js"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/message").Include(
                    "~/Scripts/transpiled/index-form.js",
                    "~/Scripts/transpiled/message/index.js"
          ));
            bundles.Add(new ScriptBundle("~/bundles/message/form").Include(
                    "~/Scripts/ckeditor/ckeditor.js",
                    "~/Scripts/transpiled/message/form.js"
          ));
            #endregion

            #region ข้อมูลหลัก

            #region ทะเบียนลูกค้า
            #endregion

            #region ทะเบียนรถ PTTOR
            #endregion

            #region ทะเบียนผู้จำหน่าย
            #endregion

            #region ทะเบียนสินค้า
            #endregion

            #region กำหนดข้อมูลหลัก
            bundles.Add(new StyleBundle("~/Content/masterdata").Include(
                "~/Content/SetMasterDataMenu/metro-bootstrap.css",
                "~/Content/SetMasterDataMenu/ddown_menu.css",
                "~/Content/SetMasterDataMenu/tabcontent_customer.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/masterdata/index").Include(
                "~/Scripts/transpiled/masterdata/tabcontent.js",
                "~/Scripts/transpiled/masterdata/jdropdown_menu.js",
                "~/Scripts/transpiled/index-form.js",
                "~/Scripts/transpiled/masterdata/index.js"
            ));
            #endregion

            #region กำหนดข้อมูลแคมเปญ
            bundles.Add(new ScriptBundle("~/bundles/campaign/index").Include(
                        "~/Scripts/transpiled/index-form.js",
                        "~/Scripts/transpiled/masterdata/campaign/index.js",
                        "~/Scripts/transpiled/masterdata/campaign/campaign-index-ex.js"));
            bundles.Add(new ScriptBundle("~/bundles/campaign/create").Include(
                        "~/Scripts/transpiled/masterdata/campaign/create.js"));
            #endregion

            #region กำหนดข้อมูลโปรโมชั่น
            bundles.Add(new ScriptBundle("~/bundles/promotion/index").Include(
                        "~/Scripts/transpiled/index-form.js",
                        "~/Scripts/transpiled/masterdata/promotion/index.js",
                        "~/Scripts/transpiled/masterdata/promotion/promotion-index-ex.js"));

            bundles.Add(new ScriptBundle("~/bundles/promotion/create").Include(
                        "~/Scripts/transpiled/masterdata/promotion/promotion-create.js"));

            bundles.Add(new ScriptBundle("~/bundles/promotion/create/step3").Include(
                        "~/Scripts/transpiled/masterdata/promotion/promotion-create-step3.js"));
            #endregion

            #endregion

            #region ข้อมูลระบบ

            #region กำหนดข้อมูลสาขา
            bundles.Add(new ScriptBundle("~/bundles/branch/index").Include(
                "~/Scripts/transpiled/index-form.js",
                "~/Scripts/transpiled/systemdata/branch/index.js"));
            bundles.Add(new ScriptBundle("~/bundles/branch/create").Include(
                "~/Scripts/transpiled/systemdata/branch/create.js"
                ));
            #endregion

            #endregion

            #region ???

            bundles.Add(new StyleBundle("~/Content/daterangepicker").Include(
                      "~/node_modules/bootstrap-daterangepicker/daterangepicker.css"));

            bundles.Add(new StyleBundle("~/Content/payment").Include(
                       "~/Content/payment.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/daterangepicker").Include(
                      "~/node_modules/bootstrap-daterangepicker/daterangepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/payment").Include(
                  "~/node_modules/cleave.js/dist/cleave.min.js",
                  "~/Scripts/transpiled/payment/index.js",
                  "~/Scripts/transpiled/payment/cash-modal.js",
                  "~/Scripts/transpiled/payment/credit-edc-modal.js",
                  "~/Scripts/transpiled/payment/credit-card-modal.js",
                  "~/Scripts/transpiled/payment/deposit-modal.js",
                  "~/Scripts/transpiled/payment/deductible-modal.js",
                  "~/Scripts/transpiled/payment/blue-card-modal.js",
                  "~/Scripts/transpiled/payment/lazada-modal.js"));

            bundles.Add(new ScriptBundle("~/bundles/payment/list").Include(
                    "~/Scripts/transpiled/index-form.js",
                    "~/Scripts/transpiled/payment/list.js"));

            bundles.Add(new ScriptBundle("~/bundles/payment/extradiscount").Include(
                    "~/Scripts/transpiled/payment/extra-discount-form.js"));

            #endregion Script

            //BundleTable.EnableOptimizations = true;
        }
    }
}