using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patika_HwFirstWeek.Models
{
    public class BaseModel
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Create time is required.")]
        public DateTime CreateTime { get; set; }

        [Required(ErrorMessage = "Update time is required.")]
        public DateTime UpdateTime { get; set; }
    }
}