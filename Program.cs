#pragma warning disable CS8600 

#region Declarare variabile

StreamReader reader = new("./input.txt");
List<List<char>> input_matrix = [];
List<List<char>> stacks = [];
List<Move> moves = [];
string line = string.Empty;
int counter = 0;
#endregion

#region Citire input din fisier

while ((line = reader.ReadLine()) != null)
{
    if (!line.Contains("move"))
    {
        List<char> cols = [];
        for (int i = 0; i < line.Length; i++)
        {
            if (char.IsDigit(line[i]))
                counter++;
            cols.Add(line[i]);
        }
        input_matrix.Add(cols);
    }
    else
        moves.Add(RetrieveMoves(line));
}
reader.Close();
#endregion

#region Logica principala din aplicatie

for (int index = 0; index < counter; index++)
{
    stacks.Add([]);
    for (int i = 0; i < input_matrix.Count - 2; i++)
    {
        if (input_matrix[i][index * 4 + 1] != ' ')
            stacks[index].Add(input_matrix[i][index * 4 + 1]);
    }
}


for (int i = 0; i < moves.Count; i++)
{
    for (int j = 0; j < moves[i].Containers; j++)
    {
        stacks[moves[i].To].Insert(0, stacks[moves[i].From][0]);
        stacks[moves[i].From].Remove(stacks[moves[i].From][0]);
    }
}

for (int i = 0; i < stacks.Count; i++)
    System.Console.Write(stacks[i][0]);
System.Console.WriteLine();
#endregion

#region Functii si clase

static Move RetrieveMoves(string str)
{
    string[] splited = str.Split(new string[] { "move", "from", "to" }, StringSplitOptions.RemoveEmptyEntries);
    var moves = splited.Where(move => !string.IsNullOrEmpty(move))
        .Select(move => int.Parse(move.Trim()))
        .ToList();
    Move move = new(moves[1], moves[2], moves[0]);
    return move;
}

class Move(int from, int to, int containers)
{
    public int From { get; set; } = from - 1;
    public int To { get; set; } = to - 1;
    public int Containers { get; set; } = containers;
}

#endregion