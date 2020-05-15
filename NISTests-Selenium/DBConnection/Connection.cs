namespace DBConnection
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Connection
    {
        private static string connt = "Data Source=10.100.19.21; Initial Catalog=ProfiERP_test; User Id=profisa; password=pfsa06BGt";
        private static SqlConnection conn = new SqlConnection(connt);
        private static string select;
        private static SqlDataReader rd;

        ///// <summary>
        ///// <para>Return List of values in DB column "Deleted"</para>
        ///// <para>for all client phone in phoneCatalog</para>
        ///// </summary>
        //public static List<string> getRequestDeletedStatus(List<string> phoneCatalog)
        //{
        //    List<string> deletedField = new List<string>();
        //    try
        //    {
        //        for (int i = 0; i < phoneCatalog.Count; i++)
        //        {
        //            select = String.Format("select * from dbo.CT_Request where Phone = '{0}' order by CreatedOn desc", phoneCatalog[i]); // RequestStatusCode must be NEW
        //            SqlCommand cmd = new SqlCommand(select, conn);
        //            conn.Open();
        //            rd = cmd.ExecuteReader();
        //            while (rd.Read())
        //            {
        //                deletedField.Add(rd["Deleted"].ToString());
        //                conn.Close();
        //                break;
        //            }
        //            conn.Close();
        //        }
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return deletedField;
        //}

        ///// <summary>
        ///// <para>Return List of values in DB column "RequestStatusCode" (must be Duplicated)</para>
        ///// <para>for all client phone in phoneCatalog</para>
        ///// </summary>
        //public static List<string> getRequestRequestStatusCode(List<string> phoneCatalog)
        //{
        //    List<string> requestNewStatus = new List<string>();
        //    try
        //    {
        //        for (int i = 0; i < phoneCatalog.Count; i++)
        //        {
        //            select = String.Format("select * from dbo.CT_Request where Phone = '{0}'order by CreatedOn desc ", phoneCatalog[i]);
        //            SqlCommand cmd = new SqlCommand(select, conn);
        //            conn.Open();
        //            rd = cmd.ExecuteReader();
        //            if (rd.Read())
        //            {
        //                requestNewStatus.Add(rd["RequestStatusCode"].ToString());
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return requestNewStatus;
        //}

        ///// <summary>
        ///// <para>Return List field Active in PotentialClient is true </para>
        ///// </summary>
        ///// <param name="phoneCatalog"></param>
        ///// <param name="nameCatalog"></param>
        ///// <returns></returns>
        //public static List<string> getPotentialClientsActiveStatus(List<string> phoneCatalog, List<string> nameCatalog)
        //{
        //    List<string> activeField = new List<string>();
        //    try
        //    {
        //        for (int i = 0; i < phoneCatalog.Count; i++)
        //        {
        //            select = String.Format("select * from dbo.CT_PotentialClient where Phone = '{0}' and FirstName='{1}' order by CreatedOn desc", phoneCatalog[i], nameCatalog[i]);
        //            SqlCommand cmd = new SqlCommand(select, conn);
        //            conn.Open();
        //            rd = cmd.ExecuteReader();
        //            while (rd.Read())
        //            {
        //                activeField.Add(rd["Active"].ToString());
        //                conn.Close();
        //                break;
        //            }
        //            conn.Close();
        //        }
        //    }

        //    finally
        //    {
        //        conn.Close();
        //    }

        //    return activeField;
        //}

        ///// <summary>
        ///// <para>Return List of RequestID in CT_Request</para>
        ///// </summary>
        ///// <param name="phoneCatalog"></param>
        ///// <returns></returns>
        //public static List<string> getRequestId(List<string> phoneCatalog)
        //{
        //    List<string> requestId = new List<string>();
        //    try
        //    {
        //        for (int i = 0; i < phoneCatalog.Count; i++)
        //        {
        //            select = String.Format("select * from dbo.CT_Request where Phone = '{0}' order by CreatedOn desc", phoneCatalog[i]);
        //            SqlCommand cmd = new SqlCommand(select, conn);
        //            conn.Open();
        //            rd = cmd.ExecuteReader();
        //            while (rd.Read())
        //            {
        //                requestId.Add(rd["RequestId"].ToString());
        //            }
        //            conn.Close();
        //        }
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return requestId;
        //}

        //public static bool distributionIsActive(string PhoneNumber)
        //{
        //    bool isActive = false;
        //    try
        //    {
        //        select = String.Format("select * from dbo.CT_RequestDistribution where RequestId  in  (select RequestID from CT_Request where Phone = '{0}') order by CreatedOn desc ", PhoneNumber);
        //        SqlCommand cmd = new SqlCommand(select, conn);
        //        conn.Open();
        //        rd = cmd.ExecuteReader();
        //        while (rd.Read())
        //        {
        //            if (rd["Active"].ToString().Equals("1"))
        //            {
        //                isActive = true;
        //            }
        //        }
        //        conn.Close();
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return isActive;
        //}

        ///// <summary>
        ///// <para>Return List of PotentialClientID in CT_PotentialClient</para>
        ///// </summary>
        ///// <param name="phoneCatalog"></param>
        ///// <returns></returns>
        //public static List<string> getPotentialClientId(List<string> phoneCatalog, List<string> nameCatalog)
        //{
        //    List<string> potentialClientId = new List<string>();
        //    try
        //    {
        //        for (int i = 0; i < phoneCatalog.Count; i++)
        //        {
        //            select = String.Format("select * from dbo.CT_PotentialClient where Phone = '{0}' and FirstName = '{1}' and Active = 1", phoneCatalog[i], nameCatalog[i]);
        //            SqlCommand cmd = new SqlCommand(select, conn);
        //            conn.Open();
        //            rd = cmd.ExecuteReader();
        //            while (rd.Read())
        //            {
        //                potentialClientId.Add(rd["PotentialClientId"].ToString());
        //            }

        //            conn.Close();
        //        }
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return potentialClientId;
        //}

        ///// <summary>
        ///// <para>Return List of PotentialClientID in CT_Requests</para>
        ///// </summary>
        ///// <param name="phoneCatalog"></param>
        ///// <returns></returns>
        //public static List<string> getPotentialClientId_Request(List<string> phoneCatalog)
        //{
        //    List<string> potentialClientId_Request = new List<string>();
        //    try
        //    {
        //        for (int i = 0; i < phoneCatalog.Count; i++)
        //        {
        //            select = String.Format("select * from dbo.CT_Request where Phone = '{0}' and PotentialClientID is not null order by CreatedOn desc", phoneCatalog[i]);
        //            SqlCommand cmd = new SqlCommand(select, conn);
        //            conn.Open();
        //            rd = cmd.ExecuteReader();
        //            while (rd.Read())
        //            {
        //                potentialClientId_Request.Add(rd["PotentialClientId"].ToString());
        //                conn.Close();
        //                break;
        //            }

        //            conn.Close();
        //        }
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return potentialClientId_Request;
        //}

        ///// <summary>
        ///// <para>Return List of RequestsID in CT_RequestDistribution</para>
        ///// </summary>
        ///// <param name="phoneCatalog"></param>
        ///// <returns></returns>
        //public static List<string> getRequestId_Distribution(List<string> phoneCatalog)
        //{
        //    List<string> requestId_Distribution = new List<string>();
        //    try
        //    {
        //        for (int i = 0; i < phoneCatalog.Count; i++)
        //        {
        //            select = String.Format("select rd.RequestID from dbo.CT_RequestDistribution  as rd join CT_Request as req on rd.RequestID =  req.RequestID where Phone = '{0}'order by rd.CreatedOn desc", phoneCatalog[i]);
        //            SqlCommand cmd = new SqlCommand(select, conn);
        //            conn.Open();
        //            rd = cmd.ExecuteReader();
        //            while (rd.Read())
        //            {
        //                if (rd["RequestID"].Equals(String.Empty))
        //                {
        //                    requestId_Distribution.Add("null");
        //                }
        //                else
        //                {
        //                    requestId_Distribution.Add(rd["RequestID"].ToString());
        //                }
        //            }

        //            conn.Close();
        //        }
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //    return requestId_Distribution;
        //}

        ///// <summary>
        ///// <para>Delete the inserted data in DB selected by the phones in phoneCatalog</para>
        ///// </summary>
        ///// <param name="phoneCatalog"></param>
        //public static void deleteDBData(List<string> phoneCatalog)
        //{
        //    {
        //        for (int i = 0; i < phoneCatalog.Count; i++)
        //        {
        //            string deleteRequestDistribution = String.Format("delete from CT_RequestDistribution where RequestID in (select r.RequestID from CT_Request as r where r.Phone = '{0}')", phoneCatalog[i]);
        //            string deleteRequest = String.Format("delete from CT_Request where Phone = '{0}'", phoneCatalog[i]);
        //            string deletePotentialClients = String.Format("delete from CT_PotentialClient where Phone = '{0}'", phoneCatalog[i]);

        //            SqlCommand deleteRequestDistributionCommand = new SqlCommand(deleteRequestDistribution, conn);
        //            SqlCommand deleteRequestCommand = new SqlCommand(deleteRequest, conn);
        //            SqlCommand deletePotentialClientsCommand = new SqlCommand(deletePotentialClients, conn);

        //            conn.Open();

        //            deleteRequestDistributionCommand.ExecuteNonQuery();
        //            deleteRequestCommand.ExecuteNonQuery();
        //            deletePotentialClientsCommand.ExecuteNonQuery();

        //            conn.Close();
        //        }
        //    }
        //}

        ///// <summary>
        ///// <para>Update CreatedOn in DB by the given paramerter days</para>
        ///// </summary>
        ///// <param name="phoneCatalog"></param>
        ///// <param name="days"></param>
        //public static void maniuplateDate(List<string> phoneCatalog, int days)
        //{
        //    for (int i = 0; i < phoneCatalog.Count; i++)
        //    {
        //        DateTime date = DateTime.Today.AddDays(days);
        //        // date.AddDays(days);
        //        string updatePotentialClient = String.Format("update CT_PotentialClient set CreatedOn = '{0}' where Phone='{1}'", date, phoneCatalog[i]);
        //        string updateRequesTable = String.Format("update CT_Request set CreatedOn = '{0}' where Phone='{1}' and PotentialClientID is not null", date, phoneCatalog[i]);

        //        SqlCommand upDatePCCmd = new SqlCommand(updatePotentialClient, conn);
        //        SqlCommand upDateReqCmd = new SqlCommand(updateRequesTable, conn);

        //        conn.Open();
        //        upDatePCCmd.ExecuteNonQuery();
        //        upDateReqCmd.ExecuteNonQuery();
        //        conn.Close();
        //    }
        //}

        //public static string dbPhoneNumber(string phoneNumber)
        //{
        //    string actualPhone = String.Empty;
        //    string select = String.Format("select * from CT_Request where Phone='{0}'", phoneNumber);
        //    SqlCommand cmd = new SqlCommand(select, conn);
        //    conn.Open();
        //    rd = cmd.ExecuteReader();
        //    while (rd.Read())
        //    {
        //        actualPhone = rd["Phone"].ToString();
        //    }
        //    conn.Close();

        //    return actualPhone;
        //}

        //public static string clientForNewRequest()
        //{
        //    string client = String.Empty;
        //    try
        //    {
        //        string select = String.Format("select top(10) FirstName, Phone from CT_Request where CreatedOn< '{0}' and Deleted = 0 and PotentialClientID is not null and Phone is not null", DateTime.Today.AddDays(-getPeriodFromDB()));
        //        SqlCommand cmd = new SqlCommand(select, conn);
        //        conn.Open();
        //        rd = cmd.ExecuteReader();
        //        List<string> phones = new List<string>();
        //        while (rd.Read())
        //        {
        //            phones.Add(rd["Phone"].ToString());
        //        }
        //        conn.Close();
        //        foreach (string phone in phones)
        //        {
        //            if (IsPhoneExisting(phone))
        //            {
        //                string sel = String.Format("select * from CT_request where phone = '{0}'", phone);
        //                SqlCommand fin = new SqlCommand(sel, conn);
        //                conn.Open();
        //                SqlDataReader reader = fin.ExecuteReader();
        //                while (reader.Read())
        //                {
        //                    client = reader["FirstName"].ToString() + ";" + reader["Phone"].ToString();
        //                    conn.Close();
        //                    return client;
        //                }
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //    return client;
        //}

        //private static bool IsPhoneExisting(string phone)
        //{
        //    string selectNew = String.Format("select * from CT_Request where CreatedOn > '{0}' and Phone='{1}'", DateTime.Today.AddDays(-getPeriodFromDB()), phone);
        //    SqlCommand cmdTwo = new SqlCommand(selectNew, conn);
        //    try
        //    {
        //        string existPhone = String.Empty;
        //        conn.Open();
        //        SqlDataReader rdTwo = cmdTwo.ExecuteReader();
        //        if (rdTwo.Read())
        //        {
        //            existPhone = rdTwo["Phone"].ToString();
        //            conn.Close();
        //            return false;
        //        }
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //    return true;
        //}

        //public static string clientWithException()
        //{
        //    string client = String.Empty;
        //    List<string> phones = new List<string>();
        //    string select = "select r.FirstName, r.Phone from ct_request as r join CT_RequestEvent as re on r.RequestID = re.RequestID where re.RequestEventTypeCode = 9 or re.RequestEventTypeCode = 10 and r.Deleted <> 1";
        //    SqlCommand cmd = new SqlCommand(select, conn);

        //    conn.Open();
        //    rd = cmd.ExecuteReader();

        //    while (rd.Read())
        //    {
        //        phones.Add(rd["Phone"].ToString());
        //    }
        //    conn.Close();

        //    for (int i = 0; i < phones.Count; i++)
        //    {
        //        string check = String.Format("select top(1)* from CT_Request where Phone = '{0}' order by CreatedOn desc", phones[i]);
        //        SqlCommand cheker = new SqlCommand(check, conn);
        //        conn.Open();
        //        //rdTwo = cheker.ExecuteReader();
        //        // foreach (var phone in phones)
        //        // {
        //        while (rdTwo.Read())
        //        {
        //            if (rdTwo["RequestStatusCode"].ToString().Equals("Rejected"))
        //            {
        //                client = rdTwo["FirstName"].ToString() + ";" + rdTwo["Phone"].ToString();
        //                conn.Close();
        //                return client;
        //            }

        //        }
        //        conn.Close();
        //        // }
        //    }
        //    conn.Close();

        //    return client;
        //}

        //public static List<string> GetRequestNameFields(List<string> phoneCatalog)
        //{
        //    List<string> names = new List<string>();

        //    foreach (string phone in phoneCatalog)
        //    {
        //        string select = String.Format("select origFirstName, origSecondName, origLastName from CT_Request where Phone = '{0}'", phone);
        //        SqlCommand cmd = new SqlCommand(select, conn);
        //        conn.Open();
        //        rd = cmd.ExecuteReader();
        //        while (rd.Read())
        //        {
        //            names.Add(rd["origFirstName"].ToString());
        //            names.Add(rd["origSecondName"].ToString());
        //            names.Add(rd["origLastName"].ToString());
        //        }
        //        conn.Close();
        //    }
        //    return names;
        //}

        //public static bool containLatinLetters(List<string> phoneCatalog)
        //{
        //    string names = String.Empty;

        //    string select = String.Format("Select FirstName, SecondName, LastName from CT_Request where Phone = '{0}'", phoneCatalog[0]);
        //    SqlCommand cmd = new SqlCommand(select, conn);
        //    conn.Open();
        //    rd = cmd.ExecuteReader();

        //    if (rd.Read())
        //    {
        //        names = rd["FirstName"].ToString() + rd["SecondName"].ToString() + rd["LastName"].ToString();
        //    }
        //    conn.Close();

        //    var chars = names.ToCharArray();

        //    foreach (char ch in chars)
        //    {
        //        if ((int)ch <= 122)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //public static int getPeriodFromDB()
        //{
        //    int period = 0;
        //    try
        //    {
        //        string selectPeriod = "Select * from CN_Options where Code = 'MinimumNumbOfDays'";
        //        SqlCommand cmd = new SqlCommand(selectPeriod, conn);
        //        conn.Open();
        //        rd = cmd.ExecuteReader();

        //        if (rd.Read())
        //        {
        //            period = Convert.ToInt16(rd["Value"].ToString());
        //        }
        //        conn.Close();
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //    return period;
        //}

        //public static List<string> getCyrillicName(List<string> phoneCatalog, List<string> origNameCatalog)
        //{
        //    List<string> cyrillicNameCatalog = new List<string>();

        //    for (int i = 0; i < phoneCatalog.Count; i++)
        //    {
        //        string select = String.Format("select * from CT_Request where Phone = '{0}' and OrigFirstName = '{1}'", phoneCatalog[i], origNameCatalog[i]);
        //        SqlCommand cmd = new SqlCommand(select, conn);
        //        conn.Open();
        //        rd = cmd.ExecuteReader();

        //        while (rd.Read())
        //        {
        //            cyrillicNameCatalog.Add(rd["FirstName"].ToString());
        //        }
        //        conn.Close();
        //    }
        //    conn.Close();

        //    return cyrillicNameCatalog;
        //}

        ///// <summary>
        ///// <para>TODO!!!</para>
        ///// </summary>
        ///// <returns></returns>
        //public static List<string> getActiveOffices()
        //{
        //    List<string> activeOffices = new List<string>();
        //    select = "select * from NC_Office  where Active = 1 and Deleted <> 1 order by DisplayOrder";
        //    SqlCommand cmd = new SqlCommand(select, conn);
        //    conn.Open();
        //    rd = cmd.ExecuteReader();

        //    activeOffices.Add("");

        //    while (rd.Read())
        //    {
        //        activeOffices.Add(rd["DisplayName"].ToString());
        //    }
        //    conn.Close();

        //    return activeOffices;
        //}


        ///// <summary>
        ///// <para>TODO!!</para>
        ///// </summary>
        ///// <param name="PartnerID"></param>
        ///// <returns></returns>
        //public static List<string> getEntryPoints(string PartnerID)
        //{
        //    List<string> entryPoints = new List<string>();
        //    try
        //    {
        //        select = String.Format("select * from NC_RequestEntryPoint where RequestPartnerID = '{0}' and Active = 1 and Deleted = 0 order by DisplayOrder", PartnerID);
        //        SqlCommand cmd = new SqlCommand(select, conn);
        //        conn.Open();
        //        rd = cmd.ExecuteReader();

        //        entryPoints.Add(string.Empty);

        //        while (rd.Read())
        //        {
        //            entryPoints.Add(rd["Name"].ToString());
        //        }
        //        conn.Close();
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //    return entryPoints;
        //}

        //public static List<string> getSources(string entryPoint)
        //{
        //    List<string> sources = new List<string>();
        //    try
        //    {
        //        select = string.Format("select * from NC_RequestSource rs join NC_ContactEntryPoint_NC_ContactSource as cs on rs.RequestSourceID = cs.RequestSourceID where cs.RequestEntryPointID = {0} and Active = 1 order by DisplayOrder", entryPoint);
        //        SqlCommand cmd = new SqlCommand(select, conn);
        //        conn.Open();
        //        rd = cmd.ExecuteReader();

        //        sources.Add(string.Empty);

        //        while (rd.Read())
        //        {
        //            sources.Add(rd["DisplayName"].ToString());
        //        }
        //        conn.Close();
        //    }
        //    finally
        //    {
        //        conn.Close();

        //    }
        //    return sources;
        //}

        //public static string getFirstName(string phone, string origName)
        //{
        //    string firstName = string.Empty;
        //    select = String.Format("select * from CT_Request where Phone = '{0}' and origFirstName = '{1}' order by CreatedOn desc", phone, origName);
        //    SqlCommand cmd = new SqlCommand(select, conn);
        //    conn.Open();
        //    rd = cmd.ExecuteReader();
        //    while (rd.Read())
        //    {
        //        firstName = rd["FirstName"].ToString();
        //    }
        //    conn.Close();

        //    return firstName;
        //}

        //public static string getSecondName(string phone, string origName)
        //{
        //    string secondName = string.Empty;
        //    select = String.Format("select * from CT_Request where Phone = '{0}' and origFirstName = '{1}' order by CreatedOn desc", phone, origName);
        //    SqlCommand cmd = new SqlCommand(select, conn);
        //    conn.Open();
        //    rd = cmd.ExecuteReader();
        //    while (rd.Read())
        //    {
        //        secondName = rd["SecondName"].ToString();
        //    }
        //    conn.Close();

        //    return secondName;
        //}

        //public static string getLastName(string phone, string origName)
        //{
        //    string lastName = string.Empty;
        //    select = String.Format("select * from CT_Request where Phone = '{0}' and origFirstName = '{1}' order by CreatedOn desc", phone, origName);
        //    SqlCommand cmd = new SqlCommand(select, conn);
        //    conn.Open();
        //    rd = cmd.ExecuteReader();
        //    while (rd.Read())
        //    {
        //        lastName = rd["LastName"].ToString();
        //    }
        //    conn.Close();

        //    return lastName;
        //}

        //public static string getOfferStatus(string ApplicationNumber)
        //{
        //    string offerStatus = string.Empty;

        //    try
        //    {
        //        select = String.Format("select OfferStatusCode from AN_Offer offer join an_application app on app.OfferID = offer.OfferID where app.ApplicationNumber = '{0}'", ApplicationNumber);
        //        SqlCommand cmd = new SqlCommand(select, conn);
        //        conn.Open();
        //        rd = cmd.ExecuteReader();
        //        if (rd.Read())
        //        {
        //            offerStatus = rd["OfferStatusCode"].ToString();
        //        }
        //    }
        //    catch (SqlException)
        //    {
        //        throw new Exception("No such application");
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //    return offerStatus;
        //}

        //public static string getAppStepCode(string ApplicationNumber)
        //{
        //    string appStep = string.Empty;

        //    try
        //    {
        //        select = String.Format("select ApplicationStepCode from an_application where ApplicationNumber = {0}", ApplicationNumber);
        //        SqlCommand cmd = new SqlCommand(select, conn);
        //        conn.Open();
        //        rd = cmd.ExecuteReader();
        //        if (rd.Read())
        //        {
        //            appStep = rd["ApplicationStepCode"].ToString();
        //        }
        //    }
        //    catch (SqlException)
        //    {
        //        throw new Exception("There are no application with this number: " + ApplicationNumber);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //    return appStep;
        //}

        //public static string GetTop1FromDBBySql(string sql)
        //{
        //    SqlCommand getData = new SqlCommand(sql, conn);

        //    string data = "NULL";

        //    try
        //    {
        //        conn.Open();
        //        data = getData.ExecuteScalar().ToString();
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //    if (data != null)
        //    {
        //        return data.ToString();
        //    }

        //    return "NULL";
        //}

        //public static void DeleteDataFromDB(string tableName, string key, string value)
        //{
        //    string deleteSql = string.Format("delete from {0} where {1}={2};", tableName, key, value);
        //    SqlCommand deleteData = new SqlCommand(deleteSql, conn);
        //    try
        //    {
        //        conn.Open();
        //        var count = deleteData.ExecuteScalar();
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}

        //public static void DeleteDataFromDBBySql(string sql)
        //{
        //    SqlCommand deleteData = new SqlCommand(sql, conn);
        //    try
        //    {
        //        conn.Open();
        //        var count = deleteData.ExecuteScalar();
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}

        //public static List<string> getParametersFromDBBySql(string sql, string parameter)
        //{
        //    List<string> data = new List<string>();
        //    SqlCommand command = new SqlCommand(sql, conn);
        //    try
        //    {
        //        conn.Open();
        //        rd = command.ExecuteReader();

        //        while (rd.Read())
        //        {
        //            data.Add(rd[parameter].ToString());
        //        }
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //    return data;
        //}

        //public static List<string> getParametersFromDBBySql(string dataSql, string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8)
        //{
        //    List<string> data = new List<string>();
        //    SqlCommand command = new SqlCommand(dataSql, conn);
        //    try
        //    {
        //        conn.Open();
        //        rd = command.ExecuteReader();
        //        while (rd.Read())
        //        {
        //            data.Add(rd[p1].ToString());
        //            data.Add(rd[p2].ToString());
        //            data.Add(rd[p3].ToString());
        //            data.Add(rd[p4].ToString());
        //            data.Add(rd[p5].ToString());
        //            data.Add(rd[p6].ToString());
        //            data.Add(rd[p7].ToString());
        //            data.Add(rd[p8].ToString());
        //        }
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //    return data;
        //}

        //public static List<string> getOrigName(List<string> phoneCatalog)
        //{
        //    List<string> origNames = new List<string>();
        //    try
        //    {
        //        string select = String.Format("Select OrigFirstName, OrigSecondName, OrigLastName from CT_Request where Phone = '{0}'", phoneCatalog[0]);
        //        SqlCommand cmd = new SqlCommand(select, conn);
        //        conn.Open();
        //        rd = cmd.ExecuteReader();

        //        while (rd.Read())
        //        {
        //            origNames.Add(rd["OrigFirstName"].ToString());
        //            origNames.Add(rd["OrigSecondName"].ToString());
        //            origNames.Add(rd["OrigLastName"].ToString());
        //        }
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return origNames;
        //}


        //public static string getExistingOffice(string status)
        //{
        //    string office = String.Empty;
        //    string select = string.Empty;
        //    try
        //    {
        //        if (status.Equals("deleted"))
        //        {
        //            select = String.Format("SELECT Name FROM NC_OFFICE WHERE DELETED = 1 order by OfficeId desc");
        //        }
        //        if (status.Equals("active"))
        //        {
        //            select = String.Format("SELECT Name FROM NC_OFFICE WHERE ACTIVE = 1 AND DELETED = 0 order by OfficeId desc");
        //        }
        //        SqlCommand cmd = new SqlCommand(select, conn);
        //        conn.Open();
        //        rd = cmd.ExecuteReader();

        //        if (rd.Read())
        //        {
        //            office = rd["OrigFirstName"].ToString();
        //        }
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return office;
        //}
    }
}
