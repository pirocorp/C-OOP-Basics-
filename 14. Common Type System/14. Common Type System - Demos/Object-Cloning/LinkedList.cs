using System;
using System.Text;

class LinkedList<T> : ICloneable
{
	public T Value { get; set; }
	public LinkedList<T> NextNode { get; private set; }

	public LinkedList(T value, LinkedList<T> nextNode = null)
	{
		this.Value = value;
		this.NextNode = nextNode;
	}

	object ICloneable.Clone()  // Implicit interface implementation
	{
		return this.Clone();
	}

	public LinkedList<T> ShallowCopy()
	{
		return this;
	}

	public LinkedList<T> MemberwiseCopy()
	{
		return (LinkedList<T>)this.MemberwiseClone();
	}

	public LinkedList<T> Clone() // Deep cloning (public method)
	{
		// Copy the first element
		var original = this;
		var valueOriginal = original.Value;
		var result = new LinkedList<T>(Value);
		var copy = result;
		original = original.NextNode;

		// Copy the rest of the elements
		while (original != null)
		{
			valueOriginal = original.Value;
			copy.NextNode = new LinkedList<T>(valueOriginal);
			original = original.NextNode;
			copy = copy.NextNode;
		}
		return result;
	}

	public override string ToString()
	{
		var currentNode = this;
		var sb = new StringBuilder("(");
		while (currentNode != null)
		{
			sb.Append(currentNode.Value);
			currentNode = currentNode.NextNode;
			if (currentNode != null)
			{
				sb.Append(", ");
			}
		}
		sb.Append(")");
		return sb.ToString();
	}
}
