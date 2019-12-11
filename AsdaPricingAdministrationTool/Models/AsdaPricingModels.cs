using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsdaPricingAdministrationTool.Models
{
    [Table("Delivery_Status", Schema = "ops")]
    public class Delivery_Status
    {
     [Key]
     public Int16 TaskOrder { get; set; }
     public string Delivery { get; set; }
     public string TaskName { get; set; }
     public string TaskStatus { get; set; }
     public string TaskDesc { get; set; }
     [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:dd/MM/yyyy HH:mm:ss tt}")]
     public DateTime? DateTime { get; set; }
     public string TaskNotes { get; set; }
    }
    [Table("Parameters", Schema = "ops")]
    public class Parameters
    {
        [Key]
        public int PID { get; set; }
        public string ParamName { get; set; }
        public string ParamValue { get; set; }
        public string ParamDesc { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm:ss tt}")]
        public DateTime? DateTime { get; set; }
    }
    [Table("Delivery_Status_History", Schema = "ops")]
    public class Delivery_Status_History
    {
        
        public Int16 TaskOrder { get; set; }
        [Key]
        [Column(Order = 1)]
        public string Delivery { get; set; }
        [Key]
        [Column(Order = 2)]
        public string TaskName { get; set; }
        public string TaskStatus { get; set; }
        public string TaskDesc { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm:ss tt}")]
        public DateTime? DateTime { get; set; }
        public string TaskNotes { get; set; }
    }
    public class FIELDMASTER
    {
        [Key]
        [Column(Order = 1)]
        public string Retailer { get; set; }
        [Key]
        [Column("IRI Week",Order = 2)]
        public Int16 IRIWeek { get; set; }
        [Column("Valid Products")]
        public Int32 ValidProducts { get; set; }
    }
    public class MARKETVOLUMES
    {
        [Key]
        [Column(Order = 1)]
        public string Retailer { get; set; }
        [Column("Collection Date",Order =2)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CollectionDate { get; set; }
        [Column("Market Volume")]
        public int? MarketVolume { get; set; }
        [Column("Market Volume Total")]
        public int? MarketVolumeTotal { get; set; }
        [Column("Count of Estimated Market Volume")]
        public int? CountofEstimatedMarketVolume { get; set; }
        [Column("Valid Products")]
        public int? ValidProducts { get; set; }
        [Column("Lions Share Fails")]
        public int? LionsShareFails { get; set; }
    }
    public class NETVIDEMAPPINGPART1
    {
        [Key]
        [Column(Order = 1)]
        public string Retailer { get; set; }
        [Column("Batch ID",Order =2)]
        public Int16 BatchID { get; set; }
        [Column("File Name")]
        public string FileName { get; set; }
        [Column("Valid Products")]
        public int ValidProducts { get; set;}
    }
    public class NETVIDEMAPPINGPART2
    {
        [Key]
        [Column(Order = 1)]
        public string Retailer { get; set; }
        [Column("Batch ID",Order =2)]
        public Int32 BatchID { get; set; }
        [Column("Collection Date", Order = 3)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CollectionDate { get; set; }
        [Column("Valid Products")]
        public int ValidProducts { get; set; }
    }
    [Table("FIELD_PRODUCTS_ISSUES_REPORT_t", Schema = "csd")]
    public class FIELD_PRODUCTS_ISSUES_REPORT_t
    {
        [Key]
        [Column(Order = 1)]
        public DateTime Collection_Date { get; set; }
        [Column(Order = 2)]
        public Int16 IRI_Week { get; set; }
        [Column(Order = 3)]
        public string COMP_NAME { get; set; }
        public string DIRECTOR { get; set; }
        public string DIVISION { get; set; }
        public string DEPARTMENT { get; set; }
        public string MDSE_CATEGORY { get; set; }
        public string MDSE_SUBCATEGORY { get; set; }
        public string FINELINE { get; set; }
        [Column(Order = 4)]
        public string COMP_ITEM_EAN { get; set; }
        public string COMP_ITEM_DESC { get; set; }
        public decimal PREV_PRICE { get; set; }
        [MaxLength(2, ErrorMessage = "please enter value up to 2 decimal places.")]
        public decimal CUR_PRICE { get; set; }
        [Column("% PRICE CHANGE")]
        public decimal PER_PRICE_CHANGE { get; set; }
        [MaxLength(2, ErrorMessage = "please enter value up to 2 decimal places.")]
        public decimal? CUR_LINKSAVE_PRICE { get; set; }
        public Byte CORRECTED { get; set; }
        public Byte EXCLUDED { get; set; }
    }
}





