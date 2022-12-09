string[] lines = System.IO.File.ReadAllLines(@"C:\Users\chris\source\repos\AdventOfCodeDay5\AdventOfCodeDay5\TextFile1.txt");
var stacksBlock = lines.Take(8).ToArray();
List<Stack<string>> stackList = new List<Stack<string>>();
List<List<string>> listList = new List<List<string>>();
for (int i = 0; i < 9; i++) { listList.Add(new List<string> { }); }
for (int i = 0; i < 9; i++) { stackList.Add(new Stack<string> { }); }

foreach (var stack in stacksBlock)
{   
    var index = 0;
    for (int i = 1; i < stack.Length; i+=4)
    {
        listList[index].Add(stack[i].ToString());
        index++;
    }
}
for (int i = 0; i < listList.Count(); i++) {
    listList[i].RemoveAll(x => x == " ");
    listList[i].Reverse();
}
for (int i = 0; i < listList.Count(); i++)
{
    for (int j = 0; j< listList[i].Count(); j++)
    { 
        stackList[i].Push(listList[i][j]);
    }
}
void MakeMove(int amount, int from, int dest)
{
    var temp = new Stack<string> { };
    for (int i = 0; i < amount; i++)
    {
        var popped = stackList[from - 1].Pop();
        temp.Push(popped);
    }
    temp.Reverse();
    //part 2
    for (int i = 0; i < amount; i++)
    {
        var popped = temp.Pop();
        stackList[dest - 1].Push(popped);
    }
    //part 1
    //for (int i = 0; i < amount; i++)
    //{
    //    var popped = stackList[from - 1].Pop();
    //    stackList[dest - 1].Push(popped);
    //}
}
for (int i = 10; i <lines.Length; i++)
{
    var trimmed = lines[i].Substring(4, lines[i].Length - 4).Trim();
    var amount = Int32.Parse(trimmed.Substring(0, 2).Trim());
    var from = Int32.Parse(trimmed.Substring(trimmed.Length - 6, 1));
    var dest = Int32.Parse(trimmed.Substring(trimmed.Length - 1, 1));
    MakeMove(amount, from, dest);
}
for (int i = 0; i < stackList.Count(); i++)
{
    Console.WriteLine(stackList[i].Peek());
}