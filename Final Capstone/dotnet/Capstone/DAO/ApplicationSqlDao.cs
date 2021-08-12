using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public class ApplicationSqlDao : IApplicationDao
    {
        private readonly string connectionString;
        public ApplicationSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Application> GetApplications(int landlordId)
        {
            List<Application> apps = new List<Application>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT a.application_id, a.renter_id, a.landlord_id, a.property_id, a.name, a.email, a.tenants, a.move_in_date, a.income, a.status, " +
                                 "p.address_line_one, p.address_line_two, p.city, p.state_abbreviation, p.zip_code " +
                                 "FROM applications a " +
                                 "JOIN properties p ON a.property_id = p.property_id " +
                                 "WHERE a.landlord_id = @landlordId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@landlordId", landlordId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Application app = GetAppFromReader(reader);
                        app.AddressLineOne = Convert.ToString(reader["address_line_one"]);
                        if (!reader.IsDBNull(6))
                        {
                            app.AddressLineTwo = Convert.ToString(reader["address_line_two"]);
                        }
                        app.City = Convert.ToString(reader["city"]);
                        app.State = Convert.ToString(reader["state_abbreviation"]);
                        app.ZipCode = Convert.ToString(reader["zip_code"]);
                        apps.Add(app);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return apps;
        }

        public int AddApplication(Application app)
        {
            int propertyId = app.PropertyId;
            int landlordId = 0;
            int appId = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlOne = "SELECT landlord_id FROM properties WHERE property_id = @propertyId";
                    SqlCommand cmdOne = new SqlCommand(sqlOne, conn);
                    cmdOne.Parameters.AddWithValue("@propertyId", propertyId);
                    SqlDataReader reader = cmdOne.ExecuteReader();
                    if (reader.Read())
                    {
                        landlordId = Convert.ToInt32(reader["landlord_id"]);
                    }
                }
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sqlTwo = "INSERT INTO applications (renter_id, landlord_id, property_id, name, email, tenants, move_in_date, income, status) "+
                                    "OUTPUT INSERTED.application_id VALUES(@renter_id, @landlord_id, @property_id, @name, @email, @tenants, @move_in_date, @income, @status)";
                    SqlCommand cmdTwo = new SqlCommand(sqlTwo, conn);
                    cmdTwo.Parameters.AddWithValue("@renter_id", app.RenterId);
                    cmdTwo.Parameters.AddWithValue("@landlord_id", landlordId);
                    cmdTwo.Parameters.AddWithValue("@property_id", app.PropertyId);
                    cmdTwo.Parameters.AddWithValue("@name", app.Name);
                    cmdTwo.Parameters.AddWithValue("@email", app.Email);
                    cmdTwo.Parameters.AddWithValue("@tenants", app.Tenants);
                    cmdTwo.Parameters.AddWithValue("@move_in_date", app.MoveInDate);
                    cmdTwo.Parameters.AddWithValue("@income", app.Income);
                    cmdTwo.Parameters.AddWithValue("@status", app.Status);
                    appId = Convert.ToInt32(cmdTwo.ExecuteScalar());
                }
            }
            catch (SqlException e)
            {
                string error = e.Message;
                throw;
            }

            return appId;
        }

        public int ApproveApplication(Application app)
        {
            int success = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "UPDATE applications SET status = 'Approved' " +
                        "WHERE application_id = @application_id; " +
                        "UPDATE properties SET available = 0 " +
                        "WHERE property_id = @property_id; " +
                        "INSERT INTO renters_properties (renter_id, property_id) " +
                        "VALUES (@renter_id, @property_id)";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@application_id", app.ApplicationId);
                    cmd.Parameters.AddWithValue("@renter_id", app.RenterId);
                    cmd.Parameters.AddWithValue("@property_id", app.PropertyId);

                    success = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return success;
        }

        public int RejectApplication(int id)
        {
            int success = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "UPDATE applications SET status = 'Rejected' " +
                        "WHERE application_id = @application_id;";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@application_id", id);

                    success = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return success;
        }

        public Application GetAppFromReader(SqlDataReader reader)
        {
            Application app = new Application()
            {
                ApplicationId = Convert.ToInt32(reader["application_id"]),
                RenterId = Convert.ToInt32(reader["renter_id"]),
                LandlordId = Convert.ToInt32(reader["landlord_id"]),
                PropertyId = Convert.ToInt32(reader["property_id"]),
                Name = Convert.ToString(reader["name"]),
                Email = Convert.ToString(reader["email"]),
                Tenants = Convert.ToInt32(reader["tenants"]),
                MoveInDate = Convert.ToDateTime(reader["move_in_date"]).ToString("yyyy-MM-dd"),
                Income = Convert.ToDecimal(reader["income"]),
                Status = Convert.ToString(reader["status"]),
            };

            return app;
        }
    }
}
