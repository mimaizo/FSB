using fsb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FSB.Models
{
    public class ViewModel
    {
        public List<Docs>? FIO { get; set; }
        public SelectList? Types { get; set; }
        public string? DocTypes { get; set; }
        public string? SearchString { get; set; }
    }
}
