using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR.Tables.Tables
{
    public class Mobile_Message
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TSuppId { get; set; }
        public int? Emp_Id { get; set; }
        public DateTime? TrDate { get; set; }
        public string Message { get; set; }
    }
}


//MessageId int identity(1,1) primary key,
//Emp_Id int ,
//TrDate datetime2,

//[Message] nvarchar(max)