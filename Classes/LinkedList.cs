using System.Windows.Markup;

namespace Lists.Classes;

public class LinkedList
{
    public int Length { get; private set; }

    public int this[int index]
    {
        get
        {
            Node current = _root;
            for (int i = 1; i <= index; i++)
            {
                current = current.Next;
            }
            return current.Value;
        }
        set
        {
            Node current = _root;
            for (int i = 1; i <=index; i++)
            {
                current = current.Next;
            }

            current.Value = value;
        }
    }
    private Node _root;
    private Node _tail;

    public LinkedList()
    {
        Length = 0;
        _root = null;
        _tail = null;
    }
    //здесь нода из 1го элемента, поэтому tail = root; В итоге и tail и root будут ссылаться на одну и ту же ноду.
    public LinkedList(int value)
    {
        Length = 1;
        _root = new Node(value);
        _tail = _root;
    }

    public LinkedList(int[] values)
    {
        Length = values.Length;
        if (values.Length != 0)
        {
            _root = new Node(values[0]);
            _tail = _root;
            for (int i = 1; i < values.Length; i++)
            {
                //в поле, где у хвоста есть следующий элемент, кладем новую ноду.
                _tail.Next = new Node(values[i]);
                _tail = _tail.Next;
            }
        }
        else //если длина массива равна 0, создаем пустой список
        {
            _root = null;
            _tail = null;
        }
    }
   

    public void Add(int value)
    {
        //увеличиваем длину на 1
        Length++;
        //обращаемся к концу, к полю нэкст, и создаем новую ноду со значением value
        _tail.Next = new Node(value);
        //пишем, что конец теперь - это последний элемент(переходим с бывшего конечного к следующему)
        _tail = _tail.Next;
    }
    public void AddFirst(int value)
    {
        Length++;
        Node tmp = new Node(value);
        tmp.Next = _root;
        _root = tmp;
    }
    public void AddByIndex(int value, int index)
    {
        if (index > this.Length)
        {
            for (int i = this.Length; i < index; i++)
            {
                Add(0);
            }
        }

        if (index < 0)
        {
            throw new IndexOutOfRangeException("Вы ввели отрицательный индекс, ошибка");
        }
        Node current = _root;
        for (int i = 1; i < index; i++)
        {
            current = current.Next;
        }
        Node tmp = new Node(value);
        tmp.Next = current.Next;
        current.Next = tmp;
        Length++;
    }
    public void RemoveFirst()
    {
        _root = _root.Next;
    }
    public void RemoveLast()
    {
        Node current = _root;
        for (int i = 1; i < this.Length; i++)
        {
            current = current.Next;
        }

        _tail = current;
    }
    public void RemoveByIndex(int index)
    {
        Node current = _root;

        for (int i = 1; i < index; i++)
        {
            current = current.Next;
        }

        current.Next = current.Next.Next;

        Length--;
    }

    public void PrintList()
    {
        
        for (int i = 0; i < this.Length; i++)
        {
            Console.WriteLine(this[i]);
        }
    }
    private int GetNodeByIndex(int index)
    {
        Node current = _root;
        for (int i = 1; i <= index; i++)
        {
            current = current.Next;
        }

        return current.Value;
    }
    public override string ToString()
    {
        if (Length != 0)
        {
            Node current = _root;
            string s = current.Value + " ";

            while (!(current.Next is null))
            {
                current = current.Next;
                s += current.Value + " ";
            }
            return s;
        }
        else
        {
            return String.Empty;
        }

    }

    public override bool Equals(object? obj)
    {
        LinkedList list = (LinkedList)obj;
        if (this.Length!=list.Length)
        {
            return false;
        }

        Node currentThis = _root;
        Node currentList = list._root;

        do
        {
            if (currentThis.Value != currentList.Value)
            {
                return false;
            }
            //это тот лист который нам передали
            currentList = currentList.Next;
            //это наш лист
            currentThis = currentThis.Next;
        }
        while (!(currentThis.Next is null));

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}