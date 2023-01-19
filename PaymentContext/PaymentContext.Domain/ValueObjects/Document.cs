using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType documentType)
        {
            Number = number;
            DocumentType = documentType;

            AddNotifications(new Contract<Document>()
                .Requires()
                .IsTrue(IsNumberValid(), "Document.Number", "Document number is invalid")
            );
        }
        
        public string Number { get; private set; }
        public EDocumentType DocumentType { get; private set; }
        
        private bool IsNumberValid()
        {
            if (DocumentType == EDocumentType.CPF)
                return IsCpfValid();
            
            if (DocumentType == EDocumentType.CNPJ)
                return IsCNPJValid();

            return false;
        }

        private bool IsCpfValid()
            => Number.Length == 11;

        private bool IsCNPJValid()
            => Number.Length == 14;
    }
}
