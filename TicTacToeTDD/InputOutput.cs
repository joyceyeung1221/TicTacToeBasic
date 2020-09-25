using System;
namespace TicTacToeTDD
{
    public class InputOutput : IIO
    {
        public InputOutput()
        {
        }

        public string RecordInput()
        {
            return Console.ReadLine();
        }

        public void Output(string text)
        {
            Console.WriteLine(text);
        }
    }
}
