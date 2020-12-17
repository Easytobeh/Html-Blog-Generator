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
            
            //If directory with author's name does not exist create it
            Console.Write("Kindly Enter Blog page name: ");
            string blogName = Console.ReadLine();
            
            Console.Write("Enter Article Name:" ); //Add exception handler at this point
            string blogTopic = Console.ReadLine();

            Console.WriteLine("Write your story:");
            string blogStory = Console.ReadLine();

            //Finally populate blog page
            CreateBlogPage(blogName, blogTopic, blogStory, subDirectoryPath);

        }
        
        static string CreateDirectory(string directory)
        {
            //Create Main Directory if it doesn't exist
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            
            Console.Write("Enter your name: ");

            string author = Console.ReadLine().ToUpper();

            while (String.IsNullOrEmpty(author))
            {
                Console.Write("Name cannotbe empty. Enter name please:");
                author = Console.ReadLine();
            }
                directory = Path.Combine(directory,author);

            //Validate directory Exist
                if (Directory.Exists(directory))
                {
                    Console.WriteLine($"\nWelcome {author}.This app allows you create your own story. It's as easy as munching on a piece of cake\n\n");
                   
                }
            
             return directory;
        }

        static void CreateBlogPage(string blogName, string blogTopic, string blogStory, string root)
        {
            string blogPath = Path.Combine(root, blogName + ".html");

           // Console.WriteLine("New directory: " + blogPath);
            blogTopic = $"<p>{blogTopic}</p>";

            string blogContent = CopyBoilerPlate();
            blogContent = $"{blogContent}";

          //  Console.WriteLine("boilerPlate: " + blogContent);

            /*string blogContent = $"<!DOCTYPE html>" +
                $"<html lang=\"en\">" +
                $"<head>" +
                $"<meta charset = \"UTF-8\">" +
                $"<meta name = \"viewport\" content = \"width = device-width, initial-scale=1.0\">" +
                $"<title> Document </title>" +
                $"</head>" +
                $"<body><h1>{blogTopic}</h1><p>Written by:{blogName}. Created On:{DateTime.Now}</p></body>" +
                $"</html> ";*/
            try 
            { 
                File.AppendAllText(blogPath, blogContent); 
            }
            catch(DirectoryNotFoundException dirEx)
            {
                Console.WriteLine($"Oops! Something went wrong. {dirEx.Message}.\n It seems you are a new User. We would attempt to create a new account for you");
                Directory.CreateDirectory(root);

                using (StreamWriter str = File.CreateText(blogPath))
                {
                    str.WriteLine(blogContent);
                    
                }
            }
            
        }

        static string CopyBoilerPlate()
        {
            //Get boilerplate content from main directory

            const string filePath = @"C:\BlogFiles\boilerplate.txt";
            string innerTextContent = "";
            try
            {
                 innerTextContent = File.ReadAllText(filePath);
            }
            catch (FileNotFoundException noFileEx)
            {
                Console.WriteLine($"{noFileEx.Message}");
            }

            return innerTextContent;
        }

    }
}
