using System;
using System.Collections.Generic;
using System.Linq;
using Notes.models;

namespace Notes.repositories
{
    public class NoteRepository: Repository
    {
        public NoteRepository()
            :base()
        {
        }

        public void persist(Note note)
        {
            Realm.Write(() =>
            {
                Realm.Add<Note>(note);
            });
        }

        public IEnumerable<Note> findAll()
        {
            return Realm.All<Note>();
        }

        public Note find(string id)
        {
            return Realm.All<Note>().Where(n => n.Id.Equals(id)).First() as Note;
        }
    }
}
