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
        public String SeqNo { get; set; }
        [CsvPosition(0)]
        public String PolicyHolder { get; set; }
        [CsvPosition(1)]
        public DateTime? PolicyHolderBirthday { get; set; }
        [CsvPosition(2)]
        public String Insured { get; set; }
        [CsvPosition(3)]
        public DateTime? InsuredBirthday { get; set; }
        [CsvPosition(4)]
        public String InsurancePolicyNo { get; set; }
        [CsvPosition(5)]
        public DateTime IPEffectiveDate { get; set; }
        [CsvPosition(6)]
        public String PrimaryIPName { get; set; }
        [CsvPosition(8)]
        public Decimal Premium { get; set; }
        [CsvPosition(9)]
        public String Telephone { get; set; }
        [CsvPosition(10)]
        public String IPStatus { get; set; }
        [CsvPosition(11)]
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
