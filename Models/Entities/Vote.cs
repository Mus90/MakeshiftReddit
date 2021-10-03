using System;
namespace MakeshiftReddit.Models.Entities
{
    public class Vote
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int VoteValue { get; set; }
     
    }
}
