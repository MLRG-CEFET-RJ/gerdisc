using System;
using System.Collections.Generic;
using System.ComponentModel.ModelsAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gerdisc.Models.Entities
{
    public record BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}