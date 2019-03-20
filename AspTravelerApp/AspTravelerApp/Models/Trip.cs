﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspTravelerApp.Models
{
    /// <summary>
    /// The topmost object that defines a planned trip
    /// </summary>
    public class Trip
    {
        public Trip()
        {
            Segments = new List<Segment>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<Segment> Segments { get; set; }
    }
}
