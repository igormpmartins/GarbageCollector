using System.Collections;

const int MAX_ITEMS = 262145;

FillList();
//FillPreSizedList();

void InitCollections()
{
    var arrayList = new ArrayList();
    var queue = new Queue<int>();
    var stack = new Stack<int>();
    var list = new List<int>();
    var dictionary = new Dictionary<int, int>();

    arrayList.Add(1);
    queue.Enqueue(1);
    stack.Push(1);
    list.Add(1);
    dictionary.Add(1, 1);

    //using debugger, it's possible to check the initial size for each collection:
    //ArrayList = 4 items
    //Queue = 4 items
    //Stack = 16 items
    //List = 4 items
    //Dictionary = 12 items
}

void FillList()
{
    var list = new List<int>();
    for (int i = 0; i < MAX_ITEMS; i++)
        list.Add(i);

    Console.WriteLine(list.Count);
}

void FillPreSizedList()
{
    var list = new List<int>(MAX_ITEMS);
    for (int i = 0; i < MAX_ITEMS; i++)
        list.Add(i);

    Console.WriteLine(list.Count);
}
