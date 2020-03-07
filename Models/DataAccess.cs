using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ChartSample
{
    public class DataAccess
    {
        public static DataTable GetSalesPerMonth()
        {
            DataTable dt = new DataTable();

            DataColumn col = new DataColumn();
            col.ColumnName = "Month";
            col.DataType = typeof(String);
            dt.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "Sales";
            col.DataType = typeof(Decimal);
            dt.Columns.Add(col);

            DataRow row = dt.NewRow();
            row["Month"] = "July";
            row["Sales"] = 122000;
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Month"] = "August";
            row["Sales"] = 96000;
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Month"] = "September";
            row["Sales"] = 135000;
            dt.Rows.Add(row);

            dt.AcceptChanges();

            return dt;
        }

        public static IEnumerable<Sale> GetSalesByDepartment()
        {
            List<Sale> sales = new List<Sale>();

            Sale s = new Sale();
            s.Department = "Service";
            s.Sales = 35000;
            sales.Add(s);

            s = new Sale();
            s.Department = "Stores";
            s.Sales = 60000;
            sales.Add(s);

            s = new Sale();
            s.Department = "Internet";
            s.Sales = 40000;
            sales.Add(s);

            return sales;
        }
    }

    public class Sale
    {
        public String Department { get; set; }
        public Decimal Sales { get; set; }
    }
}