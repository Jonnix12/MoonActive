using System.Collections.Generic;

namespace MoonActive.SequenceSystem
{
    public class SequenceHandler<T>
    {
        private List<ISequenceOperation<T>> _operations;

        public SequenceHandler()
        {
            _operations = new List<ISequenceOperation<T>>();
        }

        public void Register(ISequenceOperation<T> operation)
        {
            if (_operations.Contains(operation))
                return;
            
            _operations.Add(operation);
        }

        public void StartAll(T data)
        {
            foreach (var operation in _operations)
            {
                operation.ExecuteTask(data);
            }
        }
    }

    public interface ISequenceHandler<T>
    {
        void Register(ISequenceOperation<T> operation);
    }
}