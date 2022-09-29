using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Batch17_WebApp.Models
{
    public class ReturnModel
    {
        [EnumDataType(typeof(Status))]
        public string Status { get; set; }
        public string Message { get; set; }
        public object Model { get; set; }
    }
    public enum ReturnStatus
    {
        success,
        failed,
        NoData,
        dataIssue,
        serverFailed,
        error
    }
}
