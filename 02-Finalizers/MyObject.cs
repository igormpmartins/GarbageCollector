internal class MyObject
{
    private int index;

    public MyObject(int index)
    {
        this.index = index;
        Console.WriteLine($"Constructed object {index} in gen {GC.GetGeneration(this)}");
    }

    ~MyObject()
    {
        Thread.Sleep(500);
        Console.WriteLine($"Finalized object {index} in gen {GC.GetGeneration(this)}");
    }
}