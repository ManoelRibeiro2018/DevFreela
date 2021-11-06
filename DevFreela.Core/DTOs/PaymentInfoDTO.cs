namespace DevFreela.Core.DTOs
{
    public class PaymentInfoDTO
    {
        private int id;
        private string creditCardNumber;
        private string cvv;
        private string expiresAt;
        private string fullName;

        public PaymentInfoDTO(int id, string creditCardNumber, string cvv, string expiresAt, string fullName)
        {
            this.id = id;
            this.creditCardNumber = creditCardNumber;
            this.cvv = cvv;
            this.expiresAt = expiresAt;
            this.fullName = fullName;
        }
    }
}