﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShelf.API.XML;
using Mendo.UWP.Common;
using System.Collections.ObjectModel;
using MyShelf.API.Services;

namespace MyShelf.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        public string Id { get { return Get<string>(); } set { Set(value); } }
        public string Name { get { return Get<string>(); } set { Set(value); } }
        public string ImageUrl { get { return Get<string>(); } set { Set(value); } }
        public string Link { get { return Get<string>(); } set { Set(value); } }
        public string Age { get { return Get<string>(); } set { Set(value); } }
        public string About { get { return Get<string>(); } set { Set(value); } }
        public string Gender { get { return Get<string>(); } set { Set(value); } }
        public string Location { get { return Get<string>(); } set { Set(value); } }
        public string Website { get { return Get<string>(); } set { Set(value); } }
        public string Joined { get { return Get<string>(); } set { Set(value); } }
        public string LastActive { get { return Get<string>(); } set { Set(value); } }
        public string Interests { get { return Get<string>(); } set { Set(value); } }
        public string FavouriteBooks { get { return Get<string>(); } set { Set(value); } }
        public string GroupsCount { get { return Get<string>(); } set { Set(value); } }
        public string FriendsCount { get { return Get<string>(); } set { Set(value); } }
        public string BooksCount { get { return Get<string>(); } set { Set(value); } }

        public ObservableCollection<UserStatusViewModel> CurrentlyReading { get; set; } = new ObservableCollection<UserStatusViewModel>();
        public ObservableCollection<UpdateViewModel> Updates { get; set; } = new ObservableCollection<UpdateViewModel>();
        public ObservableCollection<ShelfViewModel> Shelves { get; set; } = new ObservableCollection<ShelfViewModel>();

        public bool IsLoading { get { return GetV(false); } set { Set(value); } }

        public UserViewModel(User friend)
        {
            PopulateData(friend);

            if (String.IsNullOrEmpty(friend.Id) && !String.IsNullOrEmpty(friend.ImageUrl) && !friend.ImageUrl.Contains("nophoto"))
                Id = System.IO.Path.GetFileNameWithoutExtension(friend.ImageUrl);
            else
                Id = friend.Id;
        }

        public UserViewModel(string id)
        {
            GetUserInfoAsync(id);
        }

        private async Task GetUserInfoAsync(string id)
        {
            IsLoading = true;
            var user = await UserService.Instance.GetUserInfo(id);

            PopulateData(user);
            IsLoading = false;
        }

        private void PopulateData(User friend)
        {
            Id = friend.Id;
            Name = friend.Name;
            ImageUrl = friend.ImageUrl;
            Link = friend.Link;
            Age = friend.Age;
            About = friend.About;
            Gender = friend.Gender;
            Location = friend.Location;
            Website = friend.Website;
            Joined = friend.Joined;
            LastActive = friend.LastActive;
            Interests = friend.Interests;
            FavouriteBooks = friend.FavoriteBooks;
            FriendsCount = $"{friend.FriendsCount} Friends";
            BooksCount = $"{friend.ReviewsCount} Books";
            GroupsCount = $"{friend.GroupsCount} Groups";

            //Task.Run( async () =>
            try
            {
                CurrentlyReading.Clear();
                if (friend.UserStatuses != null && friend.UserStatuses.Count > 0)
                {
                    foreach (var userStatus in friend.UserStatuses)
                        CurrentlyReading.Add(new UserStatusViewModel(userStatus));
                }

                Updates.Clear();
                if (friend.Updates != null && friend.Updates.Update != null && friend.Updates.Update.Count > 0)
                {
                    foreach (var userUpdate in friend.Updates.Update)
                        Updates.Add(new UpdateViewModel(userUpdate));
                }

                Shelves.Clear();
                if (friend.UserShelves != null && friend.UserShelves.Count > 0)
                {
                    foreach (var shelf in friend.UserShelves)
                        Shelves.Add(new ShelfViewModel(shelf));
                }
            }//);
            catch { }
        }

        public void UserClick()
        {
            NavigationService.Navigate(typeof(Pages.UserPage), Id);
        }

        public void BooksClick()
        {
        }

        public void FriendsClick()
        {
        }
    }
}
