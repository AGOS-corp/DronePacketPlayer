using System;
using System.Collections;
using System.Collections.Generic;

namespace AddOnSimulator
{
    public class ListCollection<T>:IEnumerable<T>
    {
        private List<T> items = new List<T>();

        // 요소를 컬렉션에 추가하는 메서드
        public void Add(T item)
        {
            if (items.Count == 0)
                items.Add(item);
            else
            {
                if (items.IndexOf(item) == -1)
                {
                    RemoveItem(item);
                    items.Add(item);
                }
            }
        }
    
        // IEnumerator<T> 인터페이스의 GetEnumerator 메서드 구현
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in items)
            {
                yield return item;
            }
        }

        // IEnumerable 인터페이스의 GetEnumerator 메서드 구현
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // 리스트에서 조건을 만족하는 첫 번째 요소를 찾는 메서드 추가
        public T Find(Predicate<T> match)
        {
            return items.Find(match);
        }

        // 특정 값을 삭제하는 메서드 추가
        public void RemoveItem(T itemToRemove)
        {
            items.RemoveAll(item => EqualityComparer<T>.Default.Equals(item, itemToRemove));
        }

    
        //Item 전체 삭제
        public void ClearAll()
        {
            items.Clear();
        }
    }
}