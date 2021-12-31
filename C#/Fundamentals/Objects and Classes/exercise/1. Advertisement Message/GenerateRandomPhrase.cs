using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1._Advertisement_Message
{
    class GenerateRandomPhrase
    {
        public GenerateRandomPhrase(List<string> phrases)
        {
            Phrases = phrases;
        } 

        public List<string> Phrases { get; set; }

        public string GetPhrase()
        {
            Random random = new Random();
            return Phrases[random.Next(Phrases.Count)];
        }

    }
}
