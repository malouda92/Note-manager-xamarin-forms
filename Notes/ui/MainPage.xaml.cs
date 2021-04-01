using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.models;
using Notes.repositories;
using Xamarin.Forms;

namespace Notes.ui
{
    public partial class MainPage : ContentPage
    {
        private NoteRepository noteRepository;
        private List<Note> notes;

        public MainPage()
        {
            InitializeComponent();

            noteRepository = new RepositoryFactory().create<NoteRepository>();
            
        }

        async void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new NewNote());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            notes = new List<Note>();
            notes = noteRepository.findAll().ToList<Note>();
            collectionView.ItemsSource = notes.OrderBy(n => n.Title).ToList();
        }

        async void collectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            if(e.CurrentSelection != null)
            {
                Note note = e.CurrentSelection.FirstOrDefault() as Note;
                DetailPage detailPage = new DetailPage();
                detailPage.BindingContext = note;
                await Navigation.PushAsync(detailPage);
            }
        }
    }
}
