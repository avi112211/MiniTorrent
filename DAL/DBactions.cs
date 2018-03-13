using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBactions
    {
        private DalDBDataContext dc = new DalDBDataContext();
        private static object _lock = new object();

        public DataSet1 getFileName(string FileName)
        {
            try
            {
                DataSet1TableAdapters.FilesTableAdapter ct = new DataSet1TableAdapters.FilesTableAdapter();
                DataSet1 ds = new DataSet1();
                ct.Fill(ds.Files, FileName);
                return ds;
            }
            catch
            {
                return null;
            }            
        }
        

        public void addNewUser(string username, string password)
        {
            Table u = new Table
            {
                UserName = username,
                PassWord = password,
                IsOnLine = false,
                IsEnabled = true
            };

            dc.Tables.InsertOnSubmit(u);
            lock (_lock)
            {
                dc.SubmitChanges();
            }
        }

        public int getUser(string username, string password)
        {
            var user = from u in dc.Tables
                            where u.UserName == username
                            where u.PassWord == password
                            select u;
            if (user.Count() != 0)
            {
                foreach (Table u in user)
                {
                    if (u.IsEnabled)
                    {
                        if (u.IsOnLine)
                            return 2;//already connected
                        else
                        {
                            u.IsOnLine = true;
                            lock (_lock)
                            {
                                dc.SubmitChanges();
                            }
                            return 1; //all good
                        }
                    }
                    else
                        return 3; //not enabled
                }
            }
            
            return 0; //not created            
        }

        public int[] countUsers()
        {
            int[] count = new int[2];
            var user = from u in dc.Tables
                       select u;
            if (user.Count() != 0)
            {
                foreach (Table u in user)
                {
                    count[0]++;
                    if (u.IsOnLine)
                        count[1]++;
                }
            }

            return count; //not created            
        }

        public bool checkUsernameExisit(string username)
        {
            //userDB user;
            var user = from u in dc.Tables
                       where u.UserName == username
                       select u;
            if (user.Count() != 0)
                return true;

            return false;
        }

        public void addNewFile(string fileName, long fileSize)
        {
            File f = new File
            {
                FileName = fileName,
                FileSize = fileSize,
                NumberOfPears = 1
            };

            dc.Files.InsertOnSubmit(f);
            lock (_lock)
            {
                dc.SubmitChanges();
            }
        }

        public void removeFile(string fileName, long fileSize)
        {
            var files = from f in dc.Files
                        where f.FileName == fileName
                        where f.FileSize == fileSize
                        select f;
            if (files.Count() != 0)
            {
                foreach (File f in files)
                {
                    if (f.NumberOfPears == 1)
                        dc.Files.DeleteOnSubmit(f);
                    else
                        f.NumberOfPears--;
                }

                lock (_lock)
                {
                    dc.SubmitChanges();
                }
            }
        }

        public void updatePear(string fileName, long fileSize)
        {
            var files = from f in dc.Files
                       where f.FileName == fileName
                       where f.FileSize == fileSize
                       select f;
            if (files.Count() != 0)
            {
                foreach (File f in files)
                {
                    f.NumberOfPears++;
                }
                lock (_lock)
                {
                    dc.SubmitChanges();
                }
            }
        }

        public void logOffUser(string username)
        {
            var user = from u in dc.Tables
                       where u.UserName == username
                       select u;

            if (user.Count() != 0)
            {
                foreach (Table u in user)
                {
                    u.IsOnLine = false;
                }
                lock (_lock)
                {
                    dc.SubmitChanges();
                }
            }
        }

        public void logOffAllUsers()
        {
            var user = from u in dc.Tables
                       select u;
            if (user.Count() != 0)
            {
                foreach (Table u in user)
                {
                    u.IsOnLine = false;
                }
                lock (_lock)
                {
                    dc.SubmitChanges();
                }
            }            
        }

        public void clearFileTable()
        {
            var files = from f in dc.Files
                       select f;
            if (files.Count() != 0)
            {
                foreach (File f in files)
                {
                    dc.Files.DeleteOnSubmit(f);
                }
                lock (_lock)
                {
                    dc.SubmitChanges();
                }
            }
        }
    }
}
