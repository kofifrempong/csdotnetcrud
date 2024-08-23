using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace crudInMacos
{
    
  
    public class PersonRepository
    {
        private string _connectionString { get; set; }
        public PersonRepository()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true,reloadOnChange:true)
                .AddEnvironmentVariables()
                .Build();
            _connectionString = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
        }
        public void Create(String name, int age)
        {


            MySqlTransaction mySqlTransaction = null;
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {

                    connection.Open();

                    mySqlTransaction = connection.BeginTransaction();

                    string SQL = "INSERT INTO person VALUES (null,@name,@age);";
                    MySqlCommand mySqlCommand = new MySqlCommand(SQL, connection);

                    mySqlCommand.Parameters.AddWithValue("@name", name);
                    mySqlCommand.Parameters.AddWithValue("@age", age);
                    mySqlCommand.ExecuteNonQuery();

                    mySqlTransaction.Commit();

                    mySqlCommand.Dispose();

                }
                catch(MySqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);

                }
            }


          

        }
        public List<PersonModel> Read()
        {
            List<PersonModel> personModels = new();



            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {

                    connection.Open();
                    string SQL = "SELECT * FROM person ";
                    MySqlCommand mySqlCommand = new MySqlCommand(SQL, connection);
                    using (var reader = mySqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            personModels.Add(new PersonModel()
                            {
                                
                                Name = reader["name"].ToString(),
                                Age = Convert.ToInt32(reader["age"]),
                                PersonId = Convert.ToInt32(reader["personId"])
                            });
                        }
                    }



                    mySqlCommand.Dispose();

                }
                catch (MySqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }


            return personModels;
        }
        public void Update(String name, int age, int personId)
        {

            MySqlTransaction mySqlTransaction = null;
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {

                    connection.Open();
                    mySqlTransaction = connection.BeginTransaction();

                    string SQL = "UPDATE person SET name = @name, age = @age WHERE personId = @personId ";
                    MySqlCommand mySqlCommand = new MySqlCommand(SQL, connection);

                    mySqlCommand.Parameters.AddWithValue("@name", name);
                    mySqlCommand.Parameters.AddWithValue("@age", age);
                    mySqlCommand.Parameters.AddWithValue("@personId", personId);

                    mySqlCommand.ExecuteNonQuery();

                    mySqlTransaction.Commit();

                    mySqlCommand.Dispose();

                }
                catch (MySqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);

                }
            }
        }
        public void Delete(int personId)
        {


            MySqlTransaction mySqlTransaction = null;

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {

                    connection.Open();

                    mySqlTransaction = connection.BeginTransaction();

                    string SQL = "DELETE FROM person WHERE personId  = @personId;";
                    MySqlCommand mySqlCommand = new MySqlCommand(SQL, connection);

                    mySqlCommand.Parameters.AddWithValue("@personId", personId);
                    mySqlCommand.ExecuteNonQuery();

                    mySqlTransaction.Commit();

                    mySqlCommand.Dispose();

                }
                catch (MySqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }
    }
  
}
