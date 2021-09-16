using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Eventhings.DbContexts
{
    [Table("tmstrcodestore")]
    public class tmstrcodestore
    {
        public int id { get; set; }

        [Required]
        [StringLength(128)]
        public string batch_number { get; set; }

        [Required]
        [StringLength(128)]
        public string batcg_name { get; set; }

        [Required]
        [StringLength(128)]
        public string code { get; set; }

        public int? encrypted_code { get; set; }

        public int active { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? date_used { get; set; }

        public int is_deleted { get; set; }

        [StringLength(128)]
        public string created_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? created_at { get; set; }

        [StringLength(128)]
        public string updated_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? updated_at { get; set; }
    }
}
