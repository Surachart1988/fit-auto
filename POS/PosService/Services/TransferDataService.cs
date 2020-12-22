using PosData.Models;
using CentralService.Injection;
using CentralService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace PosService.Services
{
    public class TransferDataService : ITransferDataService
    {
        private Entities _db;

        //static HttpClientHandler handler = new HttpClientHandler();
        static HttpClient client = new HttpClient();
        const string BaseApiUrl = "api/Transfers";
        readonly string Conn = ConfigurationManager.ConnectionStrings["Entities"].ToString();
        readonly string Conns = ConfigurationManager.ConnectionStrings["POSSqlClient"].ConnectionString;
        public TransferDataService(Entities conn)
        {
            _db = conn;
        }

        public TransferDataModel GetData(TransferDetail model)
        {
            TransferDataModel obj = new TransferDataModel
            {
                Type = model.Actfrom
            };
            model.Soure = JsonConvert.DeserializeObject<DataSet>(model.DesSoure);
            int _index = 0;
            foreach (DataTable DataSets in model.Soure.Tables)
            {
                bool cmdDelete = false;
                string Merge_Field_Tmp = "", Merge_Key = "";
                string Merge_Table_Tmp = $"#TmpTable{++_index}";
                var Table_source = _db.Transfer_Data.FirstOrDefault(w => w.Destination_Table == DataSets.TableName);
                using (SqlConnection sqlconn = new SqlConnection(Conns))
                {
                    using (SqlCommand sqlcmd = new SqlCommand("", sqlconn))
                    {
                        try
                        {
                            sqlconn.Open();

                            Merge_Key = BuildForMerge(DataSets, ref cmdDelete, Merge_Table_Tmp, Table_source, sqlcmd);

                            sqlcmd.CommandText = $"SELECT TOP 0 {Table_source.Destination_Field} INTO {Merge_Table_Tmp}  FROM dbo.{DataSets.TableName}";
                            sqlcmd.ExecuteNonQuery();

                            using (SqlBulkCopy bulkcopy = new SqlBulkCopy(sqlconn))
                            {
                                bulkcopy.BulkCopyTimeout = 660;
                                bulkcopy.DestinationTableName = Merge_Table_Tmp;
                                bulkcopy.WriteToServer(DataSets);
                                bulkcopy.Close();
                            }

                            sqlcmd.CommandTimeout = 300;
                            sqlcmd.CommandText = $@"
                            MERGE INTO dbo.{DataSets.TableName}
                                USING {Merge_Table_Tmp}
                                    ON {Merge_Key}
                            WHEN MATCHED THEN
                                UPDATE SET 
                                        {BuildColSchema(Merge_Table_Tmp, DataSets, DataSets.TableName, out Merge_Field_Tmp)}                               
                            WHEN NOT MATCHED THEN
                                INSERT(
                                    {Table_source.Destination_Field}
                                        )
                                VALUES(     
                                        {Merge_Field_Tmp}
                                        )
                            " + (cmdDelete == true ? " WHEN NOT MATCHED BY SOURCE THEN DELETE; " : ";") + @"
                            DROP TABLE " + Merge_Table_Tmp;

                            int sucess = sqlcmd.ExecuteNonQuery();
                            obj.UpdateList.Add(new UpdateDetail
                            {
                                SoureTable = DataSets.TableName,
                                Schema = sqlcmd.CommandText,
                                Rows = sucess,
                                Status = sucess > 0
                            });
                        }
                        catch (Exception ex)
                        {
                            obj.UpdateList.Add(new UpdateDetail
                            {
                                SoureTable = DataSets.TableName,
                                Schema = sqlcmd.CommandText,
                                Status = false,
                                Error_Massage = ex.Message
                            });
                        }
                        finally
                        {
                            sqlconn.Close();
                        }
                    }
                }

            }
            return obj;
        }

        private static string BuildForMerge(DataTable DataSets, ref bool cmdDelete, string Merge_Table_Tmp, Transfer_Data Table_source, SqlCommand sqlcmd)
        {
            string Merge_Key;
            string[] keys = Table_source.Destination_Key.Split(',');
            if (keys.Length > 1)
            {
                Merge_Key = Merge_Table_Tmp + "." + keys[0] + " = " + DataSets.TableName + "." + keys[0] +
                    " AND " + Merge_Table_Tmp + "." + keys[1] + " = " + DataSets.TableName + "." + keys[1];
            }
            else
            {
                Merge_Key = Merge_Table_Tmp + "." + keys[0] + " = " + DataSets.TableName + "." + keys[0];
                //Merge_Key = Merge_Table_Tmp + "." + Table_source.Destination_Field + " = " + DataSets.TableName + "." + Table_source.Destination_Field;
            }

            switch (DataSets.TableName)
            {
                case "SB_Branch":
                case "SB_System":
                case "SB_Dealercode_Master":
                case "Authorize2_Document_User":
                    cmdDelete = true;
                    break;
                case "SB_CusCar":
                    Merge_Key += $" AND {Merge_Table_Tmp}.car_reg = {DataSets.TableName}.car_reg AND {Merge_Table_Tmp}.car_provid = {DataSets.TableName}.car_provid";
                    DataTable dist3 = new DataView(DataSets).ToTable(true, "cus_code");
                    foreach (DataRow item in dist3.Select())
                    {
                        sqlcmd.CommandText = "DELETE FROM dbo.SB_CusCar WHERE cus_code = '" + item["cus_code"] + "' ";
                        sqlcmd.ExecuteNonQuery();
                    }
                    break;
                case "SB_Customer_Contact":
                    Merge_Key += $" AND {Merge_Table_Tmp}.cuscont_code = {DataSets.TableName}.cuscont_code";
                    cmdDelete = true;
                    break;
                case "SB_Proprice_Log":
                    Merge_Key += $@"    AND {Merge_Table_Tmp}.proprice_date = {DataSets.TableName}.proprice_date 
                                            AND {Merge_Table_Tmp}.pro_price_retail = {DataSets.TableName}.pro_price_retail 
                                                AND {Merge_Table_Tmp}.log_date = {DataSets.TableName}.log_date 
                                                    AND {Merge_Table_Tmp}.log_time = {DataSets.TableName}.log_time";
                    cmdDelete = true;
                    break;
                case "SB_PromotionHeader":
                    DataTable dist1 = new DataView(DataSets).ToTable(true, "pro_id");
                    foreach (DataRow item in dist1.Select())
                    {
                        sqlcmd.CommandText = "DELETE FROM [dbo].[SB_CouponDetail] WHERE coupon_group_id in (SELECT top 1 coupon_id FROM dbo.SB_PromotionHeader WHERE pro_id = '" + item["pro_id"] + "') ";
                        sqlcmd.ExecuteNonQuery();
                    }
                    break;
                case "SB_PromotionDetail":
                    Merge_Key += $@"    AND {Merge_Table_Tmp}.pro_code = {DataSets.TableName}.pro_code 
                                            AND {Merge_Table_Tmp}.product_group_code = {DataSets.TableName}.product_group_code 
                                                AND {Merge_Table_Tmp}.progroup_code = {DataSets.TableName}.progroup_code 
                                                    AND {Merge_Table_Tmp}.pro_brand_code = {DataSets.TableName}.pro_brand_code 
                                                        AND {Merge_Table_Tmp}.pro_model_code = {DataSets.TableName}.pro_model_code 
                                                            AND {Merge_Table_Tmp}.pro_size_code = {DataSets.TableName}.pro_size_code 
                                                                AND {Merge_Table_Tmp}.status_give_product = {DataSets.TableName}.status_give_product";
                    DataTable dist2 = new DataView(DataSets).ToTable(true, "pro_id");
                    foreach (DataRow item in dist2.Select())
                    {
                        sqlcmd.CommandText = "DELETE FROM dbo.SB_PromotionDetail WHERE pro_id = '" + item["pro_id"] + "' ";
                        sqlcmd.ExecuteNonQuery();
                    }
                    break;
            }

            return Merge_Key;
        }

        private static string BuildColSchema(string Merge_Table_Tmp, DataTable DataSets, string souretable, out string Merge_Field_Tmp)
        {
            string content = "";
            Merge_Field_Tmp = "";
            foreach (DataColumn tableColumn in DataSets.Columns)
            {
                content += ", " + souretable + "." + tableColumn.ColumnName + " = " + Merge_Table_Tmp + "." + tableColumn.ColumnName;
                Merge_Field_Tmp += "," + Merge_Table_Tmp + "." + tableColumn.ColumnName;
            }

            Merge_Field_Tmp = Merge_Field_Tmp.Remove(0, 1);
            return content.Remove(0, 1);
        }

        public void TransferLog(TransferDataModel model)
        {
            try
            {
                foreach (var row in model.UpdateList)
                {
                    var _log = new ST_Transfer_Data_Log();
                    _log.type = model.Type;
                    _log.table = row.SoureTable;
                    _log.txt_schema = row.Schema.Trim();
                    _log.rows_affected = row.Rows;
                    _log.status = row.Status;
                    _log.message = row.Error_Massage ?? "";
                    _log.datetime = DateTime.Now;
                    _db.ST_Transfer_Data_Log.Add(_log);
                    _db.SaveChanges();
                }
            }
            catch (Exception log)
            {
                //TO DO:
            }
        }
    }
}
