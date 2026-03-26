using pr12_trpo2.Data;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr12_trpo2.Service
{
    public class UserService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;

        public static ObservableCollection<Users> Users { get; set; } = new();
        
        public UserService()
        {
            GetAll();
        }

        public void Add (Users user)
        {
            var _user = new Users
            {
                Login = user.Login,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                CreatedAt = user.CreatedAt,
            };

            _db.Add<Users>(_user);
            Commit();
            Users.Add(_user);
        }

        public int Commit() => _db.SaveChanges();

        public void GetAll()
        {
            var users = _db.Users.ToList();
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }

        public void Remove(Users user)
        {
            _db.Remove<Users>(user);
            if (Commit() > 0)
                if (Users.Contains(user))
                    Users.Remove(user);
        }
    }
}
