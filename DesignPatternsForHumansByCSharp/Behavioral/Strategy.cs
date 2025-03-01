namespace Behavioral
{
    public class Strategy
    {
        public interface ISortStrategy
        {
            List<int> Sort(List<int> list);
        }

        public class BubbleSortStrategy : ISortStrategy
        {
            public List<int> Sort(List<int> list)
            {
                Console.WriteLine("Sorting using bubble sort");
                return list;
            }
        }

        class QuickSortStrategy : ISortStrategy
        {
            public List<int> Sort(List<int> list)
            {
                Console.WriteLine("Sorting using quick sort");
                return list;
            }
        }

        public class Sorter
        {
            public required ISortStrategy _sorterSmall;
            public required ISortStrategy _sorterLarge;
            
            public void SetSortStrategy(ISortStrategy sorterSmall, ISortStrategy sorterLarge)
            {
                _sorterSmall = sorterSmall;
                _sorterLarge = sorterLarge;
            }

            public List<int> Sort(List<int> list)
            {
                if (list.Count <= 5)
                {
                    return _sorterSmall.Sort(list);
                }
                else
                {
                    return _sorterLarge.Sort(list);
                }
            }
        }

        public static void DemonstrateStrategy()
        {
            var sorter = new Sorter
            {
                _sorterSmall = new BubbleSortStrategy(),
                _sorterLarge = new QuickSortStrategy()
            };
            
            sorter.Sort(new List<int> { 1, 2, 3, 4, 5 });
            sorter.Sort(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }
    }
}
