using System;
using VirtualAssessment.Common.Interface;

namespace VirtualAssessment.Common
{
    public class DateTimeProvider:IDateTimeProvider
    {
        public DateTime GetDateTimeNow()
        {
            return DateTime.Now;
        }
    }
}