using System.Collections;
using System.Collections.Generic;
using DungeonThingy.Actors;

namespace DungeonThingy.Core
{
    public class InitiativeList : IList<Actor>
    {
        private readonly List<Actor> _orderedTurnList = new List<Actor>();
        public int CurrentPosition { get; set; }

        public Actor Next()
        {
            var result = _orderedTurnList[CurrentPosition];

            CurrentPosition = CurrentPosition >= _orderedTurnList.Count - 1 ? 0 : CurrentPosition + 1;

            return result;
        }

        public IEnumerator<Actor> GetEnumerator()
        {
            return _orderedTurnList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _orderedTurnList).GetEnumerator();
        }

        public void Add(Actor item)
        {
            _orderedTurnList.Add(item);
        }

        public void Clear()
        {
            _orderedTurnList.Clear();
        }

        public bool Contains(Actor item)
        {
            return _orderedTurnList.Contains(item);
        }

        public void CopyTo(Actor[] array, int arrayIndex)
        {
            _orderedTurnList.CopyTo(array, arrayIndex);
        }

        public bool Remove(Actor item)
        {
            return _orderedTurnList.Remove(item);
        }

        public int Count
        {
            get { return _orderedTurnList.Count; }
        }

        public bool IsReadOnly
        {
            get { return ((ICollection<>) _orderedTurnList).IsReadOnly; }
        }

        public int IndexOf(Actor item)
        {
            return _orderedTurnList.IndexOf(item);
        }

        public void Insert(int index, Actor item)
        {
            _orderedTurnList.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _orderedTurnList.RemoveAt(index);
        }

        public Actor this[int index]
        {
            get { return _orderedTurnList[index]; }
            set { _orderedTurnList[index] = value; }
        }
    }
}