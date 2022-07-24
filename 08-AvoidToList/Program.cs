namespace _08_AvoidToList
{
    internal class Program
    {
        static IEnumerable<string> story = null;

        private static IEnumerable<string> ReadFile(string filePath)
        {
            using (StreamReader reader = File.OpenText(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    yield return line;
                }
            }
        }

        private static void SlowSpellCheck()
        {
            var dictionary = ReadFile("./allwords.txt");

            var results = story.Select(s => new
            {
                Word = s,
                Ok = dictionary.ToList().Any(d => d.Contains(s, StringComparison.InvariantCultureIgnoreCase))
            });

            foreach (var r in results)
            {
                Console.ForegroundColor = r.Ok ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write(r.Word);
                Console.Write(" ");
            }
            Console.ResetColor();
        }        
        
        private static void BetterSpellCheck()
        {
            var newDictionary = new List<string>(ReadFile("./allwords.txt"));

            //in terms of performance, the approaches bellow had virtually the same performance!
            //var newDictionary = new List<string>(466550);
            //newDictionary.AddRange(ReadFile("./allwords.txt"));
            //foreach (var word in ReadFile("./allwords.txt"))
            //  newDictionary.Add(word);

            var results = story.Select(s => new
            {
                Word = s,
                Ok = newDictionary.Any(d => d.Contains(s, StringComparison.InvariantCultureIgnoreCase))
            });

            foreach (var r in results)
            {
                Console.ForegroundColor = r.Ok ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write(r.Word);
                Console.Write(" ");
            }
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            story = ReadFile("./story.txt");
            //SlowSpellCheck();
            BetterSpellCheck();
        }
    }
}