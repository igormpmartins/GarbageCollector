using System.Collections;
using System.Text;

Console.WriteLine("Examples");

#region Gen0 optimizations

void OptimizeStrBuilder()
{
    //a new string will be created for each loop!!
    var s = new StringBuilder();
    for (int i = 0; i < 10000; i++)
        s.Append(i.ToString() + "KB");

    //Now "KB" will be created only once
    //Not using ".ToString()" will stop creating a new string for each loop!
    var sb = new StringBuilder();
    for (int i = 0; i < 10000; i++)
    {
        sb.Append(i);
        sb.Append("KB");
    }

}

void OptmList()
{
    var array = new ArrayList();
    for (int i = 0; i < 10000; i++)
        array.Add(i);

    //avoids objects (and therefore boxing) and optimizes for GC
    var list = new List<int>();
    for (int i = 0; i < 10000; i++)
        list.Add(i);
}

void ObjectsInstanciation()
{
    //static MyClass obj = new MyClass();
    //lots of other code
    //UseTheObject(obj);

    //should be
    //MyClass obj = new MyClass();
    //UseTheObject(obj);
    //obj = null;

    //You can also create a method for creating and using the obj,
    //so you don't need to set 'null'. After the method completion,
    //the var will be out of scope and GC will collect sometime.

}

#endregion

#region Lifetime optimization

//small objects should be short lived
//large objects should be longe lived
//avoid breaking these rules, because that's how GC works

//A few refactories to keep this lifetime as expected

void KeepingArrayLargeLongLived()
{
    //this keeps the large object as short lived!
    var list = new ArrayList(85190);
    UseTheList(list);
    //other code
    list = new ArrayList(85190);
    UseTheList(list);

    //this keeps the large object as long lived!
    var otherList = new ArrayList(85190);
    UseTheList(otherList);
    //other code
    otherList.Clear();
    UseTheList(otherList);
}

void KeepingArrayAsShortLived()
{
    //Pair will be long lived! even being a small object
    var list = new ArrayList(85190);
    for (int i = 0; i < 10000; i++)
        list.Add(new Pair(i, i+1));

    //no more long lived short objects
    int[] list1 = new int[85190];
    int[] list2 = new int[85190];

    for (int i = 0; i < 10000; i++)
    {
        list1[i] = i;
        list1[i] = i + 1;
    }

}

#endregion

#region Size Strategies

void ReduceSizeToKeepShortLived()
{
    var buffer = new int[32768];
    for (int i = 0; i < buffer.Length; i++)
        buffer[i] = GetByte(i);

    //reduce size!
    var otherBuffer = new byte[32768];
    for (int i = 0; i < otherBuffer.Length; i++)
        otherBuffer[i] = GetByte(i);
}

void IncreaseSizeToKeepLongLived()
{
    //should be static!
    var list = new ArrayList();
    //lots of other code!
    UseTheList(list);

    //change to ....
    //should be static too!
    var list2 = new ArrayList(85190);
    //lots of other code!
    UseTheList(list2);

}

#endregion

#region empty definitions

//methods created only for completing the examples!

void UseTheList(ArrayList list)
{
    throw new NotImplementedException();
}

byte GetByte(int i)
{
    throw new NotImplementedException();
}

class Pair
{
    public Pair(int x, int y)
    {
        throw new NotImplementedException();
    }
}

#endregion