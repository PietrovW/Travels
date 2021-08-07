using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IObservable<long> numbers = Observable.Interval(TimeSpan.FromSeconds(1));
            Subject<string> _subject;
            numbers.Subscribe(num =>
            {
                Console.WriteLine(num);
                
            },()=> Console.WriteLine("test"));

            Console.ReadKey();
          
            var singleValue = Observable.Return<string>("Value");
           // singleValue = Observable.Return<string>("Value");
            //Can be reduced to the following
            //singleValue = Observable.Return("Value");
            //which could have also been simulated with a replay subject
            var subject = new ReplaySubject<string>();
            subject.OnNext("Value");
            subject.OnCompleted();
            Console.WriteLine("Hello World!");
        }
    }
}
