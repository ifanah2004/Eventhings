﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventhings.Dto
{
    public partial class LoginDto
    {
        public string email { get; set; }
        public string password_hash { get; set; }
        public bool keep_me_signin { get; set; } = false;
    }
}