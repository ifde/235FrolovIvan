using System.Collections;

namespace Task06Lib
{
    public class Rainbow : IEnumerable<string>
    {
        public IEnumerator<string>
            GetEnumerator()
        {
            yield return "каждый ";
            yield return "охотник ";
            yield return "желает ";
            yield return "знать ";
            yield return "где ";
            yield return "сидит ";
            yield return "фазан ";
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}