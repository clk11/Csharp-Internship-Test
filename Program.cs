var l = new LFSR();
System.Console.Write((char)l.GetSeed() + " ");
foreach (var item in l.GetSequences())
{
    System.Console.Write(item + " ");
}