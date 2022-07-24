using System.Text;

const int REPETITIONS = 10000;

//StringTest();
StringBuilderTest();
//StringBuilderInitTest();

//another kind of test!
//StringFormatTest();
//StringInterpolationTest();

void StringTest()
{
    var result = string.Empty;
    for (int i = 0; i < REPETITIONS; i++)
        result += "#";
}

void StringBuilderTest()
{
    var result = new StringBuilder();
    for (int i = 0; i < REPETITIONS; i++)
        result.Append("#");
}

void StringBuilderInitTest()
{
    var result = new StringBuilder(REPETITIONS);
    for (int i = 0; i < REPETITIONS; i++)
        result.Append("#");
}

void StringFormatTest()
{
    var result = string.Empty;
    for (int i = 0; i < REPETITIONS; i++)
        result = String.Format("{0}#", i);
}

void StringInterpolationTest()
{
    var result = string.Empty;
    for (int i = 0; i < REPETITIONS; i++)
        result = $"{i}#";
}