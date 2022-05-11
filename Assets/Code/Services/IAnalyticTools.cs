using System.Collections.Generic;
namespace Services.Analytic
{
    public interface IAnalyticTools
    {
        void SendMessage(string alias,
                         IDictionary<string,
                         object> eventData = null);
    }
}