using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace Miniluv
{
    public class SqlConn
    {
        public string m_szDbFileName { get; set; }
        public SQLiteConnection m_sqlConn { get; set; }
        private string m_szConnectionString { get; set; }

        public enum HandlePacketAction
        {
            IPBlackList,
            DomainBlackList,
            MalJS,
        }
        private Dictionary<string, string[]> m_dicTable = new Dictionary<string, string[]>()
        {
            {
                "IPBlackList",
                new string[]
                {
                    "Name",
                    "Group",
                    "Domain",
                    "IPv4",
                    "IPv6",
                    "CreateDate",
                }
            },
            {
                "DomainBlackList",
                new string[]
                {
                    "Name",
                    "Group",
                    "RegexDomain",
                    "CreateDate",
                }
            },

            {
                "MalJS",
                new string[]
                {
                    "Name",
                    "Group",
                    "Domain",
                    "Script",
                    "CreateDate",
                }
            }
        };

        public SqlConn(string szDbFileName = "db.sqlite")
        {
            m_szDbFileName = szDbFileName;

            if (!CreateDB())
            {
                MessageBox.Show("Create database failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public bool CreateDB()
        {
            try
            {
                SQLiteConnection.CreateFile(m_szDbFileName);
                if (!File.Exists(m_szDbFileName))
                {
                    MessageBox.Show("Database file not found.", "CreateDB()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                m_szConnectionString = $"Data Source={m_szDbFileName};Compress=True;";
                m_sqlConn = new SQLiteConnection(m_szConnectionString);
                foreach (string szTableName in m_dicTable.Keys)
                {
                    if (!CreateTable(szTableName, m_dicTable[szTableName]))
                        return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CreateDB()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CreateTable(string szTableName, string[] aszColumns)
        {
            try
            {
                string szColumnsPattern = string.Join(",", aszColumns.Select(x => $"\"{x}\" TEXT"));
                string szQuery = $"CREATE TABLE IF NOT EXISTS {szTableName} ({szColumnsPattern})";
                ExecuteQuery(szQuery);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CreateTable()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool InsertRow(string szTableName, string[] aszRowItems)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateRow()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable ExecuteQuery(string szQuery)
        {
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(szQuery, m_sqlConn))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }

        public bool CheckItemExistsWithTableName(string szTableName, string[] aszColumns, string szValue)
        {
            foreach (string s in aszColumns)
            {
                if (CheckItemExistsWithTableName(szTableName, s, szValue))
                    return true;
            }

            return false;
        }
        public bool CheckItemExistsWithTableName(string szTableName, string szColumnName, string szValue)
        {
            string szQuery = $"SELECT \"{szColumnName}\" FROM \"{szTableName}\"";
            DataTable dt = ExecuteQuery(szQuery);
            if (dt.Rows.Count == 0)
                return true;

            foreach (DataRow dr in dt.Rows)
            {
                if (string.Equals(dr[0].ToString(), szValue))
                    return true;
            }

            return false;
        }

        public bool AddIpBlackList(string szGroup, string szName, string szIPv4Addr)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
