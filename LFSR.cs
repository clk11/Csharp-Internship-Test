public class LFSR
{
    private int Seed { get; set; }

    public static int Shift(int State)
    {
        int feedbackBit = ((State >> 6) ^ (State >> 5)) & 1;
        State = ((State << 1) | feedbackBit) & 0x7F;
        return State;
    }

    public int GetSeed()
    {
        return Seed;
    }

    public LFSR()
    {
        int s = new Random().Next(0, 128);
        Seed = s;
    }

    public List<char> GetSequences()
    {
        List<char> list = [];
        int State = Seed & 0x7F;
        do
        {
            int nextState = Shift(State);
            char nextChar = (char)nextState;

            if (!char.IsWhiteSpace(nextChar) && !char.IsControl(nextChar))
                list.Add(nextChar);

            State = nextState;
        } while (State != Seed);

        return list;
    }
}
