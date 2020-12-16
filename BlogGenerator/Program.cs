using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BlogGenerator
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Main Directory would contain all bloggers directory
            string mainDirectoryPath = @"C:\BlogFiles\";

            //Create Sub directory for a particular Blogger
            string subDirectoryPath = CreateDirectory(mainDirectoryPath);
            
            //If directory in this person's name does not exist create it
            Console.Write("Kindly Enter Blog page name: ");
            string blogName = Console.ReadLine();
            
            Console.Write("Enter blog topic:" ); //Add exception at this point
            string blogTopic = Console.ReadLine();

            Console.WriteLine("Write your story:");
            string blogStory = Console.ReadLine();

            CreateBlogPage(blogName, blogTopic, blogStory, subDirectoryPath);

                       

            /*string content = $"<!DOCTYPE html>" +
                $"<html lang=\"en\">" +
                $"< head >" +
                $"< meta charset = \"UTF-8\" >" +
                $"< meta name = \"viewport\" content = \"width = device-width, initial-scale=1.0\" >" +
                $"< title > Document </ title >" +
                $"</ head >" +
                $"< body >{blogTopic}{blogStory}</ body >" +
                $"</ html > ";*/

            //blogPageContent.Add(blogTopic);
            //blogPageContent.Add(blogStory);

            
        }
        
        static string CreateDirectory(string directory)
        {
            //Create Main Directory if it doesn't exist
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            //if(String.IsNullOrEmpty(author))
            Console.Write("Enter your name: ");

            string author = Console.ReadLine().ToUpper();
            directory = $@"{directory}{author}";
         

            //Create sub directory if it doesn't exit
            if (!Directory.Exists(directory))
            {
                Console.WriteLine("It seems you are a new User. We would attempt to create a new account for you");
                Directory.CreateDirectory(directory);

            }

            Console.WriteLine($"\nWelcome {author}.This app allows you create your own story. It's as easy as munching on a piece of cake\n\n");
            
            return directory;
        }
        static void CreateBlogPage(string blogName, string blogTopic, string blogStory, string root)
        {
            string blogPath = $@"{root}\{blogName}.html";

            Console.WriteLine("New directory: " + blogPath);
            blogTopic = $"<p>{blogTopic}</p>";

            File.AppendAllText(blogPath, $"{blogTopic}<p>Written by: {blogName}. Created On:{DateTime.Now}</p>");
            File.AppendAllText(blogPath, $"<hr>blogStory");
        }

    }
}
