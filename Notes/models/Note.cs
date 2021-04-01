using System;
using MongoDB.Bson;
using Realms;

namespace Notes.models
{
    public class Note: RealmObject
    {
        [PrimaryKey]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        public string Title { get; set; }
        public string Content { get; set; }

        public Note()
        {
        }

        public Note(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }

        public bool isValid()
        {
            return (!Title.Equals("") && !Content.Equals(""));
        }
    }
}
