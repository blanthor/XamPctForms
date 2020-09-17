using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagerAndroid.Core.Model;

namespace UserManagerAndroid.Core.DAL
{
    public class UserDatabase
    {

        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(DBConstants.DatabasePath, DBConstants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public UserDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(UserDTO).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(UserDTO)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        //...
        public Task<List<UserDTO>> GetItemsAsync()
        {
            var users = Database.Table<UserDTO>().ToListAsync();
            //UserList = new ObservableCollection<UserDTO>(conn.Table<UserDTO>().ToList());
            return users;
        }

        public Task<UserDTO> GetItemAsync(int id)
        {
            return Database.Table<UserDTO>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(UserDTO User)
        {
            if (User.Id != 0)
            {
                return Database.UpdateAsync(User);
            }
            else
            {
                return Database.InsertAsync(User);
            }
        }

        public Task<int> DeleteItemAsync(UserDTO user)
        {
            return Database.DeleteAsync(user);
        }
    }
}
