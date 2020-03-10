﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetManager.Models
{
    class Budget
    {
        public string Amount { get; set; }
        public string Filename { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
    }
}
