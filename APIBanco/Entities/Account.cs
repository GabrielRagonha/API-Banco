using System;

namespace APIBanco.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string Type { get; set; }
        public double Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ClientId { get; set; }


        // Construtor da classe Account
        public Account()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
