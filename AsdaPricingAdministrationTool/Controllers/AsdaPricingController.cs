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
            return View(_context.Delivery_Status_History.FromSql("select * from [ops].[Delivery_Status_History] order by Delivery Desc,Taskorder Asc").ToList());
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
                
                    var commandText ="UPDATE ops.parameters SET ParamValue=@value WHERE PID=@id";
                    var value = new SqlParameter("@value", val);
                    var idvalue = new SqlParameter("@id", idval);
                    _context.Database.ExecuteSqlCommand(commandText, value, idvalue);
                

            }
            return RedirectToAction(nameof(Settings));
        }


    }

}




