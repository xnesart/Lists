using Lists.Classes;

namespace Lists.Tests;

public class LinkedListTests
{
    [Test]
    
    [TestCase(new int[] {1,2,3,8,4,5,6,3,7,3} ,new int[] {1,2,3,8,4,5,6,3,7},3)]
    [TestCase(new int[] {3} ,new int[] {},3)]
    public void AddTests(int[] expectedList,int[] actualList, int value)
    {
        LinkedList expected = new LinkedList(expectedList);
        LinkedList actual = new LinkedList(actualList);
        actual.Add(value);

        Assert.AreEqual(expected, actual);
    }
    [TestCase(new int[] {3,1,2,3,8,4,5,6,3,7} ,new int[] {1,2,3,8,4,5,6,3,7},3)]
    [TestCase(new int[] {3} ,new int[] {},3)]
    [TestCase(new int[] {3,2,-4,5} ,new int[] {2,-4,5},3)]
    public void AddFirstTests(int[] expectedList,int[] actualList, int value)
    {
        LinkedList expected = new LinkedList(expectedList);
        LinkedList actual = new LinkedList(actualList);
        actual.AddFirst(value);

        Assert.AreEqual(expected, actual);
    }
    [TestCase(new int[] {1,2,3,8,4,5,6,3,7,3} ,new int[] {1,2,3,8,4,5,6,3,7},3,10)]
    [TestCase(new int[] {1,2,3,8,4,5,6,3,7,0,0,3} ,new int[] {1,2,3,8,4,5,6,3,7},3,12)]
    [TestCase(new int[] {1,2,3,8,4,5,6,3,7,0,0,0,0,3} ,new int[] {1,2,3,8,4,5,6,3,7},3,14)]
    [TestCase(new int[] {3,1} ,new int[] {1},3,0)]
    [TestCase(new int[] {1,6,3,7} ,new int[] {1,6,7},3,2)]
    [TestCase(new int[] {0,3} ,new int[] {},3,1)]
    public void AddByIndexTests(int[] expectedList,int[] actualList, int value, int index)
    {
        LinkedList expected = new LinkedList(expectedList);
        LinkedList actual = new LinkedList(actualList);
        actual.AddByIndex(value,index);

        Assert.AreEqual(expected, actual);
    }
    
    [TestCase(new int[] {2,3,8,4,5,6,3,7} ,new int[] {1,2,3,8,4,5,6,3,7})]
    [TestCase(new int[] {} ,new int[] {3})]
    public void RemoveFirstTests(int[] expectedList,int[] actualList)
    {
        LinkedList expected = new LinkedList(expectedList);
        LinkedList actual = new LinkedList(actualList);
        actual.RemoveFirst();

        Assert.AreEqual(expected, actual);
    }
    
    [TestCase(new int[] {1,2,3,8,4,5,6,3} ,new int[] {1,2,3,8,4,5,6,3,7})]
    [TestCase(new int[] {} ,new int[] {3})]
    public void RemoveLastTests(int[] expectedList,int[] actualList)
    {
        LinkedList expected = new LinkedList(expectedList);
        LinkedList actual = new LinkedList(actualList);
        actual.RemoveLast();

        Assert.AreEqual(expected, actual);
    }
    [TestCase(new int[] {1,2,3,8,4,6,3,7} ,new int[] {1,2,3,8,4,5,6,3,7},5)]
    [TestCase(new int[] {1,2,3,4,5,6,3,7} ,new int[] {1,2,3,8,4,5,6,3,7},3)]
    public void RemoveByIndexTests(int[] expectedList,int[] actualList, int index)
    {
        LinkedList expected = new LinkedList(expectedList);
        LinkedList actual = new LinkedList(actualList);
        actual.RemoveByIndex(index);

        Assert.AreEqual(expected, actual);
    }
    
    [TestCase(new int[] {8,4,5,6,3,7} ,new int[] {1,2,3,8,4,5,6,3,7},3)]
    [TestCase(new int[] {} ,new int[] {3},1)]
    public void RemoveFewElementsFromStartTests(int[] expectedList,int[] actualList, int value)
    {
        LinkedList expected = new LinkedList(expectedList);
        LinkedList actual = new LinkedList(actualList);
        actual.RemoveFewElementsFromStart(value);

        Assert.AreEqual(expected, actual);
    }
    
        
    [TestCase(new int[] {1,2,3,8,4,5} ,new int[] {1,2,3,8,4,5,6,3,7},3)]
    // [TestCase(new int[] {1,2,3} ,new int[] {1,2,3,8,4,5,6,3,7},6)]
    // [TestCase(new int[] {} ,new int[] {3},1)]
    public void RemoveFewElementsFromEndTests(int[] expectedList,int[] actualList, int value)
    {
        LinkedList expected = new LinkedList(expectedList);
        LinkedList actual = new LinkedList(actualList);
        actual.RemoveFewElementsFromEnd(value);

        Assert.AreEqual(expected, actual);
    }
    
