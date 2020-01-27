using System;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using static System.Console;

namespace FlurlDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            WriteLine("Flurl Demo!");

            WriteLine("Getting github repos data...");
            // https://api.github.com/users/fabionaspolini/repos"
            var repos = await "https://api.github.com"
                .AppendPathSegments("users", "fabionaspolini", "repos")
                .WithHeader("Accept", "application/vnd.github.v3+json")
                .WithHeader("User-Agent", "Flurl HTTP Library Demo")

                // Execute GET
                .GetAsync()

                // Convert JSON Text to Object with Newtonsoft
                .ReceiveJson<RepoModel[]>();

            WriteLine("");
            WriteLine(
                "Name".PadRight(30) +
                "Description".PadRight(100) +
                "Forked".PadRight(8) +
                "Create Date".PadRight(18) +
                "Last Update".PadRight(18) +
                "URL".PadRight(80));
            WriteLine(new string('-', 250));
            
            foreach (var repo in repos)
                WriteLine(repo.name.PadRight(30) +
                          (repo.description ?? string.Empty).PadRight(100).Substring(0, 100) +
                          repo.fork.ToString().PadRight(8) +
                          repo.created_at.ToLocalTime().ToString("dd/MM/yyyy HH:mm").PadRight(18) +
                          repo.updated_at.ToLocalTime().ToString("dd/MM/yyyy HH:mm").PadRight(18) +
                          repo.html_url.PadRight(80));
        }
    }
}