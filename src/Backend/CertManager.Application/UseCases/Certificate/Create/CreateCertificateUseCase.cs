using System;
using System.Collections.Generic;
using CertManager.Communications.Requests;
using CertManager.Communications.Responses;


namespace CertManager.Application.UseCases.Certificate.Create
{
    // Ensure CreateCertificateUseCase implements ICreateCertificateUseCase
    public class CreateCertificateUseCase : ICreateCertificateUseCase
    {
        public CreateCertificateUseCase() { 
            
        }

        public async Task<ResponseCreateCertificateJson> Execute(RequestCreateCertificateJson request)
        {
            // Validar

            // Mandar alguém criar CSR

            // Mandar alguém assinar
            
            // Mandar alguém salvar no Vault
            
        }

        private async Task Validate(RequestCreateCertificateJson request) { 
            var validator = new CreateCertificateValidator();

            var result = validator.Validate(request);

            var vaultExists = await VaultExists(request.VaultName);
            
            if (!vaultExists) {
                result.Errors.Add(new FluentValidation.Results.ValidationFailure("VaultName", "Vault does not exist"));
            }

            if (result.IsValid == false) {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
