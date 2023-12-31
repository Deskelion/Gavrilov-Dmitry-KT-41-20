﻿using System.Text.RegularExpressions;

namespace GavrilovDmitryKT_41_20.Models
{
    public class Subject
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Type { get; set; }

        public int TotalTime { get; set; }

        public bool IsValidSubjectTitle()
        {
            return Regex.Match(Title, @"^[^\d]*$").Success;
        }
    }
}
