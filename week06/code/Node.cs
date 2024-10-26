using System.Net;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        if (value == Data)
        {
            return; //if the value is equal to the current data, do not do anything, just return.
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        // if it finds the value, return true and stop recursion
        if (value == Data)
            return true;
       
        if (value < Data)
        {
            //check the left side
            if (Left is null)
                return false; //reached end, no match 
            else
                return Left.Contains(value); //continue looking
        }
        else
        {
            //check the right side
            if (Right is null)
                return false; //reached end, no match
            else
                return Right.Contains(value); //continue looking
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        //set base height
        int leftHeight = 1; 
        int rightHeight = 1;

        //check if the children are not null, then add to the corresponding height
        if (Left is not null)
            leftHeight += Left.GetHeight();
        if (Right is not null)
            rightHeight += Right.GetHeight();
        
        //return the side that is highest
        if (leftHeight > rightHeight)
            return leftHeight;
        else
            return rightHeight;
    }
}