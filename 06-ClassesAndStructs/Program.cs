const int LISTSIZE = 1000000;


//TestClass();
TestStruct();


void TestClass()
{
    var list = new List<PointClass>(LISTSIZE);
    for (int i = 0; i < LISTSIZE; i++)
    {
        list.Add(new PointClass(i, i));
    }
}

void TestStruct()
{
    var list = new List<PointStruct>(LISTSIZE);
    for (int i = 0; i < LISTSIZE; i++)
    {
        list.Add(new PointStruct(i, i));
    }
}

    