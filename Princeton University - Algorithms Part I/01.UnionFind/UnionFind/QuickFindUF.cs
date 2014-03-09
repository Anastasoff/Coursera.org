/// <summary>
/// The QuickFindUF class represents a union-find data structure. 
/// It supports the union and find operations, along with methods for determining whether two objects are in the same component and the total number of components. 
/// This implementation uses quick find. Initializing a data structure with N objects takes linear time. Afterwards, find, connected, and count takes constant time but union takes linear time.
/// </summary>
public class QuickFindUF
{
    private int[] id;

    public QuickFindUF(int n)
    {
        this.id = new int[n];
        for (int i = 0; i < n; i++)
        {
            this.id[i] = i;
        }
    }

    public int[] Id
    {
        get
        {
            return this.id;
        }
    }

    public bool Connected(int p, int q)
    {
        return this.id[p] == this.id[q];
    }

    public void Union(int p, int q)
    {
        int pId = this.id[p];
        int qId = this.id[q];
        for (int i = 0; i < this.id.Length; i++)
        {
            if (this.id[i] == pId)
            {
                this.id[i] = qId;
            }
        }
    }
}