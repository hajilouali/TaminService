using BusinessLogicLayer;
using DBFCreater;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Services.Bessines
{
    public class clsSalInsurenceDiskPersonal
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int insAutoID { get; set; }

        public string piPersonalID { get; set; }

        [MaxLength(10)]
        public string DSW_ID { get; set; }

        public int DSW_YY { get; set; }
        public int DSW_MM { get; set; }

        [MaxLength(12)]
        public string DSW_LISTNO { get; set; }

        [MaxLength(10)]
        public string DSW_ID1 { get; set; }

        [MaxLength(100)]
        public string DSW_FNAME { get; set; }

        [MaxLength(100)]
        public string DSW_LNAME { get; set; }

        [MaxLength(100)]
        public string DSW_DNAME { get; set; }

        [MaxLength(15)]
        public string DSW_IDNO { get; set; }

        [MaxLength(100)]
        public string DSW_IDPLC { get; set; }

        [MaxLength(8)]
        public string DSW_IDATE { get; set; }

        [MaxLength(8)]
        public string DSW_BDATE { get; set; }

        [MaxLength(3)]
        public string DSW_SEX { get; set; }

        [MaxLength(10)]
        public string DSW_NAT { get; set; }

        [MaxLength(100)]
        public string DSW_OCP { get; set; }

        [MaxLength(8)]
        public string DSW_SDATE { get; set; }

        [MaxLength(8)]
        public string DSW_EDATE { get; set; }

        public int DSW_DD { get; set; }
        public int DSW_ROOZ { get; set; }
        public int DSW_MAH { get; set; }
        public int DSW_MAZ { get; set; }
        public int DSW_MASH { get; set; }
        public int DSW_TOTL { get; set; }
        public int DSW_BIME { get; set; }
        public int DSW_PRATE { get; set; }
        public string DSW_JOB { get; set; }

        [MaxLength(10)]
        public string PER_NATCOD { get; set; }
    }
    public class clsSalInsurenceDiskFactory
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int insAutoID { get; set; }

        [MaxLength(10)]
        public string DSK_ID { get; set; }

        [MaxLength(100)]
        public string DSK_NAME { get; set; }

        [MaxLength(100)]
        public string DSK_FARM { get; set; }

        [MaxLength(100)]
        public string DSK_ADRS { get; set; }

        public int DSK_KIND { get; set; }
        public int DSK_YY { get; set; }
        public int DSK_MM { get; set; }

        [MaxLength(12)]
        public string DSK_LISTNO { get; set; }

        [MaxLength(100)]
        public string DSK_DISC { get; set; }

        public int DSK_NUM { get; set; }
        public int DSK_TDD { get; set; }
        public int DSK_TROOZ { get; set; }
        public int DSK_TMAH { get; set; }
        public int DSK_TMAZ { get; set; }
        public int DSK_TMASH { get; set; }
        public int DSK_TTOTL { get; set; }
        public int DSK_TBIME { get; set; }
        public int DSK_TKOSO { get; set; }
        public int DSK_BIC { get; set; }
        public int DSK_RATE { get; set; }
        public int DSK_PRATE { get; set; }
        public int DSK_BIMH { get; set; }

        [MaxLength(3)]
        public string MON_PYM { get; set; }
    }
    public class clsSalInsurenceDisk
    {
        private string connectionString = "";
        #region MyRegion
        //public string OpenDBF(string FilePath, string FileName)
        //{
        //    connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + FilePath + " ;Extended Properties=dBase IV";

        //    System.Data.OleDb.OleDbConnection oleDbConnction = new System.Data.OleDb.OleDbConnection(connectionString);
        //    oleDbConnction.Open();

        //    System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("select * FROM " + FileName, oleDbConnction);
        //    System.Data.OleDb.OleDbDataAdapter oleDbAdapter = new System.Data.OleDb.OleDbDataAdapter
        //    {
        //        SelectCommand = oleDbCommand
        //    };

        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        oleDbAdapter.Fill(dt);
        //    }
        //    catch (Exception exp) { clsPublicFunctions.showMessageBoxError(exp + "", ""); }
        //    oleDbConnction.Close();
        //    return dt.Rows[0][5].ToString();
        //}

        //public DataTable DeleteDBF(string FilePath, string FileName)
        //{
        //    connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + FilePath + " ;Extended Properties=dBase IV";

        //    System.Data.OleDb.OleDbConnection oleDbConnction = new System.Data.OleDb.OleDbConnection(connectionString);
        //    oleDbConnction.Open();

        //    System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("DELETE FROM " + FileName, oleDbConnction);
        //    System.Data.OleDb.OleDbDataAdapter oleDbAdapter = new System.Data.OleDb.OleDbDataAdapter
        //    {
        //        DeleteCommand = oleDbCommand,

        //    };
        //    DataTable dt = new DataTable();
        //    oleDbAdapter.Fill(dt);

        //    oleDbConnction.Close();


        //    return null;// OpenDBF(FilePath, FileName);
        //}

        //public DataTable InsertDBF(string FilePath, string FileName, string DSK_ID, string DSK_NAME, string DSK_FARM, string DSK_ADRS)
        //{
        //    connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + FilePath + " ;Extended Properties=dBase IV";

        //    System.Data.OleDb.OleDbConnection oleDbConnction = new System.Data.OleDb.OleDbConnection(connectionString);
        //    oleDbConnction.Open();

        //    System.Data.OleDb.OleDbCommand oleDbCommand = new System.Data.OleDb.OleDbCommand("select * FROM " + FileName, oleDbConnction);
        //    System.Data.OleDb.OleDbDataAdapter oleDbAdapter = new System.Data.OleDb.OleDbDataAdapter
        //    {
        //        SelectCommand = oleDbCommand
        //    };

        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        oleDbAdapter.Fill(dt);
        //    }
        //    catch (Exception exp) { clsPublicFunctions.showMessageBoxError(exp + "", ""); }
        //    oleDbConnction.Close();
        //    return dt;
        //}

        #endregion

        /// <summary>
        /// ساخت دیسکت بیمه مخصوص کارمندان
        /// </summary>
        /// <param name="insList"></param>
        /// <param name="DBFPath"></param>
        /// <param name="DBFName"></param>
        /// <returns></returns>
        public static bool CreateDBFPersonal(List<tblSalInsurenceDiskPersonal> insList, string DBFPath)
        {
            string DBFName = "DSKWOR00.dbf";
            try
            {
                //create a simple DBF file and output to args[0]

                DbfFile odbf = new DbfFile(Encoding.GetEncoding(1256));
                odbf.Open(Path.Combine(DBFPath, DBFName), FileMode.Create);

                #region create a headers
                odbf.Header.AddColumn(new DbfColumn("DSW_ID", DbfColumn.DbfColumnType.Character, 10, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_YY", DbfColumn.DbfColumnType.Number, 2, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_MM", DbfColumn.DbfColumnType.Number, 2, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_LISTNO", DbfColumn.DbfColumnType.Character, 12, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_ID1", DbfColumn.DbfColumnType.Character, 10, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_FNAME", DbfColumn.DbfColumnType.Character, 100, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_LNAME", DbfColumn.DbfColumnType.Character, 100, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_DNAME", DbfColumn.DbfColumnType.Character, 100, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_IDNO", DbfColumn.DbfColumnType.Character, 15, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_IDPLC", DbfColumn.DbfColumnType.Character, 100, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_IDATE", DbfColumn.DbfColumnType.Character, 8, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_BDATE", DbfColumn.DbfColumnType.Character, 8, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_SEX", DbfColumn.DbfColumnType.Character, 3, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_NAT", DbfColumn.DbfColumnType.Character, 10, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_OCP", DbfColumn.DbfColumnType.Character, 100, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_SDATE", DbfColumn.DbfColumnType.Character, 8, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_EDATE", DbfColumn.DbfColumnType.Character, 8, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_DD", DbfColumn.DbfColumnType.Number, 2, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_ROOZ", DbfColumn.DbfColumnType.Number, 12, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_MAH", DbfColumn.DbfColumnType.Number, 12, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_MAZ", DbfColumn.DbfColumnType.Number, 12, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_MASH", DbfColumn.DbfColumnType.Number, 12, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_TOTL", DbfColumn.DbfColumnType.Number, 12, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_BIME", DbfColumn.DbfColumnType.Number, 12, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_PRATE", DbfColumn.DbfColumnType.Number, 2, 0));
                odbf.Header.AddColumn(new DbfColumn("DSW_JOB", DbfColumn.DbfColumnType.Character, 6, 0));
                odbf.Header.AddColumn(new DbfColumn("PER_NATCOD", DbfColumn.DbfColumnType.Character, 10, 0));
                #endregion

                //add some records...
                DbfRecord orec = new DbfRecord(odbf.Header) { AllowDecimalTruncate = false };

                foreach (var list in insList)
                {
                    int x = 10 - list.DSW_ID.Length;
                    string DSW_ID = "";
                    for (int i = 0; i < x; i++)
                        DSW_ID += "0";
                    DSW_ID += list.DSW_ID;

                    orec[0] = DSW_ID;
                    orec[1] = (list.DSW_YY + "").Substring(2, 2);
                    orec[2] = list.DSW_MM + "";
                    orec[3] = list.DSW_LISTNO;
                    orec[4] = list.DSW_ID1;

                    orec[5] = Convert_Unicode_To_IranSystem(list.DSW_FNAME.Replace("ه", "ه").Replace("ی", "ی"));
                    orec[6] = Convert_Unicode_To_IranSystem(list.DSW_LNAME.Replace("ه", "ه").Replace("ی", "ی"));
                    orec[7] = Convert_Unicode_To_IranSystem(list.DSW_DNAME.Replace("ه", "ه").Replace("ی", "ی"));

                    orec[8] = list.DSW_IDNO;
                    orec[9] = Convert_Unicode_To_IranSystem(list.DSW_IDPLC);
                    orec[10] = list.DSW_IDATE;
                    orec[11] = list.DSW_BDATE;
                    orec[12] = Convert_Unicode_To_IranSystem(list.DSW_SEX);
                    orec[13] = Convert_Unicode_To_IranSystem(list.DSW_NAT);
                    orec[14] = Convert_Unicode_To_IranSystem(list.DSW_OCP);
                    orec[15] = list.DSW_SDATE;
                    orec[16] = list.DSW_EDATE;
                    orec[17] = list.DSW_DD + "";
                    orec[18] = list.DSW_ROOZ + "";
                    orec[19] = list.DSW_MAH + "";
                    orec[20] = list.DSW_MAZ + "";
                    orec[21] = list.DSW_MASH + "";
                    orec[22] = list.DSW_TOTL + "";
                    orec[23] = list.DSW_BIME + "";
                    orec[24] = list.DSW_PRATE + "";
                    orec[25] = list.DSW_JOB;
                    orec[26] = list.PER_NATCOD;
                    odbf.Write(orec, false);
                }

                odbf.Close();
            }
            catch
            {
                //clsPublicFunctions.showMessageBoxError("امکان ساخت دیسکت برای کارمندان وجود ندارد ، یک فایل با همین نام در مسیر مورد وجود دارد که باز است و امکان دسترسی به آن وجود ندارد ، لطفا آن فایل را ببندید یا آن را به مسیر دیگیری منتقل نمایید.", "خطا");
                return false;
            }
            return true;
        }

        /// <summary>
        /// ساخت دیسکت بیمه مخصوص کارخانه
        /// </summary>
        /// <param name="insList"></param>
        /// <param name="DBFPath"></param>
        /// <param name="DBFName"></param>
        /// <returns></returns>
        public static bool CreateDBFFactory(tblSalInsurenceDiskFactory insList, string DBFPath)
        {
            string DBFName = "DSKKAR00.dbf";
            try
            {
                //create a simple DBF file and output to args[0]
                DbfFile odbf = new DbfFile(Encoding.GetEncoding(1256));
                odbf.Open(Path.Combine(DBFPath, DBFName), FileMode.Create);

                #region create a headers
                odbf.Header.AddColumn(new DbfColumn("DSK_ID", DbfColumn.DbfColumnType.Character, 10, 0));
                odbf.Header.AddColumn(new DbfColumn("DSK_NAME", DbfColumn.DbfColumnType.Character, 100, 0));
                odbf.Header.AddColumn(new DbfColumn("DSK_FARM", DbfColumn.DbfColumnType.Character, 100, 0));
                odbf.Header.AddColumn(new DbfColumn("DSK_ADRS", DbfColumn.DbfColumnType.Character, 100, 0));
                odbf.Header.AddColumn(new DbfColumn("DSK_KIND", DbfColumn.DbfColumnType.Number, 1, 0));
                odbf.Header.AddColumn(new DbfColumn("DSK_YY", DbfColumn.DbfColumnType.Number, 2, 0));
                odbf.Header.AddColumn(new DbfColumn("DSK_MM", DbfColumn.DbfColumnType.Number, 2, 0));
                odbf.Header.AddColumn(new DbfColumn("DSK_LISTNO", DbfColumn.DbfColumnType.Character, 12, 0));
                odbf.Header.AddColumn(new DbfColumn("DSK_DISC", DbfColumn.DbfColumnType.Character, 100, 0));
                odbf.Header.AddColumn(new DbfColumn("DSK_NUM", DbfColumn.DbfColumnType.Number, 5, 0));
                odbf.Header.AddColumn(new DbfColumn("DSK_TDD", DbfColumn.DbfColumnType.Number, 6, 0));
                odbf.Header.AddColumn(new DbfColumn("DSK_TROOZ", DbfColumn.DbfColumnType.Number, 12, 0));
                odbf.Header.AddColumn(new DbfColumn("DSK_TMAH", DbfColumn.DbfColumnType.Number, 12, 0));
                odbf.Header.AddColumn(new DbfColumn("DSK_TMAZ", DbfColumn.DbfColumnType.Number, 12, 0));
                odbf.Header.AddColumn(new DbfColumn("DSK_TMASH", DbfColumn.DbfColumnType.Number, 12, 0));
                odbf.Header.AddColumn(new DbfColumn("DSK_TTOTL", DbfColumn.DbfColumnType.Number, 12, 0));
                odbf.Header.AddColumn(new DbfColumn("DSK_TBIME", DbfColumn.DbfColumnType.Number, 12, 0));
                odbf.Header.AddColumn(new DbfColumn("DSK_TKOSO", DbfColumn.DbfColumnType.Number, 12, 0));
                odbf.Header.AddColumn(new DbfColumn("DSK_BIC", DbfColumn.DbfColumnType.Number, 12, 0));
                odbf.Header.AddColumn(new DbfColumn("DSK_RATE", DbfColumn.DbfColumnType.Number, 5, 0));
                odbf.Header.AddColumn(new DbfColumn("DSK_PRATE", DbfColumn.DbfColumnType.Number, 2, 0));
                odbf.Header.AddColumn(new DbfColumn("DSK_BIMH", DbfColumn.DbfColumnType.Number, 12, 0));
                odbf.Header.AddColumn(new DbfColumn("MON_PYM", DbfColumn.DbfColumnType.Character, 3, 0));
                #endregion


                string address = "ه‘“ ù¤¢ ù¢‘› - ِ‘—¨¢¤گ";
                //if (clsSalVariable.SalfactID == "6923510198")
                //    address = "ü÷‏ُ، ô‘ُگ ِ‘“‘‏، - ِ‘ْê¬گ";
                //else if (clsSalVariable.SalfactID == "6953620020")
                //    address = "¥‘ê-–¤ّ، ù‌¤ُّƒ üَنّ“-ƒ";

                //add some records...
                DbfRecord orec = new DbfRecord(odbf.Header) { AllowDecimalTruncate = false };

                #region Insert Data To Row
                orec[0] = insList.DSK_ID;
                orec[1] = Convert_Unicode_To_IranSystem(insList.DSK_NAME);
                orec[2] = Convert_Unicode_To_IranSystem(insList.DSK_FARM);
                orec[3] = address;
                orec[4] = insList.DSK_KIND + "";
                orec[5] = (insList.DSK_YY + "").Substring(2, 2);
                orec[6] = insList.DSK_MM + "";
                orec[7] = insList.DSK_LISTNO + "";
                orec[8] = insList.DSK_DISC;
                orec[9] = insList.DSK_NUM + "";
                orec[10] = insList.DSK_TDD + "";
                orec[11] = insList.DSK_TROOZ + "";
                orec[12] = insList.DSK_TMAH + "";
                orec[13] = insList.DSK_TMAZ + "";
                orec[14] = insList.DSK_TMASH + "";
                orec[15] = insList.DSK_TTOTL + "";
                orec[16] = insList.DSK_TBIME + "";
                orec[17] = insList.DSK_TKOSO + "";
                orec[18] = insList.DSK_BIC + "";
                orec[19] = insList.DSK_RATE + "";
                orec[20] = insList.DSK_PRATE + "";
                orec[21] = insList.DSK_BIMH + "";
                orec[22] = "";
                #endregion

                odbf.Write(orec, false);
                odbf.Close();
            }
            catch
            {
                //clsPublicFunctions.showMessageBoxError("امکان ساخت دیسکت برای کارخانه وجود ندارد ، یک فایل با همین نام در مسیر مورد وجود دارد که باز است و امکان دسترسی به آن وجود ندارد ، لطفا آن فایل را ببندید یا آن را به مسیر دیگیری منتقل نمایید.", "خطا");
                return false;
            }
            return true;
        }

        #region تبدیلات ایران سیستم به ویندزو و برعکس

        //[Obsolete("استفاده کنید UnicodeFrom  بهتر است از")]
        /// <summary>
        /// تبدیل یک رشته ایران سیستم به یونیکد
        /// </summary>
        /// <param name="textEncoding"> (1256) کدپیج رشته ایران سیستم</param>
        /// <param name="iranSystemString">رشته ایران سیستم</param>
        /// <returns></returns>
        public static string Convert_IranSystem_TO_Unicode(string iranSystemString)
        {
            TextEncoding textEncoding = TextEncoding.Arabic1256;
            // وهله سازی از انکودینگ صحیح برای تبدیل رشته ایران سیستم به بایت
            Encoding encoding = Encoding.GetEncoding((int)textEncoding);


            // حذف فاصله‌های موجود در رشته
            iranSystemString = iranSystemString.Replace(" ", "");


            if (iranSystemString.Length <= 0)
                return "";
            // تبدیل رشته به بایت
            byte[] stringBytes = encoding.GetBytes(iranSystemString.Trim());

            // تغییر ترتیب بایت هااز آخر به اول در صورتی که رشته تماماً عدد نباشد
            if (!IsNumber(iranSystemString))
            {
                stringBytes = stringBytes.Reverse().ToArray();
            }

            // آرایه ای که بایت‌های معادل را در آن قرار می‌دهیم
            // مجموع تعداد بایت‌های رشته + بایت‌های اضافی محاسبه شده
            byte[] newStringBytes = new byte[stringBytes.Length + CountCharactersRequireTwoBytes(stringBytes)];

            int index = 0;

            // بررسی هر بایت و پیدا کردن بایت (های) معادل آن
            for (int i = 0; i < stringBytes.Length; ++i)
            {
                byte charByte = stringBytes[i];

                // اگر جز 128 بایت اول باشد که نیازی به تبدیل ندارد چون کد اسکی است
                if (charByte < 128)
                {
                    newStringBytes[index] = charByte;
                }
                else
                {
                    // اگر جز حروف یا اعداد بود معادلش رو قرار می‌دیم
                    if (CharactersMapper.ContainsKey(charByte))
                    {
                        //MessageBox.Show(charByte.ToString());
                        newStringBytes[index] = CharactersMapper[charByte];
                    }
                }

                // اگر کاراکتر ایران سیستم "لا" بود چون کاراکتر متناظرش در عربی 1256 "ل" است و باید یک "ا" هم بعدش اضافه کنیم
                if (charByte == 242)
                {
                    newStringBytes[++index] = 199;
                }

                // اگر کاراکتر یکی از انواعی بود که بعدشان باید یک فاصله باشد
                // و در عین حال آخرین کاراکتر رشته نبود
                if (charactersWithSpaceAfter.Contains(charByte) && Array.IndexOf(stringBytes, charByte) != stringBytes.Length - 1)
                {
                    // یک فاصله بعد ان اضافه می‌کنیم
                    newStringBytes[++index] = 32;
                }

                index += 1;
            }

            // تبدیل به رشته و ارسال به فراخواننده
            byte[] unicodeContent = Encoding.Convert(encoding, Encoding.Unicode, newStringBytes);

            string result = Encoding.Unicode.GetString(unicodeContent).Trim();
            result = result.Replace("ڑ", "ء").Replace("ؤ", "ئ");

            //در صورتی که عدد داخل رشته نیست نیاز به ادامه کار نمی‌باشد

            if (!Regex.IsMatch(result, @"\d"))
                return result;

            bool isLastDigit = false;
            string tempForDigits = "";
            string str = "";
            for (int i = 0; i < result.Length; i++)
            {
                if (Regex.IsMatch(result[i].ToString(), @"\d") || (i + 1 < result.Length && Regex.IsMatch(result[i].ToString() + result[i + 1].ToString(), @"/\d")))
                {
                    isLastDigit = true;
                    tempForDigits += result[i];
                }
                else
                {
                    if (isLastDigit && tempForDigits.Length > 0)
                    {
                        str += new string(tempForDigits.Reverse().ToArray());
                        isLastDigit = false;
                        tempForDigits = "";
                    }
                    str += result[i];
                }
                if (!string.IsNullOrWhiteSpace(tempForDigits) && i == result.Length - 1)
                {
                    str += new string(tempForDigits.Reverse().ToArray());
                }
            }
            return str;
        }

        /// <summary>
        /// تبدیل یک رشته ویندوز به ایران سیستم
        /// </summary>
        /// <param name="Unicode_Text"></param>
        /// <returns></returns>
        public static string Convert_Unicode_To_IranSystem(string Unicode_Text)
        {

            //رشته ای که فارسی است را دو کاراکتر فاصله به ابتدا و انتهای آن اضافه می کنیم
            string unicodeString = " " + Unicode_Text + " ";

            //ایجاد دو انکدینگ متفاوت
            Encoding ascii = //Encoding.ASCII;
            Encoding.GetEncoding("windows-1256");
            Encoding unicode = Encoding.Unicode;

            // تبدیل رشته به بایت
            byte[] unicodeBytes = unicode.GetBytes(unicodeString);

            // تبدیل بایتها از یک انکدینگ به دیگری
            byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

            // Convert the new byte[] into a char[] and then into a string.
            char[] asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
            ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
            string asciiString = new string(asciiChars);
            byte[] b22 = Encoding.GetEncoding("windows-1256").GetBytes(asciiChars);


            int limit = b22.Length;
            byte pre = 0, cur = 0;

            List<byte> IS_Result = new List<byte>();
            for (int i = 0; i < limit; i++)
            {
                if ((i > 0 && i < limit - 1) && b22[i] == 32)
                    IS_Result.Add(255);

                if (is_Lattin_Letter(b22[i]))
                {
                    cur = get_Lattin_Letter(b22[i]);

                    IS_Result.Add(cur);
                    //IS_Result.Add(string.Format("{0:X}", cur));

                    //pre = cur;
                }
                else if (i != 0 && i != b22.Length - 1)
                {
                    cur = get_Unicode_To_IranSystem_Char(b22[i - 1], b22[i], b22[i + 1]);

                    if (cur == 145) // برای بررسی استثنای لا
                    {
                        if (pre == 243)
                        {
                            IS_Result.RemoveAt(IS_Result.Count - 1);
                            IS_Result.Add(242);                           //برگشت کد اسکی معادل
                                                                          //IS_Result.Add(string.Format("{0:X}", 242));     //برگشت کد هگز معادل کد اسکی
                        }
                        else
                        {
                            IS_Result.Add(cur);                           //برگشت کد اسکی معادل
                                                                          //IS_Result.Add(string.Format("{0:X}", cur));     //برگشت کد هگز معادل کد اسکی
                        }
                    }
                    else
                    {
                        IS_Result.Add(cur);                               //برگشت کد اسکی معادل
                        //IS_Result.Add(string.Format("{0:X}", cur));         //برگشت کد هگز معادل کد اسکی
                    }


                }
                pre = cur;
            }

            Dictionary<byte, string> conVertUnicodeToANSI = new Dictionary<byte, string>
            {
                {128,"0"}, // 0
                {129,"1"}, // 1
                {130,"2"}, // 2
                {131,"3"}, // 3
                {132,"4"}, // 4
                {133,"5"}, // 5
                {134,"6"}, // 6
                {135,"7"}, // 7
                {136,"8"}, // 8
                {137,"9"}, // 9
                {138,"،"}, // ،
                {139,"-"}, // 
                {140,"؟"}, // 
                {141,"چ"}, // آ
                {142,"ژ"}, // ﺋ
                {143,"ڈ"}, // ء
                {144,"گ"}, // ﺍ
                {145,"‘"}, // ﺎ
                {146,"’"}, // ﺏ
                {147,"“"}, // ﺑ
                {148,"”"}, // ﭖ
                {149,"•"}, // ﭘ
                {150,"–"}, // ﺕ
                {151,"—"}, // ﺗ
                {152,"ک"}, // ﺙ
                {153,"™"}, // ﺛ
                {154,"ڑ"}, //ﺝ
                {155,"›"},// ﺟ
                {156,"œ"},//ﭼ
                {157,"‌"},//ﭼ
                {158,"‍"},//ﺡ
                {159,"ں"},//ﺣ
                {160,"،"},//ﺥ
                {161,"،"},//ﺧ
                {162,"¢"},//د
                {163,"£"},//ذ
                {164,"¤"},//ر
                {165,"¥"},//ز
                {166,"¦"},//ژ
                {167,"§"},//ﺱ
                {168,"¨"},//ﺳ
                {169,"©"},//ﺵ
                {170,"ھ"},//ﺷ
                {171,"«"},//ﺹ
                {172,"¬"},//ﺻ
                {173,"­"},//ﺽ
                {174,"®"},//ﺿ
                {175,"¯"},//ط

                {199,"گ" }, //       ا

                {224,"à"},//ظ
                {225,"ل"},//ﻉ
                {226,"â"},//ﻊ
                {227,"م"},//ﻌ
                {228,"ن"},//ﻋ
                {229,"ه"},//ﻍ
                {230,"و"},//ﻎ
                {231,"ç"},//ﻐ
                {232,"è"},//ﻏ
                {233,"é"},//ﻑ
                {234,"ê"},//ﻓ
                {235,"ë"},//ﻕ
                {236,"ى"},//ﻗ
                {237,"ي"},//ﮎ
                {238,"î"},//ﮐ
                {239,"ï"},//ﮒ
                {240,"ً"},//ﮔ
                {241,"ٌ"},//ﻝ
                {242,"ٍ"},//ﻻ
                {243,"َ"},//ﻟ
                {244,"ô"},//ﻡ
                {245,"ُ"},//ﻣ
                {246,"ِ"},//ﻥ
                {247,"÷"},//ﻧ
                {248,"ّ"},//و
                {249,"ù"},//ﻩ
                {250,"ْ"},//ﻬ
                {251,"û"},//ﻫ
                {252,"ü"},//ﯽ
                {253,"‎"},//ﯼ
                {254,"‏"},//ﯾ
                {255," "} // فاصله
            };

            string result = "";
            for (int i = IS_Result.Count - 2; i > 0; i--)
                try
                {
                    result += conVertUnicodeToANSI[IS_Result[i]];
                }
                catch { }


            return result;
        }

        // کد های تبدیل از ایران سیستم به یونی کد
        #region ConvertIranSystemToUniCode
        #region Private Methods (4)

        /// <summary>
        /// رشته ارسال شده تنها حاوی اعداد است یا نه
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static bool IsNumber(string str)
        {
            return Regex.IsMatch(str, @"^[\d]+$");
        }

        /// <summary>
        ///  محاسبه تعداد کاراکترهایی که بعد از آنها یک کاراکتر باید اضافه شود
        ///  شامل کاراکتر لا
        ///  و کاراکترهای غیرچسبان تنها در صورتی که کاراکتر پایانی رشته نباشند
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private static int CountCharactersRequireTwoBytes(byte[] irTextBytes)
        {
            return (from b in irTextBytes
                    where (
                    charactersWithSpaceAfter.Contains(b) // یکی از حروف غیرچسبان باشد
                    && Array.IndexOf(irTextBytes, b) != irTextBytes.Length - 1) // و کاراکتر آخر هم نباشد
                    || b == 242 // یا کاراکتر لا باشد
                    select b).Count();
        }

        /// <summary>
        /// خارج کردن اعدادی که در رشته ایران سیستم قرار دارند
        /// </summary>
        /// <param name="iranSystemString"></param>
        /// <returns></returns>
        private static string ExcludeNumbers(string iranSystemString)
        {
            /// گرفتن لیستی از اعداد درون رشته
            NumbersInTheString = new Stack<string>(Regex.Split(iranSystemString, @"\D+"));

            /// جایگزین کردن اعداد با یک علامت جایگزین
            /// در نهایت بعد از تبدیل رشته اعداد به رشته اضافه می شوند
            return Regex.Replace(iranSystemString, @"\d+", "#");
        }

        /// <summary>
        /// اضافه کردن اعداد جدا شده پس از تبدیل رشته
        /// </summary>
        /// <param name="convertedString"></param>
        /// <returns></returns>
        private static string IncludeNumbers(string convertedString)
        {
            while (convertedString.IndexOf("#") >= 0)
            {
                string number = Reverse(NumbersInTheString.Pop());
                if (!string.IsNullOrWhiteSpace(number))
                {
                    int index = convertedString.IndexOf("#");

                    convertedString = convertedString.Remove(index, 1);
                    convertedString = convertedString.Insert(index, number);
                }
            }

            return convertedString;
        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        #endregion
        #region private Members (3)

        // متغیری برای نگهداری اعدادی که در رشته ایران سیستم وجود دارند
        private static Stack<string> NumbersInTheString;

        // کد کاراکترها در ایران سیستم و معادل آنها در عربی 1256
        private static Dictionary<byte, byte> CharactersMapper = new Dictionary<byte, byte>
        {
        {128,48}, // 0
        {129,49}, // 1
        {130,50}, // 2
        {131,51}, // 3
        {132,52}, // 4
        {133,53}, // 5
        {134,54}, // 6
        {135,55}, // 7
        {136,56}, // 8
        {137,57}, // 9
        {138,161}, // ،
        {139,220}, // -
        {140,191}, // ؟
        {141,194}, // آ
        {142,196}, // ﺋ
        {143,154}, // ء
        {144,199}, // ﺍ
        {145,199}, // ﺎ
        {146,200}, // ﺏ
        {147,200}, // ﺑ
        {148,129}, // ﭖ
        {149,129}, // ﭘ
        {150,202}, // ﺕ
        {151,202}, // ﺗ
        {152,203}, // ﺙ
        {153,203}, // ﺛ
        {154,204}, //ﺝ
        {155,204},// ﺟ
        {156,141},//ﭼ
        {157,141},//ﭼ
        {158,205},//ﺡ
        {159,205},//ﺣ
        {160,206},//ﺥ
        {161,206},//ﺧ
        {162,207},//د
        {163,208},//ذ
        {164,209},//ر
        {165,210},//ز
        {166,142},//ژ
        {167,211},//ﺱ
        {168,211},//ﺳ
        {169,212},//ﺵ
        {170,212},//ﺷ
        {171,213},//ﺹ
        {172,213},//ﺻ
        {173,214},//ﺽ
        {174,214},//ﺿ
        {175,216},//ط
        {224,217},//ظ
        {225,218},//ﻉ
        {226,218},//ﻊ
        {227,218},//ﻌ
        {228,218},//ﻋ
        {229,219},//ﻍ
        {230,219},//ﻎ
        {231,219},//ﻐ
        {232,219},//ﻏ
        {233,221},//ﻑ
        {234,221},//ﻓ
        {235,222},//ﻕ
        {236,222},//ﻗ
        {237,152},//ﮎ
        {238,152},//ﮐ
        {239,144},//ﮒ
        {240,144},//ﮔ
        {241,225},//ﻝ
        {242,225},//ﻻ
        {243,225},//ﻟ
        {244,227},//ﻡ
        {245,227},//ﻣ
        {246,228},//ﻥ
        {247,228},//ﻧ
        {248,230},//و
        {249,229},//ﻩ
        {250,229},//ﻬ
        {251,170},//ﻫ
        {252,236},//ﯽ
        {253,237},//ﯼ
        {254,237},//ﯾ
        {255,160} // فاصله
        };

        /// <summary>
        /// لیست کاراکترهایی که بعد از آنها باید یک فاصله اضافه شود
        /// </summary>
        private static byte[] charactersWithSpaceAfter = {
                                             146, // ب
                                             148, // پ
                                             150, // ت
                                             152, // ث
                                             154, // ج
                                             156, // چ
                                             158, // ح
                                             160, // خ
                                             167, // س
                                             169, // ش
                                             171, // ص
                                             173, // ض
                                             225, // ع
                                             229, // غ
                                             233, // ف
                                             235, // ق
                                             237, // ک
                                             239, // گ
                                             241, // ل
                                             244, // م
                                             246, // ن
                                             249, // ه
                                             252, //ﯽ
                                             253 // ی
                                         };

        /// <summary>
        /// لیست کاراکترهایی که در تبدیل از ویندوز به ایران سیستم بعد از آنها باید یک فاصله اضافه شود
        /// </summary>
        private static readonly byte[] charactersWithSpaceAfterInConWinToIran = {
                                             146, // ب
                                             //144,// ا
                                            //  145,// ﺎ
                                             148, // پ
                                             150, // ت
                                             152, // ث
                                             154, // ج
                                             156, // چ
                                             158, // ح
                                             160, // خ
                                             167, // س
                                             169, // ش
                                             171, // ص
                                             173, // ض
                                             225, // ع
                                             229, // غ
                                             233, // ف
                                             235, // ق
                                             237, // ک
                                             239, // گ
                                             241, // ل
                                             244, // م
                                             246, // ن
                                             249, // ه
                                             252, //ﯽ
                                             253 // ی
                                         };
        #endregion
        #endregion

        // کد های تبدیل از یونی کد به ایران سیستم
        #region ConvertUniCodeToIranSystem
        private static Dictionary<byte, byte> CharachtersMapper_Group1 = new Dictionary<byte, byte>
        {
            {48 , 128},// 0
            {49 , 129},// 1
            {50 , 130},// 2
            {51 , 131},// 3
            {52 , 132},// 4
            {53 , 133},// 5
            {54 , 134},// 6
            {55 , 135},// 7
            {56 , 136},// 8
            {57 , 137},// 9
            {161, 138},// ،
            {191, 140},// ؟
            {193, 143},// ء 
            {194, 141},// آ
            {195, 144},// أ
            {196, 248},// ؤ  
            {197, 144},// إ
            {200, 146},// ب 
            {201, 249},// ة
            {202, 150},// ت
            {203, 152},// ث 
            {204, 154},// ﺝ
            {205, 158},// ﺡ
            {206, 160},// ﺥ
            {207, 162},// د
            {208, 163},// ذ
            {209, 164},// ر
            {210, 165},// ز
            {211, 167},// س
            {212, 169},// ش
            {213, 171},// ص
            {214, 173},// ض
            {216, 175},// ط
            {217, 224},// ظ
            {218, 225},// ع
            {219, 229},// غ
            {220, 139},// -
            {221, 233},// ف
            {222, 235},// ق
            {223, 237},// ك
            {225, 241},// ل
            {227, 244},// م
            {228, 246},// ن
            {229, 249},// ه
            {230, 248},// و
            {236, 253},// ى
            {237, 253},// ی
            {129, 148},// پ
            {141, 156},// چ
            {142, 166},// ژ
            {152, 237},// ک
            {144, 239},// گ
        };
        private static Dictionary<byte, byte> CharachtersMapper_Group2 = new Dictionary<byte, byte>
        {
            {48,128},// 
            {49,129},// 
            {50,130},//
            {51,131},// 
            {52,132},// 
            {53,133},//
            {54,134},// 
            {55,135},// 
            {56,136},//
            {57,137},// 
            {161,138},// ،
            {191,140},// ?
            {193,143},// ء
            {194,141},// آ
            {195,144},// أ
            {196,248},// ؤ
            {197,144},// إ
            {198,254},// ئ
            {199,144},// ا
            {200,147},// ب
            {201,251},// ة
            {202,151},// ت
            {203,153},// ث
            {204,155},// ج
            {205,159},// ح
            {206,161},// خ
            {207,162},// د
            {208,163},// ذ
            {209,164},// ر
            {210,165},// ز
            {211,168},// س
            {212,170},// ش
            {213,172},// ص
            {214,174},// ض
            {216,175},// ط
            {217,224},// ظ
            {218,228},// ع
            {219,232},// غ
            {220,139},// -
            {221,234},// ف
            {222,236},// ق
            {223,238},// ك
            {225,243},// ل
            {227,245},// م
            {228,247},// ن
            {229,251},// ه
            {230,248},// و
            {236,254},// ی
            {237,254},// ی
            {129,149},// پ
            {141 ,157},// چ
            {142,166},// ژ
            {152,238},// ک
            {144,240},// گ
        };
        private static Dictionary<byte, byte> CharachtersMapper_Group3 = new Dictionary<byte, byte>
        {
            {48 , 128},// 0
            {49 , 129},// 1
            {50 , 130},// 2
            {51 , 131},// 3
            {52 , 132},// 4
            {53 , 133},// 5
            {54 , 134},// 6
            {55 , 135},// 7
            {56 , 136},// 8
            {57 , 137},// 9
            {161, 138},// ،
            {191, 140},// ؟
            {193, 143},// 
            {194, 141},// 
            {195, 145},// 
            {196, 248},// 
            {197, 145},// 
            {198, 252},// 
            {199, 145},// 
            {200, 146},// 
            {201, 249},// 
            {202, 150},// 
            {203, 152},// 
            {204, 154},// 
            {205, 158},// 
            {206, 160},// 
            {207, 162},// 
            {208, 163},// 
            {209, 164},// 
            {210, 165},// 
            {211, 167},// 
            {212, 169},// 
            {213, 171},// 
            {214, 173},// 
            {216, 175},// 
            {217, 224},// 
            {218, 226},// 
            {219, 230},// 
            {220, 139},// 
            {221, 233},// 
            {222, 235},// 
            {223, 237},// 
            {225, 241},// 
            {227, 244},// 
            {228, 246},// 
            {229, 249},//   
            {230, 248},// 
            {236, 252},// 
            {237, 252},// 
            {129, 148},// 
            {141, 156},// 
            {142, 166},// 
            {152, 237},// 
            {144, 239}//
        };
        private static Dictionary<byte, byte> CharachtersMapper_Group4 = new Dictionary<byte, byte>
        {
            {48 ,128},// 0
            {49 ,129},// 1
            {50 ,130},// 2
            {51 ,131},// 3
            {52 ,132},// 4
            {53 ,133},// 5
            {54 ,134},// 6
            {55 ,135},// 7
            {56 ,136},// 8
            {57 ,137},// 9
            {161,138},// ،
            {191,140},// ؟
            {193,143},// 
            {194,141},// 
            {195,145},// 
            {196,248},// 
            {197,145},// 
            {198,254},// 
            {199,145},// 
            {200,147},// 
            {201,250},// 
            {202,151},// 
            {203,153},// 
            {204,155},// 
            {205,159},// 
            {206,161},// 
            {207,162},// 
            {208,163},// 
            {209,164},// 
            {210,165},// 
            {211,168},// 
            {212,170},// 
            {213,172},// 
            {214,174},// 
            {216,175},// 
            {217,224},// 
            {218,227},// 
            {219,231},// 
            {220,139},// 
            {221,234},// 
            {222,236},// 
            {223,238},// 
            {225,243},// 
            {227,245},// 
            {228,247},// 
            {229,250},// 
            {230,248},// 
            {236,254},// 
            {237,254},// 
            {129,149},// 
            {141,157},// 
            {142,166},// 
            {152,238},// 
            {144,240},// 
        };
        public enum TextEncoding
        {
            Arabic1256 = 1256,
            CP1252 = 1252
        }
        //آیا یک کارکتر تمام کننده است(حروف بعد از این کارکترها نباید چسبان باشند)ا
        private static Dictionary<byte, string> CharachtersMapper_Group5 = new Dictionary<byte, string>
        {
            {193,"ء"},
            {194,"آ"},
            {195,"أ"},
            {196,"ؤ"},
            {197,"إ"},
            {199,"ا"},
            {207,"د"},
            {208,"ذ"},
            {209,"ر"},
            {210,"ز"},
            {142,"ژ"},
        };
        private static bool is_Final_Letter(byte c)
        {
            return CharachtersMapper_Group5.ContainsKey(c);
        }
        //آیا کارکتر از حروف لاتین است؟
        private static bool is_Lattin_Letter(byte c)
        {
            if (c < 128 && c > 31)
                return true;
            return false;
        }

        private static byte get_Lattin_Letter(byte c)
        {
            if ("0123456789".IndexOf((char)c) >= 0)
                return (byte)(c + 80);
            return get_FarsiExceptions(c);
        }

        private static byte get_FarsiExceptions(byte c)
        {
            switch (c)
            {
                case (byte)'(': return (byte)')';
                case (byte)'{': return (byte)'}';
                case (byte)'[': return (byte)']';
                case (byte)')': return (byte)'(';
                case (byte)'}': return (byte)'{';
                case (byte)']': return (byte)'[';
                default: return c;

            }

        }

        private static bool IS_White_Letter(byte c)
        {
            if (c == 8 || c == 09 || c == 10 || c == 13 || c == 27 || c == 32 || c == 0)
            {
                return true;
            }
            return false;
        }

        private static bool Char_Cond(byte c)
        {
            return IS_White_Letter(c)
                || is_Lattin_Letter(c)
                || c == 191;
        }

        private static byte get_Unicode_To_IranSystem_Char(byte PreviousChar, byte CurrentChar, byte NextChar)
        {

            bool PFlag = Char_Cond(PreviousChar) || is_Final_Letter(PreviousChar);
            bool NFlag = Char_Cond(NextChar);
            if (PFlag && NFlag) return UCTOIS_Group_1(CurrentChar);
            else if (PFlag) return UCTOIS_Group_2(CurrentChar);
            else if (NFlag) return UCTOIS_Group_3(CurrentChar);

            return UCTOIS_Group_4(CurrentChar);

        }

        private static byte UCTOIS_Group_4(byte CurrentChar)
        {

            if (CharachtersMapper_Group4.ContainsKey(CurrentChar))
            {
                return CharachtersMapper_Group4[CurrentChar];
            }
            return CurrentChar;
        }

        private static byte UCTOIS_Group_3(byte CurrentChar)
        {
            if (CharachtersMapper_Group3.ContainsKey(CurrentChar))
            {
                return CharachtersMapper_Group3[CurrentChar];
            }
            return CurrentChar;
        }

        private static byte UCTOIS_Group_2(byte CurrentChar)
        {
            if (CharachtersMapper_Group2.ContainsKey(CurrentChar))
            {
                return CharachtersMapper_Group2[CurrentChar];
            }
            return CurrentChar;
        }

        private static byte UCTOIS_Group_1(byte CurrentChar)
        {
            if (CharachtersMapper_Group1.ContainsKey(CurrentChar))
            {
                return CharachtersMapper_Group1[CurrentChar];
            }
            return CurrentChar;
        }
        #endregion
        #endregion
    }
}
