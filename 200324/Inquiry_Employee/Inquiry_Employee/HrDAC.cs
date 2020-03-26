using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace Inquiry_Employee
{
    class HrDAC
    {
        private string connectionString;
        private static readonly HrDAC instance = new HrDAC();

        private HrDAC()
        {
            connectionString = Properties.Settings.Default.ConnectionString;
        }

        public static HrDAC Instance
        {
            get
            {
                return instance;
            }
        }
        public Employee GetEmployee(long id)
        {
            Employee employee = new Employee();

            string sql = "SELECT * FROM EMPLOYEES WHERE EMPLOYEE_ID=:EMPLOYEE_ID";
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                OracleCommand cmd = new OracleCommand(sql, conn)
                {
                    CommandType = System.Data.CommandType.Text,
                    BindByName = true
                };
                cmd.Parameters.Add(":EMPLOYEE_ID", OracleDbType.Long).Value = id;
                conn.Open();

                using (OracleDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.SingleRow))
                {
                    if (reader.Read())
                    {
                        employee.Employee_id = reader.GetInt64(reader.GetOrdinal("EMPLOYEE_ID"));
                        employee.First_name = reader.GetString(1);
                        employee.Last_name = reader.GetString(2);
                        employee.Email = reader.GetString(3);
                        employee.Phone_number = reader.GetString(4);
                        employee.Hire_date = reader.GetDateTime(5);
                        employee.Job_id = reader.GetString(6);
                        employee.Salary = reader.GetDouble(7);
                        employee.Commission = reader.IsDBNull(8)? 0.0 : reader.GetDouble(8);
                        employee.Department_ID = reader.GetInt32(9);
                        employee.Manager_ID = reader.GetInt32(10);
                    }
                }
            }

            return employee;

        }
    }
}
