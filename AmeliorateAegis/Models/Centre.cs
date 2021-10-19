using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Models
{
    [Table("Centres")]
    public class Centre
    {
        [Key]
        public long Id { get; set; }
        public DateTime CreationTime { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public Centre()
        {
            CreationTime = DateTime.Now;
        }
    }
}
