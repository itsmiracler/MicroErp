using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.TimeTracking.Web.Areas.TaskManagement.Models.Task
{
    public class AddModel
    {
        [Required]
        public string Name { get; set; }
    }
}
