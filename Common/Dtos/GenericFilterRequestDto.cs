using Common.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dtos
{
    public class GenericFilterRequestDto
    {
        public object? Value { get; set; }

        [DefaultValue(FilterType.contains)]
        public FilterType FilterType { get; set; }

        public string? PropertyName { get; set; }
        public string? SearchString { get; set; }
    }
}
