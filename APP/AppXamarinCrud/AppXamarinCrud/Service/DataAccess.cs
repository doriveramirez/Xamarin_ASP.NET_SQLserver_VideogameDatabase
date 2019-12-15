using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xamarin.Forms;
using System.IO;
using AppXamarinCrud.Model;
using SQLite;
using VideogameDatabase.Model;

namespace VideogameDatabase.Service
{
    class DataAccess : IDisposable
    {
        private SQLiteConnection connection;

        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            connection = new SQLiteConnection(Path.Combine(config.DirDB, "VideogamesDB.db3"), false);
            connection.CreateTable<Distributor>();
            connection.CreateTable<Company>();
            //connection.CreateTable<Platform>();
            //connection.CreateTable<Review>();
            connection.CreateTable<User>();
            connection.CreateTable<Videogame>();
        }

        public void InsertDistributor(Distributor distributor)
        {
            connection.Insert(distributor);
        }

        public void ModifyDistributor(Distributor distributor)
        {
            connection.Update(distributor);
        }

        public void DeleteDistributor(Distributor distributor)
        {
            connection.Delete(distributor);
        }

        public Distributor GetDistributor(int IDDistributor)
        {
            return connection.Table<Distributor>().FirstOrDefault(c => c.Id.Equals(IDDistributor));
        }

        public List<Distributor> GetDistributors()
        {
            return connection.Table<Distributor>().OrderBy(c => c.Name).ToList();
        }

        public void InsertCompany(Company company)
        {
            connection.Insert(company);
        }

        public void ModifyCompany(Company company)
        {
            connection.Update(company);
        }

        public void DeleteCompany(Company company)
        {
            connection.Delete(company);
        }

        public Company GetCompany(int IDCompany)
        {
            return connection.Table<Company>().FirstOrDefault(c => c.Id.Equals(IDCompany));
        }

        public List<Company> GetCompanies()
        {
            return connection.Table<Company>().OrderBy(c => c.Name).ToList();
        }

        public void InsertPlatform(Platform platform)
        {
            connection.Insert(platform);
        }

        public void ModifyPlatform(Platform platform)
        {
            connection.Update(platform);
        }

        public void DeletePlatform(Platform platform)
        {
            connection.Delete(platform);
        }

        public Platform GetPlatform(int IDPlatform)
        {
            return connection.Table<Platform>().FirstOrDefault(c => c.Id.Equals(IDPlatform));
        }

        public List<Platform> GetPlatforms()
        {
            return connection.Table<Platform>().OrderBy(c => c.Name).ToList();
        }

        public void InsertReview(Review review)
        {
            connection.Insert(review);
        }

        public void ModifyReview(Review review)
        {
            connection.Update(review);
        }

        public void DeleteReview(Review review)
        {
            connection.Delete(review);
        }

        public Review GetReview(int IDReview)
        {
            return connection.Table<Review>().FirstOrDefault(c => c.Id.Equals(IDReview));
        }

        public List<Review> GetReviews()
        {
            return connection.Table<Review>().OrderBy(c => c.Mark).ToList();
        }

        public void InsertUser(User user)
        {
            connection.Insert(user);
        }

        public void ModifyUser(User user)
        {
            connection.Update(user);
        }

        public void DeleteUser(User user)
        {
            connection.Delete(user);
        }

        public User GetUser(int IDUser)
        {
            return connection.Table<User>().FirstOrDefault(c => c.Id.Equals(IDUser));
        }

        public List<User> GetUsers()
        {
            return connection.Table<User>().OrderBy(c => c.Name).ToList();
        }

        public void InsertVideogame(Videogame videogame)
        {
            connection.Insert(videogame);
        }

        public void ModifyVideogame(Videogame videogame)
        {
            connection.Update(videogame);
        }

        public void DeleteVideogame(Videogame videogame)
        {
            connection.Delete(videogame);
        }

        public Videogame GetVideogame(int IDVideogame)
        {
            return connection.Table<Videogame>().FirstOrDefault(c => c.Id.Equals(IDVideogame));
        }

        public List<Videogame> GetVideogames()
        {
            return connection.Table<Videogame>().OrderBy(c => c.Name).ToList();
        }

        public Connection GetConnection()
        {
            return connection.Table<Connection>().FirstOrDefault(c => c.Id.Equals(0));
        }

        public void InsertConnection(Connection con)
        {
            connection.Delete(connection.Table<Connection>().FirstOrDefault(c => c.Id.Equals(0)));
            connection.Insert(con);
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
