using System;

namespace DIScratch
{
    public class SomeService: ISomeService
    {
        // private Guid _randomGuid = Guid.NewGuid();
        private readonly IRandomGuidProvider _randomGuid;
        
        public SomeService(IRandomGuidProvider randomGuid)
        {
            _randomGuid = randomGuid;
        }
        public void PrintSomething()
        {
            Console.WriteLine(_randomGuid);
        }
    }
}