using System;
using System.Windows.Input;
using Notes.models;
using Notes.repositories;
using Xamarin.Forms;

namespace Notes.viewModels
{
    public class NewNoteViewModel: BindableObject
    {
        public INavigation Navigation { get; set; }
        private Note note = new Note();
        public Note Note
        {
            get => note;
            set
            {
                note = value;
                OnPropertyChanged(nameof(note));
            }
        }
        public Command SaveNewNote { get; }
        public NoteRepository NoteRepository { get; set; }

        public NewNoteViewModel(INavigation navigation)
        {
            Navigation = navigation;
            NoteRepository = new NoteRepository();
            SaveNewNote = new Command(OnSaveCommand);
        }

        public async void OnSaveCommand()
        {
            NoteRepository.persist(Note);
            await Navigation.PopToRootAsync();
        }
    }
}
