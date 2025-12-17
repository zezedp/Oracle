using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertManager.Communications.Requests
{
    public class RequestCreateCertificateJson
    {
        public string CertificateName { get; set; } = string.Empty;
        public string VaultName { get; set; } = string.Empty;
        
        public List<string> dnsNames { get; set; } = new List<string>();

        public int durationInMonths { get; set; } = 0;

    }
}
