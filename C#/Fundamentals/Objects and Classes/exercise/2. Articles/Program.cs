using System;

namespace _2._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(", ");
            string title = data[0];
            string content = data[1];
            string author = data[2];

            Article article = new Article(title, content, author);
            

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] token = Console.ReadLine().Split(": ");

                string command = token[0];
                string newContent = token[1];

                if (command == "Edit")
                {
                    article.Edit(newContent);
                }
                else if (command == "ChangeAuthor")
                {
                    article.ChangeAuthor(newContent);
                }
                else
                {
                    article.Rename(newContent);
                }

            }

            Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");

        }
    }
}
