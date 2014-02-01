public class WeightedQuickUnionUF
{
    private int[] id;
    private int[] sz;
    private int count;

    public WeightedQuickUnionUF(int n)
    {
        this.count = n;
        this.id = new int[n];
        this.sz = new int[n];
        for (int i = 0; i < n; i++)
        {
            this.id[i] = i;
            this.sz[i] = i;
        }
    }

    public int[] Id
    {
        get
        {
            return this.id;
        }
    }

    public int Count
    {
        get
        {
            return this.count;
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
        if (this.sz[i] < this.sz[j])
        {
            this.id[i] = j;
            this.sz[j] += this.sz[i];
        }
        else
        {
            this.id[j] = i;
            this.sz[i] += this.sz[j];
        }

        this.count--;
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