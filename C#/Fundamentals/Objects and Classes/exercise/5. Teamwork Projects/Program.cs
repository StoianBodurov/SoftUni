using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            for (int i = 0; i < teamsCount; i++)
            {
                string[] data = Console.ReadLine().Split("-");
                string teamCreator = data[0];
                string teamName = data[1];

                if (teams.Exists(t => t.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }


                if (teams.Exists(t => t.Creator == teamCreator))
                {
                    Console.WriteLine($"{teamCreator} cannot create another team!");
                    continue;
                }

                Team team = new Team
                {
                    Name = teamName,
                    Creator = teamCreator,
                    Members = new List<string>(),
                };
                teams.Add(team);
                Console.WriteLine($"Team {teamName} has been created by {teamCreator}!");
            }

            while (true)
            {
                string[] token = Console.ReadLine().Split("->");
                if (token[0] == "end of assignment")
                {
                    break;
                }

                string user = token[0];
                string team = token[1];

                if (!teams.Exists(t => t.Name == team))
                {
                    Console.WriteLine($"Team {team} does not exist!");
                    continue;
                }

                if (!canJoin(teams, user))
                {
                    Console.WriteLine($"Member {user} cannot join team {team}!");
                    continue;
                }

                Team findetTeam = teams.Find(t => t.Name == team);
                findetTeam.Members.Add(user);
            }

            //teams.Sort((x, y) => y.Members.Count.CompareTo(x.Members.Count) +  x.Name.CompareTo(y.Name));
            List<Team> result = teams.OrderByDescending(t => t.Members.Count).ThenBy(t => t.Name).ToList();

            List<Team> disabenTeam = new List<Team>();

            foreach (var t in result)
            {
                if (t.Members.Count > 0)
                {
                    t.Members.Sort((x, y) => x.CompareTo(y));
                    Console.WriteLine(t.Name);
                    Console.WriteLine($"- {t.Creator}");
                    foreach (var m in t.Members)
                    {
                        Console.WriteLine($"-- {m}");
                    }
                }
                else
                {
                    disabenTeam.Add(t);
                }
            }
            Console.WriteLine("Teams to disband:");
            foreach (var t in disabenTeam)
            {
                Console.WriteLine(t.Name);
            }

        }

        static bool canJoin(List<Team> teams, string user)
        {
            foreach (var team in teams)
            {
                if (team.Members.Exists(m => m == user))
                {
                    return false;
                }

                if (team.Creator == user)
                {
                    return false;
                }

            }
            return true;
        }
    }
}
