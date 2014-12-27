using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCrm.DTO
{
    public class CustomerImportDto
    {
        //,投保人,投保人生日,被保人,被保人生日,保单号码,保单生效日,主险名称,期交保费,联系电话,保单状态,孤儿单,地址,备注
        [CsvLineNumber]
        public int SeqNo { get; set; }
        [CsvPosition("投保人")]
        public String PolicyHolder { get; set; }
        [CsvPosition("投保人生日")]
        public DateTime? PolicyHolderBirthday { get; set; }
        [CsvPosition("被保人")]
        public String Insured { get; set; }
        [CsvPosition("被保人生日")]
        public DateTime? InsuredBirthday { get; set; }
        [CsvPosition("保单号码")]
        public String InsurancePolicyNo { get; set; }
        [CsvPosition("保单生效日")]
        public DateTime IPEffectiveDate { get; set; }
        [CsvPosition("主险名称")]
        public String PrimaryIPName { get; set; }
        [CsvPosition("期交保费")]
        public Decimal Premium { get; set; }
        [CsvPosition("联系电话", Required = false)]
        public String Telephone { get; set; }
        [CsvPosition("保单状态")]
        public String IPStatus { get; set; }
        [CsvPosition("孤儿单")]
        public String IsOrphan { get; set; }
        //[CsvPosition(12)]
        public String Address { get; set; }
        //[CsvPosition(13)]
        public String Remark { get; set; }


        public string ImportStatus { get; set; }

        public static string SUCCESS = "导入成功";
        public static string SKIPPED = "跳过";
    }
}
