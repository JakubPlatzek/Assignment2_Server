using System.Collections.Generic;

namespace Assignment2_Server.Persistence
{
    public interface IFileContext
    {
        IList<T> ReadData<T>(string s);
        void SaveChanges();  
    }
}