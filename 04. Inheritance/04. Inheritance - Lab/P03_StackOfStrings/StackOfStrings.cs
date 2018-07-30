using System.Collections.Generic;

public class StackOfStrings
{
    private List<string> data;

    public bool IsEmpty()
    {
        return data.Count == 0;
    }

    public void Push(string newItem)
    {
        data.Add(newItem);
    }

    public string Peek()
    {
        var result = string.Empty;

        if (!IsEmpty())
        {
            var lastElementIndex = data.Count - 1;
            result = data[lastElementIndex];
        }

        return result;
    }

    public string Pop()
    {
        var result = string.Empty;

        if (!IsEmpty())
        {
            result = Peek();
            var lastElementIndex = data.Count - 1;
            data.RemoveAt(lastElementIndex);
        }

        return result;
    }
}