using CentralService.Enums;
using CentralService.Injection;
using CentralService.Models;
using newHQ.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newHQ.Controllers
{
    public class MessageController : Controller
    {
        private IMessageService _service;

        public MessageController(IMessageService messageService)
        {
            _service = messageService;
        }

        // GET: Message
        public ActionResult Index(int docType)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            var model = new MessageViewModel
            {
                DocType = (MessageDocType)docType
            };
            return View(model);
        }

        public ActionResult GetDTResult(DTParameters dataTableRequestModel, int docType)
        {
            var model = _service.GetDTResult(dataTableRequestModel, docType);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create(int docType)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            MessageStatusDropDown();
            var model = new MessageViewModel
            {
                DocType = (MessageDocType)docType
            };
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(MessageViewModel model)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            FileUpload(model);
            if (string.IsNullOrWhiteSpace(model.Name) || string.IsNullOrWhiteSpace(model.DateRange))
            {
                MessageStatusDropDown();
                return View(model);
            }

            _service.Create(model);

            return RedirectToAction("Index", new { doctype = (int)model.DocType });

        }

        public ActionResult Edit(int id)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            var model = _service.Get(id);
            MessageStatusDropDown();
            var viewModel = new MessageViewModel()
            {
                Code = model.Code,
                Content = model.Content,
                DateRange = model.StartDate.ToString("dd/MM/yyyy") + " - " + model.EndDate.ToString("dd/MM/yyyy"),
                EndDate = model.EndDate,
                FileName = model.FileName,
                Id = model.Id,
                Name = model.Name,
                StartDate = model.StartDate,
                Status = model.Status,
                StatusName = model.StatusName,
                DocType = model.DocType
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(MessageViewModel model)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            if (string.IsNullOrWhiteSpace(model.Name) || string.IsNullOrWhiteSpace(model.DateRange))
            {
                MessageStatusDropDown();
                return View(model);
            }

            if (model.Files != null)
                FileUpload(model);
            _service.Update(model);

            return RedirectToAction("Index", new { doctype = (int)model.DocType });

        }

        private void MessageStatusDropDown()
        {
            var model = _service.GetMessageStatus();
            var list = new SelectList(model, "Id", "Name");
            ViewBag.MessageStatusDropDown = list;
        }

        public void FileUpload(MessageViewModel model)
        {
            if (model.Files == null) return;

            String FileExt = Path.GetExtension(model.Files.FileName).ToUpper();
            if (FileExt == ".PDF" || FileExt == ".JPG" || FileExt == ".PNG" || FileExt == ".GIF" || FileExt == ".JPEG" || FileExt == ".BMP")
            {
                //Stream str = model.Files.InputStream;
                //BinaryReader Br = new BinaryReader(str);
                //Byte[] FileDet = Br.ReadBytes((Int32)str.Length);
                //model.FileContent = FileDet;

                string path = Server.MapPath("~/Content/UploadPdfOfMessage/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                model.FileName = $"{model.Id}-{model.Name.Replace("%"," Percent ")}{FileExt}";
                model.Files.SaveAs(path + Path.GetFileName(model.FileName));

            }
        }
    }
}