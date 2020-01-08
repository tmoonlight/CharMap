using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharMap
{

    /// <summary>
    /// 双向链表节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BdNode<T>
    {
        public T Data { set; get; }
        public BdNode<T> Next { set; get; }
        public BdNode<T> Prev { set; get; }
        public BdNode(T val, BdNode<T> prev, BdNode<T> next)
        {
            this.Data = val;
            this.Prev = prev;
            this.Next = next;
        }
    }

    public class DoubleLink<T> : IEnumerable<T>
    {
        //表头
        private BdNode<T> _linkHead;
        //最后一个元素
        private BdNode<T> _linkTail;
        //节点个数
        private int _size;
        public DoubleLink()
        {
            _linkHead = new BdNode<T>(default(T), null, null);//双向链表 表头为空
            _linkHead.Next = _linkTail;
            _linkTail = new BdNode<T>(default(T), null, null);//双向链表 表头为空
            _linkTail.Prev = _linkHead;
            _size = 0;
        }
        public int GetSize() => _size;
        public bool IsEmpty() => (_size == 0);


        // 将节点插入到第index位置之前
        public void Insert(T item)
        {
            BdNode<T> tnode = new BdNode<T>(item, null, _linkHead);
            _linkHead.Prev = tnode;
            _linkHead = tnode;
            _size++;
        }

        //结尾追加
        public void Append(T item)
        {
            BdNode<T> tnode = new BdNode<T>(item, _linkTail, null);
            _linkTail.Next = tnode;
            _linkTail = tnode;
            _size++;
        }

        public void ShowAll()
        {
            Console.WriteLine("******************* 链表数据如下 *******************");
            //for (int i = 0; i < _size; i++)
            //    Console.WriteLine("(" + i + ")=" + Get(i));
            Console.WriteLine("******************* 链表数据展示完毕 *******************\n");
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoubleLinkEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }


        internal class DoubleLinkEnumerator<T> : IEnumerator<T>
        {
            private DoubleLink<T> doubleLink;

            public DoubleLinkEnumerator(DoubleLink<T> doubleLink)
            {
                this.doubleLink = doubleLink;
            }

            private BdNode<T> _currentNode;

            private T _current;
            public T Current => _current;

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
                this.Dispose();
            }

            public bool MoveNext()
            {
                if (_currentNode == null) _currentNode = doubleLink._linkHead;
                if (_currentNode.Next == null)
                {
                    return false;
                }
                else
                {
                    _currentNode = _currentNode.Next;//进1
                    _current = _currentNode.Data;
                    return true;
                }

                //if(nextNode)

                //_currentNode = doubleLink._linkHead.Next;
                //_current = _currentNode.Data;

                //throw new NotImplementedException();
            }

            public void Reset()
            {
                _currentNode = null;
                _current = default(T);
            }
        }
    }


}
