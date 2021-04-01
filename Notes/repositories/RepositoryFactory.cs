using System;
namespace Notes.repositories
{
    public class RepositoryFactory: Repository.Factory
    {
        public RepositoryFactory()
        {
        }

        public T create<T>() where T : Repository
        {
            if(typeof(T) == typeof(NoteRepository))
            {
                return new NoteRepository() as T;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
