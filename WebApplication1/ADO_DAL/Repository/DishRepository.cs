using ADO_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ADO_DAL
{
    public class DishRepository: IDishRepository
    {
        private readonly string CS = "Server=IOFAREG;Database=SaladBar;Trusted_Connection=True";

        public IList<Dish> GetDishes()
        {
            List<Dish> dishes = new List<Dish>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetDishes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var dish = new Dish()
                    {
                        Dish_id = Convert.ToInt32(rdr["Dish_id"]),
                        Name = rdr["Name"].ToString(),
                        Description = rdr["Description"].ToString(),
                        Weight = Convert.ToInt32(rdr["Weight"]),
                        Price = Convert.ToInt32(rdr["Price"])
                    };
                    dishes.Add(dish);
                }
                return (dishes);
            }
        }

        public Dish GetDishById(int? id)
        {
            Dish dish = new Dish();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetDishById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    dish.Dish_id = Convert.ToInt32(rdr["Dish_id"]);
                    dish.Name = rdr["Name"].ToString();
                    dish.Description = rdr["Description"].ToString();
                    dish.Weight = Convert.ToInt32(rdr["Weight"]);
                    dish.Price = Convert.ToInt32(rdr["Price"]);
                }
                return dish;
            }
        }

        public Dish CreateDish(Dish dish)
        {
            List<Dish> dishes = new List<Dish>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("spCreateDish", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", dish.Name);
                cmd.Parameters.AddWithValue("@description", dish.Description);
                cmd.Parameters.AddWithValue("@weight", dish.Weight);
                cmd.Parameters.AddWithValue("@price", dish.Price);
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("spGetDishes", con);
                cmd2.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd2.ExecuteReader();
                while (rdr.Read())
                {
                    var tempDish = new Dish()
                    {
                        Dish_id = Convert.ToInt32(rdr["Dish_id"]),
                        Name = rdr["Name"].ToString(),
                        Description = rdr["Description"].ToString(),
                        Weight = Convert.ToInt32(rdr["Weight"]),
                        Price = Convert.ToInt32(rdr["Price"])
                    };
                    dishes.Add(tempDish);
                }
                return dishes[dishes.Count - 1];
            }
        }

        public Dish UpdateDish(Dish dish)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("spUpdateDish", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", dish.Dish_id);
                cmd.Parameters.AddWithValue("@name", dish.Name);
                cmd.Parameters.AddWithValue("@description", dish.Description);
                cmd.Parameters.AddWithValue("@weight", dish.Weight);
                cmd.Parameters.AddWithValue("@price", dish.Price);
                cmd.ExecuteNonQuery();
            }

            Dish dish1 = new Dish();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetDishById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@id", dish.Dish_id);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    dish1.Dish_id = Convert.ToInt32(rdr["Dish_id"]);
                    dish1.Name = rdr["Name"].ToString();
                    dish1.Description = rdr["Description"].ToString();
                    dish1.Weight = Convert.ToInt32(rdr["Weight"]);
                    dish1.Price = Convert.ToInt32(rdr["Price"]);
                }
                return dish1;
            }
        }

        public bool DeleteDishById(int? id)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("spDeleteDishById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            return true;
        }

    }
}
