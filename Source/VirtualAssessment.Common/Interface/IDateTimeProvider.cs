using System;

namespace VirtualAssessment.Common.Interface
{
    public interface IDateTimeProvider
    {
        DateTime GetDateTimeNow();
        DateTime GetDateTimeToday();
    }
}