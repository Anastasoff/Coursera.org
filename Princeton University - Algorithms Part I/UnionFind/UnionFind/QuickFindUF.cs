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