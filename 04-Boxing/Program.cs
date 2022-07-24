const int ITERATIONS = 1000000;

for (int i = 0; i < ITERATIONS; i++)
    TestMethodWithBoxing(i);
    //TestMethodNoBoxing(i);

Console.ReadLine();

void TestMethodWithBoxing(object i)
{
    var koisa = (int) i;
}

void TestMethodNoBoxing(object i)
{
    var koisa = i;
}
