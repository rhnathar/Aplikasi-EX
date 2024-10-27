using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Aplikasi_EX.Model;
using System.Windows;

public class UserViewModel
{
    private UserRepository _userRepository;
    public ObservableCollection<User> Users { get; set; }

    public UserViewModel()
    {
        _userRepository = new UserRepository();
        Users = new ObservableCollection<User>();
    }

    public void LoadUsers()
    {
        try
        {
            var userList = _userRepository.GetUsers();
            foreach (var user in userList)
            {
                Users.Add(user);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error loading users: " + ex.Message);
        }
    }
}
