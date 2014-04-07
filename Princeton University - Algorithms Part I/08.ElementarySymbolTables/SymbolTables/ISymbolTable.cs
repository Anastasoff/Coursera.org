namespace SymbolTables
{
    using System.Collections.Generic;

    /// <summary>
    /// Basic symbol table API.
    /// </summary>
    public interface ISymbolTable<TKey, TValue>
    {
        /// <summary>
        /// Put key-value pair into the table (remove key from table if value is null)
        /// </summary>
        void Put(TKey key, TValue value);

        /// <summary>
        /// Value paired with key (null if key is absent)
        /// </summary>
        TValue Get(TKey key);

        /// <summary>
        /// Remove key (and its value) from table
        /// </summary>
        void Delete(TKey key);

        /// <summary>
        /// Is there a value paired with key?
        /// </summary>
        bool Contains(TKey key);

        /// <summary>
        /// Is the table empty?
        /// </summary>
        bool IsEmpty();

        /// <summary>
        /// Number of key-value pairs in the table.
        /// </summary>
        int Size();

        /// <summary>
        /// All the keys in the table.
        /// </summary>
        IEnumerable<TKey> Keys();
    }
}