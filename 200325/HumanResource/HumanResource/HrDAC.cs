using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace HumanResource
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

            string sql = "SELECT E1.EMPLOYEE_ID 이름,E1.FIRST_NAME 성,E1.LAST_NAME 이름,E1.EMAIL,e1.PHONE_NUMBER,E1.HIRE_DATE,J.JOB_TITLE,E1.SALARY,E1.COMMISSION_PCT,E2.FIRST_NAME 매니저, D.DEPARTMENT_NAME" +
                        " FROM EMPLOYEES E1 left JOIN EMPLOYEES E2 ON E1.MANAGER_ID = E2.EMPLOYEE_ID" +
                        " left JOIN DEPARTMENTS D ON E1.DEPARTMENT_ID = D.DEPARTMENT_ID" +
                        " JOIN JOBS J ON J.JOB_ID = E1.JOB_ID   WHERE e1.EMPLOYEE_ID = :EMPLOYEE_ID"; 

            //string sql = "SELECT * FROM EMPLOYEES WHERE EMPLOYEE_ID=:EMPLOYEE_ID";
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
                        employee.Employee_id = reader.GetInt64(0);
                        employee.First_name = reader.GetString(1);
                        employee.Last_name = reader.GetString(2);
                        employee.Email = reader.GetString(3);
                        employee.Phone_number = reader.GetString(4);
                        employee.Hire_date = reader.GetDateTime(5);
                        employee.Job_id = reader.GetString(6);
                        employee.Salary = reader.GetDouble(7);
                        employee.Commission = reader.IsDBNull(8) ? 0.0 : reader.GetDouble(8);
                        employee.Manager_ID = reader.IsDBNull(9) ? "0" : reader.GetString(9);
                        employee.Department_ID = reader.IsDBNull(10) ? "0" : reader.GetString(10);
                    }
                }
            }

            return employee;
        }

        public ICollection<Employee> GetEmployeeList()
        {
            ICollection<Employee> empList = new List<Employee>();
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    OracleCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.TableDirect;
                    cmd.CommandText = "Employees";
                    conn.Open();

                    using(OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = new Employee();
                            employee.Employee_id = reader.GetInt64(reader.GetOrdinal("EMPLOYEE_ID"));
                            employee.First_name = reader.GetString(1);
                            employee.Last_name = reader.GetString(2);
                            employee.Email = reader.GetString(3);
                            employee.Phone_number = reader.GetString(4);
                            employee.Hire_date = reader.GetDateTime(5);
                            employee.Job_id = reader.GetString(6);
                            employee.Salary = reader.GetDouble(7);
                            employee.Commission = reader.IsDBNull(8) ? 0.0 : reader.GetDouble(8);
                            employee.Manager_ID = reader.IsDBNull(9) ? "0" : reader.GetInt32(9).ToString();
                            employee.Department_ID = reader.IsDBNull(10) ? "0" : reader.GetInt32(10).ToString();

                            empList.Add(employee);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return empList;
        }
        public ICollection<DataMapper> getHistory(int empNo)
        {
            DataTable dt = new DataTable();
            ICollection<DataMapper> listMapper = new List<DataMapper>();
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    OracleCommand cmd = conn.CreateCommand();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CURSOR_PKG.SP_JOB_HISTORY";
                    cmd.Parameters.Add(
                        new OracleParameter("IN_EMPLOYYE_ID", OracleDbType.Int32, empNo, System.Data.ParameterDirection.Input));
                    cmd.Parameters.Add(
                        new OracleParameter("OUT_CURSOR", OracleDbType.RefCursor,
                        System.Data.ParameterDirection.Output
                        ));
                    cmd.Connection = conn;

                    OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);
                    oracleDataAdapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        foreach(DataRow row in dt.Rows)
                        {
                            DataMapper mapper = new DataMapper();
                            mapper.StringValue1 = row[0].ToString();
                            mapper.StringValue2 = row[1].ToString();

                            DateTime.TryParse(row[2].ToString(),out DateTime dateTime);
                            mapper.DateTimeValue1 = dateTime;

                            DateTime.TryParse(row[3].ToString(), out dateTime);
                            mapper.DateTimeValue2 = dateTime;

                            listMapper.Add(mapper);
                        }
                    }
                    else
                    {
                        MessageBox.Show("데이터가 없습니다.");
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return listMapper;
        }

        public DataSet getInfo()
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    OracleCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.TableDirect;
                    cmd.CommandText = "Locations";
                    cmd.Connection = conn;

                    OracleDataAdapter oracleAdapter = new OracleDataAdapter(cmd);

                    oracleAdapter.Fill(dataSet, "Locations");

                    cmd.CommandText = "Jobs";
                    oracleAdapter.Fill(dataSet, "Jobs");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return dataSet;
        }
    }
}