    [TestCase(new int[] {1,2,3,5,6,3,7} ,new int[] {1,2,3,8,4,5,6,3,7},3,2)]
    [TestCase(new int[] {1,2,6,3,7} ,new int[] {1,2,3,8,4,5,6,3,7},2,4)]
    // [TestCase(new int[] {} ,new int[] {3},1,1)]
    public void RemoveFewElementsByIndexTests(int[] expectedList,int[] actualList, int index,int value)
    {
        LinkedList expected = new LinkedList(expectedList);
        LinkedList actual = new LinkedList(actualList);
        actual.RemoveFewElementsByIndex(index,value);

        Assert.AreEqual(expected, actual);
    }
    
    [TestCase(new int[] {7,3,6,5,4,3,2,1} ,new int[] {1,2,3,4,5,6,3,7})]
    // [TestCase(new int[] {} ,new int[] {3},1,1)]
    public void ListReverse(int[] expectedList,int[] actualList)
    {
        LinkedList expected = new LinkedList(expectedList);
        LinkedList actual = new LinkedList(actualList);
        actual.ListReverse();

        Assert.AreEqual(expected, actual);
    }
    [TestCase(8)]
    public void FindMaxValueTests(int expected)
    {
        LinkedList linkedList = new LinkedList(new int[] {1,2,3,8,4,5,6,3,7});
        int actual = linkedList.FindMaxValue();
    
        Assert.AreEqual(expected, actual);
    }
    [TestCase(1)]
    public void FindMinValueTests(int expected)
    {
        LinkedList linkedList = new LinkedList(new int[] {1,2,3,8,4,5,6,3,7});
        int actual = linkedList.FindMinValue();
    
        Assert.AreEqual(expected, actual);
    }
    [TestCase(0)]
    public void FindIndexMinValueTests(int expected)
    {
        LinkedList linkedList = new LinkedList(new int[] {1,2,3,8,4,5,6,3,7});
        int actual = linkedList.FindIndexOfMinValue();
    
        Assert.AreEqual(expected, actual);
    }
    [TestCase(3)]
    public void FindIndexMaxValueTests(int expected)
    {
        LinkedList linkedList = new LinkedList(new int[] {1,2,3,8,4,5,6,3,7});
        int actual = linkedList.FindIndexOfMaxValue();
    
        Assert.AreEqual(expected, actual);
    }
    [TestCase(new int[] {8,7,6,5,4,3,3,2,1} ,new int[] {1,2,3,8,4,5,6,3,7})]
    public void SortToMinTests(int[] expectedList,int[] actualList)
    {
        LinkedList expected = new LinkedList(expectedList);
        LinkedList actual = new LinkedList(actualList);
        actual.SortToMin();

        Assert.AreEqual(expected, actual);
    }
    [TestCase(new int[] {1,2,3,3,4,5,6,7,8} ,new int[] {1,2,3,8,4,5,6,3,7})]
    public void SortToMaxTests(int[] expectedList,int[] actualList)
    {
        LinkedList expected = new LinkedList(expectedList);
        LinkedList actual = new LinkedList(actualList);
        actual.SortToMax();

        Assert.AreEqual(expected, actual);
    }
    [TestCase(3,8)]
    public void DeleteByValueReturnIndexTests(int expected,int value)
    {
        LinkedList linkedList = new LinkedList(new int[] {1,2,3,8,4,5,6,3,7});
        int actual = linkedList.DeleteByValueReturnIndex(value);
        int index;
    
        Assert.AreEqual(expected, actual);
    }
    [TestCase(2,3)]
    public void DeleteByValuesReturnCountTests(int expected,int value)
    {
        LinkedList linkedList = new LinkedList(new int[] {1,2,3,8,4,5,6,3,7});
        int actual = linkedList.DeleteByValuesReturnCount(value);
        int index;
    
        Assert.AreEqual(expected, actual);
    }
    // [TestCase(0,1)]
    // [TestCase(1,2)]
    // [TestCase(2,3)]
    // public void GetNodeByIndexTest(int index, int expected)
    // {
    //     LinkedList a = new LinkedList(new int[] { 1, 2, 3 });
    //     int actual = a[index];
    //
    //     Assert.AreEqual(expected, actual);

    // }
}