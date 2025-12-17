using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CertManager.Communications.Requests;
using CertManager.Communications.Responses;

namespace CertManager.Application.UseCases.Certificate.Create
{
    public interface ICreateCertificateUseCase
    {
        public Task<ResponseCreateCertificateJson> Execute(RequestCreateCertificateJson request);
    }
}
