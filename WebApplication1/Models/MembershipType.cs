using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte DiscountRate { get; set; }
        public byte DurationInMonth { get; set; }
        public int Price { get; set; }

        public static readonly int Unknown = 0;
        public static readonly int Free = 1;

        //public enum MembershipTypeId
        //{
        //    Unknown=0,
        //    Free=1,
        //    Bronze=2,
        //    Silver=3,
        //    Gold=4
        //}
    }
}