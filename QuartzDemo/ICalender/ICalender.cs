using System;
using System.Collections.Generic;
using System.Text;

namespace QuartzDemo.ICalender
{
    public interface ICalender
    {
        string Description { get; set; }
        ICalender CalenderBase { get; set; }
    }
}
