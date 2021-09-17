using System;

namespace DIScratch
{
    public class RandomGuidGenerator
    {
        public Guid GetGuid { get; set; } = Guid.NewGuid();
    }
}