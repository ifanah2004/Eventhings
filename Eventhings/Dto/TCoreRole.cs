﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deveventhings.DbEntities.DbEntities
{
    public partial class tcorerole
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(128)]
        public string name { get; set; }
        [StringLength(128)]
        public string description { get; set; }
        public int level { get; set; }
        public int active { get; set; }
        public int is_deleted { get; set; }
        [StringLength(128)]
        public string created_by { get; set; }
        [Column(TypeName = "datetime2(0)")]
        public DateTime? created_at { get; set; }
        [StringLength(128)]
        public string updated_by { get; set; }
        [Column(TypeName = "datetime2(0)")]
        public DateTime? updated_at { get; set; }

        [InverseProperty("role_")]
        public virtual tcoreuserrole tcoreuserrole { get; set; }
    }
}