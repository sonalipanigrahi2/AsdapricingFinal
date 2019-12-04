using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsdaPricingAdministrationTool.Models;
using System.Collections;
using Newtonsoft.Json;
using System.Dynamic;

namespace AsdaPricingAdministrationTool.Controllers
{
    public class DeliveryStatusController : Controller
    {

        public AsdaPriceContext _context { get; set; }

        public DeliveryStatusController(AsdaPriceContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public IActionResult DeliveryStatus()
        {
            List<Delivery_Status> Data = new List<Delivery_Status>();
            Data = _context.Delivery_Status.FromSql("SELECT Top 1 * FROM ops.Delivery_Status order by TaskOrder").ToList();
            ViewBag.Data = Data[0].Delivery;
            return View(_context.Delivery_Status.FromSql("SELECT * FROM ops.Delivery_Status order by TaskOrder").ToList());
        }
        [HttpGet("[action]")]
        public IActionResult DeliveryStatusHistory()
        {
            //return View(_context.Delivery_Status_History.ToList());
            List<Delivery_Status_History> HistoryData = new List<Delivery_Status_History>();
            //return View(_context.Delivery_Status_History.ToList());

            //HistoryData = _context.Delivery_Status_History.FromSql("select * from [ops].[Delivery_Status_History] order by Delivery Desc,Taskorder Asc").ToList();
            return View(_context.Delivery_Status_History.FromSql("select * from [ops].[Delivery_Status_History] order by cast(RIGHT(Delivery,LEN(Delivery)-4) AS smalldatetime) Desc,Taskorder Asc").ToList());
        }
        [HttpGet("[action]")]
        public IActionResult JobEx()
        {
            //return View(_context.Delivery_Status_History.ToList());
            return View();
        }
        [HttpGet("[action]")]
        public IActionResult Settings(string Paramval = null, int? id = null, int update = 0)

        {
            string val = Paramval;
            Int32? idval = id;
            if (id == null && update == 0)
            {
                return View(_context.Parameters.ToList());
            }
            else if (id == null && update == 1)
            {

                return NotFound();
            }
            else
            {

                var commandText = "UPDATE ops.parameters SET ParamValue=@value WHERE PID=@id";
                var value = new SqlParameter("@value", val);
                var idvalue = new SqlParameter("@id", idval);
                _context.Database.ExecuteSqlCommand(commandText, value, idvalue);


            }
            return RedirectToAction(nameof(Settings));
        }
        public List<FIELDMASTER> GetFieldQC()
        {
            List<FIELDMASTER> FIELDMASTERQC = new List<FIELDMASTER>();
            FIELDMASTERQC = _context.FIELDMASTER.FromSql("select * from [QC].[FIELD_MASTER] order by Retailer asc,[IRI Week] asc").ToList();
            return FIELDMASTERQC;

        }
        public List<MARKETVOLUMES> GetMARKETVOLUMEQC()
        {
            List<MARKETVOLUMES> MARKETVOLUMESQC = new List<MARKETVOLUMES>();
            MARKETVOLUMESQC = _context.MARKETVOLUMES.FromSql("select * from [QC].[MARKET_VOLUMES] order by Retailer asc,[Collection Date] asc").ToList();
            return MARKETVOLUMESQC;

        }
        public List<NETVIDEMAPPINGPART1> GetNETVIDEMAPPINGPART1QC()
        {
            List<NETVIDEMAPPINGPART1> NETVIDEMAPPINGPART1QC = new List<NETVIDEMAPPINGPART1>();
            NETVIDEMAPPINGPART1QC = _context.NETVIDEMAPPINGPART1.FromSql("select * from [QC].[NETVIDE_MAPPING_PART1] order by Retailer ,[Batch ID]").ToList();
            return NETVIDEMAPPINGPART1QC;

        }
        public List<NETVIDEMAPPINGPART2> GetNETVIDEMAPPINGPART2QC()
        {
            List<NETVIDEMAPPINGPART2> GETNETVIDEMAPPINGPART2QC = new List<NETVIDEMAPPINGPART2>();
            GETNETVIDEMAPPINGPART2QC = _context.NETVIDEMAPPINGPART2.FromSql("select * from [QC].[NETVIDE_MAPPING_PART2] order by Retailer ,[Batch ID],[Collection Date] asc").ToList();
            return GETNETVIDEMAPPINGPART2QC;
        }
        [HttpGet("[action]")]
        public IActionResult QCPage()

        {
            dynamic mymodel = new ExpandoObject();
            mymodel.FIELDMASTERQC = GetFieldQC();
            mymodel.MARKETVOLUMESQC = GetMARKETVOLUMEQC();
            mymodel.NETVIDEMAPPINGPART1QC = GetNETVIDEMAPPINGPART1QC();
            mymodel.GETNETVIDEMAPPINGPART2QC = GetNETVIDEMAPPINGPART2QC();
            return View(mymodel);
        }
    }

}




