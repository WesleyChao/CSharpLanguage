using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{
    [AttributeUsage(AttributeTargets.Property)]
    public class StringLengthAttribute : Attribute
    {
        public int MaximumLength { get; set; }
        public string Desc { get; set; }

    }
}
