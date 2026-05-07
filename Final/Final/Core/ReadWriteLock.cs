using System.Threading;

namespace Final.Core
{
    internal class ReadWriteLock
    {
        private int _readers = 0;
        private int _writers = 0;
        private int _writeRequests = 0;

        // The core synchronization primitive
        private readonly object _lockObj = new object();

        public void lockRead()
        {
            lock (_lockObj)
            {
                // If a writer is writing or waiting to write, readers must wait.
                while (_writers > 0 || _writeRequests > 0)
                {
                    Monitor.Wait(_lockObj);
                }
                _readers++;
            }
        }

        public void unlockRead()
        {
            lock (_lockObj)
            {
                _readers--;
                // Wake up all waiting threads
                Monitor.PulseAll(_lockObj);
            }
        }

        public void lockWrite()
        {
            lock (_lockObj)
            {
                _writeRequests++;
                // Wait until all active readers and writers are finished
                while (_readers > 0 || _writers > 0)
                {
                    Monitor.Wait(_lockObj);
                }
                _writeRequests--;
                _writers++;
            }
        }

        public void unlockWrite()
        {
            lock (_lockObj)
            {
                _writers--;
                Monitor.PulseAll(_lockObj);
            }
        }
    }
}