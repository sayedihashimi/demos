namespace PortForwardingSampleWebApp {
    public class SingleCounter {
        private object _inclock = new object();
        private int _currentCount = 0;
        private static SingleCounter _counter = new SingleCounter();
        public static SingleCounter GetCounter() {
            return _counter;
        }

        public int Increment() {
            lock (_inclock) {
                _currentCount++;
            }
            return _currentCount;
        }
        public int GetCount() {
            return _currentCount;
        }
    }
}
