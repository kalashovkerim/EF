using System;
using System.Collections.Generic;

namespace EFhw
{
    public partial class Info
    {
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string? Color { get; set; }
        public int? Calories { get; set; }
    }
}
