using System;

namespace SEP2020.Models
{
    internal class UniqueAttribute : Attribute
    {
        public string ErrorMessage { get; set; }
    }
}