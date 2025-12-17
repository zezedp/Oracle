using CertManager.Communications.Requests;
using FluentValidation;
using CertManager.Exceptions;
namespace CertManager.Application.UseCases.Certificate.Create
{
    public class CreateCertificateValidator : AbstractValidator<RequestCreateCertificateJson>
    {
        public CreateCertificateValidator() {
            // COMMON NAME
            RuleFor(cert => cert.CertificateName).NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);
            RuleFor(cert => cert.CertificateName).MinimumLength(2).WithMessage(ResourceMessagesException.NAME_MINLENGTH);
            RuleFor(cert => cert.CertificateName).MaximumLength(72).WithMessage(ResourceMessagesException.NAME_MAXLENGTH);
            RuleFor(cert => cert.CertificateName).Matches("^[A-Za-z][A-Za-z0-9-]*[A-Za-z]$").WithMessage(ResourceMessagesException.NAME_NOTMATCH);

            // DNS NAMES
            RuleFor(cert => cert.dnsNames).NotEmpty().WithMessage(ResourceMessagesException.DNS_EMPTY);
            RuleFor(cert => cert.dnsNames).Must(list => list.Count <= 5).WithMessage(ResourceMessagesException.DNS_MAXLIST);
            RuleForEach(cert => cert.dnsNames).Matches(@"^(\*\.)?([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,}$").WithMessage(ResourceMessagesException.DNS_NOTMATCH);
            RuleForEach(cert => cert.dnsNames).MinimumLength(2).WithMessage(ResourceMessagesException.DNS_MINLENGTH);
            RuleForEach(cert => cert.dnsNames).MaximumLength(72).WithMessage(ResourceMessagesException.DNS_MAXLENGTH);

            // DURATION IN MONTHS
            RuleFor(cert => cert.durationInMonths).GreaterThan(0).WithMessage(ResourceMessagesException.DURATION_MINMONTHS); 
            RuleFor(cert => cert.durationInMonths).LessThanOrEqualTo(24).WithMessage(ResourceMessagesException.DURATION_MAXMONTHS); 

            // VAULT NAME
            RuleFor(cert => cert.VaultName).NotEmpty().WithMessage(ResourceMessagesException.VAULT_EMPTY);
            RuleFor(cert => cert.VaultName).Length(3, 24).WithMessage(ResourceMessagesException.VAULT_LENGTH);
            RuleFor(cert => cert.VaultName).Matches("^[a-z][a-z0-9-]{1,22}[a-z0-9]$").WithMessage(ResourceMessagesException.VAULT_NOTMATCH);
        }
    }
}
