using System;
using System.Collections.Generic;
using Notes.models;
using Notes.repositories;
using Xamarin.Forms;

namespace Notes.ui
{
    public partial class NewNote : ContentPage
    {
        private Note note;
        private NoteRepository noteRepository;

        public NewNote()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            if(TxtTitle.Text != null && TxtContent.Text != null)
            {
                note = new Note(TxtTitle.Text, TxtContent.Text);
                noteRepository = new RepositoryFactory().create<NoteRepository>();
                noteRepository.persist(note);
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Message", "Veuillez entrer le titre et le contenu de votre note", "OK");
            }
        }
    }
}
