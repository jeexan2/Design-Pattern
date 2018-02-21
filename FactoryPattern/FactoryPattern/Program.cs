using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FactoryPattern
{
    class Program
    {
        /** Interface command can differently handle the command of database!
         * But For today's task
         * I am not goint to use them!
        public interface iCommand
        {
            void Create();
            void Delete(int indx);
            void Update(int indx);
        }
        public class TableCommand:iCommand{
            public  void Create()
            {

            }
            public  void Delete(int indx)
            {

            }
            public  void Update(int indx)
            {

            }
          }
        public class TableElementCommand :iCommand
        {
            public void Create()
            {

            }
            public void Delete(int indx)
            {

            }
            public void Update(int indx)
            {

            }
        }**/

       /** public  class ConnectionDriver
        {
            string userId;
            string passWord;
           public void Set(string UiD,string pass)
            {
                userId = UiD;
                passWord = pass;
            }
        }
        List<ConnectionDriver> ConnectionDriverPool = new List<ConnectionDriver>();**/
        //Element Creation of Table through Interface
        public interface iTableElements
        {
            void SetTableElements(int InputId,string InputName,string InputData);
    
        }
        
        public class TableElements : iTableElements
        {

            //TableElementCommand Command;
            string name;
            int id;
            string data;
            
           
            public void SetTableElements(int InputId,string InputName,string InputData)
            {
                id = InputId;
                name = InputName;
                data = InputData;
            }
            public TableElements get()
            {
                return this;
            }
            
        }
        //Table Creation of Database
        public interface iTable 
        {
            void CreateElement();
            void DeleteElement();
            void UpdateElement();
        }
        public class Table:iTable
        {
            string name;
            //TableCommand query;
            List<TableElements> Elements = new List<TableElements>();
            public void set(string s)
            {
                name = s;
            }
            public string getName()
            {
                return name;
            }
            
            public void CreateElement()
            {

            }
            public void DeleteElement()
            {

            }
            public void UpdateElement()
            {

            }
        }
        /// <>
        /// DataBase Creation
        /// <>
        public interface iDataBase
        {
            string getName();
            void CreateTable();
            void ShowTable();
            void DeleteTable();
            void UpdateTable();
        }
 
      abstract class DataBase:iDataBase
        {

               
            protected abstract string name { get; }
            protected List<Table> table = new List<Table>();

            public abstract string getName();
            public abstract void CreateTable();
            public abstract void ShowTable();
            public  void UpdateTable() { }
            public void DeleteTable() { }
        }
        class Oracle: DataBase
        {
            List<Table> table = new List<Table>();
            protected override string name
            {
                get
                {
                    return "Oracle";
                }
            }
            public override string getName()
            {
                return "Oracle";
            }
            public override void CreateTable()
            {
                throw new NotImplementedException();
            }
            public override void ShowTable()
            {
                throw new NotImplementedException();
            }
            
        }
        class MySQL:DataBase
        {
            //List<Table> table = new List<Table>();
            protected override string name
            {
                get
                {
                    return "MySQL";
                }
            }
             public override string getName()
            {
                return "MySQL";
            }
            public override void CreateTable()
            {
                throw new NotImplementedException();
            }
            public override void ShowTable()
            {
                throw new NotImplementedException();
            }

        }
      
        class MSSQL:DataBase
        {
            List<Table> table = new List<Table>();
            protected override string name
            {
                get
                {
                    return "MSSQL";
                }
            }
            public override string getName()
            {
                return "MSSQL";
            }

            public override void CreateTable()
            {
                throw new NotImplementedException();
            }
            public override void ShowTable()
            {
                throw new NotImplementedException();
            }
        }
        

        class NewDBMS : DataBase
        {
            int id;
            List<Table> table = new List<Table>();
            public void SetId(int inputid)
            {
                id = inputid;
            }

            protected override string name
            {
                get
                {
                    return "NewDBMS "+ id.ToString();
                }
            }
            public override string getName()
            {
                return name;
            }
            public override void CreateTable()
            {
                Table tabledemo = new Table();
                Console.WriteLine("Input the table name");
                string name=Console.ReadLine();
                tabledemo.set(name);
                table.Add(tabledemo);

                
            }
            public override void ShowTable()
            {
                foreach (Table element in table)
                    Console.WriteLine("{0}", element.getName());
            }
        }
        //Singleton Class of Database Creator
        public class CreateDatabase<T> where T : new()
        {
            
            private static T ms_StaticInstance = new T();

            public T GetInstance()
            {
                return ms_StaticInstance;
            }
        }
 
       
        
        //Static class of Database Creation
        static class DatabaseCreator
        {
           static int indx = 1;

            public static DataBase Get(int id)
            {
               



                if (id == 0) return new Oracle();
                else if (id == 1) return new MySQL();
                else if (id == 2) return new MSSQL();
                else
                {
                   
                    CreateDatabase<NewDBMS> instance = new CreateDatabase<NewDBMS>();
                    NewDBMS DBMS = instance.GetInstance();
                    DBMS.SetId(indx++);
                    return DBMS;
                }
            }
        }
        
        
        static void Main(string[] args)
        {
            for(int i = 0; i < 6; i++)
            {
                iDataBase database = DatabaseCreator.Get(i);
                
                Console.WriteLine("id = {0},  Database = {1}", i, database.getName());
               
            }
            iDataBase Client = DatabaseCreator.Get(6);
            Console.WriteLine("Client Database : Databese id = {0},  Database Name = {1}", 6, Client.getName());
            Client.CreateTable();
            Client.ShowTable();
            Console.ReadKey();
        }
    }
}
