using System;
using System.Threading.Tasks;

namespace UnilogTransports.Graylog
{
    public interface IGELFClient : IDisposable
    {
        Task SendMessageAsync(GELFMessage message);
    }
}