using Lists.Classes;

namespace Lists.Tests;

public class LinkedListTests
{
    [Test]
    public void LinkedTest()
    {
        LinkedList a = new LinkedList(new int[] { 1, 2, 3 });
        LinkedList b = new LinkedList(new int[] { 1, 2, 3 });
        
        Assert.AreEqual(a,b);

    }
    [TestCase(new int[] {3}, new int[]{1,3})]
    public void RemoveFirst(int[] expectedArray, int[] actualArray)
    {
        LinkedList expected = new LinkedList(expectedArray);
        LinkedList actual = new LinkedList(actualArray);
        actual.RemoveFirst();
        
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