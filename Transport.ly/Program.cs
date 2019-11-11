using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.ly.Services;

namespace Transport.ly
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Transport.ly");
            int storyNumber = -1;
            do
            {
                Console.WriteLine($"Select story number ({StoryService.Stories.Count()} stories avaliable). Enter 0 to exit. ");
                string key = "";
                key = Console.ReadLine();
                storyNumber = -1;
                if(!int.TryParse(key, out storyNumber))
                {
                    storyNumber = -1;
                }
                if (storyNumber == 0)
                    break;
                try
                {
                    StoryService.Stories[storyNumber]();//call a story by a story number
                }
                catch(KeyNotFoundException)
                {
                    Console.WriteLine("Sorry, no user story was found.");
                }
            }
            while (storyNumber != 0);
        }
    }
}
