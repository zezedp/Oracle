using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertManager.Application.Interfaces.Services.Azure
{
    public interface ICreateCSR
    {
        Task<string> GenerateCSR();

    }
}
