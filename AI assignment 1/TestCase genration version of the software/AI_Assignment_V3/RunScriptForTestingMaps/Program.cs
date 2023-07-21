internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Which Algo to test 100 cases of maps?");
        Console.WriteLine("bfs, dfs, dfslim, astar, gbfs, astarlim");
        string algo = Console.ReadLine();
        string strCmdText = "";
        for (int i = 0; i < 2; i++)
        {
            strCmdText = "/K  \" search.exe\" Map" + i + " " + algo;

        }

        string intialState = "/K cd \"D:\\\\visual stuido 2022 repo\\\\AI assignment 1\\\\AI_Assignment_V3\\\\ConsoleApp1\\\\bin\\\\Release\"";
        System.Diagnostics.Process.Start("CMD.exe", intialState);
        System.Diagnostics.Process.Start("CMD.exe", strCmdText);
    }
}