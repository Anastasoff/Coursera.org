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