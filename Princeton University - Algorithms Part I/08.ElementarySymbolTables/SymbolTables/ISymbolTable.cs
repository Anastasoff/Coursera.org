namespace SymbolTables
{
    using System.Collections.Generic;

    /// <summary>
    /// Basic symbol table API.
    /// </summary>
    public interface ISymbolTable<Key, Value>
    {
        /// <summary>
        /// Put key-value pair into the table (remove key from table if value is null)
        /// </summary>
        void Put(Key key, Value value);

        /// <summary>
        /// Value paired with key (null if key is absent)
        /// </summary>
        Value Get(Key key);

        /// <summary>
        /// Remove key (and its value) from table
        /// </summary>
        void Delete(Key key);

        /// <summary>
        /// Is there a value paired with key?
        /// </summary>
        bool Contains(Key key);

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
        IEnumerable<Key> Keys();
    }
}