using System;
using System.Collections.Generic;

namespace _3._Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(", ");
                string title = data[0];
                string content = data[1];
                string autor = data[2];

                articles.Add(new Article(title, content, autor));

            }

            string criteria = Console.ReadLine();

            if (criteria == "title")
            {
                articles.Sort((x, y) => x.Title.CompareTo(y.Title));
            }
            else if (criteria == "content")
            {
                articles.Sort((x, y) => x.Content.CompareTo(y.Content));
            }
            else
            {
                articles.Sort((x, y) => x.Author.CompareTo(y.Author));

            }

            foreach (Article article in articles)
            {
                Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
            }
        }
    }
}
