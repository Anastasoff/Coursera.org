/// <summary>
/// The QuickUnionUF class represents a union-find data structure. 
/// It supports the union and find operations, along with methods for determining whether two objects are in the same component and the total number of components. 
/// This implementation uses quick union. Initializing a data structure with N objects takes linear time. 
/// Afterwards,union, find, and connected take time linear time (in the worst case) and count takes constant time.
/// </summary>
public class QuickUnionUF
{
    private int[] id;

    public QuickUnionUF(int n)
    {
        this.id = new int[n];
        for (int i = 0; i < n; i++)
        {
            this.id[i] = i;
        }
    }

    public bool Connected(int p, int q)
    {
        return this.Root(p) == this.Root(q);
    }

    public void Union(int p, int q)
    {
        int i = this.Root(p);
        int j = this.Root(q);
        this.id[i] = j;
    }

    private int Root(int i)
    {
        while (i != this.id[i])
        {
            i = this.id[i];
        }

        return i;
    }
}