using DBUtility;
using Models;
using Models.Common;
using System;
using System.Data;

namespace DAL
{
    public class SeqNoDAL
    {
        /// <summary>
        /// 获取采番值
        /// </summary>
        /// <param name="key">采番键值</param>
        /// <returns></returns>
        public SeqRule GetKeyValues(string key)
        {
            SeqRule ack = new SeqRule();
            string sSql = "SELECT * FROM SeqNo WHERE SeqKey='" + key + "'";
            DataSet ds = DbHelperMySQL.Query(sSql);
            SeqNo model = new SeqNo();

            if (ds.Tables.Count > 0)
            {
                model = DataRowToModel(ds.Tables[0].Rows[0]);

                ack.date_type = model.DateType;
                ack.pre_fix = model.PreFix;

                //清零
                ClearZero(model);

                if (model.NowNumber < model.MaxNumber)
                {
                    model.NowNumber += model.IncreNumber;
                    int length = (model.MaxNumber.ToString()).Length - (model.NowNumber.ToString()).Length;
                    for (int i = 0; i < length; i++)
                    {
                        ack.key_values += "0";
                    }
                    ack.key_values = ack.key_values + model.NowNumber.ToString();

                    EditSeqNo(model);
                }
            }
            return ack;
        }

        /// <summary>
        /// 采番清0
        /// </summary>
        /// <param name="model"></param>
        public void ClearZero(SeqNo model)
        {
            switch (model.ZeroType)
            {
                case "DAY":
                    if (model.UpDateTime.ToString("yyyy-MM-dd") != DateTime.Now.ToString("yyyy-MM-dd"))
                    {
                        model.NowNumber = 0;
                    }
                    else
                    {
                        model.NowNumber++;
                    }
                    break;
                case "MONTH":
                    if (model.UpDateTime.ToString("yyyy-MM") != DateTime.Now.ToString("yyyy-MM"))
                    {
                        model.NowNumber = 0;
                    }
                    else
                    {
                        model.NowNumber++;
                    }
                    break;
                case "YEAR":
                    if (model.UpDateTime.Year != DateTime.Now.Year)
                    {
                        model.NowNumber = 0;
                    }
                    else
                    {
                        model.NowNumber++;
                    }
                    break;
                case "NEVER":
                default:
                    model.NowNumber++;
                    break;
            }
            EditSeqNo(model);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        public void EditSeqNo(SeqNo model)
        {
            string sSql = "UPDATE SeqNo SET ";
            sSql += "ZeroType='" + model.ZeroType + "',";
            sSql += "NowNumber=" + model.NowNumber + ",";
            sSql += "IncreNumber=" + model.IncreNumber + ",";
            sSql += "MaxNumber=" + model.MaxNumber + ",";
            sSql += "UpDateTime='" + DateTime.Now.ToString() + "',";
            sSql += "PreFix='" + model.PreFix + "',";
            sSql += "Memo='" + model.Memo + "'";

            sSql += " WHERE SeqKey='" + model.SeqKey + "'";
            DbHelperMySQL.ExecuteSql(sSql);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SeqNo DataRowToModel(DataRow row)
        {
            SeqNo model = new SeqNo();
            if (row != null)
            {
                if (row["SeqKey"] != null)
                {
                    model.SeqKey = row["SeqKey"].ToString();
                }
                if (row["ZeroType"] != null)
                {
                    model.ZeroType = row["ZeroType"].ToString();
                }
                if (row["DateType"] != null)
                {
                    model.DateType = int.Parse(row["DateType"].ToString());
                }
                if (row["NowNumber"] != null)
                {
                    model.NowNumber = int.Parse(row["NowNumber"].ToString());
                }
                if (row["IncreNumber"] != null)
                {
                    model.IncreNumber = int.Parse(row["IncreNumber"].ToString());
                }
                if (row["MaxNumber"] != null)
                {
                    model.MaxNumber = int.Parse(row["MaxNumber"].ToString());
                }
                if (row["UpDateTime"] != null && row["UpDateTime"].ToString() != "")
                {
                    model.UpDateTime = DateTime.Parse(row["UpDateTime"].ToString());
                }
                if (row["PreFix"] != null)
                {
                    model.PreFix = row["PreFix"].ToString();
                }
                if (row["Memo"] != null)
                {
                    model.Memo = row["Memo"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 采番
        /// </summary>
        /// <returns></returns>
        public string GetSeqNo(string key)
        {
            SeqRule ack = GetKeyValues(key);
            string date = "";
            switch (ack.date_type)
            {
                //年 采番
                case 1:
                    date = DateTime.Now.ToString("yy");
                    break;
                //年 月 采番
                case 2:
                    date = DateTime.Now.ToString("yyMM");
                    break;
                //年 月 日 采番
                case 3:
                    date = DateTime.Now.ToString("yyMMdd");
                    break;
                default:
                    break;
            }
            return ack.pre_fix + date + ack.key_values;
        }
    }
}