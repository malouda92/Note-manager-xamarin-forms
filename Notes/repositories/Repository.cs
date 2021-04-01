using System;
using Realms;

namespace Notes.repositories
{
    public class Repository
    {
        protected Realm Realm { get; set; }

        public Repository()
        {
            this.Realm = Realm.GetInstance();
        }

        public interface Factory
        {
            T create<T>() where T : Repository;
        }
    }
}
