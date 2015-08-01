using System;

namespace Rolls.Models
{
    public class Roll
    {
        public int Id { get; set; }
 
        public string Name { get; set; }
 
        public int Value { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }
}