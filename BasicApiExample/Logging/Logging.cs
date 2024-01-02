namespace BasicApiExample.Logging
{
    public class Logging : Ilogging
    {
        public void Log(string message, string type)
        {
            if(type == "error") 
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Error - " + message);
                Console.BackgroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                Console.BackgroundColor= ConsoleColor.Black;
            }
        }
    }
}
