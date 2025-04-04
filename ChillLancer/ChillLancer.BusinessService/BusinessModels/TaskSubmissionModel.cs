using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillLancer.BusinessService.BusinessModels
{
    public class TaskSubmissionModel
    {
        public string? Link {get; set;}
        public string? Text {get; set;}
        public IFormFile? Image { get; set;}
    }
}
