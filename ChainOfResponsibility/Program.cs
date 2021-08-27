using System;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            CommonValidation objectToValidate = new CommonValidation() { Word = "c" };

            var chainValidation = new WordContainLetterA();
            chainValidation.SetNext(new WordContainLetterB()).SetNext(new WordContainLetterC());

            chainValidation.Handle(objectToValidate);

            Console.WriteLine("Validation Success!");

            Console.ReadLine();
        }
    }
}
