int count = 0;

while (!Console.KeyAvailable)
    new MyObject(count++);

Console.WriteLine("Terminating process...");