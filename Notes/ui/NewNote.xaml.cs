using System;
using Notes.viewModels;
using Xamarin.Forms;

namespace Notes.ui
{
    public partial class NewNote : ContentPage
    {
      
        public NewNote()
        {
            InitializeComponent();
            BindingContext = new NewNoteViewModel(Navigation);
        }      
    }
}
