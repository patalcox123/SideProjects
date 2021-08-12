using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class PropertySqlDao : IPropertyDao
    {
        private readonly string connectionString;
        public PropertySqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Property> GetProperties()
        {
            List<Property> properties = new List<Property>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT p.property_id, p.landlord_id, p.description, p.address_line_one, " +
                        "p.address_line_two, p.city, p.state_abbreviation, p.zip_code, p.price, p.date_available, " +
                        "p.available, p.beds, p.baths, i.image_link FROM properties p " +
                        "JOIN images i ON p.property_id = i.property_id WHERE i.thumbnail = 1;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        properties.Add(GetPropertyFromReader(reader));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return properties;
        }

        public Property GetProperty(int id)
        {
            Property property = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT p.property_id, p.landlord_id, p.description, p.address_line_one, " +
                        "p.address_line_two, p.city, p.state_abbreviation, p.zip_code, p.price, p.date_available, " +
                        "p.available, p.beds, p.baths, i.image_link FROM properties p " +
                        "JOIN images i ON p.property_id = i.property_id " +
                        "WHERE p.property_id = @property_id AND i.thumbnail = 1;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@property_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        property = GetPropertyFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return property;
        }

        public int AddProperty(Property property)
        {
            int propertyId = 0;

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                    string sql = "";

                    if (property.AddressLineTwo != "")
                    {
                        sql = "INSERT INTO properties (landlord_id, description, address_line_one, " +
                            "address_line_two, city, state_abbreviation, zip_code, price, date_available, " +
                            "available, beds, baths) OUTPUT INSERTED.property_id VALUES (@landlord_id, " +
                            "@description, @address_line_one, @address_line_two, @city, @state_abbreviation, " +
                            "@zip_code, @price, @date_available, @available, @beds, @baths);";
                    }
                    else
                    {
                        sql = "INSERT INTO properties (landlord_id, description, address_line_one, " +
                            "city, state_abbreviation, zip_code, price, date_available, " +
                            "available, beds, baths) OUTPUT INSERTED.property_id VALUES (@landlord_id, " +
                            "@description, @address_line_one, @city, @state_abbreviation, " +
                            "@zip_code, @price, @date_available, @available, @beds, @baths);";
                    }
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@landlord_id", property.LandlordId);
                    cmd.Parameters.AddWithValue("@description", property.Description);
                    cmd.Parameters.AddWithValue("@address_line_one", property.AddressLineOne);
                    if (property.AddressLineTwo != "")
                    {
                        cmd.Parameters.AddWithValue("@address_line_two", property.AddressLineTwo);
                    }
                    cmd.Parameters.AddWithValue("@city", property.City);
                    cmd.Parameters.AddWithValue("@state_abbreviation", property.State);
                    cmd.Parameters.AddWithValue("@zip_code", property.ZipCode);
                    cmd.Parameters.AddWithValue("@price", property.Price);
                    cmd.Parameters.AddWithValue("@date_available", property.DateAvailable);
                    cmd.Parameters.AddWithValue("@available", property.Available);
                    cmd.Parameters.AddWithValue("@beds", property.Beds);
                    cmd.Parameters.AddWithValue("@baths", property.Baths);

                    propertyId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (SqlException e)
                {
                    string error = e.Message;
                    throw;
                }

            return propertyId;
        }
        public Property GetPropertyByRenterId(int id)
        {
            Property property = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT p.property_id, p.landlord_id, p.description, p.address_line_one, p.address_line_two, p.city, " +
                                 "p.state_abbreviation, p.zip_code, p.price, p.date_available, p.available, " +
                                 "p.beds, p.baths, i.image_link " +
                                 "FROM properties p " +
                                 "JOIN images i ON p.property_id = i.property_id " +
                                 "JOIN renters_properties r ON r.property_id = p.property_id " +
                                 "WHERE r.renter_id = @renter_id AND i.thumbnail = 1";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@renter_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        property = GetPropertyFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return property;
        }
    
        public int UpdateProperty(Property property)
        {
            // Will use to track the number of rows affected
            int success = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "";

                    if (property.AddressLineTwo != null)
                    {
                        sql = "UPDATE properties SET landlord_id = @landlord_id, " +
                            "description = @description, address_line_one = @address_line_one, " +
                            "address_line_two = @address_line_two, city = @city, " +
                            "state_abbreviation = @state_abbreviation, zip_code = @zip_code, " +
                            "price = @price, date_available = @date_available, available = @available, " +
                            "beds = @beds, baths = @baths WHERE property_id = @property_id;";
                    }
                    else
                    {
                        sql = "UPDATE properties SET landlord_id = @landlord_id, " +
                            "description = @description, address_line_one = @address_line_one, " +
                            "address_line_two = NULL, city = @city, " +
                            "state_abbreviation = @state_abbreviation, zip_code = @zip_code, " +
                            "price = @price, date_available = @date_available, available = @available, " +
                            "beds = @beds, baths = @baths WHERE property_id = @property_id;";
                    }
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@property_id", property.PropertyId);
                    cmd.Parameters.AddWithValue("@landlord_id", property.LandlordId);
                    cmd.Parameters.AddWithValue("@description", property.Description);
                    cmd.Parameters.AddWithValue("@address_line_one", property.AddressLineOne);
                    if (property.AddressLineTwo != null)
                    {
                        cmd.Parameters.AddWithValue("@address_line_two", property.AddressLineTwo);
                    }
                    cmd.Parameters.AddWithValue("@city", property.City);
                    cmd.Parameters.AddWithValue("@state_abbreviation", property.State);
                    cmd.Parameters.AddWithValue("@zip_code", property.ZipCode);
                    cmd.Parameters.AddWithValue("@price", property.Price);
                    cmd.Parameters.AddWithValue("@date_available", property.DateAvailable);
                    cmd.Parameters.AddWithValue("@available", property.Available);
                    cmd.Parameters.AddWithValue("@beds", property.Beds);
                    cmd.Parameters.AddWithValue("@baths", property.Baths);

                    success = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return success;
        }

        public int DeleteProperty(int id)
        {
            // Used to count number of rows affected
            int success = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM applications WHERE property_id = @property_id;" +
                        "DELETE FROM tasks WHERE property_id = @property_id;" +
                        "DELETE FROM renters_properties WHERE property_id = @property_id;" +
                        "DELETE FROM properties WHERE property_id = @property_id;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@property_id", id);
                    success = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return success;
        }

        public Property GetPropertyFromReader(SqlDataReader reader)
        {
            Property p = new Property()
            {
                PropertyId = Convert.ToInt32(reader["property_id"]),
                LandlordId = Convert.ToInt32(reader["landlord_id"]),
                Description = Convert.ToString(reader["description"]),
                AddressLineOne = Convert.ToString(reader["address_line_one"]),
                AddressLineTwo = Convert.ToString(reader["address_line_two"]),
                City = Convert.ToString(reader["city"]),
                State = Convert.ToString(reader["state_abbreviation"]),
                ZipCode = Convert.ToString(reader["zip_code"]),
                Price = Convert.ToDecimal(reader["price"]),
                DateAvailable = Convert.ToDateTime(reader["date_available"]).ToString("yyyy-MM-dd"),
                Available = Convert.ToBoolean(reader["available"]),
                Beds = Convert.ToInt32(reader["beds"]),
                Baths = Convert.ToDouble(reader["baths"]),
                Thumbnail = Convert.ToString(reader["image_link"])
            };

            return p;
        }

    }
}
