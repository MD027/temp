﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment4.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Range(1, long.MaxValue, ErrorMessage = "Account Number cannot be neagative or Zero")]
        public int AccountNumber { get; set; }

        [StringLength(byte.MaxValue, MinimumLength = 2, ErrorMessage = "Minimum length must be 2")]
        [Required(ErrorMessage = "Name must be specified")]

        public string Name { get; set; }

        [Range(500, long.MaxValue, ErrorMessage = "Minimum balance must be 500")]

        public double CurrentBalance { get; set; }

    }
}