namespace Behavioral
{
    public class Iterator
    {
        public class RadioStation
        {
            private double frequency;

            public RadioStation(double frequency)
            {
                this.frequency = frequency;
            }

            public double GetFrequency()
            {
                return frequency;
            }
        }

        public class StationList : ICollection<RadioStation>, IEnumerable<RadioStation>
        {
            private List<RadioStation> stations = new List<RadioStation>();
            
            private int counter;
            public bool IsReadOnly => false;

            public void Add(RadioStation station)
            {
                stations.Add(station);
            }

            public void Clear()
            {
                stations.Clear();
            }

            public bool Contains(RadioStation item)
            {
                return stations.Contains(item);
            }

            public void CopyTo(RadioStation[] array, int arrayIndex)
            {
                stations.CopyTo(array, arrayIndex);
            }

            public bool Remove(RadioStation item)
            {
                return stations.Remove(item);
            }

            public IEnumerator<RadioStation> GetEnumerator()
            {
                return stations.GetEnumerator();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public void AddStation(RadioStation station)
            {
                stations.Add(station);
            }

            public void RemoveStation(RadioStation toRemove)
            {
                double toRemoveFrequency = toRemove.GetFrequency();
                stations.RemoveAll(station => station.GetFrequency() == toRemoveFrequency);
            }

            public int Count => stations.Count;

            public RadioStation Current(){
                return stations[this.counter];
            }
            public int Key(){
                return this.counter;
            }

            public void Next(){
                this.counter++;
            }

            public void Rewind(){
                this.counter = 0;
            }

            public bool Valid()
            {
                return this.counter >= 0 && this.counter < stations.Count;
            }

        }

        public static void DemonstrateIterator()
        {
            var stationList = new StationList();
            stationList.AddStation(new RadioStation(89));
            stationList.AddStation(new RadioStation(101));
            stationList.AddStation(new RadioStation(102));
            stationList.AddStation(new RadioStation(103.2));

            foreach (var station in stationList)
            {
                Console.WriteLine(station.GetFrequency());
            }

            // 移除一个电台
            Console.WriteLine("移除一个电台");
            stationList.RemoveStation(new RadioStation(101));
            // 添加一个电台
            Console.WriteLine("添加一个电台");
            stationList.AddStation(new RadioStation(104));

            foreach (var station in stationList)
            {
                Console.WriteLine(station.GetFrequency());
            }

        }

        
    }
}
