using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.Tables.Tables.HR
{
   public partial class HrMobileSetting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HrMobSetId { get; set; }
        public int DefPermReqBookId { get; set; }
        public int DefVacReqBookId { get; set; }
        public int DefLoanReqBookId { get; set; }
        public int TermId { get; set; }
    }
}
